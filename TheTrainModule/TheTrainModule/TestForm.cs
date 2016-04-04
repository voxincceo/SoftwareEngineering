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
    public partial class TestForm : Form
    {
        private TrainModel trainModel = null;

        public TestForm()
        {
            trainModel = new TrainModel(new System.Timers.Timer(1000));
            InitializeComponent();
        }

        private void CTCSend_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.idText.Text);
            int authority = Convert.ToInt32(this.authorityText.Text);
            double speed = Convert.ToDouble(this.speedText.Text);

            trainModel.SetAuthority(id, authority);
            trainModel.SetCommandedSpeed(id, speed);
        }

        private void CTCShowTrain_Click(object sender, EventArgs e)
        {
            trainModel.Show();
        }

        private void TrackModelSend_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.idText.Text);
            string beacon = this.beaconText.Text;
            string block = this.blockText.Text;
            int passengers = Convert.ToInt32(passengerText.Text);

            trainModel.SetBeacon(id, beacon);
            trainModel.SetCurrentBlock(id, block);
            trainModel.SetPassengers(id, passengers);

        }

        private void TrainControllerSend_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.idText.Text);
            int power = Convert.ToInt32(this.powerText.Text);
            string station = this.nextText.Text;
            bool lights = Convert.ToBoolean(this.lightsText.Text);
            bool doors = Convert.ToBoolean(this.doorsText.Text);
            bool ac = Convert.ToBoolean(this.ACText.Text);

            trainModel.SetPower(id, power);
            trainModel.SetNextStation(id, station);
            trainModel.SetLights(id, lights);
            trainModel.SetDoors(id, doors);
            trainModel.SetAirConditioning(id, ac);
        }
    }
}
