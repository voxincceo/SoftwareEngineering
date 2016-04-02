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
        private GeneralTrainInformation gTI = null;
        public TrainDatabase trainDatabase = null;
        private Train train = null;
        //private DateTime clock;
        //private int clockSpeed = 1000;

        private int power = 0;
        private double acceleration = 0;
        private double velocity = 0;
        private string brakes = "------";
        int crew = 2;
        int passenger = 0;
        int temp = 69;
        string doors = "------";
        string lights = "------";
        string ac = "------";
        string block = "------";
        string nextStation = "------";
        string failure = "------";

        public TrainModelForm()
        {
            gTI = new GeneralTrainInformation();
            trainDatabase = new TrainDatabase();
            //trainModelTimer = new Timer();
            //trainModelTimer.Interval = clockSpeed;
            //trainModelTimer.Tick += TrainModelTimer_Tick;
            //clock = new DateTime(1, 1, 1, 0, 0, 0);
            //trainModelTimer.Start();
            InitializeComponent();
        }

        private void TrainModelTimer_Tick(Object sender, EventArgs e)
        {
            //clock = clock.AddSeconds(1);
            //timerBox.Text = clock.ToString("HH:mm:ss") + ": x" + Convert.ToString((int)1000 / clockSpeed);
        }

        private void generalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gTI.Show();
        }

        private void TrainChosen(object sender, ToolStripItemClickedEventArgs e)
        {
            string inactive = "ACTIVE";
            string name = e.ClickedItem.Text;
            string[] trainid = name.Split(' ');
            train = trainDatabase.GetTrain(Convert.ToInt32(trainid[1]));
            trainText.Text = name;

            if (!train.active)
                inactive = "INACTIVE";
            activeText.Text = inactive;
            updateTrainInformation();
            showTrainInformation();
        }

        public void AddTrain()
        {
            ToolStripMenuItem tmi = new ToolStripMenuItem("Train " + trainDatabase.size());
            selectATrainMenu.DropDownItems.Add(tmi);
        }

        public void updateTrainDatabase(TrainDatabase td)
        {
            trainDatabase = td;
        }

        public void updateTrainInformation()
        {
           power = train.setPower;
           acceleration = train.acceleration;
           velocity = train.velocity;

            if (train.serviceBrakes)
                brakes = "Service";
            else if (train.emergencyBrakes)
                brakes = "Emergency";

           crew = train.crewCount;
           passenger = train.passengerCount;
           temp = train.temperature;
           doors = "Closed";

           if (train.doors)
               doors = "Open";

           lights = "Off";

           if (train.lights)
               lights = "On";

           block = train.currentBlock;
           nextStation = train.nextStation;
           failure = "None";

            if (train.failureMode == 1)
                failure = "Engine";
            else if (train.failureMode == 2)
                failure = "Signal Pickup";
            else if (train.failureMode == 3)
                failure = "Brake";
        }

        private void showTrainInformation()
        { 
            this.powerText.Text = Convert.ToString(power);
            this.accelerationText.Text = Convert.ToString(acceleration);
            this.velocityText.Text = Convert.ToString(Math.Ceiling(velocity * Constants.MSTOMH));
            this.brakesText.Text = brakes;
            this.crewText.Text = Convert.ToString(crew);
            this.passengerText.Text = Convert.ToString(passenger);
            this.tempText.Text = Convert.ToString(temp);
            this.doorsText.Text = doors;
            this.lightsText.Text = lights;
            this.blockText.Text = block;
            this.stationText.Text = nextStation;
            this.failureText.Text = failure;
        }
    }
}
