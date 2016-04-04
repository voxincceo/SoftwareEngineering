using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainController
{
    class TrainController
    {
        private static TrainControllerUserInterface ui;
        public int authority { get; set; }


         public TrainController(int trainID)
         {
            ui = new TrainControllerUserInterface(trainID);
            ui.Show();
         }
    }
}
