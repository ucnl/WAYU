namespace WAYU
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.primaryToolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trackBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.trackExportAsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.trackClearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.logViewCurrentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.logPlaybackBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.logClearAllEntriesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.emuBtn = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.portStatesLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.secondaryToolStrip = new System.Windows.Forms.ToolStrip();
            this.markPointBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.autoscreenshotBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbaLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.hdopLbl = new System.Windows.Forms.ToolStripLabel();
            this.plotStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.fitTracksCbx = new System.Windows.Forms.ToolStripComboBox();
            this.geoPlot = new UCNLUI.Controls.uOSMGeoPlot();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.isHistoryLinesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.primaryToolStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.secondaryToolStrip.SuspendLayout();
            this.plotStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // primaryToolStrip
            // 
            this.primaryToolStrip.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.primaryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionBtn,
            this.toolStripSeparator1,
            this.trackBtn,
            this.logBtn,
            this.toolStripSeparator4,
            this.settingsBtn,
            this.infoBtn,
            this.emuBtn});
            this.primaryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.primaryToolStrip.Name = "primaryToolStrip";
            this.primaryToolStrip.Size = new System.Drawing.Size(858, 32);
            this.primaryToolStrip.TabIndex = 1;
            this.primaryToolStrip.Text = "toolStrip1";
            // 
            // connectionBtn
            // 
            this.connectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectionBtn.Image = ((System.Drawing.Image)(resources.GetObject("connectionBtn.Image")));
            this.connectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectionBtn.Name = "connectionBtn";
            this.connectionBtn.Size = new System.Drawing.Size(140, 29);
            this.connectionBtn.Text = "CONNECTION";
            this.connectionBtn.Click += new System.EventHandler(this.connectionBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // trackBtn
            // 
            this.trackBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.trackBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackExportAsBtn,
            this.toolStripSeparator2,
            this.trackClearBtn});
            this.trackBtn.Image = ((System.Drawing.Image)(resources.GetObject("trackBtn.Image")));
            this.trackBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.trackBtn.Name = "trackBtn";
            this.trackBtn.Size = new System.Drawing.Size(85, 29);
            this.trackBtn.Text = "TRACK";
            // 
            // trackExportAsBtn
            // 
            this.trackExportAsBtn.Enabled = false;
            this.trackExportAsBtn.Name = "trackExportAsBtn";
            this.trackExportAsBtn.Size = new System.Drawing.Size(199, 30);
            this.trackExportAsBtn.Text = "EXPORT AS...";
            this.trackExportAsBtn.Click += new System.EventHandler(this.trackExportAsBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // trackClearBtn
            // 
            this.trackClearBtn.Enabled = false;
            this.trackClearBtn.Name = "trackClearBtn";
            this.trackClearBtn.Size = new System.Drawing.Size(199, 30);
            this.trackClearBtn.Text = "CLEAR";
            this.trackClearBtn.Click += new System.EventHandler(this.trackClearBtn_Click);
            // 
            // logBtn
            // 
            this.logBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewCurrentBtn,
            this.toolStripSeparator5,
            this.logPlaybackBtn,
            this.toolStripSeparator3,
            this.logClearAllEntriesBtn});
            this.logBtn.Image = ((System.Drawing.Image)(resources.GetObject("logBtn.Image")));
            this.logBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(63, 29);
            this.logBtn.Text = "LOG";
            // 
            // logViewCurrentBtn
            // 
            this.logViewCurrentBtn.Name = "logViewCurrentBtn";
            this.logViewCurrentBtn.Size = new System.Drawing.Size(259, 30);
            this.logViewCurrentBtn.Text = "VIEW CURRENT";
            this.logViewCurrentBtn.Click += new System.EventHandler(this.logViewCurrentBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(256, 6);
            // 
            // logPlaybackBtn
            // 
            this.logPlaybackBtn.Name = "logPlaybackBtn";
            this.logPlaybackBtn.Size = new System.Drawing.Size(259, 30);
            this.logPlaybackBtn.Text = "PLAYBACK...";
            this.logPlaybackBtn.Click += new System.EventHandler(this.logPlaybackBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(256, 6);
            // 
            // logClearAllEntriesBtn
            // 
            this.logClearAllEntriesBtn.Name = "logClearAllEntriesBtn";
            this.logClearAllEntriesBtn.Size = new System.Drawing.Size(259, 30);
            this.logClearAllEntriesBtn.Text = "CLEAR ALL ENTRIES";
            this.logClearAllEntriesBtn.Click += new System.EventHandler(this.logClearAllEntriesBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(105, 29);
            this.settingsBtn.Text = "SETTINGS";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(61, 29);
            this.infoBtn.Text = "INFO";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // emuBtn
            // 
            this.emuBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.emuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.emuBtn.Image = ((System.Drawing.Image)(resources.GetObject("emuBtn.Image")));
            this.emuBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.emuBtn.Name = "emuBtn";
            this.emuBtn.Size = new System.Drawing.Size(58, 29);
            this.emuBtn.Text = "EMU";
            this.emuBtn.Click += new System.EventHandler(this.emuBtn_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portStatesLbl});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 636);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(858, 25);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // portStatesLbl
            // 
            this.portStatesLbl.Name = "portStatesLbl";
            this.portStatesLbl.Size = new System.Drawing.Size(35, 20);
            this.portStatesLbl.Text = "- - -";
            // 
            // secondaryToolStrip
            // 
            this.secondaryToolStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondaryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markPointBtn,
            this.toolStripSeparator6,
            this.autoscreenshotBtn,
            this.toolStripSeparator7,
            this.toolStripLabel2,
            this.tbaLbl,
            this.toolStripLabel3,
            this.hdopLbl});
            this.secondaryToolStrip.Location = new System.Drawing.Point(0, 32);
            this.secondaryToolStrip.Name = "secondaryToolStrip";
            this.secondaryToolStrip.Size = new System.Drawing.Size(858, 30);
            this.secondaryToolStrip.TabIndex = 4;
            this.secondaryToolStrip.Text = "toolStrip1";
            // 
            // markPointBtn
            // 
            this.markPointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.markPointBtn.Image = ((System.Drawing.Image)(resources.GetObject("markPointBtn.Image")));
            this.markPointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.markPointBtn.Name = "markPointBtn";
            this.markPointBtn.Size = new System.Drawing.Size(120, 27);
            this.markPointBtn.Text = "MARK POINT";
            this.markPointBtn.Click += new System.EventHandler(this.markPointBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 30);
            // 
            // autoscreenshotBtn
            // 
            this.autoscreenshotBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autoscreenshotBtn.Image = ((System.Drawing.Image)(resources.GetObject("autoscreenshotBtn.Image")));
            this.autoscreenshotBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoscreenshotBtn.Name = "autoscreenshotBtn";
            this.autoscreenshotBtn.Size = new System.Drawing.Size(173, 27);
            this.autoscreenshotBtn.Text = "AUTO SCREENSHOT";
            this.autoscreenshotBtn.Click += new System.EventHandler(this.autoscreenshotBtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 27);
            this.toolStripLabel2.Text = "TBA:";
            // 
            // tbaLbl
            // 
            this.tbaLbl.Name = "tbaLbl";
            this.tbaLbl.Size = new System.Drawing.Size(41, 27);
            this.tbaLbl.Text = "- - -";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(64, 27);
            this.toolStripLabel3.Text = "HDOP:";
            // 
            // hdopLbl
            // 
            this.hdopLbl.Name = "hdopLbl";
            this.hdopLbl.Size = new System.Drawing.Size(41, 27);
            this.hdopLbl.Text = "- - -";
            // 
            // plotStrip
            // 
            this.plotStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.fitTracksCbx,
            this.toolStripSeparator8,
            this.isHistoryLinesVisibleBtn});
            this.plotStrip.Location = new System.Drawing.Point(0, 62);
            this.plotStrip.Name = "plotStrip";
            this.plotStrip.Size = new System.Drawing.Size(858, 28);
            this.plotStrip.TabIndex = 5;
            this.plotStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(115, 25);
            this.toolStripLabel1.Text = "TRACKS TO FIT";
            // 
            // fitTracksCbx
            // 
            this.fitTracksCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fitTracksCbx.Name = "fitTracksCbx";
            this.fitTracksCbx.Size = new System.Drawing.Size(121, 28);
            this.fitTracksCbx.SelectedIndexChanged += new System.EventHandler(this.zoomByCbx_SelectedIndexChanged);
            // 
            // geoPlot
            // 
            this.geoPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geoPlot.HistoryLinesNumber = 5;
            this.geoPlot.HistoryTextColor = System.Drawing.Color.DarkGreen;
            this.geoPlot.HistoryTextFont = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.geoPlot.HistoryVisible = true;
            this.geoPlot.LeftUpperText = null;
            this.geoPlot.LeftUpperTextColor = System.Drawing.Color.Black;
            this.geoPlot.LeftUpperTextFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.geoPlot.LegendFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.geoPlot.Location = new System.Drawing.Point(12, 94);
            this.geoPlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.geoPlot.MaxHistoryLineLength = 127;
            this.geoPlot.MeasurementLineColor = System.Drawing.Color.Black;
            this.geoPlot.MeasurementTextBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.geoPlot.MeasurementTextColor = System.Drawing.Color.Black;
            this.geoPlot.MeasurementTextFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.geoPlot.Name = "geoPlot";
            this.geoPlot.Padding = new System.Windows.Forms.Padding(11, 14, 11, 14);
            this.geoPlot.ScaleLineColor = System.Drawing.SystemColors.ControlText;
            this.geoPlot.ScaleLineFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.geoPlot.Size = new System.Drawing.Size(834, 538);
            this.geoPlot.TabIndex = 6;
            this.geoPlot.TextBackgroundColor = System.Drawing.Color.Empty;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 28);
            // 
            // isHistoryLinesVisibleBtn
            // 
            this.isHistoryLinesVisibleBtn.Checked = true;
            this.isHistoryLinesVisibleBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isHistoryLinesVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isHistoryLinesVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("isHistoryLinesVisibleBtn.Image")));
            this.isHistoryLinesVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isHistoryLinesVisibleBtn.Name = "isHistoryLinesVisibleBtn";
            this.isHistoryLinesVisibleBtn.Size = new System.Drawing.Size(75, 25);
            this.isHistoryLinesVisibleBtn.Text = "HISTORY";
            this.isHistoryLinesVisibleBtn.Click += new System.EventHandler(this.isHistoryLinesVisibleBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 661);
            this.Controls.Add(this.geoPlot);
            this.Controls.Add(this.plotStrip);
            this.Controls.Add(this.secondaryToolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.primaryToolStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "WAYU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.primaryToolStrip.ResumeLayout(false);
            this.primaryToolStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.secondaryToolStrip.ResumeLayout(false);
            this.secondaryToolStrip.PerformLayout();
            this.plotStrip.ResumeLayout(false);
            this.plotStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip primaryToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStrip secondaryToolStrip;
        private System.Windows.Forms.ToolStripButton connectionBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton trackBtn;
        private System.Windows.Forms.ToolStripMenuItem trackExportAsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem trackClearBtn;
        private System.Windows.Forms.ToolStripDropDownButton logBtn;
        private System.Windows.Forms.ToolStripMenuItem logViewCurrentBtn;
        private System.Windows.Forms.ToolStripMenuItem logPlaybackBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem logClearAllEntriesBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private System.Windows.Forms.ToolStripButton markPointBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton autoscreenshotBtn;
        private System.Windows.Forms.ToolStrip plotStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripStatusLabel portStatesLbl;
        private System.Windows.Forms.ToolStripButton emuBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox fitTracksCbx;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel tbaLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel hdopLbl;
        private UCNLUI.Controls.uOSMGeoPlot geoPlot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton isHistoryLinesVisibleBtn;
    }
}

