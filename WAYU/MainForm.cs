using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLKML;
using UCNLNav;
using UCNLNMEA;
using UCNLUI.Dialogs;
using uOSM;
using WAYU.APL;

namespace WAYU
{
    public partial class MainForm : Form
    {
        #region Properties

        uOSMTileProvider tProvider;

        APLEmulator aplEmu;
        APLLBLCore aplCore;

        TSLogProvider logger;
        SimpleSettingsProviderXML<SettingsContainer> settingsProvider;

        string settingsFileName;
        string logPath;
        string logFileName;
        string snapshotsPath;
        string tileDBPath;

        Dictionary<string, List<GeoPoint3DETm>> tracks;

        bool isRestart = false;

        bool tracksChanged = false;
        bool TracksChanged
        {
            get { return tracksChanged; }
            set
            {
                if (value != tracksChanged)
                {
                    tracksChanged = value;
                    InvokeSetEnabledState(primaryToolStrip, trackExportAsBtn, tracksChanged);
                    InvokeSetEnabledState(primaryToolStrip, trackClearBtn, tracksChanged);
                }
            }
        }

        bool isAutoScreenshot = false;

        Dictionary<TBAQuality, Color> tbaTextColors = new Dictionary<TBAQuality, Color>()
        {
            { TBAQuality.Good, Color.Green },
            { TBAQuality.Fair, Color.DarkGoldenrod },
            { TBAQuality.Poor, Color.Orange },
            { TBAQuality.Out_of_base, Color.Red },
            { TBAQuality.Invalid, Color.Black }
        };

        Dictionary<DOPState, Color> dopTextColors = new Dictionary<DOPState, Color>()
        {
            { DOPState.Ideal, Color.LimeGreen },
            { DOPState.Excellent, Color.Green },
            { DOPState.Good, Color.Olive },
            { DOPState.Moderate, Color.DarkGoldenrod },
            { DOPState.Fair, Color.Orange },
            { DOPState.Poor, Color.Red },
            { DOPState.Invalid, Color.Black }
        };

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            #region Early init

            string vString = string.Format("{0} v{1}", Application.ProductName, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.Text = vString;

            #endregion

            #region paths & filenames

            DateTime startTime = DateTime.Now;
            settingsFileName = Path.ChangeExtension(Application.ExecutablePath, "settings");
            logPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
            logFileName = StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "log", true);
            snapshotsPath = StrUtils.GetTimeDirTree(startTime, Application.ExecutablePath, "SNAPSHOTS", false);
            tileDBPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Cache\\Tiles\\");

            #endregion

            #region logger

            logger = new TSLogProvider(logFileName);
            logger.WriteStart();
            logger.Write(vString);
            logger.TextAddedEvent += (o, e) => InvokeAppendHisotryLine(e.Text);

            #endregion

            #region settings

            settingsProvider = new SimpleSettingsProviderXML<SettingsContainer>();
            settingsProvider.isSwallowExceptions = false;

            logger.Write(string.Format("Loading settings from {0}", settingsFileName));

