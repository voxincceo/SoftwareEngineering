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

        public ControlSystem()
        {
            trains = new Dictionary<int,Train>();
            trackSegments = new Dictionary<int, TrackSegment>();
        }

        public void createTrain(int number)
        {
            Train temporaryTrain = new Train();
            temporaryTrain.setNumber(number);

            trains.Add(number, temporaryTrain);
        }

        public void createTrackSegment(int number)
        {
            TrackSegment temporaryTrackSegment = new TrackSegment();
            temporaryTrackSegment.setNumber(number);

            trackSegments.Add(number, temporaryTrackSegment);
        }

        public Train getTrain(int number)
        {
            return trains[number];
        }

        public TrackSegment getTrackSegment(int number)
        {
            return trackSegments[number];
        }

        public void updateTrainSpeed(int number, int speed)
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

            temporaryTrain.updateTrainSpeed(speed);
        }

        public void updateTrainSegment(int number, int segment)
        {
            Train temporaryTrain = trains[number];

            temporaryTrain.updateSegment(segment);
        }

        public void updateTrainAuthority(int number, int authority)
        {
            Train temporaryTrain = trains[number];

            temporaryTrain.updateAuthority(authority);
        }

        public void updateSegmentLine(int number, string line)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.updateLine(line);
        }

        public void updateSegmentOpenClosed(int number, string open)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.updateOpenClosed(open);
        }

        public void updateSegmentFailure(int number, string failure)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.updateFailure(failure);
        }

        public void updateSegmentSwitchDirection(int number, string switchDirection)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.updateSwitchDirection(switchDirection);
        }

        public void updateSegmentSpeedLimit(int number, int speedLimit)
        {
            TrackSegment temporaryTrackSegment = trackSegments[number];

            temporaryTrackSegment.updateSpeedLimit(speedLimit);
        }

        public void updateTrainRoute(ArrayList route, int number)
        {
           trains[number].changeRoute(route);
        }

        public void updateTrainSchedule(Dictionary<string, double> schedule, int number)
        {
            trains[number].changeSchedule(schedule);
        }
    }
}
