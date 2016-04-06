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
        public double CurrentVelocity { get; set; }
        public int Temperature { get; set; }
        public Boolean DarkOutside { get; set; }
        public int DriverSpeed { get; set; }
        public Boolean DriverEmergencyBrake { get; set; }
        public Boolean PassengerEmergencyBrake { get; set; }
        public Boolean AirConditionerStatus { get; set; }
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
            ui.SetAuthority(SetAuthority);
            ui.SetCommandedSpeed(SetSpeed);
            ui.SetCurrentVelocity(CurrentVelocity);
            outputPower = 1;
            ui.SetOutputPower(outputPower);
            return outputPower;
        }

        public Boolean GetLightStatus()
        {
            ui.SetLightStatus(DarkOutside);
            return DarkOutside;
        }

        public void SetPassengerEmergencyBrake(Boolean emergencyBrake)
        {
            PassengerEmergencyBrake = emergencyBrake;
        }

        public Boolean GetAirConditionerStatus()
        {
            if (Temperature < 68)
                AirConditionerStatus = false;
            else
                AirConditionerStatus = true;
            ui.SetAirConditionerStatus(AirConditionerStatus);
            return AirConditionerStatus;
        }

        public Boolean GetDoorStatus()
        {
            ui.SetDoorStatus(Doors);
            return Doors;
        }

        public String GetAdvertisementName()
        {
            return AdvertisementName;
        }

        public void ChangeSpeed(int newSpeed)
        {
            DriverSpeed = newSpeed;
        }

        public void HitDriverEmergencyBrake()
        {
            DriverEmergencyBrake = true;
            ui.SetEngineerEmergencyBrake(DriverEmergencyBrake);
        }
    }
}
