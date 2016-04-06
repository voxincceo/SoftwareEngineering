using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TheTrainModule
{
    public class TrainDatabase
    {
        private int trainCount = 0;
        private Dictionary<TrainModelTrain, int> trains = null;

        public TrainDatabase()
        {
            trains = new Dictionary<TrainModelTrain, int>();
        }

        public bool AddTrain(TrainModelTrain newTrain)
        {
            if (newTrain == null)
                return false;
            else
            {
                trains.Add(newTrain, ++trainCount);
                return true; 
            }
        }

        public void AddTrain()
        {
            trains.Add(new TrainModelTrain(), ++trainCount);
        }

        public int GetTrainID(TrainModelTrain train)
        {
            int value;
            if (trains.TryGetValue(train, out value))
            {
                return value;
            }
            return -1;
        }

        public TrainModelTrain GetTrain(int id)
        {
            List<TrainModelTrain> listOfTrains = new List<TrainModelTrain>(trains.Keys);
            TrainModelTrain thisTrain = null;

            foreach(TrainModelTrain tr in listOfTrains)
            {
                int value = -1;
                trains.TryGetValue(tr, out value);

                if (value == id)
                {
                    thisTrain = tr;
                    break;
                }      
            }

            return thisTrain;
        }

        public int Size()
        {
            return trainCount;
        }

        public TrainDatabase Get()
        {
            return this;
        }

        public bool Contains(int id)
        {
            return !(this.GetTrain(id) == null);
        }

        public void UpdateTrain(int id)
        {
            GetTrain(id).Update();
        }

        public void DriveTrains()
        {
            List<TrainModelTrain> listOfTrains = new List<TrainModelTrain>(trains.Keys);

            if (listOfTrains.Count > 0)
            {
                foreach (TrainModelTrain t in listOfTrains)
                {
                    if (t == null)
                        break;

                    t.DriveTrain();
                }
            }
        }
    }
}
