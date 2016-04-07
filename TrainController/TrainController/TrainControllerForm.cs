using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTrainModule;

namespace TrainController
{
    public partial class TrainControllerForm : Form
    {
        System.Timers.Timer timer;
        Dictionary<int, TrainController> trainControllers;
        private static int trainCount = 0;
        TrainModelForm trainModel;

        public TrainControllerForm(System.Timers.Timer newTimer)
        {
            InitializeComponent();
            Hide();

            trainControllers = new Dictionary<int, TrainController>();
            timer = newTimer;
/*
            DispatchTrain(1);
            SetAuthority(1, 100);
            SetSpeed(1, 50);
            SetVelocity(1, 0);
            double result = GetPower(1);
 */
    }

        private void DispatchTrain(int trainID)
        {
            TrainController newTrain = new TrainController(trainID, this);
            trainControllers.Add(trainID, newTrain);
            trainCount++;
        }

        private void SendPower(int trainID)
        {
            double result = trainControllers[trainID].CalculatePower();
            trainModel.SetPower(trainID, (int)result);
        }

        private void SetDoorStatus(int trainID)
        {
            trainModel.SetDoors(trainID, trainControllers[trainID].Doors);
        }

        public void SendModules(TrainModelForm newTrainModel)
        {
            trainModel = newTrainModel;
        }

        public void UpdateTrain(int trainID)
        {
            if (trainControllers.ContainsKey(trainID) != true)
            {
                DispatchTrain(trainID);
            }
        }

        public void SetAuthority(int trainID, int newAuthority)
        {
            trainControllers[trainID].SetAuthority = newAuthority;
        }

        public void SetSpeed(int trainID, double newSpeed)
        {
            trainControllers[trainID].SetSpeed = newSpeed;
        }

        public void SetVelocity(int trainID, double newVelocity)
        {
            trainControllers[trainID].CurrentVelocity = newVelocity;
        }

        public void SetDarkOutside(int trainID, Boolean darkOutside)
        {
            trainControllers[trainID].DarkOutside = darkOutside;
            trainModel.SetLights(trainID, darkOutside);
        }

        public Boolean GetLightStatus(int trainID)
        {
            Boolean result = trainControllers[trainID].GetLightStatus();
            return result;
        }

        public void SetPassengerEmergencyBrakes(int trainID)
        {
            trainControllers[trainID].SetPassengerEmergencyBrake(true);
        }

        public void SetTemperature(int trainID, int Temperature)
        {
            trainControllers[trainID].Temperature = Temperature;
        }

        public void SetBeacon(int trainID, string newBeacon)
        {
            trainControllers[trainID].Beacon = newBeacon;
        }

        public String GetAdvertisementName(int trainID)
        {
            String result = trainControllers[trainID].GetAdvertisementName();
            return result;
        }

        public void SetFailure(int trainID, int failureMode)
        {
            trainControllers[trainID].SetFailure(failureMode);
        }

        public void SendDoorStatus(int trainID)
        {
            SetDoorStatus(trainID);
        }

        public void SendServiceBrake(int trainID)
        {
            trainModel.SetBrakes(trainID, 0, trainControllers[trainID].ServiceBrakes);
        }

        public void SendEmergencyBrake(int trainID)
        {
            trainModel.SetBrakes(trainID, 1, trainControllers[trainID].DriverEmergencyBrake);
        }

        public void SendAirConditionerStatus(int trainID)
        {
            trainModel.SetAirConditioning(trainID, trainControllers[trainID].AirConditionerStatus);
        }

        public void SendNextStation(int trainID)
        {
            trainModel.SetNextStation(trainID, trainControllers[trainID].NextStation);
        }
    }
}
