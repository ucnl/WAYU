using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using UCNLDrivers;
using UCNLNav;
using UCNLNMEA;
using UCNLUI;

namespace WAYU.APL
{
    #region Extra EventArgs
    public class TrackPointEventArgs : EventArgs
    {
        #region Properties

        public string TrackID { get; private set; }
        public double Latitude_deg { get; private set; }        

        public double Longitude_deg { get; private set; }

        public double RadialError_m { get; private set; }

        public double Depth_m { get; private set; }

        public double Course_deg { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public bool IsRadialError { get => !double.IsNaN(RadialError_m); }
        public bool IsCourse { get => !double.IsNaN(Course_deg); }
        public bool IsDepth { get => !double.IsNaN(Depth_m); }

        #endregion

        #region Constructor

        public TrackPointEventArgs(string trackID, double lat_deg, double lon_deg, double dpt_m, DateTime tStamp)
            : this(trackID, lat_deg, lon_deg, dpt_m, double.NaN, double.NaN, tStamp)
        {

        }

        public TrackPointEventArgs(string trackID, double lat_deg, double lon_deg, double dpt_m, double rerr_m, double crs_deg, DateTime timeStamp)
        {
            TrackID = trackID;
            Latitude_deg = lat_deg;
            Longitude_deg = lon_deg;
            Depth_m = dpt_m;
            RadialError_m = rerr_m;
            Course_deg = crs_deg;
            TimeStamp = timeStamp;
        }

        #endregion
    }

    #endregion

    public class APLCore
    {
        #region Properties

        APLPort aplPort;
        uGNSSSerialPort auxGNSSPort;
        NMEASerialPort serialOutputPort;
        UDPTranslator udpOutput;

        APLBaseProcessor bProcessor;
        PCore2D<GeoPoint3DT> pcore;
        TrackFilter sFilter;
        DHFilter dFilter;
        CourseEstimatorLA2D crsEstimator;
        WPManager wpManager;
        PrecisionTimer pTimer;
        StatHelper statHelper;

        DateTime stateUpdateTS;
        int outputCnt = 0;

        List<DateTime> fixTSs;
        double minFixDelay = double.MaxValue;
        double maxFixDelay = double.MinValue;
        double meanFixDelay = 0;

        #region Public        

        public bool LocationPresent
        {
            get => (tLat.IsInitialized && tLon.IsInitialized);
        }

        public bool IsAutoSoundSpeed
        {
            get => wpManager.IsAutoSoundSpeed;
            set => wpManager.IsAutoSalinity = value;
        }

        public bool IsAutoSalinity
        {
            get => wpManager.IsAutoSalinity;
            set => wpManager.IsAutoSalinity = value;
        }

        public double SoundSpeed_mps
        {
            get => wpManager.SoundSpeed;
            set
            {
                wpManager.SoundSpeed = value;
                wpManager.IsAutoSoundSpeed = false;
            }
        }

        public double Salinity_psu
        {
            get => wpManager.Salinity;
            set
            {
                wpManager.Salinity = value;
                wpManager.IsAutoSalinity = false;
            }
        }

        public double WaterTemperature_C
        {
            get => wpManager.Temperature;
            set => wpManager.Temperature = value;            
        }

        #region BasePointTypeToNavigate

        BasePointType bpTypeToNavigate = BasePointType.Base_1;
        public BasePointType BasePointTypeToNavigate
        {
            get => bpTypeToNavigate;
            set
            {
                bpToNavigateLat = double.NaN;
                bpToNavigateLon = double.NaN;

                bpTypeToNavigate = value;
                crsFromBP2Target = new AgingValue<double>(3, 30, APL.degrees1dec_fmtr);
                crsFromTarget2BP = new AgingValue<double>(3, 30, APL.degrees1dec_fmtr);
                dstFromBP2Target = new AgingValue<double>(3, 30, APL.meters1dec_fmtr);

                TryUpdateBasePointType();
                UpdateRelativeParameters();
            }
        }

        double bpToNavigateLat = double.NaN;
        double bpToNavigateLon = double.NaN;

        double userBPToNavigateLat = double.NaN;
        double userBPToNavigateLon = double.NaN;

        #endregion

        #region serialOutputPort

        public bool SerialOutputActive { get => (serialOutputPort != null) && (serialOutputPort.IsOpen); }

        public bool SerialOutputEnabled { get; private set; }

        #endregion

        #region udpOutput

        public bool IsUDPNMEA { get; private set; }

        public bool UDPOutputEnabled { get; private set; }   

        #endregion

        #region AUX GNSS

        public bool AuxGNSSEnabled { get; private set; }
        public bool AuxGNSSPortDetected { get => auxGNSSPort == null ? false : auxGNSSPort.Detected; }
        public bool AuxGNSSPortIsActive { get => auxGNSSPort == null ? false : auxGNSSPort.IsActive; }
        public string AuxGNSSPortStatus { get => auxGNSSPort == null ? string.Empty : auxGNSSPort.ToString(); }

