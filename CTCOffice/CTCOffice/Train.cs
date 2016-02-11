﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCOffice
{
    class Train
    {
        private int number, onSegment, position, speed, authority;
        private string direction, line;
        private System.Timers.Timer timer;
        private ArrayList route;
        private Dictionary<string, double> schedule;

        public Train()
        {
            number = 0;
            onSegment = 0;
            position = 0;
            speed = 0;
            authority = 0;
            direction = "None";
            line = "Black";

            route = new ArrayList();
            schedule = new Dictionary<string, double>();

            timer = new System.Timers.Timer(100);
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            calculatePositionAndAuthority();
        }

        public void setNumber(int value)
        {
            number = value;
        }

        public void updateSegment(int newOnSegment)
        {
            onSegment = newOnSegment;
        }

        public void updateTrainSpeed(int newSpeed)
        {
            speed = newSpeed;
        }

        public void updateAuthority(int newAuthority)
        {
            authority = newAuthority;
        }

        public void updateDirection(string newDirection)
        {
            direction = newDirection;
        }

        public void updateLine(string newLine)
        {
            line = newLine;
        }

        public string getLine()
        {
            return line;
        }

        public int getPosition()
        {
            return position;
        }

        public int getSegment()
        {
            return onSegment;
        }

        public int getNumber()
        {
            return number;
        }

        public int getSpeed()
        {
            return speed;
        }

        public int getAuthority()
        {
            return authority;
        }

        public string getDirection()
        {
            return direction;
        }

        private void calculatePositionAndAuthority()
        {
            int changeInPosition = speed / 36;  // km/h * 1000m / 3600s / 1000ms * 100ms

            if(direction.Equals("East"))
            {
                position = position + changeInPosition; 
            }
            else if (direction.Equals("West"))
            {
                position = position - changeInPosition;
            }

            authority = authority - changeInPosition;
        }

        public void changeRoute(ArrayList newRoute)
        {
            route = newRoute;
        }

        public void changeSchedule(Dictionary<string, double> newSchedule)
        {
            schedule = newSchedule;
        }

        public ArrayList getRoute()
        {
            return route;
        }

        public Dictionary<string, double> getSchedule()
        {
            return schedule;
        }
    }
}
