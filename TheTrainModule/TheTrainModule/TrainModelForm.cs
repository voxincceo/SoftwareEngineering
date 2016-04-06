using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheTrainModule
{
    public partial class TrainModelForm : Form
    {
        /*------------------------------------DECLARATIONS--------------------------------------------------------------------------------*/

        private TrainControllerForm trainControllerForm = null;
        private TrainDatabase trainDatabase = null;
        private GeneralTrainInformation generalTrainInformation = null;
        private TrainModelTrain train = null;
        private System.Timers.Timer trainModelTimer = null;
        private int interval = 1000;
        private bool trainChosen = false;
        private bool noneChosen = false;
        private bool failureMenuSet = false; 


        /*-------------------------------------------------PROPERTIES--------------------------------------------------------------------*/

        public double power { get; set; } = 0;
        public double acceleration { get; set; } = 0;
        public double velocity { get; set; } = 0;
        public bool service { get; set; } = false;
        public bool emergency { get; set; } = false;
        public int crew { get; set; } = 0;
        public int passenger { get; set; } = 0;
        public int temp { get; set; } = 0;
        public bool doors { get; set; } = false;
        public bool lights { get; set; } = false;
        public string block { get; set; } = "------";
        public string nextStation { get; set; } = "------";
        public int failure { get; set; } = 0;
        public double force { get; set; }

        /*------------------------------------------------CONSTRUCTORS---------------------------------------------------------------*/

        public TrainModelForm(System.Timers.Timer timer)
        {
            generalTrainInformation = new GeneralTrainInformation();
            trainDatabase = new TrainDatabase();
            trainModelTimer = timer;
            trainModelTimer.Elapsed += Timer_Elapsed;


            InitializeComponent();
        }

        /*-------------------------------------------------TIMER FUNCTIONS------------------------------------------------------------*/

        public void SetSystemSpeed(int speed)
        {
            trainModelTimer.Interval *= speed;
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            trainDatabase.driveTrains();
            ShowTrainInformation();
        }


        /*-------------------------------------------------UI FUNCTIONS---------------------------------------------------------------*/

        private void generalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generalTrainInformation.Show();
        }

        private void AddTrain()
        {
            ToolStripMenuItem tmi = new ToolStripMenuItem("Train " + trainDatabase.size());
            selectATrainMenu.DropDownItems.Add(tmi);
        }

        private void FailureMenu_DropDown(object sender, EventArgs e)
        {
            if (!failureMenuSet)
            {
                failureMenuSet = true;
                failureMenu.Items.Add("No Failures");
                failureMenu.Items.Add("Engine Failure");
                failureMenu.Items.Add("Signal Pickup Failure");
                failureMenu.Items.Add("Brake Failure");
            }
        }

        private void TrainChosen(object sender, ToolStripItemClickedEventArgs e)
        {
            trainChosen = true;
            string inactive = "INACTIVE";
            string name = e.ClickedItem.Text;
            
            if (name.Equals("None"))
            {
                noneChosen = true;
                trainChosen = false;
            }
            else
            {
                string[] trainid = name.Split(' ');
                train = trainDatabase.GetTrain(Convert.ToInt32(trainid[1]));
                trainText.Text = name;

                if (train.active)
                    inactive = "ACTIVE";
                activeText.Text = inactive;
            }
        }

        public void ShowTrainInformation()
        {
            if (noneChosen || !trainChosen)
            {
                SetText(0);
            }
            else
            {
                this.powerText.Text = Convert.ToString(power);
                this.accelerationText.Text = Convert.ToString(acceleration);
                this.velocityText.Text = Convert.ToString(Math.Ceiling(velocity * Constants.MSTOMH));

                if (service)
                    brakesText.Text = "Service in use";
                else if (emergency)
                    brakesText.Text = "Emergency in use";
                else
                    brakesText.Text = "------";

                this.crewText.Text = Convert.ToString(crew);
                this.passengerText.Text = Convert.ToString(passenger);
                this.tempText.Text = Convert.ToString(temp);

                if (doors)
                    doorsText.Text = "Open";
                else
                    doorsText.Text = "Closed";

                if (lights)
                    lightsText.Text = "On";
                else
                    lightsText.Text = "Off";

                this.blockText.Text = block;
                this.stationText.Text = nextStation;

                if (failure == 1)
                    failureText.Text = "Engine Failure";
                else if (failure == 2)
                    failureText.Text = "Signal Pickup Failure";
                else if (failure == 3)
                    failureText.Text = "Brake Failure";
                else
                    failureText.Text = "No Failures";
            }

        }

        public void SetText(int set)
        {
            powerText.Clear();
            accelerationText.Clear();
            velocityText.Clear();
            brakesText.Clear();
            crewText.Clear();
            passengerText.Clear();
            tempText.Clear();
            doorsText.Clear();
            lightsText.Clear();
            blockText.Clear();
            stationText.Clear();
            failureText.Clear();
        }

        /*-----------------------------PUBLIC SET METHODS---------------------------------------*/

        public void sendModules(TrainControllerForm tc)
        {
            trainControllerForm = tc;
        }

        public void SetPower(int id, int power)
        {
            TrainModelTrain t = trainDatabase.GetTrain(id);
            t.power = power;

            if (!t.active)
                t.active = true;

            trainDatabase.updateTrain(id);
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
            TrainModelTrain t = trainDatabase.GetTrain(id);

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
                AddTrain();
            }

            trainDatabase.GetTrain(id).commandedSpeed = velocity;

            this.send(id, "commanded");
        }

        public void SetAuthority(int id, int authority)
        {
            if (!IDExists(id))
            {
                trainDatabase.AddTrain();
                AddTrain();
            }

            trainDatabase.GetTrain(id).authority = authority;

            this.send(id, "authority");
        }

        public void SetUnderground(int id, bool state)
        {
            TrainModelTrain t = trainDatabase.GetTrain(id);
            t.underground = state;

            if(state)
                this.send(id, "underground");
        }

        public void SetPassengers(int id, int addition)
        {
            trainDatabase.GetTrain(id).passengerCount += addition;

            this.send(id, "passengers");
        }

        public void SetBeacon(int id, string beacon)
        {
            trainDatabase.GetTrain(id).beacon = beacon;

            this.send(id, "beacon");
        }

        public void SetCurrentBlock(int id, string block)
        {
            trainDatabase.GetTrain(id).currentBlock = block;
        }

        public bool IDExists(int id)
        {
            return trainDatabase.contains(id);
        }

        public void setPassengerBrakes(int id, bool state)
        {
            trainDatabase.GetTrain(id).emergencyBrakes = state;

            if (state)
              send(id, "emergency");
        }

        /*------------------------------------------------SEND FUNCTIONS-----------------------------------------------*/

         private void send(int id, string info)
         {
             TrainModelTrain train = trainDatabase.GetTrain(id);

             switch (info)
             {
                 case "emergency":
                     trainControllerForm.setPassengerEmergencyBrakes(id);
                     break;
                 case "beacon":
                     trainControllerForm.setBeacon(id, train.beacon);
                     break;
                 case "temperature":
                     trainControllerForm.setTemperature(id, train.temperature);
                     break;
                 case "commanded":
                     trainControllerForm.updateTrain(id);
                     trainControllerForm.setSpeed(id, train.commandedSpeed);
                     break;
                 case "authority":
                     trainControllerForm.updateTrain(id);
                     trainControllerForm.setAuthority(id, train.authority);
                     break;
                 case "velocity":
                     trainControllerForm.setVelocity(id, train.velocity);
                     break;
                 case "underground":
                     trainControllerForm.SetDarkOutside(id, train.underground);
                     break;
                case "failure":
                    trainControllerForm.SetFailure(id, train.failureMode);
                    break;
                 default:
                     break;
             }
         }

        private void SendAll(int id)
        {
            string[] information = { "emergency", "beacon", "temperature", "commanded", "authority", "velocity", "underground", "passengers" };

            for (int i = 0; i < information.Length; i++)
                this.send(id, information[i]);
        }
    }
}