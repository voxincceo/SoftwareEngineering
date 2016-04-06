using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainController;


namespace TheTrainModule
{
    public partial class TrainModelForm : Form
    {
        /*------------------------------------DECLARATIONS--------------------------------------------------------------------------------*/

        private TrainControllerForm trainControllerForm = null;
        private TrainDatabase trainDatabase = null;
        private GeneralTrainInformation generalTrainInformation = null;
        private TrainModelTrain train = null;
        private int trainId = 0;
        private System.Timers.Timer trainModelTimer = null;
        private bool trainChosen = false;
        private bool noneChosen = false;

        /*------------------------------------------------CONSTRUCTORS---------------------------------------------------------------*/

        public TrainModelForm(System.Timers.Timer timer)
        {
            generalTrainInformation = new GeneralTrainInformation();
            trainDatabase = new TrainDatabase();
            trainModelTimer = timer;
            trainModelTimer.Elapsed += Timer_Elapsed;;

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
            
            if(trainDatabase.size > 0)
            {
                for(int i = 0; i < trainDatabase.size; i++)
                {
                    send(++i, trainDatabase.GetTrain(i).velocity); 
                }
            }
            
            if (Application.OpenForms["TrainModelForm"] != null)
            {
                ShowTrainInformation();
            }
        }

        /*-------------------------------------------------UI FUNCTIONS---------------------------------------------------------------*/

        private void GeneralInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generalTrainInformation.Show();
        }

        private void AddTrain()
        {
            ToolStripMenuItem tmi = new ToolStripMenuItem("Train " + trainDatabase.size());
            selectATrainMenu.DropDownItems.Add(tmi);
        }

        private void FailureChosen(object sender, ToolStripItemClickedEventArgs e)
        {
            string failureName = e.ClickedItem.Text;

            if (train != null)
            {
                if (failureName.Equals("Engine Failure"))
                    train.failureMode = 1;
                else if (failureName.Equals("Signal Pickup Failure"))
                    train.failureMode = 2;
                else if (failureName.Equals("Brake Failure"))
                    train.failureMode = 3;
                else
                    train.failureMode = 0;

                if (train.failureMode > 0)
                    send(trainId, train.failureMode);


            }

        }        

        private void TrainChosen(object sender, ToolStripItemClickedEventArgs e)
        {
            trainChosen = true;
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
                this.Invoke(new MethodInvoker(delegate ()
               {
                   if (train.active)
                       this.activeText.Text = "ACTIVE";
                   else
                       this.activeText.Text = "INACTVE";

                   this.powerText.Text = Convert.ToString(train.power);
                   this.accelerationText.Text = Convert.ToString(train.acceleration);
                   this.velocityText.Text = Convert.ToString(Math.Ceiling(train.velocity * Constants.MSTOMH));

                   if (train.serviceBrakes)
                       brakesText.Text = "Service in use";
                   else if (train.emergencyBrakes)
                       brakesText.Text = "Emergency in use";
                   else
                       brakesText.Text = "------";

                   this.crewText.Text = Convert.ToString(train.crewCount);
                   this.passengerText.Text = Convert.ToString(train.passengerCount);
                   this.tempText.Text = Convert.ToString(train.temperature);

                   if (train.doors)
                       doorsText.Text = "Open";
                   else
                       doorsText.Text = "Closed";

                   if (train.lights)
                       lightsText.Text = "On";
                   else
                       lightsText.Text = "Off";

                   this.blockText.Text = train.currentBlock;
                   this.stationText.Text = train.nextStation;

                   if (train.failureMode == 1)
                       failureText.Text = "Engine Failure";
                   else if (train.failureMode == 2)
                       failureText.Text = "Signal Pickup Failure";
                   else if (train.failureMode == 3)
                       failureText.Text = "Brake Failure";
                   else
                       failureText.Text = "No Failures";
               }));
            }

        }

        public void SetText(int set)
        {
            this.Invoke(new MethodInvoker(delegate ()
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
            }));
        }

        /*-----------------------------PUBLIC SET METHODS---------------------------------------*/

        public void SendModules(TrainControllerForm tc)
        {
            trainControllerForm = tc;
        }

        public void SetPower(int id, int power)
        {
            TrainModelTrain t = trainDatabase.GetTrain(id);
            t.power = power;

            if (!t.active)
                t.active = true;

            trainDatabase.UpdateTrain(id);
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

            this.Send(id, "commanded");
        }

        public void SetAuthority(int id, int authority)
        {
            if (!IDExists(id))
            {
                trainDatabase.AddTrain();
                AddTrain();
            }

            trainDatabase.GetTrain(id).authority = authority;

          this.Send(id, "authority");
        }

        public void SetUnderground(int id, bool state)
        {
            TrainModelTrain t = trainDatabase.GetTrain(id);
            t.underground = state;

            if(state)
                this.Send(id, "underground");
        }

        public void SetPassengers(int id, int addition)
        {
            trainDatabase.GetTrain(id).passengerCount += addition;

            this.Send(id, "passengers");
        }

        public void SetBeacon(int id, string beacon)
        {
            trainDatabase.GetTrain(id).beacon = beacon;

            this.Send(id, "beacon");
        }

        public void SetCurrentBlock(int id, string block)
        {
            trainDatabase.GetTrain(id).currentBlock = block;
        }

        public bool IDExists(int id)
        {
            return trainDatabase.Contains(id);
        }

        public void SetPassengerBrakes(int id, bool state)
        {
            trainDatabase.GetTrain(id).emergencyBrakes = state;

            if (state)
              Send(id, "emergency");
        }

        public void FixFailure(int id)
        {
            trainDatabase.GetTrain(id).failureMode = 0;
        }



        /*------------------------------------------------SEND FUNCTIONS-----------------------------------------------*/

        private void send(int id, string info)
        {
            TrainModelTrain train = trainDatabase.GetTrain(id);

            switch (info)
            {
                case "emergency":
                    trainControllerForm.SetPassengerEmergencyBrakes(id);
                    break;
                case "beacon":
                    trainControllerForm.SetBeacon(id, train.beacon);
                    break;
                case "temperature":
                    trainControllerForm.SetTemperature(id, train.temperature);
                    break;
                case "commanded":
                    trainControllerForm.UpdateTrain(id);
                    trainControllerForm.SetSpeed(id, train.commandedSpeed);
                    break;
                case "authority":
                    trainControllerForm.UpdateTrain(id);
                    trainControllerForm.SetAuthority(id, train.authority);
                    break;
                case "velocity":
                    trainControllerForm.SetVelocity(id, train.velocity);
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
               this.Send(id, information[i]);
       }
    }
}