        #endregion

        #region APLPort

        public bool APLPortDetected { get => aplPort.Detected; }
        public bool APLPortIsActive { get => aplPort.IsActive; }
        public string APLPortStatus { get => aplPort.ToString(); }

        #endregion

        public bool IsActive { get => aplPort.IsActive; }

        public bool StatHelperActive { get => statHelper.IsActive; }

        #endregion

        #region Aging        

        AgingValue<double> tLat;
        AgingValue<double> tLon;
        AgingValue<double> tDpt;
        AgingValue<double> tLatRaw;
        AgingValue<double> tLonRaw;
        AgingValue<double> tRErr;
        DateTime tFixTime;

        AgingValue<double> tCrs;

        AgingValue<double> crsFromBP2Target;
        AgingValue<double> crsFromTarget2BP;
        AgingValue<double> dstFromBP2Target;

        AgingValue<double> auxSpeed;
        AgingValue<double> auxCourse;
        AgingValue<double> auxHeading;
        AgingValue<double> auxLat;
        AgingValue<double> auxLon;
        AgingValue<DateTime> auxTime;

        AgingValue<double> statCEP;
        AgingValue<double> statDRMS;

        Dictionary<BaseIDs, AgingValue<GeoPoint3D>> bLocs;
        Dictionary<BaseIDs, AgingValue<BatState>> bBats;

        AgingValue<DOPState> HDOPState;
        AgingValue<TBAQuality> TBAState;

        #endregion

        readonly string[] llSeparators = new string[] { ">>", " " };

        #endregion

        #region Constructor

        public APLCore(BaudRate inPortBaudrate, double rErrThreshold, int crsEstimatorFIFOSize, int sFilterFIFOSize,
            double sFilterRangeThreshold_m, int dFilterFIFOSize, double dFilterMaxSpeed_mps, double dFilterRangeThreshold_m)
        {
            #region parameters checking

            if (rErrThreshold <= 0)
                throw new ArgumentOutOfRangeException(nameof(rErrThreshold));

            if (crsEstimatorFIFOSize <= 2)
                throw new ArgumentOutOfRangeException(nameof(crsEstimatorFIFOSize));

            #endregion

            #region wpManager

            wpManager = new WPManager();
            wpManager.IsAutoSalinity = true;
            wpManager.IsAutoSoundSpeed = true;
            wpManager.IsAutoGravity = true;
            wpManager.SalinityChanged += (o, e) =>
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(CultureInfo.InvariantCulture, "Salinity = {0:F01} PSU", wpManager.Salinity);
                if (wpManager.IsAutoSalinity)
                    sb.AppendFormat(" (auto, for point: {0:F02}°, {1:F02})°", wpManager.SalinityLatPoint, wpManager.SalinityLonPoint);
                LogEvent.Rise(this, new LogEventArgs(LogLineType.INFO, sb.ToString()));                
            };
            wpManager.SoundSpeedChanged += (o, e) =>
            {
                pcore.SoundSpeed = wpManager.SoundSpeed;                

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(CultureInfo.InvariantCulture, "Speed of sound = {0:F02} m/s", wpManager.SoundSpeed);
                if (wpManager.IsAutoSoundSpeed)
                    sb.Append(" (auto)");
                LogEvent.Rise(this, new LogEventArgs(LogLineType.INFO, sb.ToString()));
            };

            #endregion

            #region Aging values

            tLat = new AgingValue<double>(3, 30, APL.latlon_fmtr);
            tLon = new AgingValue<double>(3, 30, APL.latlon_fmtr);
            tDpt = new AgingValue<double>(3, 30, APL.meters1dec_fmtr);
            tLatRaw = new AgingValue<double>(3, 30, APL.latlon_fmtr);
            tLonRaw = new AgingValue<double>(3, 30, APL.latlon_fmtr);
            tRErr = new AgingValue<double>(3, 30, APL.meters3dec_fmtr);
            tCrs = new AgingValue<double>(3, 30, APL.degrees1dec_fmtr);

            crsFromBP2Target = new AgingValue<double>(3, 30, APL.degrees1dec_fmtr);
            crsFromTarget2BP = new AgingValue<double>(3, 30, APL.degrees1dec_fmtr);
            dstFromBP2Target = new AgingValue<double>(3, 30, APL.meters1dec_fmtr);

            auxSpeed = new AgingValue<double>(3, 30, o => string.Format(CultureInfo.InvariantCulture, "{0:F01} m/s ({1:F01} km/h)", o, o * 3.6));
            auxCourse = new AgingValue<double>(3, 30, APL.degrees1dec_fmtr);
            auxHeading = new AgingValue<double>(3, 30, APL.degrees1dec_fmtr);
            auxLat = new AgingValue<double>(3, 30, APL.latlon_fmtr);
            auxLon = new AgingValue<double>(3, 30, APL.latlon_fmtr);
            auxTime = new AgingValue<DateTime>(3, 60, x => x.ToLongTimeString());

