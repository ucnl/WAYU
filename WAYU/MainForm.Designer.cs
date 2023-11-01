using UCNLUI.Controls.uPlot;

namespace WAYU
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.linkBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.logViewCurrentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logPlaybackBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logBuildEmulationDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.logRemoveEmptyEntriesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logArchiveAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.logDeleteAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logDoThemAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.utilsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.utilsTracksBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksExportAsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.trackImportBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksClearAllBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.utilsOverridesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ovrSalinityBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ovrWaterTemperatureBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ovrAtmosphericPressureBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.secondaryToolStrip = new System.Windows.Forms.ToolStrip();
            this.markPointBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.markedPointsVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.buoysVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.historyVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.plotLegendVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.notesVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.extraInfoVisibleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.resetViewBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.accuracyEstimationBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.accuracyEstimationStartStopBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.accuracyEstimationClearDataBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.navToLbl = new System.Windows.Forms.ToolStripLabel();
            this.navPointCbx = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.followMapBtn = new System.Windows.Forms.ToolStripButton();
            this.showTilesBtn = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.aplPortStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.auxGNSSPortStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomLinkLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.moonPhaseLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomToolStrip = new System.Windows.Forms.ToolStrip();
            this.noteTxb = new System.Windows.Forms.ToolStripTextBox();
            this.noteSaveBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.screenShotBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.autoscreenshotsBtn = new System.Windows.Forms.ToolStripButton();
            this.bottomSecondaryToolStrip = new System.Windows.Forms.ToolStrip();
            this.serialOutputLbl = new System.Windows.Forms.ToolStripLabel();
            this.serialOutputPortsRefreshBtn = new System.Windows.Forms.ToolStripButton();
            this.serialOutputPortNameCbx = new System.Windows.Forms.ToolStripComboBox();
            this.serialOutputLinkBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInBtn = new System.Windows.Forms.ToolStripButton();
            this.zoomOutBtn = new System.Windows.Forms.ToolStripButton();
            this.plot = new UCNLUI.Controls.uPlot.uGeoPlot();
            this.mainToolStrip.SuspendLayout();
            this.secondaryToolStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.bottomToolStrip.SuspendLayout();
            this.bottomSecondaryToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkBtn,
            this.toolStripSeparator1,
            this.settingsBtn,
            this.toolStripSeparator2,
            this.logBtn,
            this.toolStripSeparator3,
            this.utilsBtn,
            this.toolStripSeparator4,
            this.infoBtn});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(782, 38);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // linkBtn
            // 
            this.linkBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.linkBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkBtn.Image = ((System.Drawing.Image)(resources.GetObject("linkBtn.Image")));
            this.linkBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.linkBtn.Name = "linkBtn";
            this.linkBtn.Size = new System.Drawing.Size(99, 35);
            this.linkBtn.Text = "📡LINK";
            this.linkBtn.ToolTipText = "Open/Close connection (Ctrl + L)";
            this.linkBtn.Click += new System.EventHandler(this.linkBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(162, 35);
            this.settingsBtn.Text = "⚙ SETTINGS";
            this.settingsBtn.ToolTipText = "Open settings editor (Ctrl + O)";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // logBtn
            // 
            this.logBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewCurrentBtn,
            this.logPlaybackBtn,
            this.logBuildEmulationDataBtn,
            this.toolStripSeparator16,
            this.logRemoveEmptyEntriesBtn,
            this.logArchiveAllBtn,
            this.toolStripSeparator17,
            this.logDeleteAllBtn,
            this.logDoThemAllBtn});
            this.logBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logBtn.Image = ((System.Drawing.Image)(resources.GetObject("logBtn.Image")));
            this.logBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(111, 35);
            this.logBtn.Text = "📖 LOG";
            this.logBtn.ToolTipText = "Log files related items";
            // 
            // logViewCurrentBtn
            // 
            this.logViewCurrentBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logViewCurrentBtn.Name = "logViewCurrentBtn";
            this.logViewCurrentBtn.ShortcutKeyDisplayString = "Ctrl+H";
            this.logViewCurrentBtn.Size = new System.Drawing.Size(368, 36);
            this.logViewCurrentBtn.Text = "👁 View current";
            this.logViewCurrentBtn.ToolTipText = "Open current log file in a text editor (Ctrl + H)";
            this.logViewCurrentBtn.Click += new System.EventHandler(this.logViewCurrentBtn_Click);
            // 
            // logPlaybackBtn
            // 
            this.logPlaybackBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logPlaybackBtn.Name = "logPlaybackBtn";
            this.logPlaybackBtn.Size = new System.Drawing.Size(368, 36);
            this.logPlaybackBtn.Text = "▶ Playback...";
            this.logPlaybackBtn.ToolTipText = "Select a log file to playback";
            this.logPlaybackBtn.Click += new System.EventHandler(this.logPlaybackBtn_Click);
            // 
            // logBuildEmulationDataBtn
            // 
            this.logBuildEmulationDataBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logBuildEmulationDataBtn.Name = "logBuildEmulationDataBtn";
            this.logBuildEmulationDataBtn.Size = new System.Drawing.Size(368, 36);
            this.logBuildEmulationDataBtn.Text = "🏗 Build emulation data...";
            this.logBuildEmulationDataBtn.Click += new System.EventHandler(this.logBuildEmulationDataBtn_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(365, 6);
            // 
            // logRemoveEmptyEntriesBtn
            // 
            this.logRemoveEmptyEntriesBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logRemoveEmptyEntriesBtn.Name = "logRemoveEmptyEntriesBtn";
            this.logRemoveEmptyEntriesBtn.Size = new System.Drawing.Size(368, 36);
            this.logRemoveEmptyEntriesBtn.Text = "🧹 Remove empty entries";
            this.logRemoveEmptyEntriesBtn.ToolTipText = "Remove all log files, smaller than 2 kB";
            this.logRemoveEmptyEntriesBtn.Click += new System.EventHandler(this.logRemoveEmptyEntriesBtn_Click);
            // 
            // logArchiveAllBtn
            // 
            this.logArchiveAllBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logArchiveAllBtn.Name = "logArchiveAllBtn";
            this.logArchiveAllBtn.Size = new System.Drawing.Size(368, 36);
            this.logArchiveAllBtn.Text = "🗜 Archive all";
            this.logArchiveAllBtn.ToolTipText = "Archive all log files to an archive";
            this.logArchiveAllBtn.Click += new System.EventHandler(this.logArchiveAllBtn_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(365, 6);
            // 
            // logDeleteAllBtn
            // 
            this.logDeleteAllBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logDeleteAllBtn.Name = "logDeleteAllBtn";
            this.logDeleteAllBtn.Size = new System.Drawing.Size(368, 36);
            this.logDeleteAllBtn.Text = "🗑 Delete all";
            this.logDeleteAllBtn.ToolTipText = "Delete all log files";
            this.logDeleteAllBtn.Click += new System.EventHandler(this.logDeleteAllBtn_Click);
            // 
            // logDoThemAllBtn
            // 
            this.logDoThemAllBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logDoThemAllBtn.Name = "logDoThemAllBtn";
            this.logDoThemAllBtn.Size = new System.Drawing.Size(368, 36);
            this.logDoThemAllBtn.Text = "🧹+🗜+🗑 Do them all";
            this.logDoThemAllBtn.ToolTipText = "Remove empty log files and entries, archive all that\'s left and delete";
            this.logDoThemAllBtn.Click += new System.EventHandler(this.logDoThemAllBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // utilsBtn
            // 
            this.utilsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.utilsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilsTracksBtn,
            this.toolStripSeparator21,
            this.utilsOverridesBtn});
            this.utilsBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.utilsBtn.Image = ((System.Drawing.Image)(resources.GetObject("utilsBtn.Image")));
            this.utilsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.utilsBtn.Name = "utilsBtn";
            this.utilsBtn.Size = new System.Drawing.Size(129, 35);
            this.utilsBtn.Text = "🛠 UTILS";
            this.utilsBtn.ToolTipText = "Utilities";
            // 
            // utilsTracksBtn
            // 
            this.utilsTracksBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tracksExportAsBtn,
            this.toolStripSeparator18,
            this.trackImportBtn,
            this.tracksClearAllBtn});
            this.utilsTracksBtn.Name = "utilsTracksBtn";
            this.utilsTracksBtn.Size = new System.Drawing.Size(269, 36);
            this.utilsTracksBtn.Text = "🗺 TRACKS";
            // 
            // tracksExportAsBtn
            // 
            this.tracksExportAsBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tracksExportAsBtn.Name = "tracksExportAsBtn";
            this.tracksExportAsBtn.ShortcutKeyDisplayString = "Ctrl+S";
            this.tracksExportAsBtn.Size = new System.Drawing.Size(325, 36);
            this.tracksExportAsBtn.Text = "💾 Export as...";
            this.tracksExportAsBtn.ToolTipText = "Export tracks data";
            this.tracksExportAsBtn.Click += new System.EventHandler(this.tracksExportAsBtn_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(322, 6);
            // 
            // trackImportBtn
            // 
            this.trackImportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.trackImportBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackImportBtn.Name = "trackImportBtn";
            this.trackImportBtn.Size = new System.Drawing.Size(325, 36);
            this.trackImportBtn.Text = "📂Import...";
            this.trackImportBtn.Click += new System.EventHandler(this.trackImportBtn_Click);
            // 
            // tracksClearAllBtn
            // 
            this.tracksClearAllBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tracksClearAllBtn.Name = "tracksClearAllBtn";
            this.tracksClearAllBtn.Size = new System.Drawing.Size(325, 36);
            this.tracksClearAllBtn.Text = "🗑 Clear all";
            this.tracksClearAllBtn.ToolTipText = "Clear all tracks data";
            this.tracksClearAllBtn.Click += new System.EventHandler(this.tracksClearAllBtn_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(266, 6);
            // 
            // utilsOverridesBtn
            // 
            this.utilsOverridesBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ovrSalinityBtn,
            this.ovrWaterTemperatureBtn,
            this.ovrAtmosphericPressureBtn});
            this.utilsOverridesBtn.Name = "utilsOverridesBtn";
            this.utilsOverridesBtn.Size = new System.Drawing.Size(269, 36);
            this.utilsOverridesBtn.Text = "🔂 OVERRIDE...";
            // 
            // ovrSalinityBtn
            // 
            this.ovrSalinityBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ovrSalinityBtn.Name = "ovrSalinityBtn";
            this.ovrSalinityBtn.ShortcutKeyDisplayString = "Alt+S";
            this.ovrSalinityBtn.Size = new System.Drawing.Size(391, 36);
            this.ovrSalinityBtn.Text = "🧂 Water salinity";
            this.ovrSalinityBtn.Click += new System.EventHandler(this.ovrSalinityBtn_Click);
            // 
            // ovrWaterTemperatureBtn
            // 
            this.ovrWaterTemperatureBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ovrWaterTemperatureBtn.Name = "ovrWaterTemperatureBtn";
            this.ovrWaterTemperatureBtn.ShortcutKeyDisplayString = "Alt+T";
            this.ovrWaterTemperatureBtn.Size = new System.Drawing.Size(391, 36);
            this.ovrWaterTemperatureBtn.Text = "🌡 Water temperature";
            this.ovrWaterTemperatureBtn.Click += new System.EventHandler(this.ovrWaterTemperatureBtn_Click);
            // 
            // ovrAtmosphericPressureBtn
            // 
            this.ovrAtmosphericPressureBtn.Enabled = false;
            this.ovrAtmosphericPressureBtn.Name = "ovrAtmosphericPressureBtn";
            this.ovrAtmosphericPressureBtn.Size = new System.Drawing.Size(391, 36);
            this.ovrAtmosphericPressureBtn.Text = "☁ Atmospheric pressure";
            this.ovrAtmosphericPressureBtn.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(111, 35);
            this.infoBtn.Text = "ℹ INFO";
            this.infoBtn.ToolTipText = "Additional information (Ctrl + I)";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // secondaryToolStrip
            // 
            this.secondaryToolStrip.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondaryToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.secondaryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markPointBtn,
            this.toolStripSeparator5,
            this.markedPointsVisibleBtn,
            this.toolStripSeparator6,
            this.buoysVisibleBtn,
            this.toolStripSeparator7,
            this.historyVisibleBtn,
            this.toolStripSeparator8,
            this.plotLegendVisibleBtn,
            this.toolStripSeparator9,
            this.notesVisibleBtn,
            this.toolStripSeparator10,
            this.extraInfoVisibleBtn,
            this.toolStripSeparator11,
            this.resetViewBtn,
            this.toolStripSeparator12,
            this.accuracyEstimationBtn,
            this.toolStripSeparator13,
            this.navToLbl,
            this.navPointCbx,
            this.toolStripSeparator22,
            this.followMapBtn,
            this.showTilesBtn});
            this.secondaryToolStrip.Location = new System.Drawing.Point(0, 38);
            this.secondaryToolStrip.Name = "secondaryToolStrip";
            this.secondaryToolStrip.Size = new System.Drawing.Size(782, 39);
            this.secondaryToolStrip.TabIndex = 1;
            this.secondaryToolStrip.Text = "toolStrip2";
            // 
            // markPointBtn
            // 
            this.markPointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.markPointBtn.Image = ((System.Drawing.Image)(resources.GetObject("markPointBtn.Image")));
            this.markPointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.markPointBtn.Name = "markPointBtn";
            this.markPointBtn.Size = new System.Drawing.Size(50, 36);
            this.markPointBtn.Text = "✔";
            this.markPointBtn.ToolTipText = "Mark current location (Ctrl + M)";
            this.markPointBtn.Click += new System.EventHandler(this.markPointBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // markedPointsVisibleBtn
            // 
            this.markedPointsVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.markedPointsVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("markedPointsVisibleBtn.Image")));
            this.markedPointsVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.markedPointsVisibleBtn.Name = "markedPointsVisibleBtn";
            this.markedPointsVisibleBtn.Size = new System.Drawing.Size(50, 36);
            this.markedPointsVisibleBtn.Text = "📌";
            this.markedPointsVisibleBtn.ToolTipText = "Show marked points";
            this.markedPointsVisibleBtn.Click += new System.EventHandler(this.markedPointsVisible_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // buoysVisibleBtn
            // 
            this.buoysVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buoysVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("buoysVisibleBtn.Image")));
            this.buoysVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buoysVisibleBtn.Name = "buoysVisibleBtn";
            this.buoysVisibleBtn.Size = new System.Drawing.Size(50, 36);
            this.buoysVisibleBtn.Text = "🍍";
            this.buoysVisibleBtn.ToolTipText = "Show buoys";
            this.buoysVisibleBtn.Click += new System.EventHandler(this.buoysVisibleBtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // historyVisibleBtn
            // 
            this.historyVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.historyVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("historyVisibleBtn.Image")));
            this.historyVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyVisibleBtn.Name = "historyVisibleBtn";
            this.historyVisibleBtn.Size = new System.Drawing.Size(50, 36);
            this.historyVisibleBtn.Text = "📜";
            this.historyVisibleBtn.ToolTipText = "Show history scroll (log)";
            this.historyVisibleBtn.Click += new System.EventHandler(this.historyVisibleBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 39);
            // 
            // plotLegendVisibleBtn
            // 
            this.plotLegendVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.plotLegendVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("plotLegendVisibleBtn.Image")));
            this.plotLegendVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plotLegendVisibleBtn.Name = "plotLegendVisibleBtn";
            this.plotLegendVisibleBtn.Size = new System.Drawing.Size(29, 36);
            this.plotLegendVisibleBtn.Text = "⁞";
            this.plotLegendVisibleBtn.ToolTipText = "Show legend";
            this.plotLegendVisibleBtn.Click += new System.EventHandler(this.plotLegendVisibleBtn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 39);
            // 
            // notesVisibleBtn
            // 
            this.notesVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.notesVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("notesVisibleBtn.Image")));
            this.notesVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.notesVisibleBtn.Name = "notesVisibleBtn";
            this.notesVisibleBtn.Size = new System.Drawing.Size(48, 36);
            this.notesVisibleBtn.Text = "📑";
            this.notesVisibleBtn.ToolTipText = "Show notes";
            this.notesVisibleBtn.Click += new System.EventHandler(this.notesVisibleBtn_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // extraInfoVisibleBtn
            // 
            this.extraInfoVisibleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.extraInfoVisibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("extraInfoVisibleBtn.Image")));
            this.extraInfoVisibleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.extraInfoVisibleBtn.Name = "extraInfoVisibleBtn";
            this.extraInfoVisibleBtn.Size = new System.Drawing.Size(46, 36);
            this.extraInfoVisibleBtn.Text = "👽";
            this.extraInfoVisibleBtn.ToolTipText = "Show extra information";
            this.extraInfoVisibleBtn.Click += new System.EventHandler(this.extraInfoVisibleBtn_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 39);
            // 
            // resetViewBtn
            // 
            this.resetViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("resetViewBtn.Image")));
            this.resetViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetViewBtn.Name = "resetViewBtn";
            this.resetViewBtn.Size = new System.Drawing.Size(50, 36);
            this.resetViewBtn.Text = "❌";
            this.resetViewBtn.ToolTipText = "Clear current view (tracks will remain unchanged)";
            this.resetViewBtn.Click += new System.EventHandler(this.resetViewBtn_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 39);
            // 
            // accuracyEstimationBtn
            // 
            this.accuracyEstimationBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.accuracyEstimationBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accuracyEstimationStartStopBtn,
            this.toolStripSeparator19,
            this.accuracyEstimationClearDataBtn});
            this.accuracyEstimationBtn.Image = ((System.Drawing.Image)(resources.GetObject("accuracyEstimationBtn.Image")));
            this.accuracyEstimationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.accuracyEstimationBtn.Name = "accuracyEstimationBtn";
            this.accuracyEstimationBtn.Size = new System.Drawing.Size(60, 36);
            this.accuracyEstimationBtn.Text = "🎯";
            this.accuracyEstimationBtn.ToolTipText = "Statistic utilities";
            // 
            // accuracyEstimationStartStopBtn
            // 
            this.accuracyEstimationStartStopBtn.Name = "accuracyEstimationStartStopBtn";
            this.accuracyEstimationStartStopBtn.Size = new System.Drawing.Size(244, 36);
            this.accuracyEstimationStartStopBtn.Text = "⏺ Start";
            this.accuracyEstimationStartStopBtn.ToolTipText = "Start statistic test (target should be fixed)";
            this.accuracyEstimationStartStopBtn.Click += new System.EventHandler(this.accuracyEstimationStartStopBtn_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(241, 6);
            // 
            // accuracyEstimationClearDataBtn
            // 
            this.accuracyEstimationClearDataBtn.Name = "accuracyEstimationClearDataBtn";
            this.accuracyEstimationClearDataBtn.Size = new System.Drawing.Size(244, 36);
            this.accuracyEstimationClearDataBtn.Text = "🗑 Clear data";
            this.accuracyEstimationClearDataBtn.ToolTipText = "Clear current statistic test data";
            this.accuracyEstimationClearDataBtn.Click += new System.EventHandler(this.accuracyEstimationClearDataBtn_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 39);
            // 
            // navToLbl
            // 
            this.navToLbl.Name = "navToLbl";
            this.navToLbl.Size = new System.Drawing.Size(46, 36);
            this.navToLbl.Text = "🧭";
            // 
            // navPointCbx
            // 
            this.navPointCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.navPointCbx.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.navPointCbx.Name = "navPointCbx";
            this.navPointCbx.Size = new System.Drawing.Size(150, 39);
            this.navPointCbx.ToolTipText = "Select base point to navigate to/from";
            this.navPointCbx.SelectedIndexChanged += new System.EventHandler(this.navPointCbx_SelectedIndexChanged);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 39);
            // 
            // followMapBtn
            // 
            this.followMapBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.followMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("followMapBtn.Image")));
            this.followMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.followMapBtn.Name = "followMapBtn";
            this.followMapBtn.Size = new System.Drawing.Size(43, 36);
            this.followMapBtn.Text = "🡹";
            this.followMapBtn.ToolTipText = "Follow target (Ctrl + F)";
            this.followMapBtn.Click += new System.EventHandler(this.followMapBtn_Click);
            // 
            // showTilesBtn
            // 
            this.showTilesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showTilesBtn.Image = ((System.Drawing.Image)(resources.GetObject("showTilesBtn.Image")));
            this.showTilesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showTilesBtn.Name = "showTilesBtn";
            this.showTilesBtn.Size = new System.Drawing.Size(50, 35);
            this.showTilesBtn.Text = "🗺";
            this.showTilesBtn.ToolTipText = "Show/Hide map tiles (Ctrl + T)";
            this.showTilesBtn.Click += new System.EventHandler(this.showTilesBtn_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplPortStatusLbl,
            this.auxGNSSPortStatusLbl,
            this.bottomLinkLbl,
            this.moonPhaseLbl});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 519);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.ShowItemToolTips = true;
            this.mainStatusStrip.Size = new System.Drawing.Size(782, 34);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // aplPortStatusLbl
            // 
            this.aplPortStatusLbl.Name = "aplPortStatusLbl";
            this.aplPortStatusLbl.Size = new System.Drawing.Size(24, 28);
            this.aplPortStatusLbl.Text = "...";
            this.aplPortStatusLbl.ToolTipText = "Port status";
            // 
            // auxGNSSPortStatusLbl
            // 
            this.auxGNSSPortStatusLbl.Name = "auxGNSSPortStatusLbl";
            this.auxGNSSPortStatusLbl.Size = new System.Drawing.Size(24, 28);
            this.auxGNSSPortStatusLbl.Text = "...";
            // 
            // bottomLinkLbl
            // 
            this.bottomLinkLbl.IsLink = true;
            this.bottomLinkLbl.Name = "bottomLinkLbl";
            this.bottomLinkLbl.Size = new System.Drawing.Size(695, 28);
            this.bottomLinkLbl.Spring = true;
            this.bottomLinkLbl.Text = ". . .";
            this.bottomLinkLbl.Click += new System.EventHandler(this.bottomLinkLbl_Click);
            // 
            // moonPhaseLbl
            // 
            this.moonPhaseLbl.AutoToolTip = true;
            this.moonPhaseLbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.moonPhaseLbl.Name = "moonPhaseLbl";
            this.moonPhaseLbl.Size = new System.Drawing.Size(24, 28);
            this.moonPhaseLbl.Text = "...";
            // 
            // bottomToolStrip
            // 
            this.bottomToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bottomToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bottomToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noteTxb,
            this.noteSaveBtn,
            this.toolStripSeparator14,
            this.screenShotBtn,
            this.toolStripSeparator15,
            this.autoscreenshotsBtn});
            this.bottomToolStrip.Location = new System.Drawing.Point(0, 484);
            this.bottomToolStrip.Name = "bottomToolStrip";
            this.bottomToolStrip.Size = new System.Drawing.Size(782, 35);
            this.bottomToolStrip.TabIndex = 3;
            this.bottomToolStrip.Text = "toolStrip3";
            // 
            // noteTxb
            // 
            this.noteTxb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.noteTxb.Name = "noteTxb";
            this.noteTxb.Size = new System.Drawing.Size(200, 35);
            this.noteTxb.ToolTipText = "Write a note, that will be saved to the log file";
            this.noteTxb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.noteTxb_KeyDown);
            this.noteTxb.TextChanged += new System.EventHandler(this.noteTxb_TextChanged);
            // 
            // noteSaveBtn
            // 
            this.noteSaveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.noteSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("noteSaveBtn.Image")));
            this.noteSaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.noteSaveBtn.Name = "noteSaveBtn";
            this.noteSaveBtn.Size = new System.Drawing.Size(70, 32);
            this.noteSaveBtn.Text = "➕📝";
            this.noteSaveBtn.ToolTipText = "Type a note and press \'Enter\' to store it in the log file";
            this.noteSaveBtn.Click += new System.EventHandler(this.noteSaveBtn_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 35);
            // 
            // screenShotBtn
            // 
            this.screenShotBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.screenShotBtn.Image = ((System.Drawing.Image)(resources.GetObject("screenShotBtn.Image")));
            this.screenShotBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.screenShotBtn.Name = "screenShotBtn";
            this.screenShotBtn.Size = new System.Drawing.Size(43, 32);
            this.screenShotBtn.Text = "📸";
            this.screenShotBtn.ToolTipText = "Save a screenshot (Ctrl + P)";
            this.screenShotBtn.Click += new System.EventHandler(this.screenShotBtn_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 35);
            // 
            // autoscreenshotsBtn
            // 
            this.autoscreenshotsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.autoscreenshotsBtn.Image = ((System.Drawing.Image)(resources.GetObject("autoscreenshotsBtn.Image")));
            this.autoscreenshotsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoscreenshotsBtn.Name = "autoscreenshotsBtn";
            this.autoscreenshotsBtn.Size = new System.Drawing.Size(43, 32);
            this.autoscreenshotsBtn.Text = "🎞";
            this.autoscreenshotsBtn.ToolTipText = "Start/Stop autosaving screenshots every 1 second";
            this.autoscreenshotsBtn.Click += new System.EventHandler(this.autoscreenshotsBtn_Click);
            // 
            // bottomSecondaryToolStrip
            // 
            this.bottomSecondaryToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomSecondaryToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bottomSecondaryToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bottomSecondaryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialOutputLbl,
            this.serialOutputPortsRefreshBtn,
            this.serialOutputPortNameCbx,
            this.serialOutputLinkBtn,
            this.toolStripSeparator20,
            this.zoomInBtn,
            this.zoomOutBtn});
            this.bottomSecondaryToolStrip.Location = new System.Drawing.Point(0, 449);
            this.bottomSecondaryToolStrip.Name = "bottomSecondaryToolStrip";
            this.bottomSecondaryToolStrip.Size = new System.Drawing.Size(782, 35);
            this.bottomSecondaryToolStrip.TabIndex = 5;
            this.bottomSecondaryToolStrip.Text = "toolStrip1";
            // 
            // serialOutputLbl
            // 
            this.serialOutputLbl.Name = "serialOutputLbl";
            this.serialOutputLbl.Size = new System.Drawing.Size(129, 32);
            this.serialOutputLbl.Text = "Serial output:";
            // 
            // serialOutputPortsRefreshBtn
            // 
            this.serialOutputPortsRefreshBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.serialOutputPortsRefreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("serialOutputPortsRefreshBtn.Image")));
            this.serialOutputPortsRefreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.serialOutputPortsRefreshBtn.Name = "serialOutputPortsRefreshBtn";
            this.serialOutputPortsRefreshBtn.Size = new System.Drawing.Size(43, 32);
            this.serialOutputPortsRefreshBtn.Text = "🔄";
            this.serialOutputPortsRefreshBtn.ToolTipText = "Refresh ports list";
            this.serialOutputPortsRefreshBtn.Click += new System.EventHandler(this.serialOutputPortsRefreshBtn_Click);
            // 
            // serialOutputPortNameCbx
            // 
            this.serialOutputPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialOutputPortNameCbx.Name = "serialOutputPortNameCbx";
            this.serialOutputPortNameCbx.Size = new System.Drawing.Size(121, 35);
            // 
            // serialOutputLinkBtn
            // 
            this.serialOutputLinkBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.serialOutputLinkBtn.Image = ((System.Drawing.Image)(resources.GetObject("serialOutputLinkBtn.Image")));
            this.serialOutputLinkBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.serialOutputLinkBtn.Name = "serialOutputLinkBtn";
            this.serialOutputLinkBtn.Size = new System.Drawing.Size(41, 32);
            this.serialOutputLinkBtn.Text = "🔌";
            this.serialOutputLinkBtn.ToolTipText = "Enable/Disable output via serial port";
            this.serialOutputLinkBtn.Click += new System.EventHandler(this.serialOutputLinkBtn_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 35);
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomInBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomInBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomInBtn.Image")));
            this.zoomInBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(70, 32);
            this.zoomInBtn.Text = "🔍➕";
            this.zoomInBtn.ToolTipText = "Zoom in (Ctrl +)";
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomOutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomOutBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutBtn.Image")));
            this.zoomOutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(70, 32);
            this.zoomOutBtn.Text = "🔍➖";
            this.zoomOutBtn.ToolTipText = "Zoom out (Ctrl -)";
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // plot
            // 
            this.plot.BackColor = System.Drawing.Color.PowderBlue;
            this.plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plot.GridSizeVisible = true;
            this.plot.HistoryFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plot.HistoryLinesNumber = 4;
            this.plot.HistoryTextColor = System.Drawing.Color.Green;
            this.plot.HistoryVisible = true;
            this.plot.LeftUpperText = null;
            this.plot.LeftUpperTextBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.plot.LeftUpperTextColor = System.Drawing.Color.MidnightBlue;
            this.plot.LeftUpperTextFont = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plot.LeftUpperTextVisible = true;
            this.plot.LegendFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plot.LegendVisible = false;
            this.plot.Location = new System.Drawing.Point(0, 77);
            this.plot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plot.MeasuringLineBackgroundColor = System.Drawing.Color.Black;
            this.plot.MeasuringLineBackTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.plot.MeasuringLineColor = System.Drawing.Color.Black;
            this.plot.MeasuringLineCrossSize = 15;
            this.plot.MeasuringLineFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plot.MeasuringLineTextColor = System.Drawing.Color.Black;
            this.plot.MeasuringLineWidth = 1F;
            this.plot.Name = "plot";
            this.plot.Padding = new System.Windows.Forms.Padding(10);
            this.plot.RightUpperTextBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.plot.RightUpperTextColor = System.Drawing.Color.Brown;
            this.plot.RightUpperTextFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plot.RightUpperTextVisible = true;
            this.plot.ScaleLineBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.plot.ScaleLineColor = System.Drawing.Color.Black;
            this.plot.ScaleLineFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plot.ScaleLineTextColor = System.Drawing.Color.Black;
            this.plot.ScaleLineWidth = 2F;
            this.plot.ScaleTickSize = 10F;
            this.plot.ShowZoomLevel = true;
            this.plot.Size = new System.Drawing.Size(782, 372);
            this.plot.TabIndex = 6;
            this.plot.TileBorderColor = System.Drawing.Color.Gray;
            this.plot.TileBorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.plot.TileBordersVisible = true;
            this.plot.TileBorderWidth = 1F;
            this.plot.TilesEnabled = true;
            this.plot.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.plot_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.plot);
            this.Controls.Add(this.bottomSecondaryToolStrip);
            this.Controls.Add(this.bottomToolStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.secondaryToolStrip);
            this.Controls.Add(this.mainToolStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.secondaryToolStrip.ResumeLayout(false);
            this.secondaryToolStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.bottomToolStrip.ResumeLayout(false);
            this.bottomToolStrip.PerformLayout();
            this.bottomSecondaryToolStrip.ResumeLayout(false);
            this.bottomSecondaryToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStrip secondaryToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStrip bottomToolStrip;
        private System.Windows.Forms.ToolStripButton linkBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton logBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton utilsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private System.Windows.Forms.ToolStripButton markPointBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton markedPointsVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton buoysVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton historyVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton plotLegendVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton notesVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton extraInfoVisibleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton resetViewBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripDropDownButton accuracyEstimationBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripLabel navToLbl;
        private System.Windows.Forms.ToolStripComboBox navPointCbx;
        private System.Windows.Forms.ToolStripTextBox noteTxb;
        private System.Windows.Forms.ToolStripButton noteSaveBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton screenShotBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripStatusLabel aplPortStatusLbl;
        private System.Windows.Forms.ToolStripStatusLabel bottomLinkLbl;
        private System.Windows.Forms.ToolStripMenuItem logViewCurrentBtn;
        private System.Windows.Forms.ToolStripMenuItem logPlaybackBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem logRemoveEmptyEntriesBtn;
        private System.Windows.Forms.ToolStripMenuItem logArchiveAllBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem logDeleteAllBtn;
        private System.Windows.Forms.ToolStripMenuItem logDoThemAllBtn;
        private System.Windows.Forms.ToolStripMenuItem utilsTracksBtn;
        private System.Windows.Forms.ToolStripMenuItem tracksExportAsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem tracksClearAllBtn;
        private System.Windows.Forms.ToolStripMenuItem accuracyEstimationStartStopBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem accuracyEstimationClearDataBtn;
        private System.Windows.Forms.ToolStripStatusLabel moonPhaseLbl;
        private System.Windows.Forms.ToolStrip bottomSecondaryToolStrip;
        private System.Windows.Forms.ToolStripLabel serialOutputLbl;
        private System.Windows.Forms.ToolStripButton serialOutputPortsRefreshBtn;
        private System.Windows.Forms.ToolStripComboBox serialOutputPortNameCbx;
        private System.Windows.Forms.ToolStripButton serialOutputLinkBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem trackImportBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem utilsOverridesBtn;
        private System.Windows.Forms.ToolStripMenuItem ovrSalinityBtn;
        private System.Windows.Forms.ToolStripMenuItem ovrWaterTemperatureBtn;
        private System.Windows.Forms.ToolStripMenuItem ovrAtmosphericPressureBtn;
        private System.Windows.Forms.ToolStripStatusLabel auxGNSSPortStatusLbl;
        private uGeoPlot plot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton followMapBtn;
        private System.Windows.Forms.ToolStripButton showTilesBtn;
        private System.Windows.Forms.ToolStripButton zoomInBtn;
        private System.Windows.Forms.ToolStripButton zoomOutBtn;
        private System.Windows.Forms.ToolStripButton autoscreenshotsBtn;
        private System.Windows.Forms.ToolStripMenuItem logBuildEmulationDataBtn;
    }
}

