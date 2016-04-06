using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackModelPrototype
{
    class Track
    {
        private Block redYard = null;
        private Block greenYard = null;
        public ArrayList redBlocks = new ArrayList();
        public ArrayList greenBlocks = new ArrayList();
        public ArrayList redSwitches = new ArrayList();
        public ArrayList greenSwitches = new ArrayList();
        private ArrayList trainBlocks = new ArrayList();
        public Crossing lineCrossing = null;

        private int weather;
        private bool powerFailure;

        public Track()
        {
            //LoadTrack("GreenLineVF.csv");
            //LoadTrack("RedLineVF.csv");
            LoadTrack("SystemPrototype.csv");
        }

        public void LoadTrack(string trackFile)
        {
            string file = trackFile;
            string text;
            string[] blockInfo;
            ArrayList currentSwitches = null;
            ArrayList currentBlocks = null;
            Block currentBlock = null;
            Block currentYard = null;
            
            System.IO.StreamReader fileT = new System.IO.StreamReader("../../" + file);
            while ((text = fileT.ReadLine()) != null)
            {
                blockInfo = text.Split(',');
                if (currentBlock == null && blockInfo[0].Equals("red"))
                {
                    currentSwitches = redSwitches;
                    currentBlocks = redBlocks;
                }
                else if (currentBlock == null && blockInfo[0].Equals("green"))
                {
                    currentSwitches = greenSwitches;
                    currentBlocks = greenBlocks;
                }

                currentBlock = new Block(blockInfo, currentBlock);
                currentBlocks.Add(currentBlock);

                if (currentBlock.IsCrossing())
                {
                    if (lineCrossing == null)
                    {
                        lineCrossing = new Crossing(currentBlock);
                    }
                    else
                    {
                        lineCrossing.AddBlock(currentBlock);
                    }
                    currentBlock.AddCrossing(lineCrossing);
                }

                SwitchSetup(blockInfo, currentBlock, currentSwitches);
                if (blockInfo[6].Equals("FROM YARD") || blockInfo[6].Equals("TO YARD/FROM YARD"))
                {
                    if (blockInfo[0].Equals("green"))
                    {
                        greenYard = currentBlock;
                    }
                    else
                    {
                        redYard = currentBlock;
                    }
                }
            }

            foreach (Switch setupSwitch in currentSwitches)
            {
                setupSwitch.setup();
            }
            //PrintSwitchList(currentSwitches);

            foreach (Switch setupSwitch in currentSwitches)
            {
                setupSwitch.ToggleSwitch();
            }
            //PrintSwitchList(currentSwitches);
        }

        public ArrayList GetRoute(string line, string destination)
        {
            ArrayList pathBlocks = new ArrayList();
            ArrayList pathBlockStrings = new ArrayList();
            Block currentBlock = null;
            if (line.Equals("red"))
            {
                currentBlock = redYard;
            }
            else
            {
                currentBlock = greenYard;
            }
            pathBlocks.Add(currentBlock);
            while (!currentBlock.GetStation().Equals(destination))
            {
                Block lastTraversed = currentBlock;
                currentBlock = currentBlock.traverse();
                if (lastTraversed == currentBlock)
                {
                    currentBlock.ToggleSwitch();
                }
                else
                {
                    pathBlocks.Add(currentBlock);
                }
            }
            currentBlock.traverse();
            currentBlock.SetSeen(0);

            String routeBlocks;
            foreach (Block path in pathBlocks)
            {
                routeBlocks = path.GetBlockNumber() + "," + path.GetSectionName() + "," + path.GetBlockLength() + "," + path.GetSpeedLimit();
                pathBlockStrings.Add(routeBlocks);
            }
            return pathBlockStrings;
        }

        public void SwitchSetup(string[] strings, Block block, ArrayList currentSwitches)
        {
            if (strings[11].Length > 0)
            {
                bool newSwitch = true;
                Switch existingSwitch = null;
                foreach (Switch checkSwitch in currentSwitches)
                {
                    if (checkSwitch.GetSwitchNumber().Equals(strings[11]))
                    {
                        existingSwitch = checkSwitch;
                        newSwitch = false;
                    }
                }
                if (newSwitch)
                {
                    currentSwitches.Add(new Switch(block));
                }
                else
                {
                    existingSwitch.AddBlock(block);
                }
            }
        }

        public void BreakBlock(string line, int blockNumber)
        {
            GetBlock(blockNumber, line).ToggleBroken();
        }
        public bool BreakBlockCircuit(int blockNumber)
        {
            return false;
        }
        public bool CommandCrossingDown(int blockNumber)
        {
            return false;
        }
        public void CommandAuthority(string line, double commandedAuthority, int blockNumber)
        {
            GetBlock(blockNumber, line).SetAuthority(commandedAuthority);
        }
        public Block ToggleSwitch(string line, int blockNumber)
        {
            return null;
        }
        public bool CloseBlock(string line, int blockNumber)
        {
            GetBlock(blockNumber, line).CloseBlock();
            return false;
        }
        public void CommandSpeed(string line, double commandedSpeed, int blockNumber)
        {
            GetBlock(blockNumber, line).SetCommandedSpeed(commandedSpeed);
        }
        /*public bool ToggleLight(string line, int blockNumber)
        {
            return GetBlock(blockNumber, line).ToggleLights();
        }*/
        public void UpdateDistance(int trainID, double distance)
        {
            foreach (Block b in trainBlocks)
            {
                if (b.GetTrainID() == trainID)
                {
                    Block nextBlock = b.MoveTrain(distance);
                    if (nextBlock != b)
                    {
                        //b = nextBlock;
                        trainBlocks.Remove(b);
                        trainBlocks.Add(nextBlock);
                    }
                    return;
                }
            }
        }
        public void PlaceTrain(String line, int trainID)
        {
            Block trainBlock = null;
            line = line.ToLower();
            if (line.Equals("red"))
            {
                trainBlock = redYard.PlaceTrain(trainID, 0);
            }
            else
            {
                trainBlock = greenYard.PlaceTrain(trainID, 0);
            }
            trainBlocks.Add(trainBlock);
        }

        public Block GetBlock(int blockNumber, string line)
        {
            Block returnBlock = null;
            line = line.ToLower();
            if (line.Equals("red"))
            {
                foreach (Block currentBlock in redBlocks)
                {
                    if (currentBlock.GetBlockNumber() == blockNumber)
                    {
                        returnBlock = currentBlock;
                    }
                }
            }
            else
            {
                foreach (Block currentBlock in greenBlocks)
                {
                    if (currentBlock.GetBlockNumber() == blockNumber)
                    {
                        returnBlock = currentBlock;
                    }
                }
            }
            return returnBlock;
        }
        public Block GetBlock(int trainID)
        {
            /*foreach (Block reds in redBlocks)
            {
                if (reds.GetTrainID() == trainID)
                {
                    return reds;
                }
            }
            foreach (Block greens in greenBlocks)
            {
                if (greens.GetTrainID() == trainID)
                {
                    return greens;
                }
            }
            return null;*/
            foreach (Block trainBlock in trainBlocks)
            {
                if (trainBlock.GetTrainID() == trainID)
                {
                    return trainBlock;
                }
            }
            return null;
        }

        public void ShowBeacon(int blockNumber, string line)
        {
            GetBlock(blockNumber, line).SetBeaconOn();
        }

        public Switch GetSwitch(string switchNum)
        {
            foreach (Switch reds in redSwitches)
            {
                if (reds.GetSwitchNumber().Equals(switchNum))
                {
                    return reds;
                }
            }
            foreach (Switch greens in greenSwitches)
            {
                if (greens.GetSwitchNumber().Equals(switchNum))
                {
                    return greens;
                }
            }
            return null;
        }

        public void SetPowerFailure()
        {
            powerFailure = true;
        }
    }
}
