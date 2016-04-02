using System;

namespace TheTrainModule
{
    public class TrainRunner
    {
        private Train train = null;
        private double power = 0;
        private double velocity = 0;
        private double force = 0;
        private double acceleration = 0;
        private double mass = 0;
        private bool brake = false;
        private bool ebrake = false;

        public TrainRunner(Train t)
        {
            train = t;
        }

        public void update()
        {
            setMass();
            setAcceleration();
            setForce();
            setPower();

        }

        public void setPower(double P)
        {
            if (P > Constants.PMAX)
                power = Constants.PMAX;
            else
                power = P;

            update();
        }

        public void setPower()
        {
            setForce();
            power = force * velocity;
        }

        public void setForce()
        {
            setMass();

            if (brake)
            {
                if (velocity == 0)
                    force = 0;
                else
                    force = Constants.dMAXN * mass;
            }
            else if (ebrake)
            {
                if (velocity == 0)
                    force = 0;
                else
                    force = Constants.dMAXE * mass;
            }
            else
            {
                if (velocity == 0)
                    force = Constants.FMAX;
                else
                    force = mass * acceleration;
            }       
        }

        public void setVelocity(int v)
        {
            velocity = v;
            train.velocity = v;
        }
        
        private void setMass()
        {
            mass = Constants.EMPTY_MASS + (train.passengerCount + train.crewCount) * Constants.HUMAN_MASS;
        }

        public void setAcceleration()
        {
            setMass();
            setForce();

            acceleration = force / mass;
        }

        /*  Calculation for # of passengers getting off train 
         
            Uses exponential decay function:    p*l^r
                p = # of passengers on train
                l = 1/3     chosen because (2/3) of capacity is used for all maxes and 1 - 2/3 = 1/3
                r = random number between 0 and -ln(p)/(ln(1)-ln(3)) = log3(p)

        */
        public void ejectPassengers()
        {
            Random random = new Random();
            int eject = random.Next(0, maxR());

            train.passengerCount -= train.passengerCount * Convert.ToInt32(Math.Pow(Constants.LOAD, eject));
        }

        public int maxR()
        {
            return Convert.ToInt32(Math.Log(Convert.ToDouble(train.passengerCount)) / Math.Log(1/Constants.LOAD));
        }

    }
}
