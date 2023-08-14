using System;
using System.Globalization;

namespace WAYU.APL
{
    #region Enums

    public enum BasePointType
    {
        Base_1,
        Base_2,
        Base_3,
        Base_4,
        AUX_GNSS,
        Specified,        
    }

    public enum BaseIDs : int
    {
        Base_1 = 0,
        Base_2 = 1,
        Base_3 = 2,
        Base_4 = 3,
        Invalid
    }

    public enum BatState : int
    {
        OK = 0,
        DISCHARGED = 1,
        UNKNOWN
    }

    #endregion

    public static class APL
    {
        #region Properties

        public static readonly double PingerPeriod_s = 2.0;

        public static readonly string MarkedPointsTrackID = "Marked";
        public static readonly string[] BuoysTracksIDs = new string[] { "Base 1", "Base 2", "Base 3", "Base 4" };
        public static readonly string AuxGNSSTrackID = "AUX GNSS";
        public static readonly string WAYURawLocationTrackID = "WAYU (raw)";
        public static readonly string WAYULocationTrackID = "WAYU";

        public static readonly int MaxBuoysTimout_ms = 30000;

        public static Func<object, double> O2D = o => o == null ? double.NaN : (double)o;
        public static Func<object, BaseIDs> O2BaseID = o => o == null ? BaseIDs.Invalid : (BaseIDs)(int)(o);
        public static Func<object, BatState> O2BatState = o => o == null ? BatState.UNKNOWN : (BatState)(int)(o);

        public static readonly Func<double, string> meters3dec_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F03} m", o);
        public static readonly Func<double, string> meters1dec_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} m", o);
        public static readonly Func<double, string> degrees1dec_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} °", o);
        public static readonly Func<double, string> latlon_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F06} °", o);
        public static readonly Func<double, string> db_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} dB", o);
        public static readonly Func<double, string> degC_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} °C", o);
        public static readonly Func<double, string> mBar_fmtr = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} mBar", o);
        public static readonly Func<double, string> v1dec_fmt = o => string.Format(CultureInfo.InvariantCulture, "{0:F01} V", o);

        public static bool IfBasePointIsABuoy(BasePointType bpType)
        {
            return (bpType == BasePointType.Base_1) ||
                   (bpType == BasePointType.Base_2) ||
                   (bpType == BasePointType.Base_3) ||
                   (bpType == BasePointType.Base_4);
        }

        #endregion
    }
}
