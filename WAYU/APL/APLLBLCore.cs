using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using UCNLDrivers;
using UCNLNav;
using UCNLNMEA;
using UCNLPhysics;

namespace WAYU.APL
{
    #region Public enums

    public enum BaseIDs : int
    {
        BASE_1 = 0,
        BASE_2 = 1,
        BASE_3 = 2,
        BASE_4 = 3,
        BASE_INVALID
    }

    #endregion

    #region Custom EventArgs

    public class TrackUpdateEventArgs : EventArgs
    {
        #region Properties

        public string TrackID { get; private set; }
        public GeoPoint3DETm TrackPoint { get; private set; }
        public double Course_deg { get; private set; }

        #endregion

        #region Constructor

        public TrackUpdateEventArgs(string trackID, GeoPoint3DETm trackPoint, double course_deg)
        {
            TrackID = trackID;
            TrackPoint = trackPoint;
            Course_deg = course_deg;
        }

        #endregion
    }

    public class PortTimeoutEventArgs : EventArgs
    {
        #region Properties

        public string PortName { get; private set; }
        public string PortDescr { get; private set; }

        #endregion

        #region Constructor

        public PortTimeoutEventArgs(string portName, string portDescr)
        {
            PortName = portName;
            PortDescr = portDescr;
        }

        #endregion

    }

    #endregion

    public class APLLBLCore : IDisposable
    {
        #region Properties

        bool disposed = false;

        readonly int timerPeriodMS = 100;
        readonly int portsTimeoutMS = 3000;
        readonly int systemUpdateTimeoutMS = 1000;

        int systemUpdateTS = 0;

        static readonly string emuIDstr = "EMU";
        readonly int emuID = emuIDstr.GetHashCode();
        static bool nmeaSingleton = false;        

        public bool IsOpen { get; private set; }

        SerialPortsPool inPorts;
        NMEAMultipleListener nmeaListener;
        SerialPort outPort;
        PrecisionTimer timer;

        Dictionary<int, string> portDescrByHash;
        Dictionary<int, string> portNameByHash;
        Dictionary<string, int> portHashByDescr;
        Dictionary<int, int> portTSByHash;
        Dictionary<int, bool> portTimoutFlags;

        TrackFilter trkFilter;
        PCore2D<GeoPoint3DT> pCore;
        APLBaseProcessor basesProcessor;
        
        delegate T NullChecker<T>(object parameter);
        delegate object NullCheckerR<T>(T parameter);
        NullChecker<int> intNullChecker = (x => x == null ? -1 : (int)x);
        NullChecker<double> doubleNullChecker = (x => x == null ? double.NaN : (double)x);        
        NullChecker<string> stringNullChecker = (x => x == null ? string.Empty : (string)x);
        NullCheckerR<double> doubleNullCheckerR = (x => double.IsNaN(x) ? null : (object)x);

        public bool IsAutoSoundSpeed;
        public double SoundSpeed_mps
        {
            get { return pCore.SoundSpeed; }
            set 
            {
                IsAutoSoundSpeed = false;
                pCore.SoundSpeed = value; 
            }
        }

        double salinity_PSU = 0.0;
        public double SalinityPSU
        {
            get { return salinity_PSU; }
            set
            {
                if ((value >= 0.0) && (value <= 42.0))
                {
                    salinity_PSU = value;
                    if (!IsAutoSoundSpeed)
                        UpdateSoundSpeed();
                }
            }
        }

        public double WaterTemperatureC
        {
            get { return meanWaterTemperatureC.Value; }
            set 
            { 
                meanWaterTemperatureC.Value = value;
                if (!IsAutoSoundSpeed)
                    UpdateSoundSpeed();
            }
        }

        bool isPrimaryGNSS_Set = false;
        int primaryGNSS_SourceID = -1;

        DateTime primaryGNSSFixLocalTS;
        AgingValue<RMCMessageEventArgs> primaryGNSSFixRMC;

        AgingValue<double> meanWaterTemperatureC;

