using System;

namespace TheTrainModule
{
    public class Train
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

        public double commandedSpeed { get; set; }

        public int crewCount { get; set; }
        public int passengerCount { get; set; }
        public int failureMode { get; set; }
        public int setPower { get; set; }
        public int authority { get; set; }
        public int ejected { get; set; }

        public int temperature { get; set; }

        public string currentBlock { get; set; }
        public string nextStation { get; set; }
        public string beacon { get; set; }

        private double mass = Constants.EMPTY_MASS;
        private double distanceTraveled = 0;
        private double power = 0;
        private double currentPower = 0;

        private int time =0;
        private int temptime = 0;
        

        public Train()
        {
            active = true;
            doors = Constants.CLOSED;
            lights = Constants.OFF;
            serviceBrakes = false;
            emergencyBrakes = false;
            acceleration = 0;
            temperature = 0;
            velocity = 0;
            crewCount = 2;
            passengerCount = 0;
            ejected = 0;
            failureMode = Constants.NONE;
            currentBlock = null;
            nextStation = null;
            authority = 0;
            commandedSpeed = 0;
            beacon = "";
            setPower = 0;
            currentPower = setPower;
        }

        public void update()
        {
            if (currentPower != power)
            {
                time = 1;
                temptime = 1;
                power = currentPower;
            }
            else
            {
                temptime++;
                time++;
            }

            if (power == 0 && velocity == 0)
                ejectPassengers();

            if (!airConditioning && time > 1799)
            {
                temperature++;
                temptime = 0;
            }
            else if (time > 1799)
            {
                temperature--;
                temptime = 0;
            }

            calculateMass();
            calculateForce();
            calculateAcceleration();
            calculateVelocity();
            calculateDistance();
        }

        private void calculateForce()
        {
            double f = 0;
            double p = power;
            double v = velocity;
            double m = mass;

            if (v == 0 && (serviceBrakes || emergencyBrakes))
                f = 0;
            else if (v == 0)
                f = Constants.FMAX;
            else if (serviceBrakes)
                f = m * Constants.dMAXN;
            else if (emergencyBrakes)
                f = m * Constants.dMAXE;
            else
                f = p / v;

           force = f;
        }

        private void calculateMass()
        {
            mass = Constants.EMPTY_MASS + (crewCount + passengerCount) * Constants.HUMAN_MASS;
        }

        private void calculateAcceleration()
        {
           acceleration = force/mass;
        }

        private void calculateVelocity()
        {
            if (serviceBrakes)
                while (velocity > 0)
                    velocity += Math.Ceiling(Constants.dMAXN * time);
            else if (emergencyBrakes)
                while (velocity > 0)
                    velocity += Math.Ceiling(Constants.dMAXE * time);
            else
                velocity += Math.Ceiling(acceleration * time);

            if (velocity < 0)
                velocity = 0;
            else if (velocity > Constants.vMAX)
                velocity = Constants.vMAX;

        }

        private void calculateDistance()
        {
            distanceTraveled += velocity * time + 0.5 * acceleration * Math.Pow(time, 2);
        }

        private void ejectPassengers()
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