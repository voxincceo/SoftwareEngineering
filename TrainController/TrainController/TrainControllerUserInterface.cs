using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainController
{
    public partial class TrainControllerUserInterface : Form
    {
        TrainController thisTrainController;
        public TrainControllerUserInterface(int tNumber, TrainController newTrainController)
        {
            InitializeComponent();
            thisTrainController = newTrainController;
            Text = "Train Number " + tNumber.ToString();
        }

        private void TrainControllerUserInterface_Load(object sender, EventArgs e)
        {

        }


        private void setInputSpeed_TextChanged(object sender, EventArgs e)
        {
            thisTrainController.DriverSpeed = Int32.Parse(setInputSpeed.Text);
        }

        private void engineerEmergencyBrakeButton_Click(object sender, EventArgs e)
        {
            thisTrainController.DriverEmergencyBrake = true;
        }
    }
}
