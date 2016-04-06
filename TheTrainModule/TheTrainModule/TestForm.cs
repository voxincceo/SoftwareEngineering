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
        private TrainModelForm trainModelForm = null;

        public TestForm()
        {
            trainModelForm = new TrainModelForm(new System.Timers.Timer());
            InitializeComponent();
        }

        private void CTCSend_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.idText.Text);
            int authority = Convert.ToInt32(this.authorityText.Text);
            double speed = Convert.ToDouble(this.speedText.Text);

            trainModelForm.SetAuthority(id, authority);
            trainModelForm.SetCommandedSpeed(id, speed);
        }

        private void CTCShowTrain_Click(object sender, EventArgs e)
        {
            trainModelForm.Show();
        }

        private void TrackModelSend_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.idText.Text);
            string beacon = this.beaconText.Text;
            string block = this.blockText.Text;
            int passengers = Convert.ToInt32(passengerText.Text);

            trainModelForm.SetBeacon(id, beacon);
            trainModelForm.SetCurrentBlock(id, block);
            trainModelForm.SetPassengers(id, passengers);

        }

        private void TrainControllerSend_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.idText.Text);
            int power = Convert.ToInt32(this.powerText.Text);
            string station = this.nextText.Text;
            bool lights = Convert.ToBoolean(this.lightsText.Text);
            bool doors = Convert.ToBoolean(this.doorsText.Text);
            bool ac = Convert.ToBoolean(this.ACText.Text);

            trainModelForm.SetPower(id, power);
            trainModelForm.SetNextStation(id, station);
            trainModelForm.SetLights(id, lights);
            trainModelForm.SetDoors(id, doors);
            trainModelForm.SetAirConditioning(id, ac);
        }
    }
}
