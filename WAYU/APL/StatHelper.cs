using System;
using System.Collections.Generic;
using UCNLDrivers;
using UCNLNav;

namespace WAYU.APL
{
    public class StatHelper
    {
        #region Properties

        List<GeoPoint> ring;

        public int RingSize { get; private set; }
        public int RingCount { get => ring.Count; }
        public double CEP { get; private set; } = double.NaN;
        public double DRMS { get; private set; } = double.NaN;

        bool isActive = false;
        public bool IsActive
        {
            get => isActive;
            private set
            {
                if (value != isActive)
                {
                    isActive = value;
                    IsActiveChanged.Rise(this, new EventArgs());
                }
            }
        }
        public bool IsAutoStop { get; set; } = true;

        #endregion

        #region Constructor

        public StatHelper(int ringSize)
        {
            if (ringSize > 0)
            {
                RingSize = ringSize;
                ring = new List<GeoPoint>();

                CEP = double.NaN;
                DRMS = double.NaN;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        #endregion

        #region Methods

        public void Start()
        {
            Reset();
            IsActive = true;
        }

        public void Stop()
        {
            IsActive = false;
        }

        public void Reset()
        {
            ring.Clear();
            CEP = double.NaN;
            DRMS = double.NaN;
        }

        public void AddPoint(GeoPoint pt)
        {
            ring.Add(pt);

            var mPoints = Navigation.GCSToLCS(ring, Algorithms.WGS84Ellipsoid);

            Navigation.GetPointsSTD2D(mPoints, out double sigmax, out double sigmay);

            CEP = Navigation.CEP(sigmax, sigmay);
            DRMS = Navigation.DRMS(sigmax, sigmay);

            if (ring.Count >= RingSize)
            {
                if (IsAutoStop)
                    Stop();
                else
                    ring.RemoveAt(0);
            }
        }

        #endregion

        #region Events

        public EventHandler IsActiveChanged;

        #endregion
    }
}
