using System;
using System.Collections.Generic;
using UCNLNav;

namespace WAYU.APL
{
    
    public class APLBaseProcessor
    {
        #region Properties

        Dictionary<BaseIDs, GeoPoint3DT> bases;

        double pingerPeriod;
        public double PingerPeriodS
        {
            get { return pingerPeriod; }
            set
            {
                if (value > 0)
                    pingerPeriod = value;
                else
                    throw new ArgumentOutOfRangeException("Value should be greater than zero");
            }
        }

        double prevTOA = double.NaN;


        #endregion

        #region Constructor

        public APLBaseProcessor(int fifoSize, double pingerPeriodS)
        {
            PingerPeriodS = pingerPeriodS;
            bases = new Dictionary<BaseIDs, GeoPoint3DT>();
        }

        #endregion

        #region Methods

        private GeoPoint3DT[] GetBases()
        {
            List<GeoPoint3DT> result = new List<GeoPoint3DT>();
            foreach (var item in bases)
            {
                result.Add(item.Value);
            }

            return result.ToArray();
        }

        public void Reset()
        {
            bases.Clear();
            prevTOA = double.NaN;
        }

        public GeoPoint3DT[] ProcessBase(BaseIDs baseID, double lat, double lon, double dpt, double toa)
        {
            GeoPoint3DT[] result = null;

            if (!double.IsNaN(toa))
            {
                if (bases.ContainsKey(baseID))
                {
                    if (bases.Count >= 3)
                    {
                        result = GetBases();
                    }

                    bases.Clear();
                    bases.Add(baseID, new GeoPoint3DT(lat, lon, dpt, toa));
                }
                else
                {
                    if (!double.IsNaN(prevTOA))
                    {
                        if (((toa - prevTOA) <= pingerPeriod / 2) ||
                            ((toa + 60 - prevTOA) <= pingerPeriod / 2))
                        {
                            bases.Add(baseID, new GeoPoint3DT(lat, lon, dpt, toa));

                            if (bases.Count >= 4)
                            {
                                result = GetBases();
                                bases.Clear();
                            }
                        }
                        else
                        {
                            if (bases.Count >= 3)
                            {
                                result = GetBases();
                            }

                            bases.Clear();
                            bases.Add(baseID, new GeoPoint3DT(lat, lon, dpt, toa));
                        }
                    }
                    else
                    {
                        bases.Add(baseID, new GeoPoint3DT(lat, lon, dpt, toa));
                    }
                }

                prevTOA = toa;
            }

            return result;
        }

        #endregion
    }
}
