using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackController
{
    public class Rail
    {
        private int blockNumber;
        private Boolean isBroken;
        private Boolean isHeated;

        public Rail(int inBlockNumber, Boolean inBroken, Boolean inHeated)
        {
            this.blockNumber = inBlockNumber;
            this.isBroken = inBroken;
            this.isHeated = inHeated;
        }

        public int getBlockNumber()
        {
            return this.blockNumber;
        }

        public Boolean getBroken()
        {
            return this.isBroken;
        }

        public Boolean getHeated()
        {
            return this.isHeated;
        }
    }
    
}
