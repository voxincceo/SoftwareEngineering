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
        Dictionary<string, Route> segmentsInRoute;

        public ControlSystem()
        {
            trains = new Dictionary<int,Train>();
            trackSegments = new Dictionary<int, TrackSegment>();
            segmentsInRoute = new Dictionary<string, Route>();
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

        public void UpdateTrainSpeed(int number, int speed)
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

        public void UpdateTrainSegment(int number, int segment)
        {
            Train temporaryTrain = trains[number];

            temporaryTrain.SetSegment(segment);
        }

        public void UpdateTrainAuthority(int number, int authority)
        {
            Train temporaryTrain = trains[number];

            temporaryTrain.SetAuthority(authority);
        }

        public void UpdateSegmentLine(int number, string line)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetLine(line);
        }

        public void UpdateSegmentOpenClosed(int number, string open)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetOpenClosed(open);
        }

        public void UpdateSegmentFailure(int number, string failure)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetFailure(failure);
        }

        public void UpdateSegmentSwitchDirection(int number, string switchDirection)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetSwitchDirection(switchDirection);
        }

        public void UpdateSegmentSpeedLimit(int number, int speedLimit)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.SetSpeedLimit(speedLimit);
        }

        public void UpdateTrainRoute(ArrayList route, int number)
        {
           trains[number].SetRoute(route);
        }

        public void UpdateTrainSchedule(Dictionary<string, double> schedule, int number)
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
            string stations = "Station1:Station2";

            Route newRoute = new Route();
            newRoute.UpdateRoute(trackSegments);
            newRoute.SetStart(1);
            newRoute.SetEnd(5);
            newRoute.SetStationEnd("Station 2");

            segmentsInRoute.Add(stations, newRoute);

            stations = "Station2:Station1";

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

            segmentsInRoute.Add(stations, newRoute);
        }

        public Route GetRoute(string stations)
        {
            return segmentsInRoute[stations];
        }

        public int GetNumberOfSegments()
        {
            return trackSegments.Count;
        }

        public int GetNumberOfTrains()
        {
            return trains.Count;
        }

    }
}
