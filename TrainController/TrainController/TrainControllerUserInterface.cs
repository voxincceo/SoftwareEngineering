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

            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }
        }

        private void TrainControllerUserInterface_Load(object sender, EventArgs e)
        {

        }


        private void setInputSpeed_TextChanged(object sender, EventArgs e)
        {
            thisTrainController.ChangeSpeed(double.Parse(setInputSpeed.Text));
        }

        private void engineerEmergencyBrakeButton_Click(object sender, EventArgs e)
        {
            thisTrainController.HitDriverEmergencyBrake();
        }

        public void SetAuthority(int newAuthority)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                setAuthority.Text = newAuthority.ToString();
            }));
        }

        public void SetCommandedSpeed(double newSpeed)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                setCommandedSpeed.Text = newSpeed.ToString();
            }));
        }

        public void SetCurrentVelocity(double newVelocity)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                setCurrentVelocity.Text = newVelocity.ToString();
            }));
        }

        public void SetServiceBrake(Boolean serviceBrake)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (serviceBrake)
                    setServiceBrake.Text = "On";
                else
                    setServiceBrake.Text = "Off";
            }));
        }

        public void SetPassengerEmergencyBrake(Boolean emergencyBrake)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (emergencyBrake)
                    setPassengerEmergencyBrake.Text = "On";
                else
                    setPassengerEmergencyBrake.Text = "Off";
            }));
        }

        public void SetEngineerEmergencyBrake(Boolean emergencyBrake)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (emergencyBrake)
                    setEngineerEmergencyBrake.Text = "On";
                else
                    setEngineerEmergencyBrake.Text = "Off";
            }));
        }

        public void SetAirConditionerStatus(Boolean airConditioner)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (airConditioner)
                    setACstatus.Text = "On";
                else
                    setACstatus.Text = "Off";
            }));
        }

        public void SetDoorStatus(Boolean newDoorStatus)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (newDoorStatus)
                    setDoorStatus.Text = "Open";
                else
                    setDoorStatus.Text = "Closed";
            }));
        }

        public void SetCurrentTemperature(int currentTemperature)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                setCurrentTemperature.Text = currentTemperature.ToString();
            }));
        }

        public void SetLightStatus(Boolean lightStatus)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (lightStatus)
                    setLightStatus.Text = "On";
                else
                    setLightStatus.Text = "Off";
            }));
        }

        public void SetNextStop(String nextStop)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                setNextStop.Text = nextStop;
            }));
        }

        public void SetOutputPower(Double outputPower)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                setOutputPower.Text = outputPower.ToString();
            }));
        }

        public void showThis()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.Show();
            }));
        }
    }
}
