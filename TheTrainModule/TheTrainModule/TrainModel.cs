﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheTrainModule
{
    class TrainModel
    {
        private TrainModelForm trainModelForm = null;
        private TrainDatabase trainDatabase = null;
        // private TrackModelForm trackModelForm = null;
        // private TrainControllerForm trainControllerForm = null;
        private Timer timer = null;

        public TrainModel()
        {
            trainModelForm = new TrainModelForm();
            trainDatabase = new TrainDatabase();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
        }

        public TrainDatabase GetTrainDatabase()
        {
            return trainDatabase;
        }

        //------------------------PUBLIC METHODS------------------------------------//

        /*  public void GetModuleObjects(TrackModelForm tr, TrainControllerForm tc)
          {
              trf = tr;
              tcf = tc;
          } */

        public void SetPower(int id, int power)
        {
            trainDatabase.GetTrain(id).setPower = power;
        }

        public void SetVelocity(int id, double velocity)
        {
            trainDatabase.GetTrain(id).velocity = velocity;
        }

        public void SetNextStation(int id, string nextStation)
        {
            trainDatabase.GetTrain(id).nextStation = nextStation;
        }

        public void SetAirConditioning(int id, bool state)
        {
            trainDatabase.GetTrain(id).airConditioning = state;
        }

        public void SetBrakes(int id, int which, bool state)
        {
            Train t = trainDatabase.GetTrain(id);

            if (which == 0)
                t.serviceBrakes = state;
            else
                t.emergencyBrakes = state;
        }

        public void SetLights(int id, bool state)
        {
            trainDatabase.GetTrain(id).lights = state;
        }
        
        public void SetDoors(int id, bool state)
        {
            trainDatabase.GetTrain(id).doors = state;
        }

        public void SetCommandedSpeed(int id, double velocity)
        {
            if (!IDExists(id))
            {
                trainDatabase.AddTrain();
                trainModelForm.updateTrainDatabase(trainDatabase);
                trainModelForm.AddTrain();
            }
            trainDatabase.GetTrain(id).commandedSpeed = velocity;
            //this.send(id, "commanded");
        }

        public void SetAuthority(int id, int authority)
        {
            if (!IDExists(id))
            {
                trainDatabase.AddTrain();
                trainModelForm.updateTrainDatabase(trainDatabase);
                trainModelForm.AddTrain();
            }

            trainDatabase.GetTrain(id).authority = authority;
            //this.send(id, "authority");
        }

        public void SetUnderground(int id, bool state)
        {
            Train t = trainDatabase.GetTrain(id);
            t.underground = state;

            //if(state)
                //this.send(id, "underground");
        }

        public void SetPassengers(int id, int addition)
        {
            trainDatabase.GetTrain(id).passengerCount += addition;
            //this.send(id, "passengers");
        }

        public void SetBeacon(int id, string beacon)
        {
            trainDatabase.GetTrain(id).beacon = beacon;
            
            //this.send(id, "beacon");
        }

        public void SetCurrentBlock(int id, string block)
        {
            trainDatabase.GetTrain(id).currentBlock = block;
        }

        public bool IDExists(int id)
        {
            return trainDatabase.contains(id);
        }

        public void Show()
        {
            trainModelForm.Show();
        }

        private void Timer_Tick(Object sender, EventArgs e)
        {
            trainDatabase.update();
            trainModelForm.updateTrainDatabase(trainDatabase);
        }

        //---------------------------PRIVATE METHODS----------------------------------//

        /* private void send(int id, string info)
         {
             Train train = trainDatabase.GetTrain(id);

             switch (info)
             {
                 case "emergency":
                     trainControllerForm.setEmergencyBrakes(id, train.emergencyBrakes);
                     break;
                 case "beacon":
                     trainControllerForm.setBeacon(id, train.beacon);
                     break;
                 case "temperature":
                     trainControllerForm.setTemperature(id, train.temperature);
                     break;
                 case "commanded":
                     trainControllerForm.setCommandedSpeed(id, train.commandedSpeed);
                     break;
                 case "authority":
                     trainControllerForm.setAuthority(id, train.authority);
                     break;
                 case "velocity":
                     trackModelForm.setVelocity(id, train.velocity);
                     trainControllerForm.setVelocity(id, train.velocity);
                     break;
                 case "underground":
                     trainControllerForm.setUnderground(id, train.underground);
                     break;
                 case "passengers"
                     trackModelForm.setTotalPassengers(id, train.passengerCount);
                     break;
                 default:
                     break;
             }
         }

        sendAll(int id)
        {
            string[] information = { "emergency", "beacon", "temperature", "commanded", "authority", "velocity", "underground", "passengers" };

            for (int i = 0; i < information.Length; i++)
                this.send(id, information[i]);
        }*/

    }
}