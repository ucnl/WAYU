using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNLNav;

namespace WAYU.APL
{
    public class DPoint3DTm
    {
        #region Properties

        public double Dst2Prev_m;
        public double Time2Prev_s;

        public double Lat_rad;
        public double Lon_rad;
        public double Dpt_m;
        public DateTime TimeStamp;

        #endregion

        #region Constructor

        public DPoint3DTm(double inLat, double inLon, double inDpt, DateTime inTS, DPoint3DTm prevPoint)
        {
            Lat_rad = inLat;
            Lon_rad = inLon;
            Dpt_m = inDpt;
            TimeStamp = inTS;

            Dst2Prev_m = Algorithms.HaversineInverse(Lat_rad, Lon_rad,
                prevPoint.Lat_rad, prevPoint.Lon_rad,
                Algorithms.WGS84Ellipsoid.MajorSemiAxis_m);

            Time2Prev_s = inTS.Subtract(prevPoint.TimeStamp).TotalSeconds;
        }

        public DPoint3DTm(double inLat, double inLon, double inDpt, DateTime inTS)
        {
            Lat_rad = inLat;
            Lon_rad = inLon;
            Dpt_m = inDpt;
            TimeStamp = inTS;
            Dst2Prev_m = double.NaN;
            Time2Prev_s = double.NaN;
        }

        #endregion
    }

    public class DHFilter
    {
        #region Properties

        List<List<DPoint3DTm>> sides;

        int pSideIdx = 0;
        int sSideIdx { get { return pSideIdx == 0 ? 1 : 0; } }

        double maxSpeedMps = 1;
        public double MaxSpeedMps
        {
            get { return maxSpeedMps; }
            set
            {
                if (value >= 0.0)
                    maxSpeedMps = value;
                else
                    throw new ArgumentOutOfRangeException("value", "Value must be non-negative");
            }
        }

        double dstThreshold_m = 5;
        public double DstThreshold_m
        {
            get { return dstThreshold_m; }
            set
            {
                if (value >= 0.0)
                    dstThreshold_m = value;
                else
                    throw new ArgumentOutOfRangeException("value", "Value must be non-negative");
            }
        }

        int fifoSize = 0;
        public int FIFOSize { get { return fifoSize; } }

        #endregion

        #region Constructor

        public DHFilter(int fifoSize, double maxSpeedMps, double dstTrhesholdm)
        {
            this.fifoSize = fifoSize;
            MaxSpeedMps = maxSpeedMps;
            DstThreshold_m = dstTrhesholdm;
            sides = new List<List<DPoint3DTm>>
            {
                new List<DPoint3DTm>(),
                new List<DPoint3DTm>()
            };
        }

        #endregion

        #region Methods

        private void AddPoint(int listIdx, DPoint3DTm newPoint)
        {
            if (sides[listIdx].Count + 1 > fifoSize)
                sides[listIdx].RemoveAt(0);

            sides[listIdx].Add(newPoint);
        }

        private void UpdateStatistics()
        {
            if ((sides[0].Count == fifoSize) && (sides[1].Count == fifoSize))
            {
                double[] meanDst = new double[2];

                for (int i = 0; i < sides.Count; i++)
                {
                    meanDst[i] = 0.0;
                    for (int j = 0; j < sides[i].Count; j++)
                        meanDst[i] += sides[i][j].Dst2Prev_m;

                    meanDst[i] /= sides[i].Count;
                }

                double[] sigmas = new double[2];
                for (int i = 0; i < sides.Count; i++)
                {
                    for (int j = 0; j < sides[i].Count; j++)
                        sigmas[i] += Math.Pow(sides[i][j].Dst2Prev_m - meanDst[i], 2);

                    sigmas[i] = Math.Sqrt(sigmas[i]);
                }

                if (sigmas[pSideIdx] > sigmas[sSideIdx])
                    pSideIdx = sSideIdx;
            }
        }

        public bool Process(double inLat, double inLon, double inDpt, DateTime inTS,
            out double outLat, out double outLon, out double outDpt, out DateTime outTS)
        {
            bool result = false;
            outLat = double.NaN;
            outLon = double.NaN;
            outDpt = double.NaN;
            outTS = DateTime.MinValue;

            if (sides[pSideIdx].Count == 0)
            {
                AddPoint(pSideIdx, new DPoint3DTm(inLat, inLon, inDpt, inTS));
                outLat = inLat;
                outLon = inLon;
                outDpt = inDpt;
                outTS = inTS;
                result = true;
            }
            else
            {
                UpdateStatistics();

                DPoint3DTm pLastPoint = sides[pSideIdx][sides[pSideIdx].Count - 1];
                DPoint3DTm pTestPoint = new DPoint3DTm(inLat, inLon, inDpt, inTS, pLastPoint);

                if ((pTestPoint.Dst2Prev_m < pTestPoint.Time2Prev_s * maxSpeedMps) ||
                    (pTestPoint.Dst2Prev_m < dstThreshold_m))
                {
                    AddPoint(pSideIdx, pTestPoint);
                    outLat = inLat;
                    outLon = inLon;
                    outDpt = inDpt;
                    outTS = inTS;
                    result = true;
                }
                else
                {
                    DPoint3DTm sNewPoint;
                    if (sides[sSideIdx].Count > 0)
                    {
                        DPoint3DTm sLastPoint = sides[sSideIdx][sides[sSideIdx].Count - 1];
                        sNewPoint = new DPoint3DTm(inLat, inLon, inDpt, inTS, sLastPoint);
                    }
                    else
                    {
                        sNewPoint = new DPoint3DTm(inLat, inLon, inDpt, inTS);
                    }

                    AddPoint(sSideIdx, sNewPoint);
                }
            }

            return result;
        }

        #endregion
    }
}