            try
            {
                settingsProvider.Load(settingsFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            logger.Write("Current application settings:");
            logger.Write(settingsProvider.Data.ToString());

            emuBtn.Visible = settingsProvider.Data.IsEmuEnabled;

            #endregion

            #region custom UI

            List<string> z_track_keys = new List<string>();

            z_track_keys.Add("ALL");
            z_track_keys.Add("WAYU (FLT)");
            z_track_keys.Add("Marked");
            z_track_keys.Add("WAYU (FLT)+Marked");
            
            geoPlot.InitTrack("WAYU (RAW)", 64, Color.Yellow, 1, 4, false, Color.Yellow, 1, 200);
            geoPlot.InitTrack("WAYU (FLT)", settingsProvider.Data.TrackPointsToShow, Color.Red, 1, 4, true, Color.Red, 1, 200);


            if (settingsProvider.Data.IsUseAUX1)
            {
                geoPlot.InitTrack("AUX1", 64, Color.Blue, 1, 4, true, Color.Blue, 1, 200);
                z_track_keys.Add("AUX1");
                z_track_keys.Add("WAYU (FLT)+AUX1");
                z_track_keys.Add("WAYU (FLT)+AUX1+Marked");
            }

            if (settingsProvider.Data.IsUseAUX2)
            {
                geoPlot.InitTrack("AUX2", 64, Color.Blue, 1, 4, true, Color.Violet, 1, 200);
                z_track_keys.Add("AUX2");
                z_track_keys.Add("WAYU (FLT)+AUX2");
                z_track_keys.Add("WAYU (FLT)+AUX2+Marked");
            }

            z_track_keys.Add("BASE 1");
            z_track_keys.Add("BASE 2");
            z_track_keys.Add("BASE 3");
            z_track_keys.Add("BASE 4");
            z_track_keys.Add("WAYU (FLT)+WAYU (RAW)");

            geoPlot.InitTrack("Marked", 256, Color.Black, 4, 4, false, Color.Black, 1, 200);

            geoPlot.InitTrack("BASE 1", 4, Color.DarkRed, 2, 4, false, Color.Salmon, 1, 200);
            geoPlot.InitTrack("BASE 2", 4, Color.DarkOrange, 2, 4, false, Color.Gold, 1, 200);
            geoPlot.InitTrack("BASE 3", 4, Color.Green, 2, 4, false, Color.MediumSpringGreen, 1, 200);
            geoPlot.InitTrack("BASE 4", 4, Color.Purple, 2, 4, false, Color.SkyBlue, 1, 200);


            fitTracksCbx.Items.Clear();
            fitTracksCbx.Items.AddRange(z_track_keys.ToArray());
            fitTracksCbx.SelectedIndex = 0;

            geoPlot.SetTracksVisibility(true);
            geoPlot.TextBackgroundColor = Color.FromArgb(127, Color.White);

            #endregion

            #region custom items

            tracks = new Dictionary<string, List<GeoPoint3DETm>>();

            #endregion

            #region aplCore

            Dictionary<string, SerialPortSettings> ports = new Dictionary<string, SerialPortSettings>();
            ports.Add("WAYU GIBs",
                new SerialPortSettings(settingsProvider.Data.InPortName,
                    settingsProvider.Data.InPortBaudrate, 
                    System.IO.Ports.Parity.None, 
                    DataBits.dataBits8, 
                    System.IO.Ports.StopBits.One, 
                    System.IO.Ports.Handshake.None));

            if (settingsProvider.Data.IsUseAUX1)
            {
                ports.Add("AUX1",
                    new SerialPortSettings(settingsProvider.Data.AUX1PortName,
                        settingsProvider.Data.AUX1PortBaudrate,
                        System.IO.Ports.Parity.None,
                        DataBits.dataBits8,
                        System.IO.Ports.StopBits.One,
                        System.IO.Ports.Handshake.None));
            }

            if (settingsProvider.Data.IsUseAUX2)
            {
                ports.Add("AUX2",
                    new SerialPortSettings(settingsProvider.Data.AUX2PortName,
                        settingsProvider.Data.AUX2PortBaudrate,
                        System.IO.Ports.Parity.None,
                        DataBits.dataBits8,
                        System.IO.Ports.StopBits.One,
                        System.IO.Ports.Handshake.None));
            }

            aplCore = new APLLBLCore(ports,
                settingsProvider.Data.RadialErrorThresholdM,
                settingsProvider.Data.InitialSimplexSizeM,
                settingsProvider.Data.CourseEstimatorFIFOSize,
                settingsProvider.Data.TrackFilterFIFOSize);

            if ((settingsProvider.Data.PrimaryGNSSAUXID == AUX_IDs.AUX1) &&
                (settingsProvider.Data.IsUseAUX1))
            {
                aplCore.SetPrimaryGNSSSource("AUX1");                
            }
            else if ((settingsProvider.Data.PrimaryGNSSAUXID == AUX_IDs.AUX2) &&
                (settingsProvider.Data.IsUseAUX2))
            {
                aplCore.SetPrimaryGNSSSource("AUX2");
            }
            
            if (settingsProvider.Data.IsUseOutputPort)
            {
                aplCore.InitOutputPort(
                    new SerialPortSettings(settingsProvider.Data.OutputPortName,
                        settingsProvider.Data.OutputPortBaudrate,
                        System.IO.Ports.Parity.None,
                        DataBits.dataBits8,
                        System.IO.Ports.StopBits.One,
                        System.IO.Ports.Handshake.None));
            }

            aplCore.InfoEventHandler += (o, e) => logger.Write(string.Format("({0}) {1}", e.EventType, e.LogString));
            aplCore.PortStateChangedHandler += (o, e) => InvokeSetStatusStripLblText(mainStatusStrip, portStatesLbl, aplCore.GetPortsStateDescription());            
            aplCore.TrackUpdateHandler += (o, e) =>
                {
                    if (!tracks.ContainsKey(e.TrackID))
                        tracks.Add(e.TrackID, new List<GeoPoint3DETm>());
                    tracks[e.TrackID].Add(e.TrackPoint);
                    InvokeUpdateTracksPlot(e, true);

                    if (isAutoScreenshot)
                        InvokeSaveFullScreenshot();

                    TracksChanged = true;
                };
            aplCore.SystemUpdateHandler += (o, e) =>
            {
                if (geoPlot.InvokeRequired)
                {
                    var sString = aplCore.GetSystemStateDescription();
                    var tString = aplCore.GetTargetStateDescription();
                    StringBuilder sb = new StringBuilder();
                    if (!string.IsNullOrEmpty(sString))
                        sb.AppendFormat("SYSTEM:\r\n{0}\r\n", sString);
                    if (!string.IsNullOrEmpty(tString))
                        sb.AppendFormat("TARGET:\r\n{0}", tString);

                    geoPlot.LeftUpperText = sb.ToString();
                    geoPlot.Invalidate();
                }
                else
                {
                    var sString = aplCore.GetSystemStateDescription();
                    var tString = aplCore.GetTargetStateDescription();
                    StringBuilder sb = new StringBuilder();
                    if (!string.IsNullOrEmpty(sString))
                        sb.AppendFormat("SYSTEM:\r\n{0}\r\n", sString);
                    if (!string.IsNullOrEmpty(tString))
                        sb.AppendFormat("TARGET:\r\n{0}", tString);

                    geoPlot.LeftUpperText = sb.ToString();
                    geoPlot.Invalidate();
                }

                InvokeSetText(secondaryToolStrip, tbaLbl, aplCore.tbaQuality.ToString());
                InvokeSetColorMode(secondaryToolStrip, tbaLbl, tbaTextColors[aplCore.tbaQuality.Value]);

                InvokeSetText(secondaryToolStrip, hdopLbl, aplCore.dopState.ToString());
                InvokeSetColorMode(secondaryToolStrip, hdopLbl, dopTextColors[aplCore.dopState.Value]);
            };

            #endregion            

            #region aplEmu

            if (settingsProvider.Data.IsEmuEnabled)
            {
                aplEmu = new APLEmulator();
                aplEmu.EmulatorOutputEvent += (o, e) =>
                    {
                        aplCore.Emulate(e.Message);
                    };
            }

            #endregion

            #region tProvider

            tProvider = new uOSMTileProvider(256, 19, new Size(256, 256), tileDBPath, settingsProvider.Data.TileServers);
            geoPlot.ConnectTileProvider(tProvider);

            #endregion
        }

        #endregion

        #region Methods

        private void SaveFullScreenshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                target.Save(Path.Combine(snapshotsPath, string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png)));
            }
            catch
            {
                //
            }
        }

        private void InvokeSaveFullScreenshot()
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { SaveFullScreenshot(); });
            else
                SaveFullScreenshot();
        }

        private void ProcessException(Exception ex, bool isShowMsgBox)
        {
            logger.Write(ex);

            if (isShowMsgBox)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InvokeAppendHisotryLine(string line)
        {
            if (geoPlot.InvokeRequired)
                geoPlot.Invoke((MethodInvoker)delegate 
                { 
                    geoPlot.AppendHistory(line);
                    geoPlot.Invalidate();
                });
            else
            {
                geoPlot.AppendHistory(line);
                geoPlot.Invalidate();
            }
        }

        private void ProcessAnalyzeLog(string fileName)
        {
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = string.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        int idx = s.IndexOf(NMEAParser.SentenceStartDelimiter);
                        if (idx >= 0)
                        {
                            aplCore.Emulate(s.Substring(idx) + "\r\n");
                            Application.DoEvents();
                        }
                    }
                }

                MessageBox.Show(string.Format("Playback of '{0}' is finished", Path.GetFileNameWithoutExtension(fileName)),
                    "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private bool TracksExportToKML(string fileName)
        {
            KMLData data = new KMLData(fileName, string.Format("Generated by {0}", Application.ProductName));
            List<KMLLocation> kmlTrack;

            foreach (var item in tracks)
            {
                kmlTrack = new List<KMLLocation>();
                foreach (var point in item.Value)
                    kmlTrack.Add(new KMLLocation(point.Longitude, point.Latitude, -point.Depth));

                data.Add(new KMLPlacemark(string.Format("{0} track", item.Key), "", kmlTrack.ToArray()));
            }

            bool isOk = false;
            try
            {
                TinyKML.Write(data, fileName);
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        private bool TracksExportToCSV(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var track in tracks)
            {
                sb.AppendFormat("\r\nTrack name: {0}\r\n", track.Key);
                sb.Append("HH:MM:SS;LAT;LON;DPT;\r\n");

                foreach (var point in track.Value)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture,
                        "{0:00};{1:00};{2:00};{3:F06};{4:F06};{5:F03}\r\n",
                        point.TimeStamp.Hour,
                        point.TimeStamp.Minute,
                        point.TimeStamp.Second,
                        point.Latitude,
                        point.Longitude,
                        point.Depth);
                }
            }

            bool isOk = false;
            try
            {
                File.WriteAllText(fileName, sb.ToString());
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        private void OnConnectionStateChanged(bool state)
        {
            connectionBtn.Checked = state;
            settingsBtn.Enabled = !state;
            logPlaybackBtn.Enabled = !state;
            emuBtn.Enabled = !state;
        }

        private void InvokeSetStatusStripLblText(StatusStrip strip, ToolStripStatusLabel lbl, string text)
        {
            if (strip.InvokeRequired)
            {
                strip.Invoke((MethodInvoker)delegate { lbl.Text = text; });
            }
            else
            {
                lbl.Text = text;
            }
        }

        private void InvokeSetText(ToolStrip strip, ToolStripLabel lbl, string text)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { lbl.Text = text; });
            else
                lbl.Text = text;
        }

        private void InvokeSetColorMode(ToolStrip strip, ToolStripLabel lbl, Color foreColor)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { lbl.ForeColor = foreColor; });
            else
                lbl.ForeColor = foreColor;
        }

        private void InvokeSetEnabledState(ToolStrip strip, ToolStripItem item, bool enabled)
        {
            if (strip.InvokeRequired)
            {
                strip.Invoke((MethodInvoker)delegate { item.Enabled = enabled; });
            }
            else
            {
                item.Enabled = enabled;
            }
        }

        private void InvokeSetEnabledState(Control ctrl, bool enabled)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke((MethodInvoker)delegate { ctrl.Enabled = enabled; });
            }
            else
            {
                ctrl.Enabled = enabled;
            }
        }

        private void InvokeUpdateTracksPlot(TrackUpdateEventArgs e, bool isInvalidate)
        {
            if (geoPlot.InvokeRequired)
            {
                geoPlot.Invoke((MethodInvoker)delegate
                {
                    if (!double.IsNaN(e.Course_deg))
                        geoPlot.AddPoint(e.TrackID, e.TrackPoint.Latitude, e.TrackPoint.Longitude, e.Course_deg);
                    else
                        geoPlot.AddPoint(e.TrackID, e.TrackPoint.Latitude, e.TrackPoint.Longitude);

                    if (isInvalidate)
                        geoPlot.Invalidate();
                });
            }
            else
            {
                if (!double.IsNaN(e.Course_deg))
                    geoPlot.AddPoint(e.TrackID, e.TrackPoint.Latitude, e.TrackPoint.Longitude, e.Course_deg);
                else
                    geoPlot.AddPoint(e.TrackID, e.TrackPoint.Latitude, e.TrackPoint.Longitude);

                if (isInvalidate)
                    geoPlot.Invalidate();
            }
        }

        private void InvokeUpdatePlot()
        {
            if (geoPlot.InvokeRequired)
                geoPlot.Invoke((MethodInvoker)delegate { geoPlot.Invalidate(); });
            else
                geoPlot.Invalidate();
        }
       
        #endregion        

        #region Handlers

        #region UI controls

        #region primaryToolStrip

        private void connectionBtn_Click(object sender, EventArgs e)
        {
            if (aplCore.IsOpen)
            {
                try
                {
                    aplCore.Close();
                    OnConnectionStateChanged(false);
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }
            }
            else
            {
                try
                {
                    aplCore.Open();
                    OnConnectionStateChanged(true);
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }
            }
        }

        #region TRACK item

        private void trackExportAsBtn_Click(object sender, EventArgs e)
        {
            bool isSaved = false;

            using (SaveFileDialog sDilog = new SaveFileDialog())
            {
                sDilog.Title = "Exporting tracks...";
                sDilog.Filter = "Google KML (*.kml)|*.kml|CSV (*.csv)|*.csv";
                sDilog.FileName = string.Format("ApostleLBL_Tracks_{0}", StrUtils.GetHMSString());

                if (sDilog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (sDilog.FilterIndex == 1)
                        isSaved = TracksExportToKML(sDilog.FileName);
                    else if (sDilog.FilterIndex == 2)
                        isSaved = TracksExportToCSV(sDilog.FileName);
                }
            }

            if (isSaved &&
                MessageBox.Show("Tracks saved, do you want to clear all tracks data?",
                "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tracks.Clear();
                TracksChanged = false;
            }
        }

        private void trackClearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clear all tracks data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                tracks.Clear();
                TracksChanged = false;
            }
        }

        #endregion

        #region LOG item

        private void logViewCurrentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(logger.FileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }        

        private void logPlaybackBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oDialog = new OpenFileDialog())
            {
                oDialog.Title = "Select a LOG file to analyze...";
                oDialog.DefaultExt = "log";
                oDialog.Filter = "LOG files (*.log)|*.log";
                oDialog.InitialDirectory = logPath;

                if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ProcessAnalyzeLog(oDialog.FileName);
                }
            }
        }

        private void logClearAllEntriesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete all log entries?",
                                "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string logRootPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
                var dirs = Directory.GetDirectories(logRootPath);
                int dirNum = 0;
                foreach (var item in dirs)
                {
                    try
                    {
                        Directory.Delete(item, true);
                        dirNum++;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }

                MessageBox.Show(string.Format("{0} entries was/were deleted.", dirNum),
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        #endregion

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            using (SettingsEditor sEditor = new SettingsEditor())
            {
                sEditor.Text = string.Format("{0} - [Settings Editor]", Application.ProductName);
                sEditor.Value = settingsProvider.Data;

                if (sEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bool isSaved = false;
                    settingsProvider.Data = sEditor.Value;

                    try
                    {
                        settingsProvider.Save(settingsFileName);
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }

                    if ((isSaved) && (MessageBox.Show("Settings saved. Restart application to apply new settings?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
                    {
                        isRestart = true;
                        Application.Restart();
                    }
                }
            }
        }

        private void emuBtn_Click(object sender, EventArgs e)
        {
            if (aplEmu.IsRunning)
            {
                aplEmu.Stop();
                emuBtn.Checked = false;
                //connectionBtn.Enabled = true;
                logPlaybackBtn.Enabled = true;
                settingsBtn.Enabled = true;
            }
            else
            {
                aplEmu.Start();
                emuBtn.Checked = true;
                //connectionBtn.Enabled = false;
                logPlaybackBtn.Enabled = false;
                settingsBtn.Enabled = false;
            }
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());
                aDialog.Weblink = "www.unavlab.com";
                aDialog.ShowDialog();
            }
        }

        #endregion

        #region secondaryToolStrip

        private void markPointBtn_Click(object sender, EventArgs e)
        {
            aplCore.MarkTargetLocation();
        }

        private void autoscreenshotBtn_Click(object sender, EventArgs e)
        {
            isAutoScreenshot = !isAutoScreenshot;
            autoscreenshotBtn.Checked = isAutoScreenshot;
        }       

        #endregion

        #region plotStrip

        private void zoomByCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ztrackkey = fitTracksCbx.SelectedItem.ToString();
            if (ztrackkey == "ALL")
            {
                geoPlot.SetTracksVisibility(true);
            }
            else
            {
                var splits = ztrackkey.Split(new char[] { '+' });
                geoPlot.SetTracksVisibility(splits, true);
            }

            geoPlot.Invalidate();
        }

        private void isHistoryLinesVisibleBtn_Click(object sender, EventArgs e)
        {
            geoPlot.HistoryVisible = !geoPlot.HistoryVisible;
            isHistoryLinesVisibleBtn.Checked = geoPlot.HistoryVisible;
        }

        #endregion

        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tracksChanged)
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.Yes;
                while (tracksChanged && (result == System.Windows.Forms.DialogResult.Yes))
                {
                    result = MessageBox.Show("Tracks are not saved. Save them before exit?",
                        "Warning",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);
                    
                    if (result == System.Windows.Forms.DialogResult.Yes)
                        trackExportAsBtn_Click(sender, null);
                }

                e.Cancel = (result == System.Windows.Forms.DialogResult.Cancel);
            }
            else
            {
                e.Cancel = !isRestart && (MessageBox.Show(string.Format("Close {0}?", Application.ProductName),
                                                          "Question",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (aplCore != null)
            {
                if (aplCore.IsOpen)
                {
                    try
                    {
                        aplCore.Open();
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, false);
                    }
                }

                aplCore.Dispose();
            }            

            logger.Write("Closing application...");
            logger.FinishLog();
            logger.Flush();
        }        

        #endregion                                        
        
        #endregion

        #endregion        
    }
}
