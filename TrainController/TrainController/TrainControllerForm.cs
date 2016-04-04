﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainController
{
    public partial class TrainControllerForm : Form
    {

        Dictionary<int, TrainController> trainControllers;
        private static int trainCount = 0;

        public TrainControllerForm()
        {
            InitializeComponent();
            Hide();

            trainControllers = new Dictionary<int, TrainController>();
        }

        private void DispatchTrain(int trainID)
        {
            TrainController newTrain = new TrainController(trainID);
            trainControllers.Add(trainID, newTrain);
            trainCount++;
        }

        public void updateTrain(int trainID)
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

        public void SetSpeed(int trainID, int newSpeed)
        {
            trainControllers[trainID].SetSpeed = newSpeed;
        }

        public void SetVelocity(int trainID, int newVelocity)
        {
            trainControllers[trainID].CurrentVelocity = newVelocity;
        }

        public double GetPower(int trainID)
        {
            double result = trainControllers[trainID].CalculatePower();
            return result;
        }

        public void SetDarkOutside(int trainID, Boolean darkOutside)
        {
            trainControllers[trainID].DarkOutside = darkOutside;
        }

        public Boolean GetLightStatus(int trainID)
        {
            Boolean result = trainControllers[trainID].GetLightStatus();
            return result;
        }

        public void SetPassengerEmergencyBrake(int trainID)
        {
            trainControllers[trainID].SetPassengerEmergencyBrake();
        }

        public void SetTemperature(int trainID, int Temperature)
        {
            trainControllers[trainID].Temperature = Temperature;
        }

        public Boolean GetAirConditionierStatus(int trainID)
        {
            Boolean result = trainControllers[trainID].GetAirConditionerStatus();
            return result;
        }

        public Boolean GetDoorStatus(int trainID)
        {
            Boolean result = trainControllers[trainID].GetDoorStatus();
            return result;
        }

        public String GetAdvertisementName(int trainID)
        {
            String result = trainControllers[trainID].GetAdvertisementName();
            return result;
        }
    }
}
