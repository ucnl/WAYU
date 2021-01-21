using System;
using UCNLDrivers;

namespace WAYU
{
    public enum AUX_IDs
    {
        AUX1,
        AUX2,
        NONE,
    }

    [Serializable]
    public class SettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public string InPortName;
        public BaudRate InPortBaudrate;

        public bool IsUseAUX1;
        public string AUX1PortName;
        public BaudRate AUX1PortBaudrate;

        public bool IsUseAUX2;
        public string AUX2PortName;
        public BaudRate AUX2PortBaudrate;

        public AUX_IDs PrimaryGNSSAUXID;

        public bool IsUseOutputPort;
        public string OutputPortName;
        public BaudRate OutputPortBaudrate;

        public bool IsAutoSoundSpeed;        
        public double WaterTemperatureC;
        public double SalinityPSU;
        public double SoundSpeedMps;
       
        public double RadialErrorThresholdM;
        public double InitialSimplexSizeM;

        public int CourseEstimatorFIFOSize;
        public int TrackFilterFIFOSize;

        public int TrackPointsToShow;

        public bool IsEmuEnabled;

        #endregion

        #region Methods

        public override void SetDefaults()
        {
            InPortName = "COM1";
            InPortBaudrate = BaudRate.baudRate9600;

            IsUseAUX1 = false;
            AUX1PortName = "COM1";
            AUX1PortBaudrate = BaudRate.baudRate9600;

            IsUseAUX2 = false;
            AUX2PortName = "COM1";
            AUX2PortBaudrate = BaudRate.baudRate9600;

            PrimaryGNSSAUXID = AUX_IDs.NONE;

            IsUseOutputPort = false;
            OutputPortName = "COM1";
            OutputPortBaudrate = BaudRate.baudRate9600;

            IsAutoSoundSpeed = true;
            WaterTemperatureC = 17;
            SalinityPSU = 0.0;
            SoundSpeedMps = 1450;

            RadialErrorThresholdM = 10;
            InitialSimplexSizeM = 1.0;            

            TrackPointsToShow = 64;

            CourseEstimatorFIFOSize = 8;
            TrackFilterFIFOSize = 4;

            IsEmuEnabled = false;
        }

        #endregion
    }
}