            bLocs = new Dictionary<BaseIDs, AgingValue<GeoPoint3D>>();
            bBats = new Dictionary<BaseIDs, AgingValue<BatState>>();
            
            foreach (BaseIDs baseID in Enum.GetValues(typeof(BaseIDs)))
            {
                if (baseID != BaseIDs.Invalid)
                {
                    bBats.Add(baseID, new AgingValue<BatState>(30, 60, x => x == BatState.UNKNOWN ? string.Empty : string.Format("{0} ⚡ {1}", baseID.ToString().Replace('_', ' '), x.ToString())));
                    bLocs.Add(baseID, new AgingValue<GeoPoint3D>(3, 60, x => x.ToString()));
                }
            }

            HDOPState = new AgingValue<DOPState>(4, 10, x => x.ToString().Replace('_', ' ').ToUpperInvariant());
            TBAState = new AgingValue<TBAQuality>(4, 10, x => x.ToString().Replace('_', ' ').ToUpperInvariant());

            statCEP = new AgingValue<double>(4, 300, APL.meters3dec_fmtr);
            statDRMS = new AgingValue<double>(4, 300, APL.meters3dec_fmtr);

            #endregion

            #region pcore & relative items

            fixTSs = new List<DateTime>();

            sFilter = new TrackFilter(sFilterFIFOSize, sFilterRangeThreshold_m);
            dFilter = new DHFilter(dFilterFIFOSize, dFilterMaxSpeed_mps, dFilterRangeThreshold_m);

            bProcessor = new APLBaseProcessor(APL.PingerPeriod_s);

            crsEstimator = new CourseEstimatorLA2D(crsEstimatorFIFOSize);            

            pcore = new PCore2D<GeoPoint3DT>(rErrThreshold, 1.0, Algorithms.WGS84Ellipsoid, 2);
            pcore.RadialErrorExeedsThrehsoldEventHandler += (o, e) => LogEvent.Rise(this,
                new LogEventArgs(LogLineType.INFO, "Unable locate WAYU pinger: radial error exceeds threshold"));
            pcore.BaseQualityUpdatedHandler += (o, e) =>
            {
                TBAState.Value = e.TBAState;
                HDOPState.Value = e.DopState;
                ForceStateUpdate();
            };
            pcore.TargetLocationUpdatedExHandler += (o, e) =>
            {
                TrackPointReceived.Rise(this,
                    new TrackPointEventArgs(APL.WAYURawLocationTrackID, e.Location.Latitude, e.Location.Longitude, e.Location.Depth, e.TimeStamp));

                tFixTime = e.TimeStamp;

                ProcessFixTime(e.TimeStamp);

                tLatRaw.Value = e.Location.Latitude;
                tLonRaw.Value = e.Location.Longitude;
                tDpt.Value = e.Location.Depth;
                tRErr.Value = e.Location.RadialError;

                double _lat_rad = Algorithms.Deg2Rad(e.Location.Latitude);
                double _lon_rad = Algorithms.Deg2Rad(e.Location.Longitude);

                if (dFilter.Process(_lat_rad, _lon_rad, e.Location.Depth, DateTime.Now,
                    out _lat_rad, out _lon_rad, out double oDpt, out DateTime oTs))
                {
                    double oLat = Algorithms.Rad2Deg(_lat_rad);
                    double oLon = Algorithms.Rad2Deg(_lon_rad);

                    var fltTrk = sFilter.Filter(oLat, oLon);

                    tLat.Value = fltTrk.Latitude;
                    tLon.Value = fltTrk.Longitude;

                    crsEstimator.AddPoint(new GeoPoint(fltTrk.Latitude, fltTrk.Longitude));
                    if (crsEstimator.IsCourse)
                        tCrs.Value = crsEstimator.Course_deg;

                    if (StatHelperActive)
                    {
                        statHelper.AddPoint(fltTrk);
                        statCEP.Value = statHelper.CEP;
                        statDRMS.Value = statHelper.DRMS;
                    }

                    LogEvent.Rise(this, new LogEventArgs(LogLineType.INFO,
                        string.Format(CultureInfo.InvariantCulture, "WAYU Pinger located: {0}, Course: {1:F01}°",
                        fltTrk, tCrs.IsInitialized ? tCrs.Value : e.Course)));

                    TrackPointReceived.Rise(this,
                    new TrackPointEventArgs(APL.WAYULocationTrackID,
                    tLat.Value, tLon.Value, tDpt.Value, tRErr.Value, 
                    tCrs.IsInitialized ? tCrs.Value : e.Course, e.TimeStamp));

                    UpdateRelativeParameters();
                }
            };

            #endregion

            #region inPort

            aplPort = new APLPort(inPortBaudrate);

