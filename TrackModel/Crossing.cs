using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackModelPrototype
{
    class Crossing
    {
        Block redLineBlock = null;
        Block greenLineBlock = null;
        string currentLineDown = null;
        bool isBroken = false;

        public Crossing(Block newBlock)
        {
            if (newBlock.GetLine().Equals("red"))
            {
                redLineBlock = newBlock;
                currentLineDown = "red";
            }
            else
            {
                greenLineBlock = newBlock;
                currentLineDown = "green";
            }
        }

        public void AddBlock(Block newBlock)
        {
            if (newBlock.GetLine().Equals("red"))
            {
                redLineBlock = newBlock;
            }
            else
            {
                greenLineBlock = newBlock;
            }
        }

        public void ToggleCrossing()
        {
            if (currentLineDown.Equals("green"))
            {
                currentLineDown = "red";
            }
            else
            {
                currentLineDown = "green";
            }
        }

        public bool IsBroken()
        {
            return isBroken;
        }

        public string ToString()
        {
            if (currentLineDown.Equals("green"))
            {
                return "green" + "\t" + greenLineBlock.GetSectionName() + "\t" + greenLineBlock.GetBlockNumber();
            }
            else
            {
                return "red" + "\t" + redLineBlock.GetSectionName() + "\t" + redLineBlock.GetBlockNumber();
            }
        }

        public bool GetCrossingState(string line)
        {
            if (currentLineDown.Equals(line))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
