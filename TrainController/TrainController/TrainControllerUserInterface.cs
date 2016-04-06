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
            thisTrainController.ChangeSpeed(Int32.Parse(setInputSpeed.Text));
        }

        private void engineerEmergencyBrakeButton_Click(object sender, EventArgs e)
        {
            thisTrainController.HitDriverEmergencyBrake();
        }

        public void SetAuthority(int newAuthority)
        {
            setAuthority.Text = newAuthority.ToString();
        }

        public void SetCommandedSpeed(int newSpeed)
        {
            setCommandedSpeed.Text = newSpeed.ToString();
        }

        public void SetCurrentVelocity(double newVelocity)
        {
            setCurrentVelocity.Text = newVelocity.ToString();
        }

        public void SetServiceBrake(Boolean serviceBrake)
        {
            if (serviceBrake)
                setServiceBrake.Text = "On";
            else
                setServiceBrake.Text = "Off";
        }

        public void SetPassengerEmergencyBrake(Boolean emergencyBrake)
        {
            if (emergencyBrake)
                setPassengerEmergencyBrake.Text = "On";
            else
                setPassengerEmergencyBrake.Text = "Off";
        }

        public void SetEngineerEmergencyBrake(Boolean emergencyBrake)
        {
            if (emergencyBrake)
                setEngineerEmergencyBrake.Text = "On";
            else
                setEngineerEmergencyBrake.Text = "Off";
        }

        public void SetAirConditionerStatus(Boolean airConditioner)
        {
            if (airConditioner)
                setACstatus.Text = "On";
            else
                setACstatus.Text = "Off";
        }

        public void SetDoorStatus(Boolean newDoorStatus)
        {
            if (newDoorStatus)
                setDoorStatus.Text = "Open";
            else
                setDoorStatus.Text = "Closed";
        }

        public void SetCurrentTemperature(int currentTemperature)
        {
            setCurrentTemperature.Text = currentTemperature.ToString();
        }

        public void SetLightStatus(Boolean lightStatus)
        {
            if (lightStatus)
                setLightStatus.Text = "On";
            else
                setLightStatus.Text = "Off";
        }

        public void SetNextStop(String nextStop)
        {
            setNextStop.Text = nextStop;
        }

        public void SetOutputPower(Double outputPower)
        {
            setOutputPower.Text = outputPower.ToString();
        }
    }
}
