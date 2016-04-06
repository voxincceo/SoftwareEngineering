using System;

namespace TheTrainModule
{
    public class TrainModelTrain
    { 
        public bool active { get; set; }
        public bool doors { get; set; }
        public bool lights { get; set; }
        public bool serviceBrakes { get; set; }
        public bool emergencyBrakes { get; set; }
        public bool airConditioning { get; set; }
        public bool underground { get; set; }

        public double acceleration { get; set; }
        public double force { get; set; }
        public double velocity { get; set; }
        public double power { get; set; }

        public double commandedSpeed { get; set; }

        public int crewCount { get; set; }
        public int passengerCount { get; set; }
        public int failureMode { get; set; }
        public int authority { get; set; }
        public int ejected { get; set; }

        public int temperature { get; set; }

        public string currentBlock { get; set; }
        public string nextStation { get; set; }
        public string beacon { get; set; }

        private double mass = Constants.EMPTY_MASS;
        private double distanceTraveled = 0;     

        public TrainModelTrain()
        {
            active = true;
            doors = Constants.CLOSED;
            lights = Constants.OFF;
            serviceBrakes = false;
            emergencyBrakes = false;
            acceleration = 0;
            temperature = 69;
            velocity = 0;
            crewCount = 2;
            passengerCount = 0;
            ejected = 0;
            failureMode = Constants.NONE;
            currentBlock = "";
            nextStation = "";
            authority = 0;
            commandedSpeed = 0;
            beacon = "";
            power = 0;
        }

        public void Update()
        {
            CalculateMass();
            CalculateForce();
            CalculateAcceleration();
            CalculateVelocity();
            CalculateDistance();
        }

        public void ToFailure()
        {
            active = false;
            doors = Constants.CLOSED;
            lights = Constants.OFF;
            serviceBrakes = false;
            emergencyBrakes = false;
            acceleration = 0;
            temperature = 0;
            velocity = 0;
            crewCount = 0;
            passengerCount = 0;
            currentBlock = "------";
            nextStation = "------";
            authority = 0;
            commandedSpeed = 0;
            power = 0;
        }

        public void driveTrain()
        {
            if (failureMode > 0)
            {
                ToFailure();
            }
            else
            {
                CalculateVelocity();
                CalculateDistance();
            }
        }

        private void CalculateForce()
        {
            double f = 0;
            double p = power;
            double v = velocity;
            double m = mass;

            if (v == 0 && (serviceBrakes || emergencyBrakes))
            {
                f = 0;
            }
            else if(v== 0 && p == 0)
            {
                f = 0;
            }
            else if (v == 0)
            {
                f = Constants.FMAX;
            }
            else if (serviceBrakes)
            {
                f = m * Constants.dMAXN;
            }
            else if (emergencyBrakes)
            {
                f = m * Constants.dMAXE;
            }
            else
            {
                f = p / v;
            }

           force = f;
        }

        private void CalculateMass()
        {
            mass = Constants.EMPTY_MASS + (crewCount + passengerCount) * Constants.HUMAN_MASS;
        }

        private void CalculateAcceleration()
        {
            acceleration = force/mass;

            if (force < 0 && emergencyBrakes)
                acceleration = Constants.dMAXE;
            else if (force < 0)
                acceleration = Constants.dMAXN;
            else if (serviceBrakes)
                acceleration = Constants.dMAXN;
            else if (acceleration > Constants.aMAX)
                acceleration = Constants.aMAX;
        }

        private void CalculateVelocity()
        {
            if (serviceBrakes)
                while (velocity > 0)
                    velocity += Constants.dMAXN;
            else if (emergencyBrakes)
                while (velocity > 0)
                    velocity += Constants.dMAXE;
            else
                velocity += acceleration;

            if (velocity < 0)
                velocity = 0;
            else if (velocity > Constants.vMAX)
                velocity = Constants.vMAX;
        }

        private void CalculateDistance()
        {
            double distance = velocity;
            distanceTraveled += distance;
        }

        private void EjectPassengers()
        {
            int p = passengerCount;
            int r = (int)Math.Ceiling(-Math.Log(p) / Math.Log(Constants.LOAD));

            Random rand = new Random();

            int eject = 0;

            if(r > 0)
             eject = rand.Next(0, r);

            ejected = p * ((int)Math.Pow(Constants.LOAD, eject));

            passengerCount -= ejected;

        }

    }
}
