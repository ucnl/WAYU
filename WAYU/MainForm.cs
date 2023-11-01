using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Ports;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLUI;
using UCNLUI.Dialogs;
using uOSM;
using WAYU.APL;
using WAYU.ExtraUI;

namespace WAYU
{
    public partial class MainForm : Form
    {
        #region Properties

        static readonly string appicon = "🐠";

        bool isRestart = false;

        string logPath;
        string logFileName;
        string settingsFileName;
        string uiSettingsFileName;
        string snapshotsPath;
        string tileDBPath;

        int autoscreenshot_idx = 0;
        string autoscreenshots_path;
        PrecisionTimer uTimer;

        SimpleSettingsProviderXML<SettingsContainer> sProvider;
        SimpleSettingsProvider<UISettingsContainer> usProvider;

        readonly TSLogProvider logger;
        readonly LogPlayer lPlayer;
        readonly TrackManager tManager;
        readonly UIAutomation uiAutomation;
        readonly uOSMTileProvider tProvider;
        readonly APLCore core;

        #region uiAutomation

        bool markedPointsVisible
        {
            get => markedPointsVisibleBtn.Checked;
            set
            {
                markedPointsVisibleBtn.Checked = value;
                usProvider.Data.MarkedPointsVisible = value;
                plot.SetTracksVisibility(APL.APL.MarkedPointsTrackID, value);
                plot.Invalidate();
            }
        }

        bool buoysVisible
        {
            get => buoysVisibleBtn.Checked;
            set
            {
                buoysVisibleBtn.Checked = value;
                usProvider.Data.BuoysVisible = value;
                plot.SetTracksVisibility(APL.APL.BuoysTracksIDs, value);
                plot.Invalidate();
            }
        }

        bool historyVisible
        {
            get => historyVisibleBtn.Checked;
            set
            {
                historyVisibleBtn.Checked = value;
                usProvider.Data.HistoryVisible = value;
                plot.HistoryVisible = value;
                plot.Invalidate();
            }
        }

        bool plotLegendVisible
        {
            get => plotLegendVisibleBtn.Checked;
            set
            {
                plotLegendVisibleBtn.Checked = value;
                usProvider.Data.PlotLegendVisible = value;
                plot.LegendVisible = value;
                plot.Invalidate();
            }
        }

        bool notesVisible
        {
            get => notesVisibleBtn.Checked;
            set
            {
                notesVisibleBtn.Checked = value;
                usProvider.Data.NotesVisible = value;
                plot.RightUpperTextVisible = value;
                plot.Invalidate();
            }
        }

        bool extraInfoVisible
        {
            get => extraInfoVisibleBtn.Checked;
            set
            {
                extraInfoVisibleBtn.Checked = value;
                usProvider.Data.ExtraInfoVisible = value;
                plot.LeftUpperTextVisible = value;
                plot.Invalidate();
            }
        }

        bool followTarget
        {
            get => followMapBtn.Checked;
            set
            {
                followMapBtn.Checked = value;
                usProvider.Data.FollowTarget = value;

                if (value && core.LocationPresent)
                {
                    var location = core.GetLocation();
                    plot.SetCenter(location.Latitude, location.Longitude);
                }
            }
        }

        bool showTiles
        {
            get => showTilesBtn.Checked;
            set
            {
                showTilesBtn.Checked = value;
                usProvider.Data.ShowTiles = value;
                plot.TilesEnabled = value;
            }
        }

        BasePointType navigateToBasePoint
        {
            get => (BasePointType)Enum.Parse(typeof(BasePointType), navPointCbx.SelectedItem.ToString());
            set => UIHelpers.TrySetCbxItem(navPointCbx, value.ToString());
        }

        #endregion

        string serialOutputPortName
        {
            get => serialOutputPortNameCbx.SelectedItem == null ? string.Empty : serialOutputPortNameCbx.SelectedItem.ToString();
            set => UIHelpers.TrySetCbxItem(serialOutputPortNameCbx, value);
        }

        bool autoscreenshotEnabled
        {
            get => autoscreenshotsBtn.Checked;
            set => autoscreenshotsBtn.Checked = value;
        }

        #endregion

        #region Constructor

        public MainForm()
        {
            #region App title init

            string vString = string.Format("{0} {1} v{2} {3}",
                appicon,
                Application.ProductName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                MDates.GetReferenceNote());

            #endregion

            #region paths & filenames

            DateTime startTime = DateTime.Now;
            settingsFileName = Path.ChangeExtension(Application.ExecutablePath, "settings");
            uiSettingsFileName = Path.ChangeExtension(Application.ExecutablePath, "uisettings");
            logPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
            logFileName = StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "log", true);
            snapshotsPath = StrUtils.GetTimeDirTree(startTime, Application.ExecutablePath, "SNAPSHOTS", false);
            tileDBPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Cache\\Tiles\\");

            #endregion

            #region logger

            logger = new TSLogProvider(logFileName);
            logger.WriteStart();
            logger.Write(vString);
            logger.TextAddedEvent += (o, e) => InvokeAppendHistoryLine(e.Text);

            #endregion

            #region settings

            sProvider = new SimpleSettingsProviderXML<SettingsContainer>();
            sProvider.isSwallowExceptions = false;

            logger.Write(string.Format("Loading settings from {0}", settingsFileName));