            aplPort.LogEventHandler += (o, e) => LogEvent.Rise(this, e);
            aplPort.DetectedChanged += (o, e) =>
            {
                APLPortDetectedChanged.Rise(this, e);
                if (aplPort.Detected && AuxGNSSEnabled && !auxGNSSPort.IsActive)
                    auxGNSSPort.Start();
            };
            aplPort.IsActiveChanged += (o, e) => APLPortActiveChanged.Rise(this, e);
            aplPort.BaseUpdateReceived += (o, e) =>
            {
                ForceStateUpdate();

                if (e.BaseID != BaseIDs.Invalid)
                {
                    if (!double.IsNaN(e.Latitude) && !double.IsNaN(e.Longitude) && !double.IsNaN(e.Depth))
                    {
                        bLocs[e.BaseID].Value = new GeoPoint3D(e.Latitude, e.Longitude, e.Depth);
                        bBats[e.BaseID].Value = e.BaseBatState;

                        TrackPointReceived.Rise(this,
                            new TrackPointEventArgs(
                                APL.BuoysTracksIDs[(int)e.BaseID],
                                e.Latitude, e.Longitude, e.Depth, 
                                GetTimeStamp()));

                        wpManager.UpdateLocation(e.Latitude, e.Longitude);

                        if (((bpTypeToNavigate == BasePointType.Base_1) && (e.BaseID == BaseIDs.Base_1)) ||
                            ((bpTypeToNavigate == BasePointType.Base_2) && (e.BaseID == BaseIDs.Base_2)) ||
                            ((bpTypeToNavigate == BasePointType.Base_3) && (e.BaseID == BaseIDs.Base_3)) ||
                            ((bpTypeToNavigate == BasePointType.Base_4) && (e.BaseID == BaseIDs.Base_4)))
                        {
                            BasePointLocationUpdate(e.Latitude, e.Longitude);
                        }

                        if (!double.IsNaN(e.TOAs))
                        {
                            var bases = bProcessor.ProcessBase(e.BaseID, e.Latitude, e.Longitude, e.Depth, e.TOAs);

                            if ((bases != null) && (bases.Length >= 3))
                            {
                                double meanDpt = 0.0;
                                for (int i = 0; i < bases.Length; i++)
                                    meanDpt += bases[i].Depth;
                                meanDpt /= bases.Length;

                                pcore.ProcessBasePoints(bases, meanDpt, GetTimeStamp());
                            }    
                        }
                    }
                }
            };

            #endregion

            #region statHelper

            statHelper = new StatHelper(4096);
            statHelper.IsActiveChanged += (o, e) => StatHelperActiveChanged.Rise(this, EventArgs.Empty);
            statHelper.IsAutoStop = true;

            #endregion

            #region pTimer

            pTimer = new PrecisionTimer();
            pTimer.Period = 100;
            pTimer.Mode = Mode.Periodic;

            pTimer.Tick += (o, e) =>
            {
                if (DateTime.Now.Subtract(stateUpdateTS).TotalMilliseconds >= 1000)
                    ForceStateUpdate();

                if (++outputCnt * pTimer.Period >= 1000)
                {
                    outputCnt = 0;
                    if (SerialOutputActive || UDPOutputEnabled)
                        ProcessOutput();
                }
            };

            pTimer.Start();

            #endregion
        }

        #endregion

        #region Methods

        #region Public

        public bool JustParseEmuLine(string s, out BaseIDs bID, out double bLat, out double bLon, out double bDpt, out double bBat, out double bTOA)
        {
            bID = BaseIDs.Invalid;
            bLat = double.NaN;
            bLon = double.NaN;
            bDpt = double.NaN;
            bBat = double.NaN;
            bTOA = double.NaN;

            var splits = s.Split(llSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 3)
            {
                if (splits[1] == "(WAYU_GIBs)")
                {
                    var nstr = splits[2];
                    if (!nstr.EndsWith(NMEAParser.SentenceEndDelimiter))
                        nstr += NMEAParser.SentenceEndDelimiter;

                    return aplPort.JustParseAPLA(nstr, out bID, out bLat, out bLon, out bDpt, out bBat, out bTOA);
                }
                else
                    return false;
            }
            else
                return false;
        }

