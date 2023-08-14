using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLDrivers;
using WAYU.APL;

namespace WAYU
{
    [Serializable]
    public class UISettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public string SerialOutputPortName;

        public bool MarkedPointsVisible;
        public bool BuoysVisible;
        public bool HistoryVisible;
        public bool PlotLegendVisible;
        public bool NotesVisible;
        public bool ExtraInfoVisible;
        public bool FollowTarget;
        public bool ShowTiles;

        public BasePointType BasePointTypeToNavigate;

        public Size WindowSize;
        public Point WindowLocation;
        public FormWindowState WindowState;

        #endregion

        #region Methods

        public override void SetDefaults()
        {
            SerialOutputPortName = "COM1";

            MarkedPointsVisible = true;
            BuoysVisible = true;
            HistoryVisible = true;
            PlotLegendVisible = true;
            NotesVisible = true;
            ExtraInfoVisible = true;
            FollowTarget = true;
            ShowTiles = true;

            BasePointTypeToNavigate = BasePointType.Base_1;

            WindowState = FormWindowState.Normal;
            WindowLocation = new Point(0, 0);
    }

        #endregion
    }
}