            try
            {
                sProvider.Load(settingsFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            logger.Write("Current application settings:");
            logger.Write(sProvider.Data.ToString());

            #endregion            

            InitializeComponent();

            this.Text = vString;

            #region tProvider

            if ((sProvider.Data.TileServers != null) &&
                (sProvider.Data.TileServers.Length > 0))
            {
                tProvider = new uOSMTileProvider(1024,
                    19,
                    new Size(sProvider.Data.TileSizePx, sProvider.Data.TileSizePx),
                    tileDBPath,
                    sProvider.Data.TileServers);

                tProvider.DownloadingEnabled = sProvider.Data.EnableTilesDownloading;
            }

            #endregion

            #region tManager

            tManager = new TrackManager();
            tManager.IsEmptyChanged += (o, e) =>
            {
                UIHelpers.InvokeSetEnabledState(mainToolStrip, tracksExportAsBtn, !tManager.IsEmpty);
                UIHelpers.InvokeSetEnabledState(mainToolStrip, tracksClearAllBtn, !tManager.IsEmpty);
            };
            tManager.IsEmptyChanged(this, EventArgs.Empty);

            #endregion

            #region Misc. init

            moonPhaseLbl.Text = AstroAndTimeUtils.MoonPhaseIcon(DateTime.Now);
            moonPhaseLbl.ToolTipText = AstroAndTimeUtils.MoonPhaseDescription(DateTime.Now);

            navPointCbx.Items.Clear();
            navPointCbx.Items.AddRange(Enum.GetNames(typeof(APL.BasePointType)));

            SwitchOutputPortUIEnabledState(false);

            plot.InitTrack(APL.APL.WAYULocationTrackID, sProvider.Data.TrackPointsToShow, Color.Red, 8, 1, true);
            plot.InitTrack(APL.APL.BuoysTracksIDs[0], 4, Color.DarkRed, 8, 1, false);
            plot.InitTrack(APL.APL.BuoysTracksIDs[1], 4, Color.DarkOrange, 8, 1, false);
            plot.InitTrack(APL.APL.BuoysTracksIDs[2], 4, Color.Green, 8, 1, false);
            plot.InitTrack(APL.APL.BuoysTracksIDs[3], 4, Color.Purple, 8, 1, false);
            plot.InitTrack(APL.APL.MarkedPointsTrackID, 256, Color.Black, 8, 1, false);

            if (sProvider.Data.IsUseAUXGNSS)
                plot.InitTrack(APL.APL.AuxGNSSTrackID, 64, Color.Blue, 8, 1, true);

            if (tProvider != null)
                plot.ConnectTileProvider(tProvider);

            #endregion

            #region uiAutomation

            uiAutomation = new UIAutomation();
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(markedPointsVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(buoysVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(historyVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(plotLegendVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(notesVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(extraInfoVisible));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(followTarget));
            uiAutomation.InitBoolProperty<MainForm>(this, nameof(showTiles));

            #endregion            

            #region lPlayer

            lPlayer = new LogPlayer();
            lPlayer.NewLogLineHandler += (o, e) =>
            {
                if (e.Line.StartsWith("(INFO)"))
                {
                    int idx = e.Line.IndexOf(' ');
                    if (idx >= 0)
                    {
                        core.Emulate(e.Line.Substring(idx).Trim());
                    }
                }
                else if (e.Line.StartsWith("NOTE"))
                {
                    var match = Regex.Match(e.Line, "\"[^\" ][^\"]*\"");
                    if (match.Success)
                        InvokeSetNoteText(match.ToString().Trim('"'));
                }
                else if (e.Line.StartsWith(UIAutomation.LogID))
                {
                    int idx = e.Line.IndexOf(' ');
                    if (idx >= 0)
                        InvokePerformUIAction(e.Line.Substring(idx).Trim());
                }
            };

            lPlayer.LogPlaybackFinishedHandler += (o, e) =>
            {
                core.Stop();

                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        settingsBtn.Enabled = true;
                        linkBtn.Enabled = true;
                        logPlaybackBtn.Text = "▶ Playback...";
                        MessageBox.Show(
                            string.Format("Log-file \"{0}\" playback is finished.", lPlayer.LogFileName),
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    });
                }
                else
                {
                    settingsBtn.Enabled = true;
                    linkBtn.Enabled = true;
                    logPlaybackBtn.Text = "▶ Playback...";
                    MessageBox.Show(
                        string.Format("Log-file \"{0}\" playback is finished.", lPlayer.LogFileName),
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            };

            #endregion

            #region core

            core = new APLCore(sProvider.Data.InPortBaudrate,
                sProvider.Data.RadialErrorThreshold_m, sProvider.Data.CourseEstimatorFIFOSize,
                sProvider.Data.TrackSmootherFIFOSize, sProvider.Data.TrackSmootherRangeThreshold_m,
                sProvider.Data.DHFilterFIFOSize, sProvider.Data.DHFilterMaxSpeed_mps, sProvider.Data.DHFilterRangeThreshold_m);

            core.Salinity_psu = sProvider.Data.Salinity_PSU;
            core.WaterTemperature_C = sProvider.Data.WaterTemperature_C;
            core.IsAutoSalinity = sProvider.Data.IsAutoSalinity;
            core.SoundSpeed_mps = sProvider.Data.SoundSpeed_mps;
            core.IsAutoSoundSpeed = sProvider.Data.IsAutoSoundSpeed;

            if (sProvider.Data.IsUseAUXGNSS)
                core.AuxGNSSInit(sProvider.Data.AUXGNSSBaudrate);

            if (sProvider.Data.IsUseUDPOutput)
                core.UDPOutputInit(IPAddress.Parse(sProvider.Data.OutputUDPIPAddress),
                    sProvider.Data.OutputUDPPort,
                    sProvider.Data.IsUDPOutputNMEA);

            core.TrackPointReceived += (o, e) =>
            {
                tManager.AddPoint(e.TrackID, e.Latitude_deg, e.Longitude_deg, double.IsNaN(e.Depth_m) ? 0 : e.Depth_m, e.TimeStamp);

                if (e.TrackID != APL.APL.WAYURawLocationTrackID)
                    InvokeAddPoint(e);

                if (e.TrackID == APL.APL.WAYULocationTrackID)
                    InvokeCheckAutocenterCenterPlot(e.Latitude_deg, e.Longitude_deg);
            };

            core.APLPortDetectedChanged += (o, e) =>
                InvokeUpdatePortStatusLbl(mainStatusStrip, aplPortStatusLbl, core.IsActive, core.APLPortDetected, core.APLPortStatus);
            core.APLPortActiveChanged += (o, e) =>
            {
                UIHelpers.InvokeSetCheckedState(mainToolStrip, linkBtn, core.IsActive);
                UIHelpers.InvokeSetEnabledState(mainToolStrip, settingsBtn, !core.IsActive);
                UIHelpers.InvokeSetEnabledState(mainToolStrip, logPlaybackBtn, !core.IsActive);
                InvokeUpdatePortStatusLbl(mainStatusStrip, aplPortStatusLbl, core.IsActive, core.APLPortDetected, core.APLPortStatus);
                logger.Write(string.Format("{0}={1}", nameof(core.IsActive), core.IsActive));
            };

            core.AuxGNSSPortActiveChanged += (o, e) =>
                InvokeUpdatePortStatusLbl(mainStatusStrip, auxGNSSPortStatusLbl, core.IsActive, core.AuxGNSSPortDetected, core.AuxGNSSPortStatus);
            core.AuxGNSSPortDetectedChanged += (o, e) =>
            {
                InvokeUpdatePortStatusLbl(mainStatusStrip, auxGNSSPortStatusLbl, core.IsActive, core.AuxGNSSPortDetected, core.AuxGNSSPortStatus);
                InvokeSwitchOutputPortUIEnabledState(core.AuxGNSSPortDetected);

                if (core.AuxGNSSPortDetected &&
                   !core.SerialOutputEnabled)
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            serialOutputPortsRefreshBtn_Click(serialOutputPortsRefreshBtn, EventArgs.Empty);
                            UIHelpers.TrySetCbxItem(serialOutputPortNameCbx, usProvider.Data.SerialOutputPortName);
                            serialOutputLinkBtn_Click(null, EventArgs.Empty);
                        });
                    }
                    else
                    {
                        serialOutputPortsRefreshBtn_Click(serialOutputPortsRefreshBtn, EventArgs.Empty);
                        UIHelpers.TrySetCbxItem(serialOutputPortNameCbx, usProvider.Data.SerialOutputPortName);
                        serialOutputLinkBtn_Click(null, EventArgs.Empty);
                    }
                }
            };

            core.StateUpdated += (o, e) => InvokeSetLeftUpperText(core.GetSystemDescription() + core.GetDelayStatistics());

            core.StatHelperActiveChanged += (o, e) =>
            {
                if (core.StatHelperActive)
                {
                    InvokeSetText(secondaryToolStrip, accuracyEstimationStartStopBtn, "⏹ Stop");
                    InvokeSetCheckedState(secondaryToolStrip, accuracyEstimationStartStopBtn, true);
                }
                else
                {
                    InvokeSetText(secondaryToolStrip, accuracyEstimationStartStopBtn, "⏺ Start");
                    InvokeSetCheckedState(secondaryToolStrip, accuracyEstimationStartStopBtn, false);
                }
            };

            core.LogEvent += (o, e) => logger.Write(string.Format("({0}) {1}", e.EventType, e.LogString));

            #endregion            

            #region UI settings

            usProvider = new SimpleSettingsProviderXML<UISettingsContainer>();
            usProvider.isSwallowExceptions = true;
            usProvider.Load(uiSettingsFileName);

            markedPointsVisible = usProvider.Data.MarkedPointsVisible;
            buoysVisible = usProvider.Data.BuoysVisible;
            historyVisible = usProvider.Data.HistoryVisible;
            plotLegendVisible = usProvider.Data.PlotLegendVisible;
            notesVisible = usProvider.Data.NotesVisible;
            extraInfoVisible = usProvider.Data.ExtraInfoVisible;
            followTarget = usProvider.Data.FollowTarget;
            showTiles = usProvider.Data.ShowTiles;

            if ((usProvider.Data.WindowSize.Width >= this.MinimumSize.Width) &&
                (usProvider.Data.WindowSize.Height >= this.MinimumSize.Height))
                this.Size = usProvider.Data.WindowSize;

            this.Location = usProvider.Data.WindowLocation;
            this.WindowState = usProvider.Data.WindowState;

            if ((usProvider.Data.BasePointTypeToNavigate == BasePointType.Specified) ||
               (usProvider.Data.BasePointTypeToNavigate == BasePointType.AUX_GNSS))
                usProvider.Data.BasePointTypeToNavigate = BasePointType.Base_1;

            navigateToBasePoint = usProvider.Data.BasePointTypeToNavigate;

            #endregion

            #region uTimer

            uTimer = new PrecisionTimer();
            uTimer.Period = 1000;
            uTimer.Mode = Mode.Periodic;
            uTimer.Tick += (o, e) => InvokeSaveAutoscreenshot();

            #endregion
        }

