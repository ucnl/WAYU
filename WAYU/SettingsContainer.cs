using System;
using UCNLDrivers;

namespace WAYU
{
    [Serializable]
    public class SettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public BaudRate InPortBaudrate;
        public bool IsUseAUXGNSS;
        public BaudRate AUXGNSSBaudrate;
        public BaudRate SerialOutputBaudrate;

        public bool IsUseUDPOutput;
        public string OutputUDPIPAddress;
        public int OutputUDPPort;
        public bool IsUDPOutputNMEA;

        public bool IsAutoSalinity;
        public double Salinity_PSU;
        public bool IsAutoSoundSpeed;
        public double SoundSpeed_mps;
        public double WaterTemperature_C;

        public double RadialErrorThreshold_m;
        public int CourseEstimatorFIFOSize;
        public int TrackSmootherFIFOSize;
        public double TrackSmootherRangeThreshold_m;
        public int DHFilterFIFOSize;
        public double DHFilterRangeThreshold_m;
        public double DHFilterMaxSpeed_mps;

        public int TrackPointsToShow;
        public int TileSizePx;

        public bool IsEmuEnabled;
        public string[] TileServers;

        public bool EnableTilesDownloading;

        #endregion

        #region Methods

        public override void SetDefaults()
        {
            InPortBaudrate = BaudRate.baudRate9600;

            IsUseAUXGNSS = false;
            AUXGNSSBaudrate = BaudRate.baudRate9600;

            IsAutoSalinity = true;
            Salinity_PSU = UCNLPhysics.PHX.PHX_FWTR_SALINITY_PSU;
            IsAutoSoundSpeed = true;
            SoundSpeed_mps = UCNLPhysics.PHX.PHX_FWTR_SOUND_SPEED_MPS;
            WaterTemperature_C = 17;

            SerialOutputBaudrate = BaudRate.baudRate9600;

            IsUseUDPOutput = false;
            OutputUDPIPAddress = "255.255.255.255";
            OutputUDPPort = 28128;
            IsUDPOutputNMEA = true;

            TrackPointsToShow = 256;
            RadialErrorThreshold_m = 10;

            CourseEstimatorFIFOSize = 8;
            TrackSmootherFIFOSize = 4;
            TrackSmootherRangeThreshold_m = 100;
            DHFilterFIFOSize = 8;
            DHFilterRangeThreshold_m = 10;
            DHFilterMaxSpeed_mps = 1;

            IsEmuEnabled = true;
            TileSizePx = 256;
            TileServers = new string[]
            {
                "https://a.tile.openstreetmap.org",
                "https://b.tile.openstreetmap.org",
                "https://c.tile.openstreetmap.org"
            };

            EnableTilesDownloading = false;
        }

        #endregion
    }
}
