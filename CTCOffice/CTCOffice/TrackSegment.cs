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

        public void SetLength(int value)
        {
            length = value;
        }

        public void SetNumber(int value)
        {
            number = value;
        }

        public void SetLine(string newLine)
        {
            line = newLine;
        }

        public void SetOpenClosed(string newOpenClosed)
        {
            openClosed = newOpenClosed;
        }

        public void SetFailure(string newFailure)
        {
            failure = newFailure;
        }

        public void SetSwitchDirection(string newSwitchDirection)
        {
            switchDirection = newSwitchDirection;
        }

        public void SetSpeedLimit(int newSpeedLimit)
        {
            speedLimit = newSpeedLimit;
        }

        public int GetLength()
        {
            return length;
        }

        public int GetNumber()
        {
            return number;
        }

        public int GetSpeedLimit()
        {
            return speedLimit;
        }

        public string GetLine()
        {
            return line;
        }

        public string GetOpenClosed()
        {
            return openClosed;
        }
        
        public string GetFailure()
        {
            return failure;
        }

        public string GetSwitchDirection()
        {
            return switchDirection;
        }
    }
}
