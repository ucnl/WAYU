using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLNav;
using UCNLUI;

namespace WAYU.ExtraUI
{
    public partial class SelectLocationDialog : Form
    {
        #region Properties

        public double Latitude
        {
            get
            {
                var lt = Convert.ToDouble(latEdit.Value);
                return lt >= -90 ? lt <= 90 ? lt : double.NaN : double.NaN;
            }
            set
            {
                UIHelpers.SetNumericEditValue(latEdit, value);
            }
        }

        public double Longitude
        {
            get
            {
                var ln = Convert.ToDouble(lonEdit.Value);
                return ln >= -180 ? ln <= 180 ? ln : double.NaN : double.NaN;
            }
            set
            {
                UIHelpers.SetNumericEditValue(lonEdit, value);
            }
        }

        #endregion

        #region Constructor

        public SelectLocationDialog()
        {
            InitializeComponent();

            latEdit.ValueChanged += (o, e) => onLatLonChanged(o, e);
            lonEdit.ValueChanged += (o, e) => onLatLonChanged(o, e);

            onLatLonChanged(null, null);
        }

        #endregion

        #region Methods

        public void SetPoints(IEnumerable<GeoPoint> points)
        {
            pointsList.Items.Clear();
            foreach (var point in points)
                pointsList.Items.Add(point);
        }

        public void ClearPoints()
        {
            pointsList.Items.Clear();
        }

        #endregion

        #region Handlers

        private void onLatLonChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = !double.IsNaN(Latitude) && !double.IsNaN(Longitude);
        }

        private void pointsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pointsList.SelectedItem != null)
            {
                var sPoint = (pointsList.SelectedItem as GeoPoint);
                Latitude = sPoint.Latitude;
                Longitude = sPoint.Longitude;
            }
        }

        #endregion        
    }
}