        public GeoPoint GetLocation()
        {
            double lat = 0.0;
            double lon = 0.0;

            if (tLat.IsInitialized && tLon.IsInitialized)
            {
                lat = tLat.Value;
                lon = tLon.Value;
            }
            else if (auxLat.IsInitialized && auxLon.IsInitialized)
            {
                lat = auxLat.Value;
                lon = auxLon.Value;
            }
            else
            {
                if (bLocs.ContainsKey(BaseIDs.Base_1) && bLocs[BaseIDs.Base_1].IsInitialized)
                {
                    lat = bLocs[BaseIDs.Base_1].Value.Latitude;
                    lon = bLocs[BaseIDs.Base_1].Value.Longitude;
                }
                else if (bLocs.ContainsKey(BaseIDs.Base_2) && bLocs[BaseIDs.Base_2].IsInitialized)
                {
                    lat = bLocs[BaseIDs.Base_2].Value.Latitude;
                    lon = bLocs[BaseIDs.Base_2].Value.Longitude;
                }
                else if (bLocs.ContainsKey(BaseIDs.Base_3) && bLocs[BaseIDs.Base_3].IsInitialized)
                {
                    lat = bLocs[BaseIDs.Base_3].Value.Latitude;
                    lon = bLocs[BaseIDs.Base_3].Value.Longitude;
                }
                else if (bLocs.ContainsKey(BaseIDs.Base_4) && bLocs[BaseIDs.Base_4].IsInitialized)
                {
                    lat = bLocs[BaseIDs.Base_4].Value.Latitude;
                    lon = bLocs[BaseIDs.Base_4].Value.Longitude;
                }
            }
            
            return new GeoPoint(lat, lon);
        }

        public string GetDelayStatistics()
        {
            if (fixTSs.Count < 2) return string.Empty;
            else
                return string.Format(CultureInfo.InvariantCulture,
                    "\r\nFDL:\r\n MIN: {0:F01} sec\r\n MAX: {1:F01} sec\r\n MEA: {2:F01} sec\r\n CNT: {3}\r\n",
                    minFixDelay, maxFixDelay, meanFixDelay, fixTSs.Count);
        }


        public void Start()
        {
            if (AuxGNSSEnabled && auxGNSSPort.IsActive)
                auxGNSSPort.Stop();

            if (!aplPort.IsActive)
            {
                aplPort.Start();
                fixTSs = new List<DateTime>();
                maxFixDelay = double.MinValue;
                minFixDelay = double.MaxValue;
                meanFixDelay = 0;
            }
        }

        public void Stop()
        {
            if (aplPort.IsActive)
            {
                aplPort.Stop();

                if (AuxGNSSEnabled && auxGNSSPort.IsActive)
                    auxGNSSPort.Stop();

                if (SerialOutputActive)                
                    SerialOutputClose();
            }
        }

        public void AuxGNSSInit(BaudRate baudrate)
        {
            if (!AuxGNSSEnabled)
            {
                AuxGNSSEnabled = true;

                auxGNSSPort = new uGNSSSerialPort(baudrate)
                {
                    IsLogIncoming = true,
                    IsTryAlways = true
                };

                auxGNSSPort.DetectedChanged += (o, e) => AuxGNSSPortDetectedChanged.Rise(o, e);
                auxGNSSPort.IsActiveChanged += (o, e) => AuxGNSSPortActiveChanged.Rise(o, e);
                auxGNSSPort.HeadingUpdated += (o, e) =>
                {
                    auxHeading.Value = auxGNSSPort.Heading;
                    HeadingUpdated.Rise(this, new EventArgs());
                };

                auxGNSSPort.LocationUpdated += (o, e) =>
                {
                    auxTime.Value = auxGNSSPort.GNSSTime;
                    auxLat.Value = auxGNSSPort.Latitude;
                    auxLon.Value = auxGNSSPort.Longitude;
                    auxCourse.Value = auxGNSSPort.CourseOverGround;
                    auxSpeed.Value = auxGNSSPort.GroundSpeed;                  

                    TrackPointReceived.Rise(this,
                        new TrackPointEventArgs(APL.AuxGNSSTrackID, 
                        auxGNSSPort.Latitude, auxGNSSPort.Longitude, 0.0,
                        GetTimeStamp()));

                    if (bpTypeToNavigate == BasePointType.AUX_GNSS)
                        BasePointLocationUpdate(auxGNSSPort.Latitude, auxGNSSPort.Longitude);
                };

                auxGNSSPort.LogEventHandler += (o, e) => LogEvent.Rise(o, e);
            }
        }

        public void SerialOutputInit(string portName, BaudRate baudrate)
        {
            if (SerialOutputActive)
                SerialOutputClose();

            SerialOutputEnabled = true;

            serialOutputPort = new NMEASerialPort(
                new SerialPortSettings(portName, 
                baudrate, 
                System.IO.Ports.Parity.None, 
                DataBits.dataBits8, 
                System.IO.Ports.StopBits.One, 
                System.IO.Ports.Handshake.None));

            LogEvent.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Initalizing output via serial connection on {0} ({1})", portName, baudrate)));
        }

        public void SerialOutputClose()
        {
            try
            {
                serialOutputPort.Close();
                LogEvent.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Output via serial connection on {0} ({1}) is closed", serialOutputPort.PortName, serialOutputPort.PortBaudRate)));
            }
            catch (Exception ex)
            {
                LogEvent.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }            
        }

        public void SerialOutputDeInit()
        {
            SerialOutputClose();
            SerialOutputEnabled = false;
        }