        #endregion

        #region Methods

        #region Custom UI invokers

        private void InvokeSaveAutoscreenshot()
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { SaveAutoscreenShot(); });
            else
                SaveAutoscreenShot();
        }

        private void CheckAutocenterPlot(double lat, double lon)
        {
            if (followTarget)
            {
                plot.SetCenter(lat, lon);
            }
        }

        private void InvokeCheckAutocenterCenterPlot(double lat, double lon)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { CheckAutocenterPlot(lat, lon); });
            else
                CheckAutocenterPlot(lat, lon);
        }

        private void InvokeAppendHistoryLine(string line)
        {
            if (plot == null)
                return;

            if (plot.InvokeRequired)
                plot.Invoke((MethodInvoker)delegate
                {
                    plot.AppendHistoryLine(line);
                    plot.Invalidate();
                });
            else
            {
                plot.AppendHistoryLine(line);
                plot.Invalidate();
            }
        }

        private void InvokeUpdatePortStatusLbl(StatusStrip strip, ToolStripStatusLabel lbl, bool active, bool detected, string text)
        {
            Color backColor = Color.FromKnownColor(KnownColor.Control);
            Color foreColor = Color.FromKnownColor(KnownColor.ControlText);

            if (active)
            {
                foreColor = Color.Yellow;
                if (!detected)
                    backColor = Color.Red;
                else
                    backColor = Color.Green;
            }

            UIHelpers.InvokeSetText(strip, lbl, text, foreColor, backColor);
        }

        private void InvokeSwitchOutputPortUIEnabledState(bool enabled)
        {
            if (bottomSecondaryToolStrip.InvokeRequired)
                bottomSecondaryToolStrip.Invoke((MethodInvoker)delegate { SwitchOutputPortUIEnabledState(enabled); });
            else
                SwitchOutputPortUIEnabledState(enabled);
        }

        private void SwitchOutputPortUIEnabledState(bool enabled)
        {
            serialOutputPortNameCbx.Enabled = enabled;
            serialOutputLinkBtn.Enabled = enabled;
            serialOutputPortsRefreshBtn.Enabled = enabled;
            serialOutputLbl.Enabled = enabled;
        }

        private void InvokeSetLeftUpperText(string text)
        {
            if (plot.InvokeRequired)
                plot.Invoke((MethodInvoker)delegate
                {
                    plot.LeftUpperText = text;
                    plot.Invalidate();
                });
            else
            {
                plot.LeftUpperText = text;
                plot.Invalidate();
            }
        }

        private void InvokeSetNoteText(string text)
        {
            if (plot.InvokeRequired)
                plot.Invoke((MethodInvoker)delegate
                {
                    plot.RightUpperTextSet(text);
                    plot.Invalidate();
                });
            else
            {
                plot.RightUpperTextSet(text);
                plot.Invalidate();
            }
        }

        private void InvokePerformUIAction(string uiActionName)
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { uiAutomation.PerformUIAction(uiActionName); });
            else
                uiAutomation.PerformUIAction(uiActionName);
        }

        private void InvokeSetCheckedState(ToolStrip strip, ToolStripMenuItem item, bool checkedState)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate
                {
                    item.Checked = checkedState;
                });
            else
                item.Checked = checkedState;
        }

        private void InvokeSetText(ToolStrip strip, ToolStripMenuItem item, string text)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate
                {
                    item.Text = text;
                });
            else
                item.Text = text;
        }

        private void InvokeAddPoint(TrackPointEventArgs e)
        {
            if (plot.InvokeRequired)
                plot.Invoke((MethodInvoker)delegate
                {
                    AddPoint(e);
                });
            else
                AddPoint(e);
        }

        private void AddPoint(TrackPointEventArgs e)
        {
            if (e.IsCourse)
                plot.AddPoint(e.TrackID, e.Latitude_deg, e.Longitude_deg, e.Course_deg);
            else
                plot.AddPoint(e.TrackID, e.Latitude_deg, e.Longitude_deg);

            plot.Invalidate();
        }

        #endregion

        private void StartAutoscreenShots()
        {
            if (uTimer.IsRunning)
                uTimer.Stop();

            autoscreenshot_idx = 0;
            autoscreenshots_path = StrUtils.GetTimeDirTree(DateTime.Now, Application.ExecutablePath, "AUTOSNAPSHOTS", false);

            uTimer.Start();
        }

        private void StopAutoscreenShots()
        {
            uTimer.Stop();
        }

        private void ProcessException(Exception ex, bool isMsgBox)
        {
            logger.Write(ex);

            if (isMsgBox)
                MessageBox.Show(ex.Message,
                    string.Format("{0} {1} - Error", appicon, Application.ProductName),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void StatusHintLinkUpdate(string text, string linkText)
        {
            bottomLinkLbl.Text = text;
            bottomLinkLbl.Tag = linkText;
        }

        private void JustSaveFullScreenshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                var fName = string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png);
                var path = Path.Combine(snapshotsPath, fName);
                target.Save(path, ImageFormat.Png);
            }
            catch
            {
            }
        }

        private void SaveAutoscreenShot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(autoscreenshots_path))
                    Directory.CreateDirectory(autoscreenshots_path);

                var fName = string.Format("{0:000000}.{1}", autoscreenshot_idx++, ImageFormat.Png);
                var path = Path.Combine(autoscreenshots_path, fName);
                target.Save(path, ImageFormat.Png);
            }
            catch { }
        }

        private string SaveFullScreenshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                var fName = string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png);
                var path = Path.Combine(snapshotsPath, fName);
                target.Save(path, ImageFormat.Png);

                return string.Format("{0} {1}|{2}", "Screenshot saved to", fName, path);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void InvokeSaveFullScreenshot()
        {
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { SaveFullScreenshot(); });
            else
                SaveFullScreenshot();
        }

        #region log utils

        private int RemoveEmptyEntries(string rootPath, string exclude, int minSize)
        {
            var dirs = Directory.GetDirectories(rootPath);
            int fNum = 0;
            foreach (var item in dirs)
            {
                var fNames = Directory.GetFiles(item);

                foreach (var fName in fNames)
                {
                    if (fName != exclude)
                    {
                        FileInfo fInfo = new FileInfo(fName);
                        if (fInfo.Length <= minSize)
                        {
                            try
                            {
                                File.Delete(fName);
                                fNum++;
                            }
                            catch { }
                        }
                    }
                }

                fNames = Directory.GetFiles(item);
                if (fNames.Length == 0)
                {
                    try
                    {
                        Directory.Delete(item);
                    }
                    catch { }
                }
            }

            return fNum;
        }

        private int ClearAllEntries(string rootPath)
        {
            var dirs = Directory.GetDirectories(rootPath);
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

            return dirNum;
        }


        #endregion

        #endregion

        #region UI Handlers

        #region mainToolStrip
        private void linkBtn_Click(object sender, EventArgs e)
        {
            if (core.IsActive)
                core.Stop();
            else
                core.Start();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            bool isSaved = false;

            using (SettingsEditor sEditor = new SettingsEditor())
            {
                sEditor.Text = string.Format("{0} {1} - SettingsEditor",
                    appicon, Application.ProductName);
                sEditor.Value = sProvider.Data;

                if (sEditor.ShowDialog() == DialogResult.OK)
                {
                    sProvider.Data = sEditor.Value;

                    try
                    {
                        sProvider.Save(settingsFileName);
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }

            if (isSaved &&
                MessageBox.Show("Settings has been updated, restart application to apply new settings?",
                string.Format("{0} {1} - Question",
                appicon, Application.ProductName),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                isRestart = true;
                Application.Restart();
            }
        }

        #region LOG

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
            if (lPlayer.IsRunning)
            {
                if (MessageBox.Show("log is currently playing, abort?",
                    string.Format("{0} {1} - Question",
                    appicon, Application.ProductName),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    lPlayer.RequestToStop();
            }
            else
            {
                using (OpenFileDialog oDialog = new OpenFileDialog())
                {
                    oDialog.Title = string.Format("{0} {1}",
                        appicon, "Select a log file to playback");
                    oDialog.DefaultExt = "log";
                    oDialog.Filter = "Log files (*.log)|*.log";

                    if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lPlayer.Playback(oDialog.FileName);

                        logPlaybackBtn.Text = string.Format("⏹ {0}", "Stop playback");
                        settingsBtn.Enabled = false;
                        linkBtn.Enabled = false;
                    }
                }
            }
        }

        private void logBuildEmulationDataBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oDialog = new OpenFileDialog())
            {
                oDialog.Title = string.Format("{0} {1}",
                    appicon, "Select a log file to build emulation data");
                oDialog.DefaultExt = "log";
                oDialog.Filter = "Log files (*.log)|*.log";

                if (oDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bool parsed = false;
                    List<Tuple<double, string>> lp_result = new List<Tuple<double, string>>();

                    try
                    {
                        lp_result = lPlayer.ParseLog(oDialog.FileName);
                        parsed = true;
                        
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }

                    if (parsed)
                    {

                        List<string> sres = new List<string>();

                        double fts = lp_result[0].Item1;

                        for (int i = 0; i < lp_result.Count; i++)
                        {
                            var sec = lp_result[i].Item1 - fts;
                            var str = lp_result[i].Item2;

                            if (str.StartsWith("(INFO)"))
                            {
                                int idx = str.IndexOf(' ');
                                if (idx >= 0)
                                {
                                    str = str.Substring(idx).Trim();

                                    bool isAPLA = core.JustParseEmuLine(str, out BaseIDs bID, out double bLat, out double bLon, out double bDpt, out double bBat, out double bTOA);

                                    if (isAPLA)
                                    {
                                        var line = string.Format(
                                            CultureInfo.InvariantCulture,
                                            "{{ {0:F03}, {1}, {2:F06}, {3:F06}, {4:F06} }}",
                                            sec, (int)bID, bLat, bLon, bTOA);

                                        if (i != lp_result.Count - 1)
                                            line += ",";                                      

                                        sres.Add(line);
                                    }
                                }
                            }
                        }

                        var dsize = sres.Count;
                        if (dsize > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            var sStart = 

                            /*
                            #define EMU_DATA_SIZE (XXX)
                            // Second, bID, lat, lon, toa
                            const PROGMEM float data[DATA_SIZE][5] = {
                            { 0.095950, 0, 48.976069, 44.740133, 0.09595 }, 
                            .....
                            }
                            */

                            sb.Append("// WAYU AUTOGENERATED CODE -->\r\n");
                            sb.AppendFormat("#define EMU_DATA_SIZE ({0})\r\n", dsize);
                            sb.Append("const PROGMEM float emu_data[EMU_DATA_SIZE][5] = {\r\n");

                            foreach (var item in sres)
                                sb.AppendLine(item);

                            sb.Append("};\r\n");
                            sb.Append("// END OF WAYU AUTOGENERATED CODE\r\n");

                            using (SaveFileDialog sDialog = new SaveFileDialog())
                            {
                                sDialog.Title = string.Format("{0} {1}",
                                   appicon, "Specify the name of the C-file to store the emulation data");
                                sDialog.DefaultExt = "c";
                                sDialog.Filter = "C-files (*.c)|*.c";

                                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    try
                                    {
                                        File.WriteAllText(sDialog.FileName, sb.ToString());
                                    }
                                    catch (Exception ex)
                                    {
                                        ProcessException(ex, true);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There was no data for emulation found in the specified log file",
                                string.Format("{0} {1} - Information",
                                appicon, Application.ProductName),
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
        }

        private void logRemoveEmptyEntriesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All log files less than 2 kb will be deleted, Ok?",
                string.Format("{0} {1} - Question",
                appicon,
                Application.ProductName),
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                var fNum = RemoveEmptyEntries(logPath, logger.FileName, 2048);

                MessageBox.Show(string.Format("{0} {1}", fNum, "files was/were deleted"),
                    string.Format("{0} {1} - Information",
                    appicon,
                    Application.ProductName),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void logArchiveAllBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Title = string.Format("{0} {1}",
                    appicon, "Select a file name to compress all log files to");
                sDialog.Filter = "Zip-archives (*.zip)|*.zip";
                sDialog.DefaultExt = "zip";
                sDialog.FileName = string.Format("LOG_Archive_{0}", StrUtils.GetYMDString());

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ZipFile.CreateFromDirectory(logPath, sDialog.FileName);
                        StatusHintLinkUpdate(string.Format("{0} {1}",
                           "All log files comressed to", Path.GetFileName(sDialog.FileName)), sDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }

        private void logDeleteAllBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all log files (action cannot be undone)?",
                                string.Format("{0} {1} - Warning",
                                appicon, Application.ProductName),

                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                var dirNum = ClearAllEntries(logPath);

                MessageBox.Show(string.Format("{0} {1}",
                    dirNum, "entries was/were deleted"),
                    string.Format("{0} {1} - Information",
                    appicon, Application.ProductName),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void logDoThemAllBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Move all log files to an archive?",
                               string.Format("{0} {1} - Warning",
                               appicon, Application.ProductName),
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                RemoveEmptyEntries(logPath, logFileName, 2048);

                bool archived = false;
                using (SaveFileDialog sDialog = new SaveFileDialog())
                {
                    sDialog.Title = string.Format("{0} {1}",
                        appicon, "Select a name of archive to compress all log files to");
                    sDialog.Filter = "Zip-archives (*.zip)|*.zip";
                    sDialog.DefaultExt = "zip";
                    sDialog.FileName = string.Format("LOG_Archive_{0}", StrUtils.GetYMDString());

                    if (sDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ZipFile.CreateFromDirectory(logPath, sDialog.FileName);
                            StatusHintLinkUpdate(string.Format("{0} {1}",
                           "All log files moved to", Path.GetFileName(sDialog.FileName)), sDialog.FileName);

                            archived = true;
                        }
                        catch (Exception ex)
                        {
                            ProcessException(ex, true);
                        }
                    }
                }

                if (!archived)
                {
                    MessageBox.Show("Some errors occured moving log files to an archive. The archive was not created.",
                        string.Format("{0} {1} - Error",
                        appicon, Application.ProductName),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    ClearAllEntries(logPath);
                }
            }
        }

        #endregion

        #region UTILS

        #region TRACKS

        private void tracksExportAsBtn_Click(object sender, EventArgs e)
        {
            bool saved = false;
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Title = string.Format("{0} {1}",
                    appicon, "Exporting tracks...");
                sDialog.Filter = "KML (*.kml)|*.kml|CSV (*.csv)|*.csv";
                sDialog.FileName = StrUtils.GetHMSString();

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // KML
                        if (sDialog.FilterIndex == 1)
                        {
                            tManager.ExportToKML(sDialog.FileName);
                            saved = true;
                        }
                        // CSV
                        else if (sDialog.FilterIndex == 2)
                        {
                            tManager.ExportToCSV(sDialog.FileName);
                            saved = true;
                        }

                        StatusHintLinkUpdate(string.Format("{0} {1}",
                           "All tracks were saved to", Path.GetFileName(sDialog.FileName)), sDialog.FileName);

                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }

            if (saved)
            {
                if (MessageBox.Show("Tracks saved. Clear all tracks data?",
                    string.Format("{0} {1} - Question", appicon, Application.ProductName),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    tManager.Clear();

            }
        }

        private void trackImportBtn_Click(object sender, EventArgs e)
        {
            bool isOk = false;

            using (OpenFileDialog oDialog = new OpenFileDialog())
            {
                oDialog.Title = string.Format("{0} {1}",
                    appicon, "Importing tracks...");
                oDialog.Filter = "KML (*.kml)|*.kml";

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        tManager.ImportFromKML(oDialog.FileName);
                        isOk = true;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }

                if (isOk)
                    MessageBox.Show(string.Format("Data was imported from {0}", oDialog.FileName),
                        string.Format("{0} {1} - Information", appicon, Application.ProductName),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

            }
        }
        private void tracksClearAllBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all tracks data?",
                string.Format("{0} {1} - Question", appicon, Application.ProductName),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                tManager.Clear();
        }


        #endregion

        #region OVERRIDE

        private void ovrSalinityBtn_Click(object sender, EventArgs e)
        {
            using (NumDialog nDialog = new NumDialog())
            {
                nDialog.Text = string.Format("{0} {1} - Override water salinity",
                    appicon, Application.ProductName);
                nDialog.ValueCaption = "Water salinity, PSU";
                nDialog.MaxValue = 40;
                nDialog.MinValue = 0;
                nDialog.DecimalPlaces = 1;
                nDialog.Value = core.Salinity_psu;

                if (nDialog.ShowDialog() == DialogResult.OK)
                    core.Salinity_psu = nDialog.Value;
            }
        }

        private void ovrWaterTemperatureBtn_Click(object sender, EventArgs e)
        {
            using (NumDialog nDialog = new NumDialog())
            {
                nDialog.Text = string.Format("{0} {1} - Override water temperature",
                    appicon, Application.ProductName);
                nDialog.ValueCaption = "Water temperature, °C";
                nDialog.MaxValue = 40;
                nDialog.MinValue = -4;
                nDialog.DecimalPlaces = 1;
                nDialog.Value = core.WaterTemperature_C;

                if (nDialog.ShowDialog() == DialogResult.OK)
                    core.WaterTemperature_C = nDialog.Value;
            }
        }

        #endregion

        #endregion

        private void infoBtn_Click(object sender, EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());
                aDialog.Weblink = "https://docs.unavlab.com";// www.docs.unavlab.com";
                aDialog.ShowDialog();
            }
        }

        #endregion

        #region secondaryToolStrip

        private void markPointBtn_Click(object sender, EventArgs e)
        {
            core.MarkTargetLocation();
        }

        private void markedPointsVisible_Click(object sender, EventArgs e)
        {
            markedPointsVisible = !markedPointsVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(markedPointsVisible)));
        }

        private void buoysVisibleBtn_Click(object sender, EventArgs e)
        {
            buoysVisible = !buoysVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(buoysVisible)));
        }

        private void historyVisibleBtn_Click(object sender, EventArgs e)
        {
            historyVisible = !historyVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(historyVisible)));
        }

        private void plotLegendVisibleBtn_Click(object sender, EventArgs e)
        {
            plotLegendVisible = !plotLegendVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(plotLegendVisible)));
        }

        private void notesVisibleBtn_Click(object sender, EventArgs e)
        {
            notesVisible = !notesVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(notesVisible)));
        }

        private void extraInfoVisibleBtn_Click(object sender, EventArgs e)
        {
            extraInfoVisible = !extraInfoVisible;
            logger.Write(uiAutomation.GetBoolPropertyStateLogString<MainForm>(this, nameof(extraInfoVisible)));
        }

        private void followMapBtn_Click(object sender, EventArgs e)
        {
            followTarget = !followTarget;
            logger.Write(uiAutomation.GetPropertyStateLogString<MainForm>(this, nameof(followTarget)));
        }

        private void showTilesBtn_Click(object sender, EventArgs e)
        {
            showTiles = !showTiles;
            logger.Write(uiAutomation.GetPropertyStateLogString<MainForm>(this, nameof(showTiles)));
        }

        private void resetViewBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear current plot? This action will not change the tracks.",
                string.Format("{0} {1} - Question", appicon, Application.ProductName),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                plot.Clear();
                plot.Invalidate();
            }
        }

        #region Accuracy estimation group

        private void accuracyEstimationStartStopBtn_Click(object sender, EventArgs e)
        {
            if (core.StatHelperActive)
                core.AccuracyEstimationStop();
            else
                core.AccuracyEstimationStart();
        }

        private void accuracyEstimationClearDataBtn_Click(object sender, EventArgs e)
        {
            core.AccuracyEstimationDiscard();
        }

        #endregion

        private void navPointCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (core != null)
            {
                core.BasePointTypeToNavigate = navigateToBasePoint;
                usProvider.Data.BasePointTypeToNavigate = navigateToBasePoint;

                if (navigateToBasePoint == BasePointType.Specified)
                {
                    using (SelectLocationDialog sDialog = new SelectLocationDialog())
                    {
                        sDialog.Text = "Specify a point to use as a reference";
                        sDialog.SetPoints(tManager.GetTrack2D(APL.APL.MarkedPointsTrackID));
                        var currentLocation = core.GetLocation();
                        sDialog.Latitude = currentLocation.Latitude;
                        sDialog.Longitude = currentLocation.Longitude;

                        if (sDialog.ShowDialog() == DialogResult.OK)
                        {
                            core.SetBasePointToNavigate(sDialog.Latitude, sDialog.Longitude, true);
                        }
                        else
                        {
                            navigateToBasePoint = BasePointType.Base_1;
                        }
                    }
                }
            }
        }

        #endregion

        #region bottomToolStrip

        private void noteTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) &&
                (!string.IsNullOrEmpty(noteTxb.Text)))
                noteSaveBtn_Click(noteTxb, EventArgs.Empty);
        }

        private void noteTxb_TextChanged(object sender, EventArgs e)
        {
            noteSaveBtn.Enabled = !string.IsNullOrWhiteSpace(noteTxb.Text);
        }

        private void noteSaveBtn_Click(object sender, EventArgs e)
        {
            logger.Write(string.Format("NOTE: \"{0}\"", noteTxb.Text));
            plot.RightUpperTextSet(noteTxb.Text);
            noteTxb.Clear();
        }

        private void screenShotBtn_Click(object sender, EventArgs e)
        {
            var res = SaveFullScreenshot();
            var splits = res.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (splits.Length >= 2)
                StatusHintLinkUpdate(splits[0], splits[1]);
        }

        private void autoscreenshotsBtn_Click(object sender, EventArgs e)
        {
            if (!autoscreenshotEnabled)
            {
                if (MessageBox.Show(
                    "Enable automatic scneen shot every 1 second? Frames will be saved to AUTOSNAPSHOTS folder",
                    string.Format("{0} {1} - Question", appicon, Application.ProductName),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    autoscreenshotEnabled = true;
                    StartAutoscreenShots();
                }
            }
            else
            {
                if (MessageBox.Show(
                    string.Format("Stop automatic scneen shot every 1 second? {0} Frames are saved to {1}", autoscreenshot_idx, autoscreenshots_path),
                    string.Format("{0} {1} - Question", appicon, Application.ProductName),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    autoscreenshotEnabled = false;
                    StopAutoscreenShots();
                }
            }
        }

        #endregion

        #region bottomSecondaryToolStrip

        private void serialOutputPortsRefreshBtn_Click(object sender, EventArgs e)
        {
            serialOutputPortNameCbx.Items.Clear();
            serialOutputPortNameCbx.Items.AddRange(SerialPort.GetPortNames());
            if (serialOutputPortNameCbx.Items.Count > 0)
            {
                serialOutputPortNameCbx.SelectedIndex = 0;
            }

            serialOutputLinkBtn.Enabled = serialOutputPortNameCbx.Items.Count > 0;
        }

        private void serialOutputLinkBtn_Click(object sender, EventArgs e)
        {
            if (core.SerialOutputEnabled)
            {
                if (sender != null)
                    core.SerialOutputDeInit();
                else
                    core.SerialOutputClose();
            }
            else
            {
                try
                {
                    core.SerialOutputInit(serialOutputPortName, sProvider.Data.SerialOutputBaudrate);
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }
            }
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            plot.ZoomOut();
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            plot.ZoomIn();
        }

        #endregion

        #region mainStatusStrip

        private void bottomLinkLbl_Click(object sender, EventArgs e)
        {
            try
            {
                if (bottomLinkLbl.Tag != null)
                {
                    var fpath = (string)bottomLinkLbl.Tag;
                    if (!string.IsNullOrEmpty(fpath))
                        Process.Start(fpath);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        #endregion

        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tManager.Changed)
            {
                DialogResult dResult = DialogResult.Yes;
                while (tManager.Changed && (dResult == DialogResult.Yes))
                {
                    dResult = MessageBox.Show("Save tracks before exit?",
                    string.Format("{0} {1} - Question", appicon, Application.ProductName),
                    isRestart ? MessageBoxButtons.YesNo : MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                    if (dResult == DialogResult.Yes)
                        tracksExportAsBtn_Click(tracksExportAsBtn, EventArgs.Empty);
                }

                if (dResult == DialogResult.Cancel)
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = !isRestart &&
                    (MessageBox.Show("Close application?",
                    string.Format("{0} {1} - Question", appicon, Application.ProductName),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes);
            }

            if (!e.Cancel)
            {
                if (core.IsActive)
                    core.Stop();

                if (autoscreenshotEnabled)
                {
                    autoscreenshotEnabled = false;
                    StopAutoscreenShots();
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.FinishLog();
            logger.Flush();

            #region UISettings

            usProvider.Data.WindowState = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)
            {
                usProvider.Data.WindowSize = this.Size;
                usProvider.Data.WindowLocation = this.Location;
            }

            usProvider.Save(uiSettingsFileName);

            #endregion
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt)
            {
                if (e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.P)
                    {
                        screenShotBtn_Click(screenShotBtn, null);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.S)
                    {
                        if (utilsTracksBtn.Enabled)
                            tracksExportAsBtn_Click(tracksExportAsBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.L)
                    {
                        if (linkBtn.Enabled)
                            linkBtn_Click(linkBtn, null);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.M)
                    {
                        markPointBtn_Click(markPointBtn, null);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.H)
                    {
                        logViewCurrentBtn_Click(logViewCurrentBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.F)
                    {
                        followMapBtn_Click(followMapBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.T)
                    {
                        showTilesBtn_Click(showTilesBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.D1)
                    {
                        navigateToBasePoint = BasePointType.Base_1;
                    }
                    else if (e.KeyCode == Keys.D2)
                    {
                        navigateToBasePoint = BasePointType.Base_2;
                    }
                    else if (e.KeyCode == Keys.D3)
                    {
                        navigateToBasePoint = BasePointType.Base_3;
                    }
                    else if (e.KeyCode == Keys.D4)
                    {
                        navigateToBasePoint = BasePointType.Base_4;
                    }
                    else if (e.KeyCode == Keys.A)
                    {
                        buoysVisibleBtn_Click(buoysVisibleBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.O)
                    {
                        if (settingsBtn.Enabled)
                            settingsBtn_Click(settingsBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Add)
                    {
                        zoomInBtn_Click(zoomInBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.Subtract)
                    {
                        zoomOutBtn_Click(zoomOutBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.I)
                    {
                        infoBtn_Click(infoBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                }
            }
            else
            {
                if (!e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        ovrSalinityBtn_Click(ovrSalinityBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                    else if (e.KeyCode == Keys.T)
                    {
                        ovrWaterTemperatureBtn_Click(ovrWaterTemperatureBtn, EventArgs.Empty);
                        e.SuppressKeyPress = true;
                    }
                }
            }

            if (!e.SuppressKeyPress)
            {
                if (!noteTxb.Focused)
                    noteTxb.Focus();
            }
        }

        #endregion

        #region plot

        private void plot_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (core.LocationPresent)
            {
                var location = core.GetLocation();
                plot.SetCenter(location.Latitude, location.Longitude);
            }
        }

        #endregion

        #endregion
    }
}
