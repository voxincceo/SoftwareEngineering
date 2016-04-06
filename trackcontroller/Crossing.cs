using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackController
{
    class Crossing
    {
        private String blockNumber;
        private Boolean state;

        public Crossing(String inBlock, Boolean inState)
        {
            this.blockNumber = inBlock;
            this.state = inState;
        }
        public String getBlockNumber()
        {
            return this.blockNumber;
        }
        public Boolean getState()
        {
            return this.state;
        }
        public void setState(Boolean invar)
        {
            this.state = invar;
        }
    }
}
