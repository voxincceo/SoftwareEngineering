using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainController
{
    public class TrainController
    {
        private static TrainControllerUserInterface ui;
        private static TrainControllerForm thisTrainControllerForm;
        public int SetAuthority { get; set; }
        public double SetSpeed { get; set; }
        public double CurrentVelocity { get; set; }
        public int Temperature { get; set; }
        public Boolean DarkOutside { get; set; }
        public double DriverSpeed { get; set; }
        public Boolean ServiceBrakes { get; set; }
        public Boolean DriverEmergencyBrake { get; set; }
        public Boolean PassengerEmergencyBrake { get; set; }
        public Boolean AirConditionerStatus { get; set; }
        private static double outputPower;
        public Boolean Doors { get; set; }
        public String AdvertisementName { get; set; }
        public String Beacon { get; set; }
        public String NextStation { get; set; }
        public int FailureMode { get; set; }
        public int ThisTrainID { get; set; }

         public TrainController(int trainID, TrainControllerForm trainControllerForm)
         {
            ui = new TrainControllerUserInterface(trainID, this);
            thisTrainControllerForm = trainControllerForm;
            ThisTrainID = trainID;
            SetAuthority = 0;
            SetSpeed = 0;
            CurrentVelocity = 0;
            Temperature = 68;
            DarkOutside = false;
            DriverSpeed = 0;
            DriverEmergencyBrake = false;
            outputPower = 0;
            ui.showThis();
           
         }

        private void SendDoorStatus()
        {
            thisTrainControllerForm.SendDoorStatus(ThisTrainID);
        }

        private void SendServiceBrake()
        {
            thisTrainControllerForm.SendServiceBrake(ThisTrainID);
        }

        private void SendEmergencyBrake()
        {
            thisTrainControllerForm.SendEmergencyBrake(ThisTrainID);
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
            thisTrainControllerForm.SendAirConditionerStatus(ThisTrainID);
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

        public void ChangeSpeed(double newSpeed)
        {
            DriverSpeed = newSpeed;
        }

        public void HitDriverEmergencyBrake()
        {
            DriverEmergencyBrake = true;
            ui.SetEngineerEmergencyBrake(DriverEmergencyBrake);
        }

        public void SetFailure(int newFailure)
        {
            FailureMode = newFailure;
        }
    }
}
