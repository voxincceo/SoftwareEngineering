using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackModelPrototype
{
    class Block
    {
        private string line;
        private string section;
        private int blockNumber;
        private double blockLength;
        private double grade;
        private int speedLimit;
        private string station;
        private string switchBlock;
        private string underground;
        private double elevation;
        private double cumulativeElevation;
        private string arrow;
        private string switchNumber;
        private int direction;
        private string crossing;
        private string switchType;
        private string stationSide;
        private int stationPeople = 0;
        private bool toYard = false;
        private bool fromYard = false;
        private Block nextBlock;
        private Block prevBlock;
        private int seen = 0;
        private Switch switcher = null;
        String stationName;

        private bool brokenBlock = false;
        private bool closedBlock = false;
        private bool brokenCircuit = false;
        private bool signalWorking = true;
        private Crossing railroadCrossing = null;

        private int trainID = 0;
        private bool blockOccupied = false;
        private bool crossingOccurence;
        private double commandedAuthority = -1;
        private double commandedSpeed = 0;
        private double distanceTraveled = 0;
        private bool lights;    // Green = true, Red = false
        private bool beacon;
        private bool beaconCommanded = false;
        private bool trackHeater = false;

        public Block(String[] blockInfo, Block lastCreated)
        {
            line = blockInfo[0];
            section = blockInfo[1];
            blockNumber = Int32.Parse(blockInfo[2]);
            blockLength = Double.Parse(blockInfo[3]);
            grade = Double.Parse(blockInfo[4]);
            speedLimit = Int32.Parse(blockInfo[5]);
            station = blockInfo[6];
            switchBlock = blockInfo[7];
            underground = blockInfo[8];
            elevation = Double.Parse(blockInfo[9]);
            cumulativeElevation = Double.Parse(blockInfo[10]);
            switchNumber = blockInfo[11];
            arrow = blockInfo[12];
            direction = Int32.Parse(blockInfo[13]);
            crossing = blockInfo[14];
            switchType = blockInfo[15];
            commandedAuthority = -1;
            commandedSpeed = speedLimit;

            if (station.Equals("TO YARD") || station.Equals("TO YARD/FROM YARD"))
            {
                toYard = true;
            }
            if (station.Equals("FROM YARD") || station.Equals("TO YARD/FROM YARD"))
            {
                fromYard = true;
                commandedAuthority = 100;
                commandedSpeed = 10;
            }

            if (toYard == false && fromYard == false && station.Length > 0)
            {
                String[] stationInfo = station.Split('-');
                station = stationInfo[0];
                stationSide = stationInfo[1];
            }

            if (lastCreated == null)
            {

            }
            else if (direction == 1 || direction == 2)
            {
                nextBlock = lastCreated;

                if (nextBlock.GetDirection() == -1)
                {
                    nextBlock.SetNext(this);
                }

                nextBlock.SetPrev(this);
            }
            else if (direction == -1)
            {
                prevBlock = lastCreated;

                if (prevBlock.GetDirection() == 2)
                {
                    prevBlock.SetPrev(this);
                }
                else
                {
                    prevBlock.SetNext(this);
                }
            }

            if (IsStation())
            {
                Random people = new Random();
                stationPeople = people.Next(100);
            }
        }

        

        public void SetNext(Block next)
        {
            nextBlock = next;
        }
        public void SetPrev(Block prev)
        {
            prevBlock = prev;
        }
        public double GetElevation()
        {
            return elevation;
        }
        public double GetCumulativeElevation()
        {
            return cumulativeElevation;
        }
        public String GetLine()
        {
            return line;
        }
        public void SetSwitch(Switch s)
        {
            switcher = s;
        }
        public int GetStationPeople()
        {
            return stationPeople;
        }
        public void ToggleSwitch()
        {
            if (switcher != null)
            {
                switcher.ToggleSwitch();
            }
        }

        public Block GetNext()
        {
            return nextBlock;
        }
        public Block GetPrev()
        {
            return prevBlock;
        }
        public string GetSectionName()
        {
            return section;
        }
        public string GetStation()
        {
            return station;
        }
        public string GetStationSide()
        {
            return stationSide;
        }
        public string GetSwitchNumber()
        {
            return switchNumber;
        }
        public Switch GetSwitch()
        {
            return switcher;
        }
        public string GetSwitchBlock()
        {
            return switchBlock;
        }
        public string GetSwitchType()
        {
            return switchType;
        }
        public void SetSeen(int i)
        {
            seen = i;
        }
        private void SetTrainID(int ID)
        {
            trainID = ID;
        }
        private int GetSeen()
        {
            return seen;
        }

        public Block traverse()
        {
            Block returnBlock = null;
            seen = 1;
            bool zeroNext = false;
            bool zeroPrev = false;

            if (direction == 1 || direction == -1)
            {
                if (this.GetNext() == null)
                {
                    returnBlock = this;
                }
                else
                {
                    returnBlock = this.GetNext();
                }

                if (this.GetPrev() != null)
                {
                    this.GetPrev().SetSeen(0);
                }
            }

            else
            {
                if (this.station.Equals("TO YARD/FROM YARD"))
                {
                    returnBlock = this.GetNext();
                    if (returnBlock == null)
                    {
                        returnBlock = this;
                    }
                }
                else if (this.GetNext() == null)
                {
                    returnBlock = this;
                }
                else if (this.GetPrev() == null)
                {
                    returnBlock = this;
                }
                else if (this.GetNext().GetSeen() == 1)
                {
                    returnBlock = this.GetPrev();
                    zeroNext = true;
                }
                else if (this.GetPrev().GetSeen() == 1)
                {
                    returnBlock = this.GetNext();
                    zeroPrev = true;
                }

                if (returnBlock != null && this.GetArrow().Equals("Head") && returnBlock.GetArrow().Equals("Head") && (returnBlock.GetDirection() == 1 || returnBlock.GetDirection() == -1))
                {
                    returnBlock = this;
                    zeroPrev = false;
                    zeroNext = false;
                }
            }

            if (zeroPrev)
            {
                this.GetPrev().SetSeen(0);
            }
            if (zeroNext)
            {
                this.GetNext().SetSeen(0);
            }
            return returnBlock;
        }

        public Block peek()
        {
            Block returnBlock = null;
            bool zeroNext = false;
            bool zeroPrev = false;

            if (direction == 1 || direction == -1)
            {
                if (this.GetNext() == null)
                {
                    returnBlock = this;
                }
                else
                {
                    returnBlock = this.GetNext();
                }
                if (this.GetPrev() != null)
                {
                    //this.GetPrev().SetSeen(0);
                }
            }
            else
            {
                if (this.station.Equals("TO YARD/FROM YARD"))
                {
                    returnBlock = this.GetNext();
                    if (returnBlock == null)
                    {
                        returnBlock = this;
                    }
                }
                else if (this.GetNext() == null)
                {
                    returnBlock = this;
                }
                else if (this.GetPrev() == null)
                {
                    returnBlock = this;
                }
                else if (this.GetNext().GetSeen() == 1)
                {
                    returnBlock = this.GetPrev();
                    zeroNext = true;
                }
                else if (this.GetPrev().GetSeen() == 1)
                {
                    returnBlock = this.GetNext();
                    zeroPrev = true;
                }

                if (returnBlock != null && this.GetArrow().Equals("Head") && returnBlock.GetArrow().Equals("Head") && (returnBlock.GetDirection() == 1 || returnBlock.GetDirection() == -1))
                {
                    returnBlock = this;
                    zeroPrev = false;
                    zeroNext = false;
                }
            }

            if (zeroPrev)
            {
                //this.GetPrev().SetSeen(0);
            }
            if (zeroNext)
            {
                //this.GetNext().SetSeen(0);
            }
            return returnBlock;

        }

        public string GetArrow()
        {
            return arrow;
        }

        public Block PlaceTrain(int train, double distanceMoved)
        {
            trainID = train;
            blockOccupied = true;
            return this.MoveTrain(distanceMoved);
        }

        public Block MoveTrain(double moved)
        {
            double newDist = moved + distanceTraveled;

            Block currentBlock = this;
            if (newDist >= blockLength)
            {
                Block temp = currentBlock;
                blockOccupied = false;
                distanceTraveled = 0;
                newDist = newDist - blockLength;
                currentBlock = this.TraverseTrain(trainID);
                if (temp == currentBlock)
                {
                    //currentBlock.ToggleSwitch();
                    //currentBlock = currentBlock.TraverseTrain(trainID);
                }
                else
                {
                    currentBlock = currentBlock.PlaceTrain(trainID, newDist);
                }              
            }
            else
            {
                distanceTraveled = newDist;
            }
            return currentBlock;
        }

        public Block TraverseTrain(int train)
        {
            Block returnBlock = null;
            bool zeroNext = false;
            bool zeroPrev = false;

            if (direction == 1 || direction == -1)
            {
                if (this.GetNext() == null)
                {
                    returnBlock = this;
                }
                else
                {
                    returnBlock = this.GetNext();
                }
                if (this.GetPrev() != null)
                {
                    zeroPrev = true;
                }
            }
            else
            {
                if (this.station.Equals("TO YARD/FROM YARD"))
                {
                    returnBlock = this.GetNext();
                    if (returnBlock == null)
                    {
                        returnBlock = this;
                    }
                }
                else if (this.GetNext() == null)
                {
                    returnBlock = this;
                }
                else if (this.GetPrev() == null)
                {
                    returnBlock = this;
                }
                else if (this.GetNext().GetTrainID() == train)
                {
                    returnBlock = this.GetPrev();
                    zeroNext = true;
                }
                else if (this.GetPrev().GetTrainID() == train)
                {
                    returnBlock = this.GetNext();
                    zeroPrev = true;
                }

                if (returnBlock != null && this.GetArrow().Equals("Head") && returnBlock.GetArrow().Equals("Head") && (returnBlock.GetDirection() == 1 || returnBlock.GetDirection() == -1))
                {
                    returnBlock = this;
                    zeroPrev = false;
                    zeroNext = false;
                }
            }

            if (zeroNext)
            {
                this.GetNext().SetTrainID(0);
            }
            if (zeroPrev)
            {
                this.GetPrev().SetTrainID(0);
            }
            return returnBlock;
        }

        public int GetDirection()
        {
            return direction;
        }
        public bool IsSwitch()
        {
            if (switchNumber.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetAuthority(double authority)
        {
            commandedAuthority = authority;
        }
        public double GetBlockLength()
        {
            return blockLength;
        }
        public int GetBlockSpeedLimit()
        {
            return speedLimit;
        }
        public bool IsBlockOccupied()
        {
            return blockOccupied;
        }
        public int GetBlockDirection()
        {
            return direction;
        }
        public bool IsBlockWorking()
        {
            return false;
        }
        public int GetBlockNumber()
        {
            return blockNumber;
        }
        public void CloseBlock()
        {
            closedBlock = true;
        }
        public void OpenBlock()
        {
            closedBlock = false;
        }
        public int GetTrainID()
        {
            return trainID;
        }
        public void SetCommandedSpeed(double cS)
        {
            commandedSpeed = cS;
        }
        public bool GetLights()
        {
            return lights;
        }
        public void ToggleLights(bool value)
        {
            lights = value;
        }
        public void SetBeaconOn()
        {
            beaconCommanded = true;
        }
        public int GetSpeedLimit()
        {
            return speedLimit;
        }
        public bool IsBroken()
        {
            return brokenBlock;
        }
        public bool IsClosed()
        {
            return closedBlock;
        }
        public void BreakCircuit()
        {
            brokenCircuit = true;
            blockOccupied = true;
        }
        public bool IsSignalWorking()
        {
            return signalWorking;
        }
        public bool IsStation()
        {
            if (station.Length>0 && (!toYard||!fromYard))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double GetGrade()
        {
            return grade;
        }
        public double GetTrainAuthority()
        {
            double temp = commandedAuthority;
            commandedAuthority = -1;
            return temp;
        }
        public double GetTrainCommandedSpeed()
        {
            return commandedSpeed;
        }
        public String GetBeacon()
        {
            if (station.Length > 0 && beaconCommanded && (!toYard||!fromYard))
            {
                beaconCommanded = false;
                return station + "," + stationSide + "," + "90" + "," + stationPeople;
            }
            else
            {
                return "";
            }
        }
        public bool IsCrossing()
        {
            if (crossing.Equals("-"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Crossing GetCrossing()
        {
            return railroadCrossing;
        }
        public void AddCrossing(Crossing newCrossing)
        {
            railroadCrossing = newCrossing;
        }
        public void ToggleBroken()
        {
            brokenBlock = !(brokenBlock);
        }
        public double ConvertFromMetricMeters(int value)
        {
            double miles;
            miles = value * 0.000621371;
            return miles;
        }
        public double ConvertFromMetricKilometers(int value)
        {
            double miles;
            miles = value * 0.621371;
            return miles;
        }
    }
}
