using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCNLUI;

namespace WAYU.ExtraUI
{
    public partial class NumDialog : Form
    {
        #region Properties

        public double Value
        {
            get => Convert.ToDouble(valueEdit.Value);
            set => UIHelpers.SetNumericEditValue(valueEdit, value);
        }

        public string ValueCaption
        {
            get => valueLbl.Text;
            set => valueLbl.Text = value;
        }

        public int DecimalPlaces
        {
            get => valueEdit.DecimalPlaces;
            set => valueEdit.DecimalPlaces = value;
        }

        public double MaxValue
        {
            get => Convert.ToDouble(valueEdit.Maximum);
            set => valueEdit.Maximum = Convert.ToDecimal(value);
        }

        public double MinValue
        {
            get => Convert.ToDouble(valueEdit.Minimum);
            set => valueEdit.Minimum = Convert.ToDecimal(value);
        }

        #endregion

        #region Constructor

        public NumDialog()
        {
            InitializeComponent();
        }

        #endregion
    }
}
