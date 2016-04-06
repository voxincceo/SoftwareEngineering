using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCOffice
{
    class ControlSystem
    {
        Dictionary<int, Train> trains;
        Dictionary<int, TrackSegment> trackSegments;
        Dictionary<double, Route> routes;
        LinkedList<int> stations;

        public ControlSystem()
        {
            trains = new Dictionary<int,Train>();
            trackSegments = new Dictionary<int, TrackSegment>();
            routes = new Dictionary<double, Route>();
            stations = new LinkedList<int>();
        }

        public void CreateTrain(int number)
        {
            Train temporaryTrain = new Train();
            temporaryTrain.SetNumber(number);

            trains.Add(number, temporaryTrain);
        }

        public void CreateTrackSegment(int number)
        {
            TrackSegment temporaryTrackSegment = new TrackSegment();
            temporaryTrackSegment.SetNumber(number);

            trackSegments.Add(number, temporaryTrackSegment);
        }

        public Train GetTrain(int number)
        {
            return trains[number];
        }

        public TrackSegment GetTrackSegment(int number)
        {
            return trackSegments[number];
        }

        public void SetTrainSpeed(int number, int speed)
        {
            Train temporaryTrain = trains[number];
            /*int oldOnSegment = temporaryTrain.getSegment();
            int changeInPosition;

            if (oldOnSegment == onSegment)
            {
                changeInPosition = Math.Abs(position - temporaryTrain.getPosition());
            }
            else
            {
                if (position > temporaryTrain.getPosition())
                {
                    changeInPosition = position + (trackSegments[oldOnSegment].getLength() - temporaryTrain.getPosition());
                }
                else
                {
                    changeInPosition = (trackSegments[onSegment].getLength() - position) + temporaryTrain.getPosition();
                }
            }*/

            temporaryTrain.SetTrainSpeed(speed);
        }

        public void SetTrainSegment(int number, int segment)
        {
            Train temporaryTrain = trains[number];

            temporaryTrain.SetSegment(segment);
        }

        public void SetTrainAuthority(int number, int authority)
        {
            Train temporaryTrain = trains[number];

            temporaryTrain.SetAuthority(authority);
        }

        public void SetSegmentLine(int number, string line)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetLine(line);
        }

        public void SetSegmentOpenClosed(int number, string open)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetOpenClosed(open);
        }

        public void SetSegmentFailure(int number, string failure)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetFailure(failure);
        }

        public void SetSegmentSwitch(int number, string switchDirection)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetSwitchDirection(switchDirection);
        }

        public void SetSegmentSpeedLimit(int number, int speedLimit)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetSpeedLimit(speedLimit);
        }

        public void SetTrainRoute(int number, Route route)
        {
           trains[number].SetRoute(route);
        }

        public void SetTrainSchedule(int number, Dictionary<int, double> schedule)
        {
            trains[number].SetSchedule(schedule);
        }

        public ArrayList GetTrains()
        {
            ArrayList trainList = new ArrayList();
            foreach (KeyValuePair<int, Train> pair in trains)
            {
                trainList.Add(pair.Value);
            }

            return trainList;
        }

        public ArrayList GetTrackSegments()
        {
            ArrayList segmentList = new ArrayList();
            foreach (KeyValuePair<int, TrackSegment> pair in trackSegments)
            {
                segmentList.Add(pair.Value);
            }

            return segmentList;
        }

        public void GenerateRoutes()
        {
            double stations = 1.5;

            Route newRoute = new Route();
            ArrayList routeMakeUp = new ArrayList();
            routeMakeUp.Add(trackSegments[1]);
            routeMakeUp.Add(trackSegments[2]);
            routeMakeUp.Add(trackSegments[3]);
            routeMakeUp.Add(trackSegments[4]);
            routeMakeUp.Add(trackSegments[5]);
            newRoute.SetStart(1);
            newRoute.SetEnd(5);
            newRoute.SetRoute(newRoute.GetNumberOfPossibleRoutes() + 1, routeMakeUp);

            routes.Add(stations, newRoute);

            stations = 6.13;
            newRoute = new Route();
            routeMakeUp = new ArrayList();
            routeMakeUp.Add(trackSegments[6]);
            routeMakeUp.Add(trackSegments[7]);
            routeMakeUp.Add(trackSegments[8]);
            routeMakeUp.Add(trackSegments[9]);
            routeMakeUp.Add(trackSegments[10]);
            routeMakeUp.Add(trackSegments[11]);
            routeMakeUp.Add(trackSegments[12]);
            routeMakeUp.Add(trackSegments[13]);
            newRoute.SetStart(6);
            newRoute.SetEnd(13);
            newRoute.SetRoute(newRoute.GetNumberOfPossibleRoutes() + 1, routeMakeUp);

            routes.Add(stations, newRoute);

            /*stations = "Station2:Station1";

            newRoute = new Route();
            Dictionary<int, TrackSegment> segments = new Dictionary<int, TrackSegment>();
            segments.Add(5, trackSegments[5]);
            segments.Add(4, trackSegments[4]);
            segments.Add(3, trackSegments[3]);
            segments.Add(2, trackSegments[2]);
            segments.Add(1, trackSegments[1]);

            newRoute.UpdateRoute(segments);
            newRoute.SetStart(5);
            newRoute.SetEnd(1);
            newRoute.SetStationEnd("Station 1");

            routes.Add(stations, newRoute);*/
        }

        public void GenerateStations()
        {
            LinkedListNode<int> node = new LinkedListNode<int>(0);
            foreach(KeyValuePair<int, TrackSegment> ts in trackSegments)
            {
                if(ts.Value.IsStation())
                {
                    if(stations.Count == 0)
                    {
                        stations.AddFirst(ts.Value.GetNumber());
                        node = stations.First;
                    }
                    else
                    {
                        stations.AddAfter(node, ts.Value.GetNumber());
                        node = stations.Find(ts.Value.GetNumber());
                    }
                }
            }
        }

        public Route GetRoute(double stations)
        {
            return routes[stations];
        }

        public int GetNumberOfSegments()
        {
            return trackSegments.Count;
        }

        public int GetNumberOfTrains()
        {
            return trains.Count;
        }

        public void UpdateTrainRoute(int number)
        {
            Train train = trains[number];
           
            if(train.GetSegment() != train.GetDestination())
            {
                if (train.GetSegment() != 1)    //check if fresh out of yard
                {
                    train.SetNextStation(stations.Find(train.GetNextStation()).Next.Value);
                }
                else
                {
                    train.SetNextStation(stations.First.Next.Value);
                }

                if (routes.ContainsKey(train.GetSegment() + ((double)train.GetNextStation() / 10)))
                {
                    train.SetRoute(GetRoute(train.GetSegment() + ((double)train.GetNextStation() / 10)));
                    train.SetActiveRoute(1);
                    train.SetDirection("East");
                }
                else if (routes.ContainsKey(train.GetNextStation() + ((double)train.GetSegment() / 10))) 
                {
                    train.SetRoute(GetRoute(train.GetNextStation() + ((double)train.GetSegment() / 10)));
                    train.SetActiveRoute(1);
                    train.SetDirection("West");
                }
            }
        }

    }
}
