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
        public int Authority { get; set; }
        public int Speed { get; set; }
        public int CurrentVelocity { get; set; }
        private static double outputPower = 0;

         public TrainController(int trainID)
         {
            ui = new TrainControllerUserInterface(trainID);
            ui.Show();
         }

        public double CalculatePower()
        {
            
        }
    }
}
