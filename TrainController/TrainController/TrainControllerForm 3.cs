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
            trainControllers = new Dictionary<int, TrainController>();
            InitializeComponent();
            Hide();
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
            trainControllers[trainID].Authority = newAuthority;
        }

        public void SetSpeed(int trainID, int newSpeed)
        {
            trainControllers[trainID].Speed = newSpeed;
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
    }
}
