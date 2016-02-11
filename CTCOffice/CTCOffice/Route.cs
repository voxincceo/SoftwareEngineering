using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCOffice
{
    class Route
    {
        Dictionary<int, TrackSegment> route;
        private int start, end;

        public Route()
        {
            route = new Dictionary<int, TrackSegment>();
            start = 0;
            end = 0;
        }

        public void UpdateRoute(Dictionary<int, TrackSegment> newRoute)
        {
            route = newRoute;
        }

        public Dictionary<int, TrackSegment> GetRoute()
        {
            return route;
        }

        public int GetStart()
        {
            return start;
        }

        public int GetEnd()
        {
            return end;
        }

        public void SetStart(int value)
        {
            start = value;
        }

        public void SetEnd(int value)
        {
            end = value;
        }
   
    }
}
