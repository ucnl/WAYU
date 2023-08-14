using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLUI;
using UCNLUI.Dialogs;

namespace WAYU.ExtraUI
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        #region CONNECTION tab

        BaudRate inPortBaudrate
        {
            get => (BaudRate)Enum.Parse(typeof(BaudRate), inPortBaudrateCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(inPortBaudrateCbx, value.ToString());
        }

        BaudRate serialAUXGNSSPortBaudrate
        {
            get => (BaudRate)Enum.Parse(typeof(BaudRate), serialAUXGNSSPortBaudrateCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(serialAUXGNSSPortBaudrateCbx, value.ToString());
        }

        bool serialAUXGNSSEnabled
        {
            get => serialAUXGNSSEnabledChb.Checked;
            set => serialAUXGNSSEnabledChb.Checked = value;
        }

        BaudRate serialOutputPortBaudrate
        {
            get => (BaudRate)Enum.Parse(typeof(BaudRate), serialOutputPortBaudrateCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(serialOutputPortBaudrateCbx, value.ToString());
        }

        string udpOutputIPAddress
        {
            get => udpOutputIPAddressEdit.Text;
            set => udpOutputIPAddressEdit.Text = value;
        }

        int udpOutputPort
        {
            get => Convert.ToInt32(udpOutputPortEdit.Value);
            set => UIHelpers.SetNumericEditValue(udpOutputPortEdit, value);
        }

        bool udpOutputEnabled
        {
            get => udpOutputEnabledChb.Checked;
            set => udpOutputEnabledChb.Checked = value;
        }

        bool udpOutputNMEA
        {
            get => udpOutputNMEAChb.Checked;
            set => udpOutputNMEAChb.Checked = value;
        }


        #endregion

        #region PHYSICS tab

        double salinity_PSU
        {
            get => Convert.ToDouble(salinityEdit.Value);
            set => UIHelpers.SetNumericEditValue(salinityEdit, value);
        }

        bool salinityAuto
        {
            get => salinityAutoChb.Checked;
            set => salinityAutoChb.Checked = value;
        }

        double waterTemperature
        {
            get => Convert.ToDouble(waterTemperatureEdit.Value);
            set => UIHelpers.SetNumericEditValue(waterTemperatureEdit, value);
        }

        double speedOfSound
        {
            get => Convert.ToDouble(speedOfSoundEdit.Value);
            set => UIHelpers.SetNumericEditValue(speedOfSoundEdit, value);
        }

        bool speedOfSoundAuto
        {
            get => speedOfSoundAutoChb.Checked;
            set => speedOfSoundAutoChb.Checked = value;
        }

        double rerrThrehsold
        {
            get => Convert.ToDouble(rerrThrehsoldEdit.Value);
            set => UIHelpers.SetNumericEditValue(rerrThrehsoldEdit, value);
        }

        int crsEstimatorFIFOSize
        {
            get => Convert.ToInt32(crsEstimatorFIFOSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(crsEstimatorFIFOSizeEdit, value);
        }

        int sfilterFIFOSize
        {
            get => Convert.ToInt32(sfilterFIFOSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(sfilterFIFOSizeEdit, value);
        }

        double sfilterRangeThreshold
        {
            get => Convert.ToDouble(sfilterRangeThresholdEdit.Value);
            set => UIHelpers.SetNumericEditValue(sfilterRangeThresholdEdit, value);
        }

        int dhfilterFIFOSize
        {
            get => Convert.ToInt32(dhfilterFIFOSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(dhfilterFIFOSizeEdit, value);
        }

        double dhfilterRangeThreshold
        {
            get => Convert.ToDouble(dhfilterRangeThresholdEdit.Value);
            set => UIHelpers.SetNumericEditValue(dhfilterRangeThresholdEdit, value);
        }

        double dhfilterMaxSpeed
        {
            get => Convert.ToDouble(dhfilterMaxSpeedEdit.Value);
            set => UIHelpers.SetNumericEditValue(dhfilterMaxSpeedEdit, value);
        }

        bool isEmuEnabled = false;

        #endregion

        #region EXTRA tab

        int numberOfTrackPoints
        {
            get => Convert.ToInt32(numberOfTrackPointsEdit.Value);
            set => UIHelpers.SetNumericEditValue(numberOfTrackPointsEdit, value);
        }        

        int tileSize
        {
            get => Convert.ToInt32(tileSizeEdit.Value);
            set => UIHelpers.SetNumericEditValue(tileSizeEdit, value);
        }

        string[] tileServers
        {
            get => tileServersEdit.Lines;
            set => tileServersEdit.Lines = value;
        }

        bool enableTilesDownloading
        {
            get => tilesDownloadingEnabledChb.Checked;
            set => tilesDownloadingEnabledChb.Checked = value;
        }

        #endregion

        #endregion

        #region Main

        public SettingsContainer Value
        {
            get
            {
                SettingsContainer result = new SettingsContainer();

                result.InPortBaudrate = inPortBaudrate;
                result.IsUseAUXGNSS = serialAUXGNSSEnabled;
                result.AUXGNSSBaudrate = serialAUXGNSSPortBaudrate;
                result.SerialOutputBaudrate = serialOutputPortBaudrate;

                result.IsUseUDPOutput = udpOutputEnabled;
                result.OutputUDPIPAddress = udpOutputIPAddress;
                result.OutputUDPPort = udpOutputPort;
                result.IsUDPOutputNMEA = udpOutputNMEA;

                result.IsAutoSalinity = salinityAuto;
                result.Salinity_PSU = salinity_PSU;
                result.IsAutoSoundSpeed = speedOfSoundAuto;
                result.SoundSpeed_mps = speedOfSound;
                result.WaterTemperature_C = waterTemperature;

                result.RadialErrorThreshold_m = rerrThrehsold;
                result.CourseEstimatorFIFOSize = crsEstimatorFIFOSize;
                result.TrackSmootherFIFOSize = sfilterFIFOSize;
                result.TrackSmootherRangeThreshold_m = sfilterRangeThreshold;
                result.DHFilterFIFOSize = dhfilterFIFOSize;
                result.DHFilterRangeThreshold_m = dhfilterRangeThreshold;
                result.DHFilterMaxSpeed_mps = dhfilterMaxSpeed;

                result.TrackPointsToShow = numberOfTrackPoints;
                result.TileSizePx = tileSize;

                result.IsEmuEnabled = isEmuEnabled;
                result.TileServers = tileServers;
                result.EnableTilesDownloading = enableTilesDownloading;

                return result;
            }
            set
            {
                inPortBaudrate = value.InPortBaudrate;
                serialAUXGNSSEnabled = value.IsUseAUXGNSS;
                serialAUXGNSSPortBaudrate = value.AUXGNSSBaudrate;
                serialOutputPortBaudrate = value.SerialOutputBaudrate;

                udpOutputEnabled = value.IsUseUDPOutput;
                udpOutputIPAddress = value.OutputUDPIPAddress;
                udpOutputPort = value.OutputUDPPort;
                udpOutputNMEA = value.IsUDPOutputNMEA;

                salinityAuto = value.IsAutoSalinity;
                salinity_PSU = value.Salinity_PSU;
                speedOfSoundAuto = value.IsAutoSoundSpeed;
                speedOfSound = value.SoundSpeed_mps;
                waterTemperature = value.WaterTemperature_C;

                rerrThrehsold = value.RadialErrorThreshold_m;
                crsEstimatorFIFOSize = value.CourseEstimatorFIFOSize;
                sfilterFIFOSize = value.TrackSmootherFIFOSize;
                sfilterRangeThreshold = value.TrackSmootherRangeThreshold_m;
                dhfilterFIFOSize = value.DHFilterFIFOSize;
                dhfilterRangeThreshold = value.DHFilterRangeThreshold_m;
                dhfilterMaxSpeed = value.DHFilterMaxSpeed_mps;

                numberOfTrackPoints = value.TrackPointsToShow;
                tileSize = value.TileSizePx;

                isEmuEnabled = value.IsEmuEnabled;
                tileServers = value.TileServers;
                enableTilesDownloading = value.EnableTilesDownloading;
            }
        }

        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            var baudrates = Enum.GetNames(typeof(BaudRate));

            inPortBaudrateCbx.DataSource = baudrates;
            serialAUXGNSSPortBaudrateCbx.DataSource = baudrates;
            serialOutputPortBaudrateCbx.DataSource = baudrates;

            udpOutputIPAddressEdit.TextChanged += (o, e) => CheckValidity();
            speedOfSoundAutoChb.CheckedChanged += (o, e) => speedOfSoundEdit.Enabled = !speedOfSoundAuto;
        }

        #endregion

        #region Methods

        public bool IsValidIP(string addr)
        {
            string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
            Regex check = new Regex(pattern);
            bool valid = false;
            if (addr == "")
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(addr, 0);
            }
            return valid;
        }


        private void CheckValidity()
        {
            okBtn.Enabled = !udpOutputEnabled || IsValidIP(udpOutputIPAddress);
        }

        #endregion

        #region Handlers

        private void setDefaultSettingsBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will reset settings to defaults, OK?",
                "Question",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Value = new SettingsContainer();
            }
        }

        private void salinityAutoChb_CheckedChanged(object sender, EventArgs e)
        {
            salinityEdit.Enabled = !salinityAuto;
            salinitySearchBtn.Enabled = !salinityAuto;
        }

        private void speedOfSoundAutoChb_CheckedChanged(object sender, EventArgs e)
        {
            speedOfSoundEdit.Enabled = speedOfSoundAuto;
        }

        private void udpOutputEnabledChb_CheckedChanged(object sender, EventArgs e)
        {
            udpOutputLbl.Enabled = udpOutputEnabled;
            udpOutputIPAddressEdit.Enabled = udpOutputEnabled;
            udpOutputPortEdit.Enabled = udpOutputEnabled;
            udpOutputNMEAChb.Enabled = udpOutputEnabled;
        }
        
        private void serialAUXGNSSEnabledChb_CheckedChanged(object sender, EventArgs e)
        {
            serialAUXGNSSLbl.Enabled = serialAUXGNSSEnabled;
            serialAUXGNSSPortBaudrateCbx.Enabled = serialAUXGNSSEnabled;
        }

        private void salinitySearchBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SalinityDialog sDialog = new SalinityDialog())
            {
                sDialog.Text = string.Format("{0} - ", Application.ProductName);

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    salinity_PSU = sDialog.Salinity;
                }
            }
        }

        private void SettingsEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Tab)
                {
                    mainTabControl.SelectedIndex = (mainTabControl.SelectedIndex + 1) % mainTabControl.TabCount;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.D)
                {
                    setDefaultSettingsBtn_Click(setDefaultSettingsBtn, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                }
            }
        }

        #endregion        
    }
}