        public void UDPOutputInit(IPAddress ipAddress, int port, bool isNMEA)
        {
            try
            {
                udpOutput = new UDPTranslator(port, ipAddress);
                UDPOutputEnabled = true;
                IsUDPNMEA = isNMEA;

                LogEvent.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Initalizing output via UDP on {0}:{1}", ipAddress, port)));
            }
            catch (Exception ex)
            {
                LogEvent.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
            }
        }

        public void UDPOutputDeInit()
        {
            if (UDPOutputEnabled)
            {
                UDPOutputEnabled = false;
                LogEvent.Rise(this, new LogEventArgs(LogLineType.INFO,
                    string.Format("Output via UDP on {0}:{1} is closed", udpOutput.Address, udpOutput.Port)));
            }
        }

        public void SetBasePointToNavigate(double lat, double lon, bool isSetAsPrimary)
        {
            userBPToNavigateLat = lat;
            userBPToNavigateLon = lon;

            if (isSetAsPrimary)
            {
                bpTypeToNavigate = BasePointType.Specified;
                BasePointLocationUpdate(lat, lon);
            }
        }

        public void MarkTargetLocation()
        {
            if (tLat.IsInitialized && tLon.IsInitialized)
                TrackPointReceived.Rise(this, new TrackPointEventArgs("Marked", tLat.Value, tLon.Value, tDpt.Value, GetTimeStamp()));
        }

        public void Emulate(string eString)
        {
            string str = eString.Trim() + NMEAParser.SentenceEndDelimiter;

            var splits = str.Split(llSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length == 3)
            {
                if (splits[1] == "(GNSS)")
                {
                    if (auxGNSSPort == null)
                        AuxGNSSInit(BaudRate.baudRate9600);

                    auxGNSSPort.EmulateInput(splits[2]);
                }
                else if (splits[1] == "(WAYU_GIBs)")
                {
                    aplPort.EmulateInput(splits[2]);
                }
            }
        }

        public string GetSystemDescription()
        {
            StringBuilder sb = new StringBuilder();

            if (tLat.IsInitialized && tLon.IsInitialized && 
                tRErr.IsInitialized && tCrs.IsInitialized)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "TGT\r\n LAT: {0}\r\n LON: {1}\r\n RER: {2}\r\n CRS: {3}\r\n",
                    tLat.ToString(),
                    tLon.ToString(),
                    tRErr.ToString(),
                    tCrs.ToString());
            }

            sb.AppendFormat("\r\nREF: {0}\r\n", BasePointTypeToNavigate.ToString().Replace('_', ' '));
            if (dstFromBP2Target.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture, " DST: {0}\r\n", dstFromBP2Target.ToString());
            if (crsFromBP2Target.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture, " AZM: {0}\r\n", crsFromBP2Target.ToString());
            if (crsFromTarget2BP.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture, " RAZ: {0}\r\n", crsFromTarget2BP.ToString());

            sb.Append("\r\n");

            foreach (var item in bBats)
            {
                if (item.Value.IsInitialized)
                {
                    var st = item.Value.ToString();
                    if (!string.IsNullOrEmpty(st))
                        sb.AppendLine(st);
                }
            }

