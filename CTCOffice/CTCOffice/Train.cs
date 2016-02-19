using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCOffice
{
    class Train
    {
        private int number, onSegment, listNumber;
        private double position, authority, timeOnSchedule, speed;
        private string direction, line;
        private System.Timers.Timer timer;
        private ArrayList route;
        private Dictionary<string, double> schedule;
        private Route routeSegments;

        public Train()
        {
            number = 0;
            onSegment = 0;
            position = 0;
            speed = 0;
            authority = 0;
            timeOnSchedule = 0;
            listNumber = 0;
            direction = "None";
            line = "Black";

            route = new ArrayList();
            schedule = new Dictionary<string, double>();
            routeSegments = new Route();

            timer = new System.Timers.Timer(100);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CalculatePositionAndAuthority();
        }

        public void SetNumber(int value)
        {
            number = value;
        }

        public void SetSegment(int newOnSegment)
        {
            onSegment = newOnSegment;
        }

        public void SetTrainSpeed(double newSpeed)
        {
            speed = newSpeed;
        }

        public void SetAuthority(double newAuthority)
        {
            authority = newAuthority;
        }

        public void SetDirection(string newDirection)
        {
            direction = newDirection;
        }

        public void SetLine(string newLine)
        {
            line = newLine;
        }

        public void SetPosition(double newPosition)
        {
            position = newPosition;
        }

        public void SetTimeOnSchedule(double time)
        {
            timeOnSchedule = time;
        }

        public void SetListNumber(int number)
        {
            listNumber = number;
        }

        public int GetListNumber()
        {
            return listNumber;
        }

        public string GetLine()
        {
            return line;
        }

        public double GetPosition()
        {
            return position;
        }

        public int GetSegment()
        {
            return onSegment;
        }

        public int GetNumber()
        {
            return number;
        }

        public double GetSpeed()
        {
            return speed;
        }

        public double GetAuthority()
        {
            return authority;
        }

        public string GetDirection()
        {
            return direction;
        }

        public double GetTimeOnSchedule()
        {
            return timeOnSchedule;
        }

        private void CalculatePositionAndAuthority()
        {
            double changeInPosition = (double) speed / 36;  // km/h * 1000m / 3600s / 1000ms * 100ms

            if(direction.Equals("East"))
            {
                position = position + changeInPosition; 
            }
            else if (direction.Equals("West"))
            {
                position = position + changeInPosition;
            }

            authority = authority - changeInPosition;
            timeOnSchedule += 0.1;
        }

        public void SetRoute(ArrayList newRoute)
        {
            route = newRoute;
        }

        public void SetSchedule(Dictionary<string, double> newSchedule)
        {
            schedule = newSchedule;
        }

        public ArrayList GetRoute()
        {
            return route;
        }

        public Dictionary<string, double> GetSchedule()
        {
            return schedule;
        }

        public void SetRouteSegments(Route newRoute)
        {
            routeSegments = newRoute;
        }

        public Route GetRouteSegments()
        {
            return routeSegments;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
