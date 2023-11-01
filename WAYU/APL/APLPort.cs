using System;
using UCNLDrivers;
using UCNLNav;
using UCNLNMEA;

namespace WAYU.APL
{
    #region Custom EventArgs

    public class BaseUpdateEventArgs : EventArgs
    {
        #region Properties

        public BaseIDs BaseID { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public double Depth { get; private set; }
        public BatState BaseBatState { get; private set; }
        public double TOAs { get; private set; }

        #endregion

        #region Constructor

        public BaseUpdateEventArgs(BaseIDs bID, double bLat, double bLon, double bDpt, BatState bState, double bTOAs)
        {
            BaseID = bID;
            Latitude = bLat;
            Longitude = bLon;
            Depth = bDpt;
            BaseBatState = bState;
            TOAs = bTOAs;
        }

        #endregion
    }

    #endregion

    public class APLPort : uSerialPort
    {
        #region Properties

        static bool nmeaSingleton = false;

        #endregion

        #region Constructor

        public APLPort(BaudRate baudRate) 
            : base(baudRate)
        {
            base.PortDescription = "WAYU_GIBs";
            base.IsLogIncoming = true;
            base.IsTryAlways = true;

            if (!nmeaSingleton)
            {
                NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.APL);
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.APL, "A", "x,x.x,x.x,x.x,x,x.x");
                NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.APL, "L", "x");
                nmeaSingleton = true;
            }
        }

        #endregion

        #region Methods

        public bool JustParseAPLA(string s, out BaseIDs bID, out double bLat, out double bLon, out double bDpt, out double bBat, out double bTOA)
        {
            bool result = false;

            bID = BaseIDs.Invalid;
            bLat = double.NaN;
            bLon = double.NaN;
            bDpt = double.NaN;
            bBat = double.NaN;
            bTOA = double.NaN;

            try
            {
                var nres = NMEAParser.Parse(s);
                if (nres is NMEAProprietarySentence)
                {
                    var pres = (NMEAProprietarySentence)(nres);
                    if ((pres.Manufacturer == ManufacturerCodes.APL) &&
                        (pres.SentenceIDString == "A"))
                    {
                        bID = APL.O2BaseID(pres.parameters[0]);
                        bLat = APL.O2D(pres.parameters[1]);
                        bLon = APL.O2D(pres.parameters[2]);
                        bDpt = APL.O2D(pres.parameters[3]);
                        bBat = APL.O2D(pres.parameters[4]);
                        bTOA = APL.O2D(pres.parameters[5]);
                        result = true;
                    }

                }

            }
            catch
            {

            }

            return result;
        }


        private void OnAPLA(object[] parameters)
        {
            // Incoming APLA sentence received
            // $PAPLA,bID,bLat,bLon,bDpt,bBat,bTOA

            BaseIDs baseID = APL.O2BaseID(parameters[0]);
            double bLat = APL.O2D(parameters[1]);
            double bLon = APL.O2D(parameters[2]);
            double bDpt = APL.O2D(parameters[3]);
            BatState bBat = APL.O2BatState(parameters[4]);
            double bTOA = APL.O2D(parameters[5]);

            BaseUpdateReceived.Rise(this, new BaseUpdateEventArgs(baseID, bLat, bLon, bDpt, bBat, bTOA));
        }


        public override void InitQuerySend()
        {
            var msg = NMEAParser.BuildProprietarySentence(ManufacturerCodes.APL, "L", new object[] { 0 });
            Send(msg);
        }

        public override void OnClosed()
        {
            StopTimer();
        }

        public override void ProcessIncoming(NMEASentence sentence)
        {
            if (sentence is NMEAStandartSentence)
                ForceTimer(); // It is not the right port
            else
            {
                var pSentence = (sentence as NMEAProprietarySentence);
                if (pSentence.Manufacturer == ManufacturerCodes.APL)
                {
                    if (!detected)
                        detected = true;

                    StopTimer();

                    if (pSentence.SentenceIDString == "A")                    
                        OnAPLA(pSentence.parameters);                    

                    StartTimer(APL.MaxBuoysTimout_ms);
                }
                else
                {
                    detected = false;
                }
            }
        }

        #endregion

        #region Events

        public EventHandler<BaseUpdateEventArgs> BaseUpdateReceived;

        #endregion
    }
}