            if (statCEP.IsInitialized && statDRMS.IsInitialized)
            {
                sb.AppendFormat("\r\nStats (by {0} points)\r\n", statHelper.RingCount);
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "  CEP: {0}\r\n DRMS: {1}\r\n2DRMS: {2:F03} m\r\n3DRMS: {3:F03} m\r\n",
                    statCEP.ToString(), 
                    statDRMS.ToString(), 
                    statDRMS.Value * 2,
                    statDRMS.Value * 3);
            }
            
            return sb.ToString();
        }

        public void AccuracyEstimationStart()
        {
            AccuracyEstimationDiscard();
            statHelper.Start();
        }

        public void AccuracyEstimationStop()
        {
            statHelper.Stop();
        }

        public void AccuracyEstimationDiscard()
        {
            statHelper.Reset();
            statCEP = new AgingValue<double>(4, 300, APL.meters3dec_fmtr);
            statDRMS = new AgingValue<double>(4, 300, APL.meters3dec_fmtr);
        }

        #endregion

        #region Private

        private void ProcessFixTime(DateTime ts)
        {
            fixTSs.Add(ts);

            if (fixTSs.Count > 0)
            {
                double mnDelay = 0;
                for (int i = 1; i < fixTSs.Count; i++)
                {
                    var delay = fixTSs[i].Subtract(fixTSs[i - 1]).TotalSeconds;
                    mnDelay += delay;

                    if (minFixDelay > delay)
                        minFixDelay = delay;

                    if (maxFixDelay < delay)
                        maxFixDelay = delay;

                    //
                    if (delay < 40)
                    {
                        //
                        meanFixDelay += delay;
                        //
                    }
                    //
                }

                meanFixDelay /= fixTSs.Count;
            }
        }

        private void ForceStateUpdate()
        {
            StateUpdated.Rise(this, EventArgs.Empty);
            stateUpdateTS = DateTime.Now;
        }

        private DateTime GetTimeStamp()
        {
            if (auxTime.IsInitialized)
                return auxTime.Value.Add(DateTime.Now.Subtract(auxTime.TimeStamp));
            else
                return DateTime.Now;
        }

        private void UpdateRelativeParameters()
        {
            if (tLat.IsInitialized &&
                tLon.IsInitialized &&
                !double.IsNaN(bpToNavigateLat) &&
                !double.IsNaN(bpToNavigateLon))
            {
                var tLat_rag = Algorithms.Deg2Rad(tLat.Value);
                var tLon_rag = Algorithms.Deg2Rad(tLon.Value);
                var bpLat_rag = Algorithms.Deg2Rad(bpToNavigateLat);
                var bpLon_rag = Algorithms.Deg2Rad(bpToNavigateLon);

                Algorithms.VincentyInverse(bpLat_rag, bpLon_rag, tLat_rag, tLon_rag,
                    Algorithms.WGS84Ellipsoid,
                    Algorithms.VNC_DEF_EPSILON, Algorithms.VNC_DEF_IT_LIMIT,
                    out double dst_m,
                    out double fwd_az,
                    out double rev_az,
                    out int it_cnt);

                rev_az = Algorithms.Wrap2PI(rev_az + Math.PI);

                crsFromBP2Target.Value = Algorithms.Rad2Deg(fwd_az);
                crsFromTarget2BP.Value = Algorithms.Rad2Deg(rev_az);
                dstFromBP2Target.Value = dst_m;

                ForceStateUpdate();
            }
        }

        private void TryUpdateBasePointType()
        {
            if ((BasePointTypeToNavigate == BasePointType.Base_1) &&
                (bLocs[BaseIDs.Base_1].IsInitialized))
            {
                BasePointLocationUpdate(bLocs[BaseIDs.Base_1].Value.Latitude, bLocs[BaseIDs.Base_1].Value.Longitude);
            } 
            else if ((BasePointTypeToNavigate == BasePointType.Base_2) &&
                     (bLocs[BaseIDs.Base_2].IsInitialized))
            {
                BasePointLocationUpdate(bLocs[BaseIDs.Base_2].Value.Latitude, bLocs[BaseIDs.Base_2].Value.Longitude);
            }
            else if ((BasePointTypeToNavigate == BasePointType.Base_3) &&
                     (bLocs[BaseIDs.Base_3].IsInitialized))
            {
                BasePointLocationUpdate(bLocs[BaseIDs.Base_3].Value.Latitude, bLocs[BaseIDs.Base_3].Value.Longitude);
            }
            else if ((BasePointTypeToNavigate == BasePointType.Base_4) &&
                     (bLocs[BaseIDs.Base_4].IsInitialized))
            {
                BasePointLocationUpdate(bLocs[BaseIDs.Base_4].Value.Latitude, bLocs[BaseIDs.Base_4].Value.Longitude);
            }
            else if ((BasePointTypeToNavigate == BasePointType.AUX_GNSS) &&
                     (auxLat.IsInitialized && auxLon.IsInitialized))
            {
                BasePointLocationUpdate(auxLat.Value, auxLon.Value);
            }
        }

        private void BasePointLocationUpdate(double lat, double lon)
        {
            bpToNavigateLat = lat;
            bpToNavigateLon = lon;            
            UpdateRelativeParameters();
        }        

        private string GetNMEAOutputString()
        {
            StringBuilder sb = new StringBuilder();

            bool isValid = tLat.IsInitializedAndNotObsolete && tLon.IsInitializedAndNotObsolete;

            var latCls = isValid ? tLat.Value > 0 ? "N" : "S" : string.Empty;
            var lonCls = isValid ? tLon.Value > 0 ? "E" : "W" : string.Empty;
            var rmcValid = isValid ? "Valid" : "Invalid";

            sb.Append(
                NMEAParser.BuildSentence(
                    TalkerIdentifiers.GN,
                    SentenceIdentifiers.RMC,
                    new object[]
                    {
                        GetTimeStamp(),
                        rmcValid,
                        Math.Abs(tLat.Value), latCls,
                        Math.Abs(tLon.Value), lonCls,
                        null, // speed
                        tCrs.IsInitialized ? tCrs.Value : double.NaN, // track true
                        tFixTime,
                        null, // magnetic variation
                        null, // magnetic variation direction
                        "A",
                    }));

            sb.AppendLine();

            sb.Append(
                NMEAParser.BuildSentence(
                    TalkerIdentifiers.GN,
                    SentenceIdentifiers.GGA,
                    new object[]
                    {
                        tFixTime,
                        Math.Abs(tLat.Value), latCls,
                        Math.Abs(tLon.Value), lonCls,
                        "GPS fix",
                        4,
                        tRErr.Value,
                        -tDpt.Value,
                        "M",
                        null,
                        "M",
                        null,
                        null
                    }));

            sb.AppendLine();

            return sb.ToString();
        }

        private string GetCommonOutputString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("@WAYU,1,");

            if (auxLat.IsInitialized && auxLon.IsInitialized)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "{0:F06},{1:F01},{2:F01},",
                    auxLat.Value,
                    auxLon.Value,
                    auxLat.Age.TotalSeconds);
            }
            else
            {
                sb.Append(",,,");
            }

            foreach (BaseIDs bid in Enum.GetValues(typeof(BaseIDs)))
            {
                if (bid != BaseIDs.Invalid)
                {
                    if (bLocs[bid].IsInitialized && bBats[bid].IsInitialized)
                    {
                        sb.AppendFormat(CultureInfo.InvariantCulture,
                            "{0:F06},{1:F06},{2},{3:F01},",
                            bLocs[bid].Value.Latitude,
                            bLocs[bid].Value.Longitude,
                            (int)bBats[bid].Value,
                            bLocs[bid].Age.TotalSeconds);
                    }
                    else
                    {
                        sb.Append(",,,");
                    }
                }
            }

            if (tLat.IsInitialized && tLon.IsInitialized && tDpt.IsInitialized && tRErr.IsInitialized)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture,
                        "{0:F06},{1:F06},{2:F01},{3:F01},{4:F01},",
                        tLat.Value,
                        tLon.Value,
                        tDpt.Value,
                        tRErr.Value,
                        tLat.Age.TotalSeconds);
            }
            else
            {
                sb.Append(",,,,,");
            }

            if (tCrs.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "{0:F01},", tCrs.Value);
            else
                sb.Append(",");

            if (dstFromBP2Target.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "{0:F01},", dstFromBP2Target.Value);
            else
                sb.Append(",");

            if (crsFromBP2Target.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "{0:F01},", crsFromBP2Target.Value);
            else
                sb.Append(",");

            if (crsFromTarget2BP.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "{0:F01},{1:F01},",
                    crsFromTarget2BP.Value,
                    crsFromTarget2BP.Age.TotalSeconds);
            else
                sb.Append(",,");

            if (HDOPState.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "{0},",
                    HDOPState.Value);
            else
                sb.Append(",");

            if (TBAState.IsInitialized)
                sb.AppendFormat(CultureInfo.InvariantCulture,
                    "{0},{1:F01}",
                    TBAState.Value,
                    TBAState.Age.TotalSeconds);
            else
                sb.Append(",");

            sb.Append("\r\n");            

            return sb.ToString();
        }

        private void ProcessOutput()
        {
            if (SerialOutputActive || (UDPOutputEnabled && IsUDPNMEA))
            {
                var nmeaString = GetNMEAOutputString();

                if (SerialOutputActive)
                {
                    try
                    {
                        serialOutputPort.SendData(nmeaString.ToString());
                        LogEvent.Rise(this,
                            new LogEventArgs(LogLineType.INFO,
                            string.Format("{0} (SOUT) << {1}",
                            serialOutputPort.PortName,
                            nmeaString)));
                    }
                    catch (Exception ex)
                    {
                        LogEvent.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                    }
                }

                if (UDPOutputEnabled && IsUDPNMEA)
                {
                    try
                    {
                        udpOutput.Send(nmeaString);
                        LogEvent.Rise(this,
                            new LogEventArgs(LogLineType.INFO,
                            string.Format("{0}:{1} (UOUT) << {2}",
                            udpOutput.Address,
                            udpOutput.Port,
                            nmeaString)));
                    }
                    catch (Exception ex)
                    {
                        LogEvent.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                    }
                }
            }
            else if (UDPOutputEnabled && !IsUDPNMEA)
            {
                var cSring = GetCommonOutputString();

                try
                {
                    udpOutput.Send(cSring);
                    LogEvent.Rise(this,
                        new LogEventArgs(LogLineType.INFO,
                        string.Format("{0}:{1} (UOUT) << {2}",
                        udpOutput.Address,
                        udpOutput.Port,
                        cSring)));
                }
                catch (Exception ex)
                {
                    LogEvent.Rise(this, new LogEventArgs(LogLineType.ERROR, ex));
                }
            }
        }

        #endregion

        #endregion

        #region Handlers


        #endregion

        #region Events

        public EventHandler<LogEventArgs> LogEvent;
        public EventHandler StateUpdated;

        public EventHandler APLPortDetectedChanged;
        public EventHandler APLPortActiveChanged;

        public EventHandler AuxGNSSPortDetectedChanged;
        public EventHandler AuxGNSSPortActiveChanged;
        public EventHandler HeadingUpdated;

        public EventHandler StatHelperActiveChanged;

        public EventHandler<TrackPointEventArgs> TrackPointReceived;

        #endregion
    }
}
