using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackController
{
    class Switch
    {
        private int switchNum;
        private Boolean state;

        public Switch(int inSwitchNum, Boolean inState)
        {
            this.switchNum = inSwitchNum;
            this.state = inState;
        }
        public int getSwitchNum()
        {
            return this.switchNum;
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
