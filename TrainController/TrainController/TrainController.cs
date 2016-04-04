using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainController
{
    public class TrainController
    {
        private static TrainControllerUserInterface ui;
        public int SetAuthority { get; set; }
        public int SetSpeed { get; set; }
        public int CurrentVelocity { get; set; }
        public int Temperature { get; set; }
        public Boolean DarkOutside { get; set; }
        public int DriverSpeed { get; set; }
        public Boolean DriverEmergencyBrake { get; set; }
        private static double outputPower;
        public Boolean Doors { get; set; }
        public String AdvertisementName { get; set; }

         public TrainController(int trainID)
         {
            ui = new TrainControllerUserInterface(trainID, this);
            SetAuthority = 0;
            SetSpeed = 0;
            CurrentVelocity = 0;
            Temperature = 68;
            DarkOutside = false;
            DriverSpeed = 0;
            DriverEmergencyBrake = false;
            outputPower = 0;
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

        public Boolean GetAirConditionerStatus()
        {
            if (Temperature < 68)
                return false;
            else
                return true;
        }

        public Boolean GetDoorStatus()
        {
            return Doors;
        }

        public String GetAdvertisementName()
        {
            return AdvertisementName;
        }
    }
}
