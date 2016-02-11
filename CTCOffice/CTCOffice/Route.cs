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
        private string stationEnd;

        public Route()
        {
            route = new Dictionary<int, TrackSegment>();
            start = 0;
            end = 0;
            stationEnd = "";
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

        public string GetStationEnd()
        {
            return stationEnd;
        }

        public void SetStart(int value)
        {
            start = value;
        }

        public void SetEnd(int value)
        {
            end = value;
        }

        public void SetStationEnd(string value)
        {
            stationEnd = value;
        }
   
    }
}
