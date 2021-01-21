namespace WAYU
{
    partial class SettingsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.connectionTab = new System.Windows.Forms.TabPage();
            this.isUseOutputChb = new System.Windows.Forms.CheckBox();
            this.pgnssGroup = new System.Windows.Forms.GroupBox();
            this.pGNSSSourceCbx = new System.Windows.Forms.ComboBox();
            this.outputGroup = new System.Windows.Forms.GroupBox();
            this.outputPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.outputPortNameCbx = new System.Windows.Forms.ComboBox();
            this.isUseAUX2Chb = new System.Windows.Forms.CheckBox();
            this.aux2Group = new System.Windows.Forms.GroupBox();
            this.aux2PortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.aux2PortNameCbx = new System.Windows.Forms.ComboBox();
            this.isUseAUX1Chb = new System.Windows.Forms.CheckBox();
            this.aux1Group = new System.Windows.Forms.GroupBox();
            this.aux1PortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.aux1PortNameCbx = new System.Windows.Forms.ComboBox();
            this.aplGIBGoup = new System.Windows.Forms.GroupBox();
            this.aplGIBPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.aplGIBPortNameCbx = new System.Windows.Forms.ComboBox();
            this.commonTab = new System.Windows.Forms.TabPage();
            this.trackPointsToShowEdit = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.initialSimplexSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.radialErrorThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.styBaseBtn = new System.Windows.Forms.LinkLabel();
            this.soundSpeedEdit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.waterSalinityEdit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.waterTemperatureEdit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.isAutoSoundSpeedChb = new System.Windows.Forms.CheckBox();
            this.courseEstimatorFifoSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.mainTabControl.SuspendLayout();
            this.connectionTab.SuspendLayout();
            this.pgnssGroup.SuspendLayout();
            this.outputGroup.SuspendLayout();
            this.aux2Group.SuspendLayout();
            this.aux1Group.SuspendLayout();
            this.aplGIBGoup.SuspendLayout();
            this.commonTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackPointsToShowEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialSimplexSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialErrorThresholdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterSalinityEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterTemperatureEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseEstimatorFifoSizeEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.Location = new System.Drawing.Point(349, 635);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(119, 39);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okBtn.Location = new System.Drawing.Point(191, 635);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(119, 39);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.connectionTab);
            this.mainTabControl.Controls.Add(this.commonTab);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(456, 592);
            this.mainTabControl.TabIndex = 2;
            // 
            // connectionTab
            // 
            this.connectionTab.Controls.Add(this.isUseOutputChb);
            this.connectionTab.Controls.Add(this.pgnssGroup);
            this.connectionTab.Controls.Add(this.outputGroup);
            this.connectionTab.Controls.Add(this.isUseAUX2Chb);
            this.connectionTab.Controls.Add(this.aux2Group);
            this.connectionTab.Controls.Add(this.isUseAUX1Chb);
            this.connectionTab.Controls.Add(this.aux1Group);
            this.connectionTab.Controls.Add(this.aplGIBGoup);
            this.connectionTab.Location = new System.Drawing.Point(4, 32);
            this.connectionTab.Name = "connectionTab";
            this.connectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.connectionTab.Size = new System.Drawing.Size(448, 556);
            this.connectionTab.TabIndex = 0;
            this.connectionTab.Text = "CONNECTION";
            this.connectionTab.UseVisualStyleBackColor = true;
            // 
            // isUseOutputChb
            // 
            this.isUseOutputChb.AutoSize = true;
            this.isUseOutputChb.Location = new System.Drawing.Point(6, 395);
            this.isUseOutputChb.Name = "isUseOutputChb";
            this.isUseOutputChb.Size = new System.Drawing.Size(154, 27);
            this.isUseOutputChb.TabIndex = 5;
            this.isUseOutputChb.Text = "Use output port";
            this.isUseOutputChb.UseVisualStyleBackColor = true;
            this.isUseOutputChb.CheckedChanged += new System.EventHandler(this.isUseOutputChb_CheckedChanged);
            // 
            // pgnssGroup
            // 
            this.pgnssGroup.Controls.Add(this.pGNSSSourceCbx);
            this.pgnssGroup.Location = new System.Drawing.Point(6, 298);
            this.pgnssGroup.Name = "pgnssGroup";
            this.pgnssGroup.Size = new System.Drawing.Size(206, 77);
            this.pgnssGroup.TabIndex = 6;
            this.pgnssGroup.TabStop = false;
            this.pgnssGroup.Text = "Primary GNSS source";
            // 
            // pGNSSSourceCbx
            // 
            this.pGNSSSourceCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pGNSSSourceCbx.FormattingEnabled = true;
            this.pGNSSSourceCbx.Location = new System.Drawing.Point(6, 29);
            this.pGNSSSourceCbx.Name = "pGNSSSourceCbx";
            this.pGNSSSourceCbx.Size = new System.Drawing.Size(191, 31);
            this.pGNSSSourceCbx.TabIndex = 1;
            // 
            // outputGroup
            // 
            this.outputGroup.Controls.Add(this.outputPortBaudrateCbx);
            this.outputGroup.Controls.Add(this.outputPortNameCbx);
            this.outputGroup.Enabled = false;
            this.outputGroup.Location = new System.Drawing.Point(6, 428);
            this.outputGroup.Name = "outputGroup";
            this.outputGroup.Size = new System.Drawing.Size(206, 117);
            this.outputGroup.TabIndex = 4;
            this.outputGroup.TabStop = false;
            this.outputGroup.Text = "Output Port";
            // 
            // outputPortBaudrateCbx
            // 
            this.outputPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputPortBaudrateCbx.FormattingEnabled = true;
            this.outputPortBaudrateCbx.Location = new System.Drawing.Point(6, 66);
            this.outputPortBaudrateCbx.Name = "outputPortBaudrateCbx";
            this.outputPortBaudrateCbx.Size = new System.Drawing.Size(191, 31);
            this.outputPortBaudrateCbx.TabIndex = 1;
            // 
            // outputPortNameCbx
            // 
            this.outputPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputPortNameCbx.FormattingEnabled = true;
            this.outputPortNameCbx.Location = new System.Drawing.Point(6, 29);
            this.outputPortNameCbx.Name = "outputPortNameCbx";
            this.outputPortNameCbx.Size = new System.Drawing.Size(191, 31);
            this.outputPortNameCbx.TabIndex = 0;
            // 
            // isUseAUX2Chb
            // 
            this.isUseAUX2Chb.AutoSize = true;
            this.isUseAUX2Chb.Location = new System.Drawing.Point(226, 142);
            this.isUseAUX2Chb.Name = "isUseAUX2Chb";
            this.isUseAUX2Chb.Size = new System.Drawing.Size(107, 27);
            this.isUseAUX2Chb.TabIndex = 5;
            this.isUseAUX2Chb.Text = "Use AUX2";
            this.isUseAUX2Chb.UseVisualStyleBackColor = true;
            this.isUseAUX2Chb.CheckedChanged += new System.EventHandler(this.isUseAUX2Chb_CheckedChanged);
            // 
            // aux2Group
            // 
            this.aux2Group.Controls.Add(this.aux2PortBaudrateCbx);
            this.aux2Group.Controls.Add(this.aux2PortNameCbx);
            this.aux2Group.Enabled = false;
            this.aux2Group.Location = new System.Drawing.Point(226, 175);
            this.aux2Group.Name = "aux2Group";
            this.aux2Group.Size = new System.Drawing.Size(206, 117);
            this.aux2Group.TabIndex = 4;
            this.aux2Group.TabStop = false;
            this.aux2Group.Text = "AUX2 Port";
            // 
            // aux2PortBaudrateCbx
            // 
            this.aux2PortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux2PortBaudrateCbx.FormattingEnabled = true;
            this.aux2PortBaudrateCbx.Location = new System.Drawing.Point(6, 66);
            this.aux2PortBaudrateCbx.Name = "aux2PortBaudrateCbx";
            this.aux2PortBaudrateCbx.Size = new System.Drawing.Size(191, 31);
            this.aux2PortBaudrateCbx.TabIndex = 1;
            // 
            // aux2PortNameCbx
            // 
            this.aux2PortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux2PortNameCbx.FormattingEnabled = true;
            this.aux2PortNameCbx.Location = new System.Drawing.Point(6, 29);
            this.aux2PortNameCbx.Name = "aux2PortNameCbx";
            this.aux2PortNameCbx.Size = new System.Drawing.Size(191, 31);
            this.aux2PortNameCbx.TabIndex = 0;
            // 
            // isUseAUX1Chb
            // 
            this.isUseAUX1Chb.AutoSize = true;
            this.isUseAUX1Chb.Location = new System.Drawing.Point(6, 142);
            this.isUseAUX1Chb.Name = "isUseAUX1Chb";
            this.isUseAUX1Chb.Size = new System.Drawing.Size(107, 27);
            this.isUseAUX1Chb.TabIndex = 3;
            this.isUseAUX1Chb.Text = "Use AUX1";
            this.isUseAUX1Chb.UseVisualStyleBackColor = true;
            this.isUseAUX1Chb.CheckedChanged += new System.EventHandler(this.isUseAUX1Chb_CheckedChanged);
            // 
            // aux1Group
            // 
            this.aux1Group.Controls.Add(this.aux1PortBaudrateCbx);
            this.aux1Group.Controls.Add(this.aux1PortNameCbx);
            this.aux1Group.Enabled = false;
            this.aux1Group.Location = new System.Drawing.Point(6, 175);
            this.aux1Group.Name = "aux1Group";
            this.aux1Group.Size = new System.Drawing.Size(206, 117);
            this.aux1Group.TabIndex = 2;
            this.aux1Group.TabStop = false;
            this.aux1Group.Text = "AUX1 Port";
            // 
            // aux1PortBaudrateCbx
            // 
            this.aux1PortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux1PortBaudrateCbx.FormattingEnabled = true;
            this.aux1PortBaudrateCbx.Location = new System.Drawing.Point(6, 66);
            this.aux1PortBaudrateCbx.Name = "aux1PortBaudrateCbx";
            this.aux1PortBaudrateCbx.Size = new System.Drawing.Size(191, 31);
            this.aux1PortBaudrateCbx.TabIndex = 1;
            // 
            // aux1PortNameCbx
            // 
            this.aux1PortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux1PortNameCbx.FormattingEnabled = true;
            this.aux1PortNameCbx.Location = new System.Drawing.Point(6, 29);
            this.aux1PortNameCbx.Name = "aux1PortNameCbx";
            this.aux1PortNameCbx.Size = new System.Drawing.Size(191, 31);
            this.aux1PortNameCbx.TabIndex = 0;
            // 
            // aplGIBGoup
            // 
            this.aplGIBGoup.Controls.Add(this.aplGIBPortBaudrateCbx);
            this.aplGIBGoup.Controls.Add(this.aplGIBPortNameCbx);
            this.aplGIBGoup.Location = new System.Drawing.Point(6, 6);
            this.aplGIBGoup.Name = "aplGIBGoup";
            this.aplGIBGoup.Size = new System.Drawing.Size(206, 117);
            this.aplGIBGoup.TabIndex = 0;
            this.aplGIBGoup.TabStop = false;
            this.aplGIBGoup.Text = "APL GIBs Port";
            // 
            // aplGIBPortBaudrateCbx
            // 
            this.aplGIBPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aplGIBPortBaudrateCbx.FormattingEnabled = true;
            this.aplGIBPortBaudrateCbx.Location = new System.Drawing.Point(6, 66);
            this.aplGIBPortBaudrateCbx.Name = "aplGIBPortBaudrateCbx";
            this.aplGIBPortBaudrateCbx.Size = new System.Drawing.Size(191, 31);
            this.aplGIBPortBaudrateCbx.TabIndex = 1;
            // 
            // aplGIBPortNameCbx
            // 
            this.aplGIBPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aplGIBPortNameCbx.FormattingEnabled = true;
            this.aplGIBPortNameCbx.Location = new System.Drawing.Point(6, 29);
            this.aplGIBPortNameCbx.Name = "aplGIBPortNameCbx";
            this.aplGIBPortNameCbx.Size = new System.Drawing.Size(191, 31);
            this.aplGIBPortNameCbx.TabIndex = 0;
            // 
            // commonTab
            // 
            this.commonTab.Controls.Add(this.courseEstimatorFifoSizeEdit);
            this.commonTab.Controls.Add(this.label6);
            this.commonTab.Controls.Add(this.trackPointsToShowEdit);
            this.commonTab.Controls.Add(this.label7);
            this.commonTab.Controls.Add(this.initialSimplexSizeEdit);
            this.commonTab.Controls.Add(this.label5);
            this.commonTab.Controls.Add(this.radialErrorThresholdEdit);
            this.commonTab.Controls.Add(this.label4);
            this.commonTab.Controls.Add(this.styBaseBtn);
            this.commonTab.Controls.Add(this.soundSpeedEdit);
            this.commonTab.Controls.Add(this.label3);
            this.commonTab.Controls.Add(this.waterSalinityEdit);
            this.commonTab.Controls.Add(this.label2);
            this.commonTab.Controls.Add(this.waterTemperatureEdit);
            this.commonTab.Controls.Add(this.label1);
            this.commonTab.Controls.Add(this.isAutoSoundSpeedChb);
            this.commonTab.Location = new System.Drawing.Point(4, 32);
            this.commonTab.Name = "commonTab";
            this.commonTab.Padding = new System.Windows.Forms.Padding(3);
            this.commonTab.Size = new System.Drawing.Size(448, 556);
            this.commonTab.TabIndex = 1;
            this.commonTab.Text = "COMMON";
            this.commonTab.UseVisualStyleBackColor = true;
            // 
            // trackPointsToShowEdit
            // 
            this.trackPointsToShowEdit.Location = new System.Drawing.Point(287, 300);
            this.trackPointsToShowEdit.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.trackPointsToShowEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.trackPointsToShowEdit.Name = "trackPointsToShowEdit";
            this.trackPointsToShowEdit.Size = new System.Drawing.Size(107, 30);
            this.trackPointsToShowEdit.TabIndex = 15;
            this.trackPointsToShowEdit.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Track points to show";
            // 
            // initialSimplexSizeEdit
            // 
            this.initialSimplexSizeEdit.DecimalPlaces = 1;
            this.initialSimplexSizeEdit.Location = new System.Drawing.Point(287, 240);
            this.initialSimplexSizeEdit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.initialSimplexSizeEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.initialSimplexSizeEdit.Name = "initialSimplexSizeEdit";
            this.initialSimplexSizeEdit.Size = new System.Drawing.Size(107, 30);
            this.initialSimplexSizeEdit.TabIndex = 11;
            this.initialSimplexSizeEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Initial simplex size, m";
            // 
            // radialErrorThresholdEdit
            // 
            this.radialErrorThresholdEdit.DecimalPlaces = 1;
            this.radialErrorThresholdEdit.Location = new System.Drawing.Point(287, 204);
            this.radialErrorThresholdEdit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.radialErrorThresholdEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radialErrorThresholdEdit.Name = "radialErrorThresholdEdit";
            this.radialErrorThresholdEdit.Size = new System.Drawing.Size(107, 30);
            this.radialErrorThresholdEdit.TabIndex = 9;
            this.radialErrorThresholdEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Radial error threshold, m";
            // 
            // styBaseBtn
            // 
            this.styBaseBtn.AutoSize = true;
            this.styBaseBtn.Enabled = false;
            this.styBaseBtn.Location = new System.Drawing.Point(408, 95);
            this.styBaseBtn.Name = "styBaseBtn";
            this.styBaseBtn.Size = new System.Drawing.Size(34, 23);
            this.styBaseBtn.TabIndex = 7;
            this.styBaseBtn.TabStop = true;
            this.styBaseBtn.Text = ">>";
            this.styBaseBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.styBaseBtn_LinkClicked);
            // 
            // soundSpeedEdit
            // 
            this.soundSpeedEdit.DecimalPlaces = 1;
            this.soundSpeedEdit.Location = new System.Drawing.Point(287, 142);
            this.soundSpeedEdit.Maximum = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            this.soundSpeedEdit.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.soundSpeedEdit.Name = "soundSpeedEdit";
            this.soundSpeedEdit.Size = new System.Drawing.Size(107, 30);
            this.soundSpeedEdit.TabIndex = 6;
            this.soundSpeedEdit.Value = new decimal(new int[] {
            1450,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sound speed, m/s";
            // 
            // waterSalinityEdit
            // 
            this.waterSalinityEdit.DecimalPlaces = 1;
            this.waterSalinityEdit.Enabled = false;
            this.waterSalinityEdit.Location = new System.Drawing.Point(287, 93);
            this.waterSalinityEdit.Maximum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.waterSalinityEdit.Name = "waterSalinityEdit";
            this.waterSalinityEdit.Size = new System.Drawing.Size(107, 30);
            this.waterSalinityEdit.TabIndex = 4;
            this.waterSalinityEdit.ValueChanged += new System.EventHandler(this.waterSalinityEdit_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Water salinity, PSU";
            // 
            // waterTemperatureEdit
            // 
            this.waterTemperatureEdit.DecimalPlaces = 1;
            this.waterTemperatureEdit.Enabled = false;
            this.waterTemperatureEdit.Location = new System.Drawing.Point(287, 57);
            this.waterTemperatureEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.waterTemperatureEdit.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.waterTemperatureEdit.Name = "waterTemperatureEdit";
            this.waterTemperatureEdit.Size = new System.Drawing.Size(107, 30);
            this.waterTemperatureEdit.TabIndex = 2;
            this.waterTemperatureEdit.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.waterTemperatureEdit.ValueChanged += new System.EventHandler(this.waterTemperatureEdit_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Water temperature, °C";
            // 
            // isAutoSoundSpeedChb
            // 
            this.isAutoSoundSpeedChb.AutoSize = true;
            this.isAutoSoundSpeedChb.Location = new System.Drawing.Point(21, 18);
            this.isAutoSoundSpeedChb.Name = "isAutoSoundSpeedChb";
            this.isAutoSoundSpeedChb.Size = new System.Drawing.Size(171, 27);
            this.isAutoSoundSpeedChb.TabIndex = 0;
            this.isAutoSoundSpeedChb.Text = "Auto sound speed";
            this.isAutoSoundSpeedChb.UseVisualStyleBackColor = true;
            this.isAutoSoundSpeedChb.CheckedChanged += new System.EventHandler(this.isAutoSoundSpeedChb_CheckedChanged);
            // 
            // courseEstimatorFifoSizeEdit
            // 
            this.courseEstimatorFifoSizeEdit.Location = new System.Drawing.Point(287, 355);
            this.courseEstimatorFifoSizeEdit.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.courseEstimatorFifoSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.courseEstimatorFifoSizeEdit.Name = "courseEstimatorFifoSizeEdit";
            this.courseEstimatorFifoSizeEdit.Size = new System.Drawing.Size(107, 30);
            this.courseEstimatorFifoSizeEdit.TabIndex = 17;
            this.courseEstimatorFifoSizeEdit.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Course estimator FIFO size";
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 686);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsEditor";
            this.Text = "SettingsEditor";
            this.mainTabControl.ResumeLayout(false);
            this.connectionTab.ResumeLayout(false);
            this.connectionTab.PerformLayout();
            this.pgnssGroup.ResumeLayout(false);
            this.outputGroup.ResumeLayout(false);
            this.aux2Group.ResumeLayout(false);
            this.aux1Group.ResumeLayout(false);
            this.aplGIBGoup.ResumeLayout(false);
            this.commonTab.ResumeLayout(false);
            this.commonTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackPointsToShowEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialSimplexSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialErrorThresholdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterSalinityEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterTemperatureEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseEstimatorFifoSizeEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage connectionTab;
        private System.Windows.Forms.TabPage commonTab;
        private System.Windows.Forms.CheckBox isUseAUX1Chb;
        private System.Windows.Forms.GroupBox aux1Group;
        private System.Windows.Forms.ComboBox aux1PortBaudrateCbx;
        private System.Windows.Forms.ComboBox aux1PortNameCbx;
        private System.Windows.Forms.GroupBox aplGIBGoup;
        private System.Windows.Forms.ComboBox aplGIBPortBaudrateCbx;
        private System.Windows.Forms.ComboBox aplGIBPortNameCbx;
        private System.Windows.Forms.CheckBox isUseAUX2Chb;
        private System.Windows.Forms.GroupBox aux2Group;
        private System.Windows.Forms.ComboBox aux2PortBaudrateCbx;
        private System.Windows.Forms.ComboBox aux2PortNameCbx;
        private System.Windows.Forms.GroupBox pgnssGroup;
        private System.Windows.Forms.ComboBox pGNSSSourceCbx;
        private System.Windows.Forms.CheckBox isUseOutputChb;
        private System.Windows.Forms.GroupBox outputGroup;
        private System.Windows.Forms.ComboBox outputPortBaudrateCbx;
        private System.Windows.Forms.ComboBox outputPortNameCbx;
        private System.Windows.Forms.CheckBox isAutoSoundSpeedChb;
        private System.Windows.Forms.NumericUpDown waterTemperatureEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel styBaseBtn;
        private System.Windows.Forms.NumericUpDown soundSpeedEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown waterSalinityEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown radialErrorThresholdEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown initialSimplexSizeEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown trackPointsToShowEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown courseEstimatorFifoSizeEdit;
        private System.Windows.Forms.Label label6;
    }
}