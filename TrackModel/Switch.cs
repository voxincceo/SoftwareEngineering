using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackModelPrototype
{
    class Switch
    {
        private ArrayList switchBlocks;
        private string switchNum;
        private Block switchedBlock = null;
        private Block unswitchedBlock = null;
        private Block switchBlock = null;
        private int setupCount = 0;
        private bool brokenSwitch = false;

        public Switch(Block blockIn)
        {
            switchNum = blockIn.GetSwitchNumber();
            AddBlock(blockIn);
        }

        public void AddBlock(Block blockIn)
        {
            blockIn.SetSwitch(this);

            if (blockIn.GetSwitchBlock().Length > 0)
            {
                switchBlock = blockIn;
            }
            else if (switchedBlock == null)
            {
                switchedBlock = blockIn;
            }
            else
            {
                unswitchedBlock = blockIn;
            }
        }

        public string GetSwitchNumber()
        {
            return switchNum;
        }
        public Block GetSwitchBlock()
        {
            return switchBlock;
        }
        public Block GetSwitchedBlock()
        {
            return switchedBlock;
        }
        public Block GetUnswitchedBlock()
        {
            return unswitchedBlock;
        }
        private void SetOutOfSection(Block sourceBlock, Block targetBlock)
        {
            if (sourceBlock.GetNext() != null && sourceBlock.GetNext().GetSectionName().Equals(sourceBlock.GetSectionName()))
            {
                sourceBlock.SetPrev(targetBlock);
            }
            else
            {
                sourceBlock.SetNext(targetBlock);
            }
        }

        public void setup()
        {
            if (switchBlock.GetSwitchType().Equals("-"))
            {
                SetOutOfSection(switchBlock, switchedBlock);
                SetOutOfSection(switchedBlock, switchBlock);
                SetOutOfSection(unswitchedBlock, null);
            }
            else if (switchBlock.GetSwitchType().Equals("BEFORE"))
            {
                switchBlock.SetPrev(switchedBlock);
                if (switchedBlock.GetSectionName().Equals(switchBlock.GetSectionName()))
                {
                    switchedBlock.SetNext(switchBlock);
                    SetOutOfSection(unswitchedBlock, null);
                }
                else
                {
                    SetOutOfSection(switchedBlock, switchBlock);
                    unswitchedBlock.SetNext(null);
                }
            }
            else if (switchBlock.GetSwitchType().Equals("AFTER"))
            {
                if (switchBlock.GetDirection() == -1)
                {
                    switchBlock.SetPrev(switchedBlock);

                    if (switchedBlock.GetSectionName().Equals(switchBlock.GetSectionName()))
                    {
                        switchedBlock.SetNext(switchBlock);
                        SetOutOfSection(unswitchedBlock, null);
                    }
                    else
                    {
                        SetOutOfSection(switchedBlock, switchBlock);
                        unswitchedBlock.SetNext(null);
                    }
                }
                else
                {
                    switchBlock.SetNext(switchedBlock);
                    if (switchedBlock.GetSectionName().Equals(switchBlock.GetSectionName()))
                    {
                        switchedBlock.SetPrev(switchBlock);
                        SetOutOfSection(unswitchedBlock, null);
                    }
                    else
                    {
                        SetOutOfSection(switchedBlock, switchBlock);
                        unswitchedBlock.SetPrev(null);
                    }
                }
            }

            if (setupCount < 2)
            {
                setupCount++;
                ToggleSwitch();
            }
        }

        public void ToggleSwitch()
        {
            Block temp = switchedBlock;
            switchedBlock = unswitchedBlock;
            unswitchedBlock = temp;
            setup();
        }

        public void breakSwitch()
        {
            brokenSwitch = !(brokenSwitch);
        }

        public bool IsSwitchWorking()
        {
            return brokenSwitch;
        }

        public bool GetSwitchPosition()
        {
            return false;
        }

        public string SwitchToString()
        {
            if (brokenSwitch)
            {
                return switchedBlock.GetLine() + "\t" + switchNum + "\t" + brokenSwitch;
            }
            else
            {
                return switchedBlock.GetLine() + "\t" + switchedBlock + "\t" + switchedBlock.GetSectionName() + switchedBlock.GetBlockNumber();
            }
        }
    }
}
