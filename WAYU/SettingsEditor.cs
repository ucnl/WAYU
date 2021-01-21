using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLPhysics;
using UCNLUI.Dialogs;

namespace WAYU
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        public SettingsContainer Value
        {
            get
            {
                SettingsContainer value = new SettingsContainer();

                value.InPortName = aplGIBPortName;
                value.InPortBaudrate = aplGIBPortBaudrate;

                value.IsUseAUX1 = isUseAUX1;
                value.AUX1PortName = AUX1PortName;
                value.AUX1PortBaudrate = AUX1PortBaudrate;

                value.IsUseAUX2 = isUseAUX2;
                value.AUX2PortName = AUX2PortName;
                value.AUX2PortBaudrate = AUX2PortBaudrate;

                value.PrimaryGNSSAUXID = primaryGNSSSource;

                value.IsUseOutputPort = isUseOutputPort;
                value.OutputPortName = outputPortName;
                value.OutputPortBaudrate = outputPortBaudrate;

                value.IsAutoSoundSpeed = isAutoSoundSpeed;
                value.WaterTemperatureC = waterTemperatureC;
                value.SalinityPSU = waterSalinityPSU;
                value.SoundSpeedMps = soundSpeedMps;

                value.RadialErrorThresholdM = radialErrorThreshold;
                value.InitialSimplexSizeM = initialSimplexSize;
                value.TrackPointsToShow = trackPointsToShow;

                value.CourseEstimatorFIFOSize = courseEstimatorFifoSize;

                return value;
            }
            set
            {
                aplGIBPortName = value.InPortName;
                aplGIBPortBaudrate = value.InPortBaudrate;
                isUseAUX1 = value.IsUseAUX1;
                AUX1PortName = value.AUX1PortName;
                AUX1PortBaudrate = value.AUX1PortBaudrate;
                isUseAUX2 = value.IsUseAUX2;
                AUX2PortName = value.AUX2PortName;
                AUX2PortBaudrate = value.AUX2PortBaudrate;
                primaryGNSSSource = value.PrimaryGNSSAUXID;
                isUseOutputPort = value.IsUseOutputPort;
                outputPortName = value.OutputPortName;
                outputPortBaudrate = value.OutputPortBaudrate;
                isAutoSoundSpeed = value.IsAutoSoundSpeed;
                waterTemperatureC = value.WaterTemperatureC;
                waterSalinityPSU = value.SalinityPSU;
                soundSpeedMps = value.SoundSpeedMps;
                radialErrorThreshold = value.RadialErrorThresholdM;
                initialSimplexSize = value.InitialSimplexSizeM;
                trackPointsToShow = value.TrackPointsToShow;
                courseEstimatorFifoSize = value.CourseEstimatorFIFOSize;
            }
        }

        string aplGIBPortName
        {
            get { return UIUtils.TryGetCbxItem(aplGIBPortNameCbx); }
            set { UIUtils.TrySetCbxItem(aplGIBPortNameCbx, value); }
        }

        BaudRate aplGIBPortBaudrate
        {
            get { return (BaudRate)Enum.Parse(typeof(BaudRate), UIUtils.TryGetCbxItem(aplGIBPortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(aplGIBPortBaudrateCbx, value.ToString()); }
        }

        bool isUseAUX1
        {
            get { return isUseAUX1Chb.Checked; }
            set { isUseAUX1Chb.Checked = value; }
        }

        string AUX1PortName
        {
            get { return UIUtils.TryGetCbxItem(aux1PortNameCbx); }
            set { UIUtils.TrySetCbxItem(aux1PortNameCbx, value); }
        }

        BaudRate AUX1PortBaudrate
        {
            get { return (BaudRate)Enum.Parse(typeof(BaudRate), UIUtils.TryGetCbxItem(aux1PortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(aux1PortBaudrateCbx, value.ToString()); }
        }

        bool isUseAUX2
        {
            get { return isUseAUX2Chb.Checked; }
            set { isUseAUX2Chb.Checked = value; }
        }

        string AUX2PortName
        {
            get { return UIUtils.TryGetCbxItem(aux2PortNameCbx); }
            set { UIUtils.TrySetCbxItem(aux2PortNameCbx, value); }
        }

        BaudRate AUX2PortBaudrate
        {
            get { return (BaudRate)Enum.Parse(typeof(BaudRate), UIUtils.TryGetCbxItem(aux2PortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(aux2PortBaudrateCbx, value.ToString()); }
        }

        AUX_IDs primaryGNSSSource
        {
            get { return (AUX_IDs)Enum.Parse(typeof(AUX_IDs), UIUtils.TryGetCbxItem(pGNSSSourceCbx)); }
            set { UIUtils.TrySetCbxItem(pGNSSSourceCbx, value.ToString()); }
        }

        bool isUseOutputPort
        {
            get { return isUseOutputChb.Checked; }
            set { isUseOutputChb.Checked = value; }
        }

        string outputPortName
        {
            get { return UIUtils.TryGetCbxItem(outputPortNameCbx); }
            set { UIUtils.TrySetCbxItem(outputPortNameCbx, value); }
        }

        BaudRate outputPortBaudrate
        {
            get { return (BaudRate)Enum.Parse(typeof(BaudRate), UIUtils.TryGetCbxItem(outputPortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(outputPortBaudrateCbx, value.ToString()); }
        }


        bool isAutoSoundSpeed
        {
            get { return isAutoSoundSpeedChb.Checked; }
            set { isAutoSoundSpeedChb.Checked = value; }
        }

        double waterTemperatureC
        {
            get { return Convert.ToDouble(waterTemperatureEdit.Value); }
            set { UIUtils.TrySetNEditValue(waterTemperatureEdit, value); }
        }

        double waterSalinityPSU
        {
            get { return Convert.ToDouble(waterSalinityEdit.Value); }
            set { UIUtils.TrySetNEditValue(waterSalinityEdit, value); }
        }

        double soundSpeedMps
        {
            get { return Convert.ToDouble(soundSpeedEdit.Value); }
            set { UIUtils.TrySetNEditValue(soundSpeedEdit, value); }
        }

        double radialErrorThreshold
        {
            get { return Convert.ToDouble(radialErrorThresholdEdit.Value); }
            set { UIUtils.TrySetNEditValue(radialErrorThresholdEdit, value); }
        }

        double initialSimplexSize
        {
            get { return Convert.ToDouble(initialSimplexSizeEdit.Value); }
            set { UIUtils.TrySetNEditValue(initialSimplexSizeEdit, value); }
        }

        int trackPointsToShow
        {
            get { return Convert.ToInt32(trackPointsToShowEdit.Value); }
            set { UIUtils.TrySetNEditValue(trackPointsToShowEdit, value); }
        }

        int courseEstimatorFifoSize
        {
            get { return Convert.ToInt32(courseEstimatorFifoSizeEdit.Value); }
            set { UIUtils.TrySetNEditValue(courseEstimatorFifoSizeEdit, value); }
        }

        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            var portNames = SerialPort.GetPortNames();
            if (portNames.Length > 0)
            {
                aplGIBPortNameCbx.Items.AddRange(portNames);
                aux1PortNameCbx.Items.AddRange(portNames);
                aux2PortNameCbx.Items.AddRange(portNames);
                outputPortNameCbx.Items.AddRange(portNames);

                aplGIBPortNameCbx.SelectedIndex = 0;
                aux1PortNameCbx.SelectedIndex = 0;
                aux2PortNameCbx.SelectedIndex = 0;
                outputPortNameCbx.SelectedIndex = 0;
            }

            var baudrates = Enum.GetNames(typeof(BaudRate));
            aplGIBPortBaudrateCbx.Items.AddRange(baudrates);
            aux1PortBaudrateCbx.Items.AddRange(baudrates);
            aux2PortBaudrateCbx.Items.AddRange(baudrates);
            outputPortBaudrateCbx.Items.AddRange(baudrates);

            aplGIBPortBaudrate = BaudRate.baudRate9600;
            AUX1PortBaudrate = BaudRate.baudRate9600;
            AUX2PortBaudrate = BaudRate.baudRate9600;
            outputPortBaudrate = BaudRate.baudRate9600;

            aplGIBPortNameCbx.SelectedIndexChanged += (o, e) => CheckUIValidity();
            aux1PortNameCbx.SelectedIndexChanged += (o, e) => CheckUIValidity();
            aux2PortNameCbx.SelectedIndexChanged += (o, e) => CheckUIValidity();
            outputPortNameCbx.SelectedIndexChanged += (o, e) => CheckUIValidity();

            onAuxUsedChanged();

        }

        #endregion

        #region Handlers

        private void isUseAUX1Chb_CheckedChanged(object sender, EventArgs e)
        {
            aux1Group.Enabled = isUseAUX1Chb.Checked;
            onAuxUsedChanged();
            CheckUIValidity();
        }

        private void isUseAUX2Chb_CheckedChanged(object sender, EventArgs e)
        {
            aux2Group.Enabled = isUseAUX2Chb.Checked;
            onAuxUsedChanged();
            CheckUIValidity();
        }

        private void isUseOutputChb_CheckedChanged(object sender, EventArgs e)
        {
            outputGroup.Enabled = isUseOutputChb.Checked;
            CheckUIValidity();
        }

        private void isAutoSoundSpeedChb_CheckedChanged(object sender, EventArgs e)
        {
            soundSpeedEdit.Enabled = !isAutoSoundSpeedChb.Checked;
            waterTemperatureEdit.Enabled = isAutoSoundSpeedChb.Checked;
            waterSalinityEdit.Enabled = isAutoSoundSpeedChb.Checked;
            styBaseBtn.Enabled = isAutoSoundSpeedChb.Checked;
        }

        private void waterTemperatureEdit_ValueChanged(object sender, EventArgs e)
        {
            soundSpeedMps = PHX.Speed_of_sound_UNESCO_calc(waterTemperatureC, PHX.PHX_ATM_PRESSURE_MBAR, waterSalinityPSU);
        }

        private void waterSalinityEdit_ValueChanged(object sender, EventArgs e)
        {
            soundSpeedMps = PHX.Speed_of_sound_UNESCO_calc(waterTemperatureC, PHX.PHX_ATM_PRESSURE_MBAR, waterSalinityPSU);
        }

        private void styBaseBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SalinityDialog sDialog = new SalinityDialog())
            {
                sDialog.Title = "World salinity database";

                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    waterSalinityPSU = sDialog.Salinity;
                }
            }
        }

        #endregion

        #region Methods

        private void CheckUIValidity()
        {
            bool result = false;

            result = (!string.IsNullOrEmpty(aplGIBPortName)) &&
                     (!isUseOutputPort || !string.IsNullOrEmpty(outputPortName)) &&
                     (!isUseAUX1 || !string.IsNullOrEmpty(AUX1PortName)) &&
                     (!isUseAUX2 || !string.IsNullOrEmpty(AUX2PortName)) &&                   
                     (!isUseOutputPort || !string.IsNullOrEmpty(outputPortName));

            if (result)
            {
                List<string> ports = new List<string>();
                ports.Add(aplGIBPortName);

                if (isUseOutputPort)
                {
                    if (ports.Contains(outputPortName))
                        result = false;
                    else
                        ports.Add(outputPortName);
                }

                if (result)
                {
                    if (isUseAUX1)
                    {
                        if (ports.Contains(AUX1PortName))
                            result = false;
                        else
                            ports.Add(AUX1PortName);
                    }

                    if (result)
                    {
                        if (isUseAUX2)
                        {
                            if (ports.Contains(AUX2PortName))
                                result = false;
                            else
                                ports.Add(AUX2PortName);
                        }                        
                    }
                }
            }

            okBtn.Enabled = result;
        }

        private void onAuxUsedChanged()
        {
            List<string> pgnssItems = new List<string>();
            if (isUseAUX1)
                pgnssItems.Add(AUX_IDs.AUX1.ToString());

            if (isUseAUX2)
                pgnssItems.Add(AUX_IDs.AUX2.ToString());

            pgnssItems.Add(AUX_IDs.NONE.ToString());
            pGNSSSourceCbx.Items.Clear();
            pGNSSSourceCbx.Items.AddRange(pgnssItems.ToArray());

            primaryGNSSSource = AUX_IDs.NONE;
        }

        #endregion               
    }
}
