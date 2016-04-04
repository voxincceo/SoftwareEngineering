using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCOffice
{
    public class Route
    {
        private Dictionary<int, ArrayList> routes;
        private int start, end;

        public Route()
        {
            routes = new Dictionary<int, ArrayList>();
            start = 0;
            end = 0;
        }

        public void SetRoute(int number, ArrayList newRoute)
        {
            routes[number] = newRoute;
        }

        public ArrayList GetRoute(int number)
        {
            return routes[number];
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

        public int GetNumberOfPossibleRoutes()
        {
            return routes.Count;
        }
    }
}
