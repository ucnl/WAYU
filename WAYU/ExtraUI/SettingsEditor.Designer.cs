namespace WAYU.ExtraUI
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
            this.setDefaultSettingsBtn = new System.Windows.Forms.Button();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.connectionsTab = new System.Windows.Forms.TabPage();
            this.connectionTbl = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.serialAUXGNSSLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serialOutputLbl = new System.Windows.Forms.Label();
            this.serialAUXGNSSEnabledChb = new System.Windows.Forms.CheckBox();
            this.udpOutputLbl = new System.Windows.Forms.Label();
            this.udpOutputIPAddressEdit = new System.Windows.Forms.MaskedTextBox();
            this.udpOutputPortEdit = new System.Windows.Forms.NumericUpDown();
            this.udpOutputEnabledChb = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.udpOutputNMEAChb = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.serialAUXGNSSPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.serialOutputPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.inPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.physicsTab = new System.Windows.Forms.TabPage();
            this.phxTbl = new System.Windows.Forms.TableLayoutPanel();
            this.waterTemperatureEdit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.salinityEdit = new System.Windows.Forms.NumericUpDown();
            this.salinityAutoChb = new System.Windows.Forms.CheckBox();
            this.salinitySearchBtn = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.speedOfSoundEdit = new System.Windows.Forms.NumericUpDown();
            this.speedOfSoundAutoChb = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.rerrThrehsoldEdit = new System.Windows.Forms.NumericUpDown();
            this.crsEstimatorFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.dhfilterFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.dhfilterRangeThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.dhfilterMaxSpeedEdit = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.sfilterFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.sfilterRangeThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.extraTab = new System.Windows.Forms.TabPage();
            this.miscTbl = new System.Windows.Forms.TableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tileServersEdit = new System.Windows.Forms.TextBox();
            this.tileSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.numberOfTrackPointsEdit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tilesDownloadingEnabledChb = new System.Windows.Forms.CheckBox();
            this.mainTabControl.SuspendLayout();
            this.connectionsTab.SuspendLayout();
            this.connectionTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udpOutputPortEdit)).BeginInit();
            this.physicsTab.SuspendLayout();
            this.phxTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterTemperatureEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSoundEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rerrThrehsoldEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crsEstimatorFIFOSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhfilterFIFOSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhfilterRangeThresholdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhfilterMaxSpeedEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfilterFIFOSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfilterRangeThresholdEdit)).BeginInit();
            this.extraTab.SuspendLayout();
            this.miscTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfTrackPointsEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(654, 497);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(116, 44);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(506, 497);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(116, 44);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // setDefaultSettingsBtn
            // 
            this.setDefaultSettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setDefaultSettingsBtn.Location = new System.Drawing.Point(12, 497);
            this.setDefaultSettingsBtn.Name = "setDefaultSettingsBtn";
            this.setDefaultSettingsBtn.Size = new System.Drawing.Size(116, 44);
            this.setDefaultSettingsBtn.TabIndex = 2;
            this.setDefaultSettingsBtn.Text = "DEFAULTS";
            this.setDefaultSettingsBtn.UseVisualStyleBackColor = true;
            this.setDefaultSettingsBtn.Click += new System.EventHandler(this.setDefaultSettingsBtn_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.connectionsTab);
            this.mainTabControl.Controls.Add(this.physicsTab);
            this.mainTabControl.Controls.Add(this.extraTab);
            this.mainTabControl.HotTrack = true;
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(758, 479);
            this.mainTabControl.TabIndex = 3;
            // 
            // connectionsTab
            // 
            this.connectionsTab.Controls.Add(this.connectionTbl);
            this.connectionsTab.Location = new System.Drawing.Point(4, 37);
            this.connectionsTab.Name = "connectionsTab";
            this.connectionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.connectionsTab.Size = new System.Drawing.Size(750, 438);
            this.connectionsTab.TabIndex = 0;
            this.connectionsTab.Text = "🔌 CONNECTION";
            this.connectionsTab.UseVisualStyleBackColor = true;
            // 
            // connectionTbl
            // 
            this.connectionTbl.ColumnCount = 5;
            this.connectionTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connectionTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connectionTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connectionTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connectionTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.connectionTbl.Controls.Add(this.label2, 0, 1);
            this.connectionTbl.Controls.Add(this.serialAUXGNSSLbl, 0, 2);
            this.connectionTbl.Controls.Add(this.label1, 1, 0);
            this.connectionTbl.Controls.Add(this.label4, 2, 0);
            this.connectionTbl.Controls.Add(this.serialOutputLbl, 0, 3);
            this.connectionTbl.Controls.Add(this.serialAUXGNSSEnabledChb, 3, 2);
            this.connectionTbl.Controls.Add(this.udpOutputLbl, 0, 6);
            this.connectionTbl.Controls.Add(this.udpOutputIPAddressEdit, 1, 6);
            this.connectionTbl.Controls.Add(this.udpOutputPortEdit, 2, 6);
            this.connectionTbl.Controls.Add(this.udpOutputEnabledChb, 3, 6);
            this.connectionTbl.Controls.Add(this.label8, 1, 5);
            this.connectionTbl.Controls.Add(this.label9, 2, 5);
            this.connectionTbl.Controls.Add(this.label10, 2, 1);
            this.connectionTbl.Controls.Add(this.label11, 2, 2);
            this.connectionTbl.Controls.Add(this.label12, 2, 3);
            this.connectionTbl.Controls.Add(this.udpOutputNMEAChb, 4, 6);
            this.connectionTbl.Controls.Add(this.label15, 3, 3);
            this.connectionTbl.Controls.Add(this.serialAUXGNSSPortBaudrateCbx, 1, 2);
            this.connectionTbl.Controls.Add(this.serialOutputPortBaudrateCbx, 1, 3);
            this.connectionTbl.Controls.Add(this.inPortBaudrateCbx, 1, 1);
            this.connectionTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionTbl.Location = new System.Drawing.Point(3, 3);
            this.connectionTbl.Name = "connectionTbl";
            this.connectionTbl.RowCount = 8;
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.connectionTbl.Size = new System.Drawing.Size(744, 432);
            this.connectionTbl.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "APL Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serialAUXGNSSLbl
            // 
            this.serialAUXGNSSLbl.AutoSize = true;
            this.serialAUXGNSSLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialAUXGNSSLbl.Enabled = false;
            this.serialAUXGNSSLbl.Location = new System.Drawing.Point(3, 79);
            this.serialAUXGNSSLbl.Margin = new System.Windows.Forms.Padding(3);
            this.serialAUXGNSSLbl.Name = "serialAUXGNSSLbl";
            this.serialAUXGNSSLbl.Size = new System.Drawing.Size(160, 36);
            this.serialAUXGNSSLbl.TabIndex = 2;
            this.serialAUXGNSSLbl.Text = "Serial AUX GNSS";
            this.serialAUXGNSSLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(169, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Baudrate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(340, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialOutputLbl
            // 
            this.serialOutputLbl.AutoSize = true;
            this.serialOutputLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialOutputLbl.Location = new System.Drawing.Point(3, 121);
            this.serialOutputLbl.Margin = new System.Windows.Forms.Padding(3);
            this.serialOutputLbl.Name = "serialOutputLbl";
            this.serialOutputLbl.Size = new System.Drawing.Size(160, 36);
            this.serialOutputLbl.TabIndex = 8;
            this.serialOutputLbl.Text = "Serial output";
            this.serialOutputLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serialAUXGNSSEnabledChb
            // 
            this.serialAUXGNSSEnabledChb.AutoSize = true;
            this.serialAUXGNSSEnabledChb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialAUXGNSSEnabledChb.Location = new System.Drawing.Point(473, 79);
            this.serialAUXGNSSEnabledChb.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.serialAUXGNSSEnabledChb.Name = "serialAUXGNSSEnabledChb";
            this.serialAUXGNSSEnabledChb.Size = new System.Drawing.Size(99, 36);
            this.serialAUXGNSSEnabledChb.TabIndex = 10;
            this.serialAUXGNSSEnabledChb.Text = "Enable";
            this.serialAUXGNSSEnabledChb.UseVisualStyleBackColor = true;
            this.serialAUXGNSSEnabledChb.CheckedChanged += new System.EventHandler(this.serialAUXGNSSEnabledChb_CheckedChanged);
            // 
            // udpOutputLbl
            // 
            this.udpOutputLbl.AutoSize = true;
            this.udpOutputLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udpOutputLbl.Enabled = false;
            this.udpOutputLbl.Location = new System.Drawing.Point(3, 217);
            this.udpOutputLbl.Margin = new System.Windows.Forms.Padding(3);
            this.udpOutputLbl.Name = "udpOutputLbl";
            this.udpOutputLbl.Size = new System.Drawing.Size(160, 34);
            this.udpOutputLbl.TabIndex = 12;
            this.udpOutputLbl.Text = "UDP output";
            this.udpOutputLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // udpOutputIPAddressEdit
            // 
            this.udpOutputIPAddressEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udpOutputIPAddressEdit.Enabled = false;
            this.udpOutputIPAddressEdit.Location = new System.Drawing.Point(169, 217);
            this.udpOutputIPAddressEdit.Name = "udpOutputIPAddressEdit";
            this.udpOutputIPAddressEdit.Size = new System.Drawing.Size(165, 34);
            this.udpOutputIPAddressEdit.TabIndex = 13;
            this.udpOutputIPAddressEdit.Text = "255.255.255.255";
            // 
            // udpOutputPortEdit
            // 
            this.udpOutputPortEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udpOutputPortEdit.Enabled = false;
            this.udpOutputPortEdit.Location = new System.Drawing.Point(340, 217);
            this.udpOutputPortEdit.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.udpOutputPortEdit.Name = "udpOutputPortEdit";
            this.udpOutputPortEdit.Size = new System.Drawing.Size(120, 34);
            this.udpOutputPortEdit.TabIndex = 14;
            this.udpOutputPortEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udpOutputPortEdit.Value = new decimal(new int[] {
            28128,
            0,
            0,
            0});
            // 
            // udpOutputEnabledChb
            // 
            this.udpOutputEnabledChb.AutoSize = true;
            this.udpOutputEnabledChb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udpOutputEnabledChb.Location = new System.Drawing.Point(473, 217);
            this.udpOutputEnabledChb.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.udpOutputEnabledChb.Name = "udpOutputEnabledChb";
            this.udpOutputEnabledChb.Size = new System.Drawing.Size(99, 34);
            this.udpOutputEnabledChb.TabIndex = 15;
            this.udpOutputEnabledChb.Text = "Enable";
            this.udpOutputEnabledChb.UseVisualStyleBackColor = true;
            this.udpOutputEnabledChb.CheckedChanged += new System.EventHandler(this.udpOutputEnabledChb_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(169, 183);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 28);
            this.label8.TabIndex = 16;
            this.label8.Text = "IP Address";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(340, 183);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 28);
            this.label9.TabIndex = 17;
            this.label9.Text = "Port";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(340, 37);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 36);
            this.label10.TabIndex = 18;
            this.label10.Text = "- auto -";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(340, 79);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 36);
            this.label11.TabIndex = 19;
            this.label11.Text = "- auto -";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(340, 121);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 36);
            this.label12.TabIndex = 20;
            this.label12.Text = "- runtime -";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // udpOutputNMEAChb
            // 
            this.udpOutputNMEAChb.AutoSize = true;
            this.udpOutputNMEAChb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udpOutputNMEAChb.Enabled = false;
            this.udpOutputNMEAChb.Location = new System.Drawing.Point(585, 217);
            this.udpOutputNMEAChb.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.udpOutputNMEAChb.Name = "udpOutputNMEAChb";
            this.udpOutputNMEAChb.Size = new System.Drawing.Size(156, 34);
            this.udpOutputNMEAChb.TabIndex = 21;
            this.udpOutputNMEAChb.Text = "NMEA";
            this.udpOutputNMEAChb.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(466, 121);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 36);
            this.label15.TabIndex = 22;
            this.label15.Text = "- runtime -";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialAUXGNSSPortBaudrateCbx
            // 
            this.serialAUXGNSSPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialAUXGNSSPortBaudrateCbx.Enabled = false;
            this.serialAUXGNSSPortBaudrateCbx.FormattingEnabled = true;
            this.serialAUXGNSSPortBaudrateCbx.Location = new System.Drawing.Point(169, 79);
            this.serialAUXGNSSPortBaudrateCbx.Name = "serialAUXGNSSPortBaudrateCbx";
            this.serialAUXGNSSPortBaudrateCbx.Size = new System.Drawing.Size(165, 36);
            this.serialAUXGNSSPortBaudrateCbx.TabIndex = 7;
            // 
            // serialOutputPortBaudrateCbx
            // 
            this.serialOutputPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialOutputPortBaudrateCbx.FormattingEnabled = true;
            this.serialOutputPortBaudrateCbx.Location = new System.Drawing.Point(169, 121);
            this.serialOutputPortBaudrateCbx.Name = "serialOutputPortBaudrateCbx";
            this.serialOutputPortBaudrateCbx.Size = new System.Drawing.Size(165, 36);
            this.serialOutputPortBaudrateCbx.TabIndex = 9;
            // 
            // inPortBaudrateCbx
            // 
            this.inPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inPortBaudrateCbx.FormattingEnabled = true;
            this.inPortBaudrateCbx.Location = new System.Drawing.Point(169, 37);
            this.inPortBaudrateCbx.Name = "inPortBaudrateCbx";
            this.inPortBaudrateCbx.Size = new System.Drawing.Size(165, 36);
            this.inPortBaudrateCbx.TabIndex = 6;
            // 
            // physicsTab
            // 
            this.physicsTab.Controls.Add(this.phxTbl);
            this.physicsTab.Location = new System.Drawing.Point(4, 37);
            this.physicsTab.Name = "physicsTab";
            this.physicsTab.Padding = new System.Windows.Forms.Padding(3);
            this.physicsTab.Size = new System.Drawing.Size(750, 438);
            this.physicsTab.TabIndex = 1;
            this.physicsTab.Text = "🧪 PHYSICS";
            this.physicsTab.UseVisualStyleBackColor = true;
            // 
            // phxTbl
            // 
            this.phxTbl.ColumnCount = 4;
            this.phxTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.phxTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.phxTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.phxTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.phxTbl.Controls.Add(this.waterTemperatureEdit, 1, 1);
            this.phxTbl.Controls.Add(this.label5, 0, 0);
            this.phxTbl.Controls.Add(this.label13, 0, 1);
            this.phxTbl.Controls.Add(this.salinityEdit, 1, 0);
            this.phxTbl.Controls.Add(this.salinityAutoChb, 2, 0);
            this.phxTbl.Controls.Add(this.salinitySearchBtn, 3, 0);
            this.phxTbl.Controls.Add(this.label14, 0, 2);
            this.phxTbl.Controls.Add(this.speedOfSoundEdit, 1, 2);
            this.phxTbl.Controls.Add(this.speedOfSoundAutoChb, 2, 2);
            this.phxTbl.Controls.Add(this.label16, 0, 4);
            this.phxTbl.Controls.Add(this.label17, 0, 5);
            this.phxTbl.Controls.Add(this.label19, 0, 8);
            this.phxTbl.Controls.Add(this.label20, 0, 9);
            this.phxTbl.Controls.Add(this.label21, 0, 10);
            this.phxTbl.Controls.Add(this.rerrThrehsoldEdit, 1, 4);
            this.phxTbl.Controls.Add(this.crsEstimatorFIFOSizeEdit, 1, 5);
            this.phxTbl.Controls.Add(this.dhfilterFIFOSizeEdit, 1, 8);
            this.phxTbl.Controls.Add(this.dhfilterRangeThresholdEdit, 1, 9);
            this.phxTbl.Controls.Add(this.dhfilterMaxSpeedEdit, 1, 10);
            this.phxTbl.Controls.Add(this.label18, 0, 6);
            this.phxTbl.Controls.Add(this.label22, 0, 7);
            this.phxTbl.Controls.Add(this.sfilterFIFOSizeEdit, 1, 6);
            this.phxTbl.Controls.Add(this.sfilterRangeThresholdEdit, 1, 7);
            this.phxTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phxTbl.Location = new System.Drawing.Point(3, 3);
            this.phxTbl.Name = "phxTbl";
            this.phxTbl.RowCount = 13;
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.phxTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.phxTbl.Size = new System.Drawing.Size(744, 432);
            this.phxTbl.TabIndex = 0;
            // 
            // waterTemperatureEdit
            // 
            this.waterTemperatureEdit.DecimalPlaces = 1;
            this.waterTemperatureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waterTemperatureEdit.Location = new System.Drawing.Point(262, 43);
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
            this.waterTemperatureEdit.Size = new System.Drawing.Size(120, 34);
            this.waterTemperatureEdit.TabIndex = 5;
            this.waterTemperatureEdit.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 34);
            this.label5.TabIndex = 0;
            this.label5.Text = "Salinity, PSU";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 43);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(253, 34);
            this.label13.TabIndex = 1;
            this.label13.Text = "Water temperature, °C";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // salinityEdit
            // 
            this.salinityEdit.DecimalPlaces = 1;
            this.salinityEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salinityEdit.Location = new System.Drawing.Point(262, 3);
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            this.salinityEdit.Size = new System.Drawing.Size(120, 34);
            this.salinityEdit.TabIndex = 2;
            // 
            // salinityAutoChb
            // 
            this.salinityAutoChb.AutoSize = true;
            this.salinityAutoChb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salinityAutoChb.Location = new System.Drawing.Point(395, 3);
            this.salinityAutoChb.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.salinityAutoChb.Name = "salinityAutoChb";
            this.salinityAutoChb.Size = new System.Drawing.Size(77, 34);
            this.salinityAutoChb.TabIndex = 3;
            this.salinityAutoChb.Text = "Auto";
            this.salinityAutoChb.UseVisualStyleBackColor = true;
            this.salinityAutoChb.CheckedChanged += new System.EventHandler(this.salinityAutoChb_CheckedChanged);
            // 
            // salinitySearchBtn
            // 
            this.salinitySearchBtn.AutoSize = true;
            this.salinitySearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salinitySearchBtn.Location = new System.Drawing.Point(478, 3);
            this.salinitySearchBtn.Margin = new System.Windows.Forms.Padding(3);
            this.salinitySearchBtn.Name = "salinitySearchBtn";
            this.salinitySearchBtn.Size = new System.Drawing.Size(263, 34);
            this.salinitySearchBtn.TabIndex = 4;
            this.salinitySearchBtn.TabStop = true;
            this.salinitySearchBtn.Text = "🔎";
            this.salinitySearchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salinitySearchBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.salinitySearchBtn_LinkClicked);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 83);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(253, 34);
            this.label14.TabIndex = 7;
            this.label14.Text = "Speed of sound, m/s";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // speedOfSoundEdit
            // 
            this.speedOfSoundEdit.DecimalPlaces = 1;
            this.speedOfSoundEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedOfSoundEdit.Location = new System.Drawing.Point(262, 83);
            this.speedOfSoundEdit.Maximum = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            this.speedOfSoundEdit.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.speedOfSoundEdit.Name = "speedOfSoundEdit";
            this.speedOfSoundEdit.Size = new System.Drawing.Size(120, 34);
            this.speedOfSoundEdit.TabIndex = 8;
            this.speedOfSoundEdit.Value = new decimal(new int[] {
            1450,
            0,
            0,
            0});
            // 
            // speedOfSoundAutoChb
            // 
            this.speedOfSoundAutoChb.AutoSize = true;
            this.speedOfSoundAutoChb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedOfSoundAutoChb.Location = new System.Drawing.Point(395, 83);
            this.speedOfSoundAutoChb.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.speedOfSoundAutoChb.Name = "speedOfSoundAutoChb";
            this.speedOfSoundAutoChb.Size = new System.Drawing.Size(77, 34);
            this.speedOfSoundAutoChb.TabIndex = 9;
            this.speedOfSoundAutoChb.Text = "Auto";
            this.speedOfSoundAutoChb.UseVisualStyleBackColor = true;
            this.speedOfSoundAutoChb.CheckedChanged += new System.EventHandler(this.speedOfSoundAutoChb_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 143);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(253, 34);
            this.label16.TabIndex = 10;
            this.label16.Text = "Radial error threshold, m";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 183);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(253, 34);
            this.label17.TabIndex = 12;
            this.label17.Text = "Course estimator FIFO size";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(3, 303);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(253, 34);
            this.label19.TabIndex = 16;
            this.label19.Text = "DHFilter FIFO size";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(3, 343);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(253, 34);
            this.label20.TabIndex = 18;
            this.label20.Text = "DHFilter range threshold, m";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(3, 383);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(253, 34);
            this.label21.TabIndex = 20;
            this.label21.Text = "DHFilter max speed, m/s";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rerrThrehsoldEdit
            // 
            this.rerrThrehsoldEdit.DecimalPlaces = 1;
            this.rerrThrehsoldEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rerrThrehsoldEdit.Location = new System.Drawing.Point(262, 143);
            this.rerrThrehsoldEdit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.rerrThrehsoldEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rerrThrehsoldEdit.Name = "rerrThrehsoldEdit";
            this.rerrThrehsoldEdit.Size = new System.Drawing.Size(120, 34);
            this.rerrThrehsoldEdit.TabIndex = 11;
            this.rerrThrehsoldEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // crsEstimatorFIFOSizeEdit
            // 
            this.crsEstimatorFIFOSizeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crsEstimatorFIFOSizeEdit.Location = new System.Drawing.Point(262, 183);
            this.crsEstimatorFIFOSizeEdit.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.crsEstimatorFIFOSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.crsEstimatorFIFOSizeEdit.Name = "crsEstimatorFIFOSizeEdit";
            this.crsEstimatorFIFOSizeEdit.Size = new System.Drawing.Size(120, 34);
            this.crsEstimatorFIFOSizeEdit.TabIndex = 13;
            this.crsEstimatorFIFOSizeEdit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // dhfilterFIFOSizeEdit
            // 
            this.dhfilterFIFOSizeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dhfilterFIFOSizeEdit.Location = new System.Drawing.Point(262, 303);
            this.dhfilterFIFOSizeEdit.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.dhfilterFIFOSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dhfilterFIFOSizeEdit.Name = "dhfilterFIFOSizeEdit";
            this.dhfilterFIFOSizeEdit.Size = new System.Drawing.Size(120, 34);
            this.dhfilterFIFOSizeEdit.TabIndex = 17;
            this.dhfilterFIFOSizeEdit.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // dhfilterRangeThresholdEdit
            // 
            this.dhfilterRangeThresholdEdit.DecimalPlaces = 1;
            this.dhfilterRangeThresholdEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dhfilterRangeThresholdEdit.Location = new System.Drawing.Point(262, 343);
            this.dhfilterRangeThresholdEdit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.dhfilterRangeThresholdEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dhfilterRangeThresholdEdit.Name = "dhfilterRangeThresholdEdit";
            this.dhfilterRangeThresholdEdit.Size = new System.Drawing.Size(120, 34);
            this.dhfilterRangeThresholdEdit.TabIndex = 19;
            this.dhfilterRangeThresholdEdit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dhfilterMaxSpeedEdit
            // 
            this.dhfilterMaxSpeedEdit.DecimalPlaces = 1;
            this.dhfilterMaxSpeedEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dhfilterMaxSpeedEdit.Location = new System.Drawing.Point(262, 383);
            this.dhfilterMaxSpeedEdit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.dhfilterMaxSpeedEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dhfilterMaxSpeedEdit.Name = "dhfilterMaxSpeedEdit";
            this.dhfilterMaxSpeedEdit.Size = new System.Drawing.Size(120, 34);
            this.dhfilterMaxSpeedEdit.TabIndex = 21;
            this.dhfilterMaxSpeedEdit.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(3, 223);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(253, 34);
            this.label18.TabIndex = 14;
            this.label18.Text = "SFilter FIFO size";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(3, 263);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(253, 34);
            this.label22.TabIndex = 22;
            this.label22.Text = "SFilter range threshold, m";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sfilterFIFOSizeEdit
            // 
            this.sfilterFIFOSizeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfilterFIFOSizeEdit.Location = new System.Drawing.Point(262, 223);
            this.sfilterFIFOSizeEdit.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.sfilterFIFOSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sfilterFIFOSizeEdit.Name = "sfilterFIFOSizeEdit";
            this.sfilterFIFOSizeEdit.Size = new System.Drawing.Size(120, 34);
            this.sfilterFIFOSizeEdit.TabIndex = 15;
            this.sfilterFIFOSizeEdit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // sfilterRangeThresholdEdit
            // 
            this.sfilterRangeThresholdEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfilterRangeThresholdEdit.Location = new System.Drawing.Point(262, 263);
            this.sfilterRangeThresholdEdit.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.sfilterRangeThresholdEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sfilterRangeThresholdEdit.Name = "sfilterRangeThresholdEdit";
            this.sfilterRangeThresholdEdit.Size = new System.Drawing.Size(120, 34);
            this.sfilterRangeThresholdEdit.TabIndex = 23;
            this.sfilterRangeThresholdEdit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // extraTab
            // 
            this.extraTab.Controls.Add(this.miscTbl);
            this.extraTab.Location = new System.Drawing.Point(4, 37);
            this.extraTab.Name = "extraTab";
            this.extraTab.Padding = new System.Windows.Forms.Padding(3);
            this.extraTab.Size = new System.Drawing.Size(750, 438);
            this.extraTab.TabIndex = 2;
            this.extraTab.Text = "👽 EXTRA";
            this.extraTab.UseVisualStyleBackColor = true;
            // 
            // miscTbl
            // 
            this.miscTbl.ColumnCount = 2;
            this.miscTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.miscTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.miscTbl.Controls.Add(this.label23, 0, 0);
            this.miscTbl.Controls.Add(this.label24, 0, 2);
            this.miscTbl.Controls.Add(this.label25, 0, 3);
            this.miscTbl.Controls.Add(this.tileServersEdit, 1, 3);
            this.miscTbl.Controls.Add(this.tileSizeEdit, 1, 2);
            this.miscTbl.Controls.Add(this.numberOfTrackPointsEdit, 1, 0);
            this.miscTbl.Controls.Add(this.label3, 0, 5);
            this.miscTbl.Controls.Add(this.tilesDownloadingEnabledChb, 1, 5);
            this.miscTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscTbl.Location = new System.Drawing.Point(3, 3);
            this.miscTbl.Name = "miscTbl";
            this.miscTbl.RowCount = 7;
            this.miscTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.miscTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.miscTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.miscTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.miscTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.miscTbl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.miscTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.miscTbl.Size = new System.Drawing.Size(744, 432);
            this.miscTbl.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Location = new System.Drawing.Point(3, 3);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(289, 34);
            this.label23.TabIndex = 0;
            this.label23.Text = "Number of track points to show";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Location = new System.Drawing.Point(3, 63);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(289, 34);
            this.label24.TabIndex = 2;
            this.label24.Text = "Tile size, px";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Location = new System.Drawing.Point(3, 103);
            this.label25.Margin = new System.Windows.Forms.Padding(3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(289, 219);
            this.label25.TabIndex = 4;
            this.label25.Text = "Tile servers";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tileServersEdit
            // 
            this.tileServersEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileServersEdit.Location = new System.Drawing.Point(298, 103);
            this.tileServersEdit.Multiline = true;
            this.tileServersEdit.Name = "tileServersEdit";
            this.tileServersEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tileServersEdit.Size = new System.Drawing.Size(443, 219);
            this.tileServersEdit.TabIndex = 5;
            this.tileServersEdit.Text = "https://a.tile.openstreetmap.org\r\nhttps://b.tile.openstreetmap.org\r\nhttps://c.til" +
    "e.openstreetmap.org";
            // 
            // tileSizeEdit
            // 
            this.tileSizeEdit.Enabled = false;
            this.tileSizeEdit.Location = new System.Drawing.Point(298, 63);
            this.tileSizeEdit.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.tileSizeEdit.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.tileSizeEdit.Name = "tileSizeEdit";
            this.tileSizeEdit.Size = new System.Drawing.Size(120, 34);
            this.tileSizeEdit.TabIndex = 3;
            this.tileSizeEdit.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // numberOfTrackPointsEdit
            // 
            this.numberOfTrackPointsEdit.Location = new System.Drawing.Point(298, 3);
            this.numberOfTrackPointsEdit.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numberOfTrackPointsEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfTrackPointsEdit.Name = "numberOfTrackPointsEdit";
            this.numberOfTrackPointsEdit.Size = new System.Drawing.Size(120, 34);
            this.numberOfTrackPointsEdit.TabIndex = 1;
            this.numberOfTrackPointsEdit.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enable tiles download";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tilesDownloadingEnabledChb
            // 
            this.tilesDownloadingEnabledChb.AutoSize = true;
            this.tilesDownloadingEnabledChb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilesDownloadingEnabledChb.Location = new System.Drawing.Point(298, 328);
            this.tilesDownloadingEnabledChb.Name = "tilesDownloadingEnabledChb";
            this.tilesDownloadingEnabledChb.Size = new System.Drawing.Size(443, 22);
            this.tilesDownloadingEnabledChb.TabIndex = 7;
            this.tilesDownloadingEnabledChb.UseVisualStyleBackColor = true;
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.setDefaultSettingsBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "SettingsEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsEditor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsEditor_KeyDown);
            this.mainTabControl.ResumeLayout(false);
            this.connectionsTab.ResumeLayout(false);
            this.connectionTbl.ResumeLayout(false);
            this.connectionTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udpOutputPortEdit)).EndInit();
            this.physicsTab.ResumeLayout(false);
            this.phxTbl.ResumeLayout(false);
            this.phxTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterTemperatureEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedOfSoundEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rerrThrehsoldEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crsEstimatorFIFOSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhfilterFIFOSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhfilterRangeThresholdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dhfilterMaxSpeedEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfilterFIFOSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfilterRangeThresholdEdit)).EndInit();
            this.extraTab.ResumeLayout(false);
            this.miscTbl.ResumeLayout(false);
            this.miscTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfTrackPointsEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button setDefaultSettingsBtn;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage connectionsTab;
        private System.Windows.Forms.TabPage physicsTab;
        private System.Windows.Forms.TableLayoutPanel connectionTbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label serialAUXGNSSLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox inPortBaudrateCbx;
        private System.Windows.Forms.ComboBox serialAUXGNSSPortBaudrateCbx;
        private System.Windows.Forms.Label serialOutputLbl;
        private System.Windows.Forms.ComboBox serialOutputPortBaudrateCbx;
        private System.Windows.Forms.CheckBox serialAUXGNSSEnabledChb;
        private System.Windows.Forms.Label udpOutputLbl;
        private System.Windows.Forms.MaskedTextBox udpOutputIPAddressEdit;
        private System.Windows.Forms.NumericUpDown udpOutputPortEdit;
        private System.Windows.Forms.CheckBox udpOutputEnabledChb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox udpOutputNMEAChb;
        private System.Windows.Forms.TabPage extraTab;
        private System.Windows.Forms.TableLayoutPanel phxTbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown waterTemperatureEdit;
        private System.Windows.Forms.NumericUpDown salinityEdit;
        private System.Windows.Forms.CheckBox salinityAutoChb;
        private System.Windows.Forms.LinkLabel salinitySearchBtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown speedOfSoundEdit;
        private System.Windows.Forms.CheckBox speedOfSoundAutoChb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown rerrThrehsoldEdit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown crsEstimatorFIFOSizeEdit;
        private System.Windows.Forms.NumericUpDown sfilterFIFOSizeEdit;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown dhfilterFIFOSizeEdit;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown dhfilterMaxSpeedEdit;
        private System.Windows.Forms.NumericUpDown dhfilterRangeThresholdEdit;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown sfilterRangeThresholdEdit;
        private System.Windows.Forms.TableLayoutPanel miscTbl;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tileServersEdit;
        private System.Windows.Forms.NumericUpDown tileSizeEdit;
        private System.Windows.Forms.NumericUpDown numberOfTrackPointsEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox tilesDownloadingEnabledChb;
    }
}