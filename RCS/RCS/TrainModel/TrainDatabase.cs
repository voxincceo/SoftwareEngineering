using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TheTrainModule
{
    public class TrainDatabase
    {
        private int trainCount = 0;
        private Dictionary<Train, int> trains = null;

        public TrainDatabase()
        {
            trains = new Dictionary<Train, int>();
        }

        public bool AddTrain(Train newTrain)
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
            trains.Add(new Train(), ++trainCount);
        }

        public int GetTrainID(Train train)
        {
            int value;
            if (trains.TryGetValue(train, out value))
            {
                return value;
            }
            return -1;
        }

        public Train GetTrain(int id)
        {
            List<Train> listOfTrains = new List<Train>(trains.Keys);
            Train thisTrain = null;

            foreach(Train tr in listOfTrains)
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

        public int size()
        {
            return trainCount;
        }

        public TrainDatabase get()
        {
            return this;
        }

        public bool contains(int id)
        {
            return !(this.GetTrain(id) == null);
        }

        public void updateTrain(int id)
        {
            GetTrain(id).update();
        }

        public void driveTrains()
        {
            List<Train> listOfTrains = new List<Train>(trains.Keys);

            if (listOfTrains.Count > 0)
            {
                foreach (Train t in listOfTrains)
                {
                    if (t == null)
                        break;

                    t.driveTrain();
                }
            }
        }
    }
}
