using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTrainModule
{
    static class Constants
    {
        //------------------BOOLEANS---------------//

        public const bool ON = true;
        public const bool OFF = false;
        public const bool OPEN = true;
        public const bool CLOSED = false;

        //------------------INTS-------------------//

        public const int NONE = 0;
        public const int TRAIN_ENGINE = 1;
        public const int SIGNAL_PICKUP = 2;
        public const int BRAKE = 3;
        public const int MAX_PASSENGERS = 222;


        //------------------DOUBLES----------------//

        public const double MTOFT = 3.28084;            // m to ft
        public const double MTOMI = .000621371;         // m to mi
        public const double MSTOMH = 2.23694;           // ms/s to mph
        public const double KMTOFT = 3280.84;           // km to ft
        public const double KHTOMH = 0.621371;          // km/hr to mph
        public const double TTOKG = 907.185;            // short ton (T) to kg
        public const double KGTOT = .0011023;           // kg to T
        public const double KHTOMS = .277778;           // km/hr to m/s
        public const double KGTOLB = 2.20462;           // kg to lb
        public const double HUMAN_MASS = 88.3;          // average mass of one human in kg
        public const double aMAX = 0.5;                 // max acceleration of train in m/s^2 at 2/3 capacity
        public const double FMAX = 9994.582583;         // max force of train in N at 2/3 capacity
        public const double vMAX = 19.44446;            // max velocity of the train in m/s
        public const double PMAX = 514;                 // max power of train in W at 2/3 capacity
        public const double EMPTY_MASS = 40188.2955;    // empty mass of train in kg
        public const double dMAXN = -1.2;               // max deceleration under normal brakes
        public const double dMAXE = -2.73;              // max deceleration under emergency brakes
        public const double LOAD = 1 / 3;               // for passenger ejection
    }
}
