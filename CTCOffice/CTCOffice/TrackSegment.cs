using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCOffice
{
    class TrackSegment
    {
        private int number, speedLimit, length;
        private string line, openClosed, failure, switchDirection;

        public TrackSegment()
        {
            number = 0;
            speedLimit = 0;
            length = 0;
            line = "Black";
            openClosed = "Open";
            failure = "None";
            switchDirection = "N/A";
        }

        public void setLength(int value)
        {
            length = value;
        }

        public void setNumber(int value)
        {
            number = value;
        }

        public void updateLine(string newLine)
        {
            line = newLine;
        }

        public void updateOpenClosed(string newOpenClosed)
        {
            openClosed = newOpenClosed;
        }

        public void updateFailure(string newFailure)
        {
            failure = newFailure;
        }

        public void updateSwitchDirection(string newSwitchDirection)
        {
            switchDirection = newSwitchDirection;
        }

        public void updateSpeedLimit(int newSpeedLimit)
        {
            speedLimit = newSpeedLimit;
        }

        public int getLength()
        {
            return length;
        }

        public int getNumber()
        {
            return number;
        }

        public int getSpeedLimit()
        {
            return speedLimit;
        }

        public string getLine()
        {
            return line;
        }

        public string getOpenClosed()
        {
            return openClosed;
        }
        
        public string getFailure()
        {
            return failure;
        }

        public string getSwitchDirection()
        {
            return switchDirection;
        }
    }
}
