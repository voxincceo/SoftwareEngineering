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
        public int SetAuthority { get; set; }
        public int SetSpeed { get; set; }
        public int CurrentVelocity { get; set; }
        public Boolean DarkOutside { get; set; }
        private static double outputPower = 0;

         public TrainController(int trainID)
         {
            ui = new TrainControllerUserInterface(trainID);
            ui.Show();
         }

        public double CalculatePower()
        {
            outputPower = SetAuthority;
            return outputPower;
        }

        public Boolean GetLightStatus()
        {
            return DarkOutside;
        }

        public void SetPassengerEmergencyBrake()
        {

        }
    }
}