        AgingValue<GeoPoint3DETm> targetFix;
        AgingValue<double> targetCourse;
        AgingValue<GeoPoint3DETm> targetFixFlt;
        
        AgingValue<double> distanceToTarget;
        AgingValue<double> forwardAzimuthToTarget;
        AgingValue<double> reverseAzimuthToTarget;

        Dictionary<BaseIDs, AgingValue<bool>> BaseBatStates;

        public AgingValue<DOPState> dopState;
        public AgingValue<TBAQuality> tbaQuality;

        #endregion

        #region Constructor

        public APLLBLCore(Dictionary<string, SerialPortSettings> inPortSettings, 
            double radialErrorThreshold, double simplexSize, int courseEstimatorFifoSize, int trackFilterSize)
        {
            #region misc. initialization

            primaryGNSSFixRMC = new AgingValue<RMCMessageEventArgs>(2, 10, 
                x => string.Format(CultureInfo.InvariantCulture, "LAT: {0:F06}°\r\nLON: {1:F06}°\r\nSPD: {2:F01} m/s (3:F01 km/h)\r\nTRK: {4:F01}°",
                    x.Latitude, x.Longitude, x.SpeedKmh / 3.6, x.SpeedKmh, x.TrackTrue));

            meanWaterTemperatureC = new AgingValue<double>(10, 30, x => string.Format(CultureInfo.InvariantCulture, "MTW: {0:F01} °C", x));

            targetFix = new AgingValue<GeoPoint3DETm>(3, 60,
                x => string.Format(CultureInfo.InvariantCulture, "LAT: {0:F06}°\r\nLON: {1:F06}°\r\nRER: {2:F03} m", 
                    x.Latitude, x.Longitude, x.RadialError));

            targetFixFlt = new AgingValue<GeoPoint3DETm>(3, 60,
                x => string.Format(CultureInfo.InvariantCulture, "LAT: {0:F06}°\r\nLON: {1:F06}°",
                    x.Latitude, x.Longitude));

            targetCourse = new AgingValue<double>(4, 8, x => string.Format(CultureInfo.InvariantCulture, "CRS: {0:F01}°", x));
            distanceToTarget = new AgingValue<double>(4, 8, x => string.Format(CultureInfo.InvariantCulture, "D2T: {0:F01} m", x));
            forwardAzimuthToTarget = new AgingValue<double>(4, 8, x => string.Format(CultureInfo.InvariantCulture, "FAZ: {0:F01}°", x));
            reverseAzimuthToTarget = new AgingValue<double>(4, 8, x => string.Format(CultureInfo.InvariantCulture, "RAZ: {0:F01}°", x));

            BaseBatStates = new Dictionary<BaseIDs, AgingValue<bool>>();
            BaseBatStates.Add(BaseIDs.BASE_1, new AgingValue<bool>(30, 60, x => !x ? string.Format("{0} BAT LOW!", BaseIDs.BASE_1) : string.Empty));
            BaseBatStates.Add(BaseIDs.BASE_2, new AgingValue<bool>(30, 60, x => !x ? string.Format("{0} BAT LOW!", BaseIDs.BASE_1) : string.Empty));
            BaseBatStates.Add(BaseIDs.BASE_3, new AgingValue<bool>(30, 60, x => !x ? string.Format("{0} BAT LOW!", BaseIDs.BASE_1) : string.Empty));
            BaseBatStates.Add(BaseIDs.BASE_4, new AgingValue<bool>(30, 60, x => !x ? string.Format("{0} BAT LOW!", BaseIDs.BASE_1) : string.Empty));

            dopState = new AgingValue<DOPState>(4, 10, x => x.ToString().Replace('_', ' ').ToUpperInvariant());
            tbaQuality = new AgingValue<TBAQuality>(4, 10, x => x.ToString().Replace('_', ' ').ToUpperInvariant());

            #endregion

            #region pCore

            trkFilter = new TrackFilter(trackFilterSize);

            pCore = new PCore2D<GeoPoint3DT>(radialErrorThreshold, simplexSize, Algorithms.WGS84Ellipsoid, courseEstimatorFifoSize);
            pCore.RadialErrorExeedsThrehsoldEventHandler += (o, e) => InfoEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO, "WAYU Pinger location failed: radial error exeeds threshold"));
            pCore.TargetLocationUpdatedExHandler += (o, e) =>
                {
                    targetFix.Value = new GeoPoint3DETm(e.Location.Latitude, e.Location.Longitude, e.Location.Depth, e.Location.RadialError, e.TimeStamp);
                    targetCourse.Value = e.Course;

                    var fltTrk = trkFilter.Filter(e.Location.Latitude, e.Location.Longitude);
                    targetFixFlt.Value = new GeoPoint3DETm(fltTrk.Latitude, fltTrk.Longitude, e.Location.Depth, e.Location.RadialError, e.TimeStamp);

                    if (primaryGNSSFixRMC.IsInitializedAndNotObsolete)
                        UpdateTargetRelativeData();

                    InfoEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO, 
                        string.Format(CultureInfo.InvariantCulture,"WAYU Pinger located: {0}, Course: {1:F01}°",
                        targetFixFlt, e.Course)));
                    
                    TrackUpdateHandler.Rise(this,
                        new TrackUpdateEventArgs("WAYU (RAW)", targetFix.Value, e.Course));

                    TrackUpdateHandler.Rise(this,
                        new TrackUpdateEventArgs("WAYU (FLT)", targetFixFlt.Value, e.Course));

                    if ((outPort != null) &&
                        (outPort.IsOpen))
                    {
                        WriteOutData(targetFixFlt.Value.Latitude, targetFixFlt.Value.Longitude, 0.0, targetFix.Value.RadialError,
                            targetCourse.Value, targetFix.Value.RadialError <= pCore.RadialErrorThreshold);
                    }

                    SystemUpdate();
                };

            pCore.BaseQualityUpdatedHandler += (o, e) =>
                {
                    dopState.Value = e.DopState;
                    tbaQuality.Value = e.TBAState;
                };

            #endregion

            #region basesProcessor

            basesProcessor = new APLBaseProcessor(4, 2.0);

            #endregion

            #region NMEA

            if (!nmeaSingleton)
            {
                NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.APL);                
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.APL, "A", "x,x.x,x.x,x.x,x,x.x");
                nmeaSingleton = true;
            }

            #endregion

            #region Port dictionaries

            portDescrByHash = new Dictionary<int, string>();
            portNameByHash = new Dictionary<int, string>();
            portHashByDescr = new Dictionary<string, int>();
            portTimoutFlags = new Dictionary<int, bool>();
            portTSByHash = new Dictionary<int, int>();
            
            portDescrByHash.Add(emuID, emuIDstr);
            portNameByHash.Add(emuID, emuIDstr);
            portHashByDescr.Add(emuIDstr, emuID);            

            #endregion

            #region nmeaListener

            nmeaListener = new NMEAMultipleListener();
            nmeaListener.LogEventHandler += (o, e) => InfoEventHandler.Rise(o, e);
            nmeaListener.NMEAIncomingMessageReceived += (o, e) => InfoEventHandler.Rise(o,
                new LogEventArgs(LogLineType.INFO,
                    string.Format("{0} ({1}) >> {2}", portNameByHash[e.SourceID], portDescrByHash[e.SourceID], e.Message)));

            nmeaListener.RMCSentenceReceived += new EventHandler<RMCMessageEventArgs>(nmeaListener_RMCSentenceReceivedHandler);
            nmeaListener.MTWSentenceReceived += new EventHandler<MTWMessageEventArgs>(nmeaListener_MTWSentenceReceivedHandler);
            nmeaListener.NMEAProprietaryUnsupportedSentenceParsed += new EventHandler<NMEAUnsupportedProprietaryEventArgs>(nmeaListener_NMEAUnsupportedProprietaryReceivedHander);

            #endregion

            #region inPorts

            List<SerialPortSettings> portsList = new List<SerialPortSettings>();

            foreach (var inPort in inPortSettings)
            {
                int portHash = inPort.Value.PortName.GetHashCode();
                portDescrByHash.Add(portHash, inPort.Key);
                portNameByHash.Add(portHash, inPort.Value.PortName);
                portHashByDescr.Add(inPort.Key, portHash);

                portTimoutFlags.Add(portHash, false);
                portTSByHash.Add(portHash, 0);
                portsList.Add(inPort.Value);
            }

            inPorts = new SerialPortsPool(portsList.ToArray());
            inPorts.DataReceived += (o, e) =>
                {
                    int portKey = e.PortName.GetHashCode();
                    portTSByHash[portKey] = 0;
                    if (portTimoutFlags[portKey])
                    {
                        portTimoutFlags[portKey] = false;
                        PortStateChangedHandler.Rise(this, new EventArgs());
                    }

                    nmeaListener.ProcessIncoming(portKey, e.Data);
                };
            inPorts.ErrorReceived += (o, e) => InfoEventHandler.Rise(o,
                new LogEventArgs(LogLineType.ERROR,
                    string.Format("{0} ({1}) >> {2}", e.PortName, portDescrByHash[e.PortName.GetHashCode()], e.EventType.ToString())));

            #endregion            

            #region timer

            timer = new PrecisionTimer();
            timer.Mode = Mode.Periodic;
            timer.Period = 100;

            timer.Tick += (o, e) =>
                {
                    if (IsOpen)
                    {
                        int[] keys = new int[portTSByHash.Count]; 
                        portTSByHash.Keys.CopyTo(keys, 0);
                        for (int i = 0; i < keys.Length; i++)
                        {
                            portTSByHash[keys[i]] += timerPeriodMS;
                            if (portTSByHash[keys[i]] > portsTimeoutMS)
                            {
                                portTSByHash[keys[i]] = 0;
                                if (!portTimoutFlags[keys[i]])
                                {
                                    portTimoutFlags[keys[i]] = true;
                                    PortStateChangedHandler.Rise(this, new EventArgs());
                                }
                            }
                        }
                    }

                    systemUpdateTS += timerPeriodMS;
                    if (systemUpdateTS > systemUpdateTimeoutMS)
                        SystemUpdate();
                };

            timer.Start();

            #endregion
        }

        #endregion

        #region Methods

        #region Private

        private void WriteOutData(double bLat, double bLon, double bDpt, double rErr, double course, bool isValid)
        {
            string latCardinal, lonCardinal;

            string RMCvString;
            if (isValid) RMCvString = "Valid";
            else RMCvString = "Invalid";

            if (bLat > 0) latCardinal = "North";
            else latCardinal = "South";

            if (bLon > 0) lonCardinal = "East";
            else lonCardinal = "West";

            StringBuilder emuString = new StringBuilder();

            #region RMC

            emuString.Append(NMEAParser.BuildSentence(TalkerIdentifiers.GP,
                SentenceIdentifiers.RMC,
                new object[] 
                {
                    GetTimeStamp(), 
                    RMCvString, 
                    doubleNullCheckerR(Math.Abs(bLat)), latCardinal,
                    doubleNullCheckerR(Math.Abs(bLon)), lonCardinal,
                    null, // speed
                    doubleNullCheckerR(course), // track true
                    GetTimeStamp(),
                    null, // magnetic variation
                    null, // magnetic variation direction
                    "A",
                }));

            #endregion

            #region GGA

            if (bLat > 0) latCardinal = "N";
            else latCardinal = "S";

            if (bLon > 0) lonCardinal = "E";
            else lonCardinal = "W";

            emuString.Append(NMEAParser.BuildSentence(TalkerIdentifiers.GP,
                SentenceIdentifiers.GGA,
                new object[]
                {
                    GetTimeStamp(),
                    doubleNullCheckerR(Math.Abs(bLat)), latCardinal,
                    doubleNullCheckerR(Math.Abs(bLon)), lonCardinal,
                    "GPS fix",
                    4,
                    doubleNullCheckerR(rErr),
                    doubleNullCheckerR(-bDpt),
                    "M",
                    null,
                    "M",
                    null,
                    null
                }));

            #endregion

            var emuStr = emuString.ToString();

            try
            {
                var bytes = Encoding.ASCII.GetBytes(emuStr);
                outPort.Write(bytes, 0, bytes.Length);

                InfoEventHandler.Rise(this, new LogEventArgs(LogLineType.INFO, string.Format("{0} (OUT) << {1}", outPort.PortName, emuStr)));
            }
            catch (Exception ex)
            {
                InfoEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }
        }

        private void SystemUpdate()
        {
            systemUpdateTS = 0;
            SystemUpdateHandler.Rise(this, new EventArgs());
        }

        private DateTime GetTimeStamp()
        {
            if (primaryGNSSFixRMC.IsInitialized)
                return primaryGNSSFixRMC.Value.TimeFix.Add(DateTime.Now.Subtract(primaryGNSSFixLocalTS));
            else
                return DateTime.Now;
        }

        private void UpdateSoundSpeed()
        {
            if (meanWaterTemperatureC.IsInitialized)
                pCore.SoundSpeed = PHX.Speed_of_sound_UNESCO_calc(meanWaterTemperatureC.Value, PHX.PHX_ATM_PRESSURE_MBAR, salinity_PSU);
        }

        private void UpdateTargetRelativeData()
        {
            if (primaryGNSSFixRMC.IsInitializedAndNotObsolete &&
                targetFixFlt.IsInitialized)
            {
                double sp_lat_rad = Algorithms.Deg2Rad(primaryGNSSFixRMC.Value.Latitude);
                double sp_lon_rad = Algorithms.Deg2Rad(primaryGNSSFixRMC.Value.Longitude);
                double ep_lat_rad = Algorithms.Deg2Rad(targetFixFlt.Value.Latitude);
                double ep_lon_rad = Algorithms.Deg2Rad(targetFixFlt.Value.Longitude);

                double dst_m = double.NaN;
                double fwd_az_rad = double.NaN;
                double rev_az_rad = double.NaN;
                int its = -1;

                Algorithms.VincentyInverse(sp_lat_rad, sp_lon_rad,
                    ep_lat_rad, ep_lon_rad, Algorithms.WGS84Ellipsoid,
                    Algorithms.VNC_DEF_EPSILON, Algorithms.VNC_DEF_IT_LIMIT,
                    out dst_m, out fwd_az_rad, out rev_az_rad, out its);

                rev_az_rad += Math.PI;
                if (rev_az_rad > Math.PI * 2)
                    rev_az_rad -= Math.PI * 2;

                if (!double.IsNaN(dst_m))
                    distanceToTarget.Value = dst_m;

                if (!double.IsNaN(fwd_az_rad))
                    forwardAzimuthToTarget.Value = Algorithms.Rad2Deg(fwd_az_rad);

                if (!double.IsNaN(rev_az_rad))
                    reverseAzimuthToTarget.Value = Algorithms.Rad2Deg(rev_az_rad);
            }
        }

        private void TryLocate(IEnumerable<GeoPoint3DT> basePoints)
        {
            double baseMeanDepth = 0.0;
            int bCount = 0;
            foreach (var item in basePoints)
            {
                baseMeanDepth += item.Depth;
                bCount++;
            }

            if (bCount >= 3)
            {
                baseMeanDepth /= bCount;
                pCore.ProcessBasePoints(basePoints, baseMeanDepth, GetTimeStamp());
            }
        }

        private void OnAPLA(object[] parameters)
        {
            // Incoming APLA sentence received
            // $PAPLA,bID,bLat,bLon,bDpt,bBat,bTOA

            BaseIDs baseID = (BaseIDs)(int)parameters[0];
            double bLat = doubleNullChecker(parameters[1]);
            double bLon = doubleNullChecker(parameters[2]);
            double bDpt = doubleNullChecker(parameters[3]);
            bool bBat = Convert.ToBoolean(intNullChecker(parameters[4]));
            double bTOA = doubleNullChecker(parameters[5]);

            if ((baseID != BaseIDs.BASE_INVALID) &&
                (!double.IsNaN(bLat) &&
                (!double.IsNaN(bLon) &&
                (!double.IsNaN(bDpt)))))
            {
                TrackUpdateHandler.Rise(this,
                    new TrackUpdateEventArgs(baseID.ToString().Replace('_', ' '),
                        new GeoPoint3DETm(bLat, bLon, bDpt, 0.0, GetTimeStamp()), double.NaN));

                BaseBatStates[baseID].Value = bBat;

                var bases = basesProcessor.ProcessBase(baseID, bLat, bLon, bDpt, bTOA);

                if (bases != null)
                    TryLocate(bases);                
            }
        }

        #endregion

        #region Public

        public void Open()
        {
            if (!IsOpen)
            {
                foreach (var item in portNameByHash)
                {
                    if (item.Key != emuID)
                    {
                        try
                        {
                            InfoEventHandler.Rise(this,
                                new LogEventArgs(LogLineType.INFO, string.Format("Opening {0} ({1})...",
                                    item.Value, portDescrByHash[item.Key])));

                            inPorts.Open(item.Value);
                        }
                        catch (Exception ex)
                        {
                            InfoEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                        }
                    }                    
                }

                if (outPort != null)
                {
                    try
                    {
                        InfoEventHandler.Rise(this,
                            new LogEventArgs(LogLineType.INFO, string.Format("Opening {0} (OUTPUT)...", outPort.PortName)));

                        outPort.Open();
                    }
                    catch (Exception ex)
                    {
                        InfoEventHandler.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                    }
                }

                IsOpen = true;
            }
            else
                throw new InvalidOperationException("Connection(s) already opened");

            PortStateChangedHandler.Rise(this, new EventArgs());
        }

        public void Close()
        {
            if (IsOpen)
            {
                inPorts.Close();

                if (outPort != null)
                {
                    outPort.Close();
                }

                IsOpen = false;
            }
            else
                throw new InvalidOperationException("Connection(s) is not opened");

            PortStateChangedHandler.Rise(this, new EventArgs());
        }

        public void SetPrimaryGNSSSource(string key)
        {
            primaryGNSS_SourceID = portHashByDescr[key];
            isPrimaryGNSS_Set = true;
        }

        public void InitOutputPort(SerialPortSettings portSettings)
        {
            portDescrByHash.Add(portSettings.PortName.GetHashCode(), "OUT");
            portNameByHash.Add(portSettings.PortName.GetHashCode(), portSettings.PortName);

            outPort = new SerialPort(portSettings.PortName, (int)portSettings.PortBaudRate, 
                portSettings.PortParity, (int)portSettings.PortDataBits, portSettings.PortStopBits);
            outPort.ErrorReceived += (o, e) => InfoEventHandler.Rise(o, 
                new LogEventArgs(LogLineType.ERROR,
                    string.Format("{0} ({1}) >> {2}", outPort.PortName, portDescrByHash[outPort.PortName.GetHashCode()], e.EventType.ToString())));
        }

        public void Emulate(string nmeaString)
        {
            if (!nmeaString.Contains("EMU")) // to prevent to emulate emulator's output
                nmeaListener.ProcessIncoming(emuID, nmeaString);
        }

        public string GetPortsStateDescription()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in portTimoutFlags)
            {
                if (inPorts.IsOpen(portNameByHash[item.Key]))
                {
                    if (item.Value)
                        sb.AppendFormat("{0} ({1}): TIMEOUT ", portNameByHash[item.Key], portDescrByHash[item.Key]);
                    else
                        sb.AppendFormat("{0} ({1}): OK ", portNameByHash[item.Key], portDescrByHash[item.Key]);
                }
                else
                    sb.AppendFormat("{0} ({1}): CLOSED ", portNameByHash[item.Key], portDescrByHash[item.Key]);
            }

            return sb.ToString();
        }

        public string GetTargetStateDescription()
        {
            StringBuilder sb = new StringBuilder();

            if (targetFix.IsInitialized)
                sb.AppendLine(targetFix.ToString());

            if (targetCourse.IsInitialized)
                sb.AppendLine(targetCourse.ToString());          

            return sb.ToString();
        }

        public string GetSystemStateDescription()
        {
            StringBuilder sb = new StringBuilder();

            if (primaryGNSSFixRMC.IsInitialized)
                sb.AppendLine(primaryGNSSFixRMC.ToString());

            if (distanceToTarget.IsInitialized)
                sb.AppendLine(distanceToTarget.ToString());

            if (forwardAzimuthToTarget.IsInitialized)
                sb.AppendLine(forwardAzimuthToTarget.ToString());

            if (reverseAzimuthToTarget.IsInitialized)
                sb.AppendLine(reverseAzimuthToTarget.ToString());

            foreach (var item in BaseBatStates)
            {
                if (item.Value.IsInitialized)
                {
                    var st = item.Value.ToString();
                    if (!string.IsNullOrEmpty(st))
                        sb.AppendLine(st);
                }
            }

            return sb.ToString();
        }

        public void MarkTargetLocation()
        {
            if (targetFixFlt.IsInitialized)
                TrackUpdateHandler.Rise(this, new TrackUpdateEventArgs("Marked", targetFixFlt.Value, double.NaN));
        }

        #endregion

        #endregion

        #region Handlers

        #region nmeaListener

        private void nmeaListener_RMCSentenceReceivedHandler(object sender, RMCMessageEventArgs e)
        {
            if (e.IsValid)
            {
                if (isPrimaryGNSS_Set && (e.SourceID == primaryGNSS_SourceID))
                {
                    primaryGNSSFixRMC.Value = e;
                    primaryGNSSFixLocalTS = DateTime.Now;

                    if (targetFix.IsInitialized)
                        UpdateTargetRelativeData();

                    SystemUpdate();
                }

                TrackUpdateHandler.Rise(this,
                    new TrackUpdateEventArgs(portDescrByHash[e.SourceID],
                        new GeoPoint3DETm(e.Latitude, e.Longitude, double.NaN, double.NaN, e.TimeFix), e.TrackTrue));
            }
        }

        private void nmeaListener_MTWSentenceReceivedHandler(object sender, MTWMessageEventArgs e)
        {
            if (e.IsValid)
            {
                meanWaterTemperatureC.Value = e.MeanWaterTemperature;
                if (!IsAutoSoundSpeed)
                    UpdateSoundSpeed();

                SystemUpdate();
            }
        }

        private void nmeaListener_NMEAUnsupportedProprietaryReceivedHander(object sender, NMEAUnsupportedProprietaryEventArgs e)
        {
            if ((e.Sentence.Manufacturer == UCNLNMEA.ManufacturerCodes.APL) &&
                (e.Sentence.SentenceIDString == "A"))
            {
                OnAPLA(e.Sentence.parameters);
            }
        }

        #endregion

        #endregion

        #region Events

        public EventHandler<LogEventArgs> InfoEventHandler;
        public EventHandler SystemUpdateHandler;
        public EventHandler<TrackUpdateEventArgs> TrackUpdateHandler;
        public EventHandler PortStateChangedHandler;
        
        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    #region timer

                    if (timer.IsRunning)
                    {
                        timer.Stop();
                    }
                    timer.Dispose();

                    #endregion

                    #region inPorts

                    if (inPorts != null)
                    {
                        try
                        {
                            inPorts.Close();
                        }
                        catch { }

                        inPorts.Dispose();
                    }

                    #endregion

                    #region outPort

                    if (outPort != null)
                    {
                        if (outPort.IsOpen)
                        {
                            try
                            {
                                outPort.Close();
                            }
                            catch { }
                        }

                        outPort.Dispose();
                    }

                    #endregion
                }

                disposed = true;
            }
        }

        #endregion
    }
}
