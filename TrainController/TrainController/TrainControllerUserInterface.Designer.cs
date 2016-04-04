namespace TrainController
{
    partial class TrainControllerUserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AuthorityLabel = new System.Windows.Forms.Label();
            this.setAuthority = new System.Windows.Forms.Label();
            this.commandedSpeed = new System.Windows.Forms.Label();
            this.setCommandedSpeed = new System.Windows.Forms.Label();
            this.currentVelocity = new System.Windows.Forms.Label();
            this.setCurrentVelocity = new System.Windows.Forms.Label();
            this.inputSpeed = new System.Windows.Forms.Label();
            this.setInputSpeed = new System.Windows.Forms.TextBox();
            this.passengerEmergencyBrake = new System.Windows.Forms.Label();
            this.setPassengerEmergencyBrake = new System.Windows.Forms.Label();
            this.engineerEmergencyBrake = new System.Windows.Forms.Label();
            this.setEngineerEmergencyBrake = new System.Windows.Forms.Label();
            this.engineerEmergencyBrakeButton = new System.Windows.Forms.Button();
            this.serviceBrake = new System.Windows.Forms.Label();
            this.setServiceBrake = new System.Windows.Forms.Label();
            this.currentTemperature = new System.Windows.Forms.Label();
            this.setCurrentTemperature = new System.Windows.Forms.Label();
            this.ACstatus = new System.Windows.Forms.Label();
            this.setACstatus = new System.Windows.Forms.Label();
            this.outputPower = new System.Windows.Forms.Label();
            this.setOutputPower = new System.Windows.Forms.Label();
            this.lightStatus = new System.Windows.Forms.Label();
            this.setLightStatus = new System.Windows.Forms.Label();
            this.doorStatus = new System.Windows.Forms.Label();
            this.setDoorStatus = new System.Windows.Forms.Label();
            this.nextStop = new System.Windows.Forms.Label();
            this.setNextStop = new System.Windows.Forms.Label();
            this.failureAlerts = new System.Windows.Forms.Label();
            this.setFailureAlert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AuthorityLabel
            // 
            this.AuthorityLabel.AutoSize = true;
            this.AuthorityLabel.BackColor = System.Drawing.Color.Transparent;
            this.AuthorityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.AuthorityLabel.Location = new System.Drawing.Point(12, 9);
            this.AuthorityLabel.Name = "AuthorityLabel";
            this.AuthorityLabel.Size = new System.Drawing.Size(83, 24);
            this.AuthorityLabel.TabIndex = 0;
            this.AuthorityLabel.Text = "Authority";
            // 
            // setAuthority
            // 
            this.setAuthority.AutoSize = true;
            this.setAuthority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setAuthority.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setAuthority.Location = new System.Drawing.Point(300, 12);
            this.setAuthority.Name = "setAuthority";
            this.setAuthority.Size = new System.Drawing.Size(47, 22);
            this.setAuthority.TabIndex = 1;
            this.setAuthority.Text = "0000";
            // 
            // commandedSpeed
            // 
            this.commandedSpeed.AutoSize = true;
            this.commandedSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.commandedSpeed.Location = new System.Drawing.Point(12, 52);
            this.commandedSpeed.Name = "commandedSpeed";
            this.commandedSpeed.Size = new System.Drawing.Size(181, 24);
            this.commandedSpeed.TabIndex = 2;
            this.commandedSpeed.Text = "Commanded Speed";
            // 
            // setCommandedSpeed
            // 
            this.setCommandedSpeed.AutoSize = true;
            this.setCommandedSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setCommandedSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setCommandedSpeed.Location = new System.Drawing.Point(300, 55);
            this.setCommandedSpeed.Name = "setCommandedSpeed";
            this.setCommandedSpeed.Size = new System.Drawing.Size(47, 22);
            this.setCommandedSpeed.TabIndex = 3;
            this.setCommandedSpeed.Text = "0000";
            // 
            // currentVelocity
            // 
            this.currentVelocity.AutoSize = true;
            this.currentVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.currentVelocity.Location = new System.Drawing.Point(12, 95);
            this.currentVelocity.Name = "currentVelocity";
            this.currentVelocity.Size = new System.Drawing.Size(143, 24);
            this.currentVelocity.TabIndex = 4;
            this.currentVelocity.Text = "Current Velocity";
            // 
            // setCurrentVelocity
            // 
            this.setCurrentVelocity.AutoSize = true;
            this.setCurrentVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setCurrentVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setCurrentVelocity.Location = new System.Drawing.Point(300, 98);
            this.setCurrentVelocity.Name = "setCurrentVelocity";
            this.setCurrentVelocity.Size = new System.Drawing.Size(47, 22);
            this.setCurrentVelocity.TabIndex = 5;
            this.setCurrentVelocity.Text = "0000";
            // 
            // inputSpeed
            // 
            this.inputSpeed.AutoSize = true;
            this.inputSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputSpeed.Location = new System.Drawing.Point(12, 224);
            this.inputSpeed.Name = "inputSpeed";
            this.inputSpeed.Size = new System.Drawing.Size(112, 24);
            this.inputSpeed.TabIndex = 6;
            this.inputSpeed.Text = "Speed Input";
            // 
            // setInputSpeed
            // 
            this.setInputSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setInputSpeed.Location = new System.Drawing.Point(300, 224);
            this.setInputSpeed.Name = "setInputSpeed";
            this.setInputSpeed.Size = new System.Drawing.Size(47, 26);
            this.setInputSpeed.TabIndex = 7;
            this.setInputSpeed.Text = "0000";
            this.setInputSpeed.TextChanged += new System.EventHandler(this.setInputSpeed_TextChanged);
            // 
            // passengerEmergencyBrake
            // 
            this.passengerEmergencyBrake.AutoSize = true;
            this.passengerEmergencyBrake.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.passengerEmergencyBrake.Location = new System.Drawing.Point(12, 181);
            this.passengerEmergencyBrake.Name = "passengerEmergencyBrake";
            this.passengerEmergencyBrake.Size = new System.Drawing.Size(256, 24);
            this.passengerEmergencyBrake.TabIndex = 8;
            this.passengerEmergencyBrake.Text = "Passenger Emergency Brake";
            // 
            // setPassengerEmergencyBrake
            // 
            this.setPassengerEmergencyBrake.AutoSize = true;
            this.setPassengerEmergencyBrake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setPassengerEmergencyBrake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setPassengerEmergencyBrake.Location = new System.Drawing.Point(314, 184);
            this.setPassengerEmergencyBrake.Name = "setPassengerEmergencyBrake";
            this.setPassengerEmergencyBrake.Size = new System.Drawing.Size(33, 22);
            this.setPassengerEmergencyBrake.TabIndex = 9;
            this.setPassengerEmergencyBrake.Text = "Off";
            // 
            // engineerEmergencyBrake
            // 
            this.engineerEmergencyBrake.AutoSize = true;
            this.engineerEmergencyBrake.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.engineerEmergencyBrake.Location = new System.Drawing.Point(12, 267);
            this.engineerEmergencyBrake.Name = "engineerEmergencyBrake";
            this.engineerEmergencyBrake.Size = new System.Drawing.Size(244, 24);
            this.engineerEmergencyBrake.TabIndex = 10;
            this.engineerEmergencyBrake.Text = "Engineer Emergency Brake";
            // 
            // setEngineerEmergencyBrake
            // 
            this.setEngineerEmergencyBrake.AutoSize = true;
            this.setEngineerEmergencyBrake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setEngineerEmergencyBrake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setEngineerEmergencyBrake.Location = new System.Drawing.Point(314, 270);
            this.setEngineerEmergencyBrake.Name = "setEngineerEmergencyBrake";
            this.setEngineerEmergencyBrake.Size = new System.Drawing.Size(33, 22);
            this.setEngineerEmergencyBrake.TabIndex = 11;
            this.setEngineerEmergencyBrake.Text = "Off";
            // 
            // engineerEmergencyBrakeButton
            // 
            this.engineerEmergencyBrakeButton.Location = new System.Drawing.Point(357, 267);
            this.engineerEmergencyBrakeButton.Name = "engineerEmergencyBrakeButton";
            this.engineerEmergencyBrakeButton.Size = new System.Drawing.Size(310, 29);
            this.engineerEmergencyBrakeButton.TabIndex = 12;
            this.engineerEmergencyBrakeButton.Text = "Emergency Brake";
            this.engineerEmergencyBrakeButton.UseVisualStyleBackColor = true;
            this.engineerEmergencyBrakeButton.Click += new System.EventHandler(this.engineerEmergencyBrakeButton_Click);
            // 
            // serviceBrake
            // 
            this.serviceBrake.AutoSize = true;
            this.serviceBrake.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.serviceBrake.Location = new System.Drawing.Point(12, 138);
            this.serviceBrake.Name = "serviceBrake";
            this.serviceBrake.Size = new System.Drawing.Size(126, 24);
            this.serviceBrake.TabIndex = 13;
            this.serviceBrake.Text = "Service Brake";
            // 
            // setServiceBrake
            // 
            this.setServiceBrake.AutoSize = true;
            this.setServiceBrake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setServiceBrake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setServiceBrake.Location = new System.Drawing.Point(314, 141);
            this.setServiceBrake.Name = "setServiceBrake";
            this.setServiceBrake.Size = new System.Drawing.Size(33, 22);
            this.setServiceBrake.TabIndex = 14;
            this.setServiceBrake.Text = "Off";
            // 
            // currentTemperature
            // 
            this.currentTemperature.AutoSize = true;
            this.currentTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.currentTemperature.Location = new System.Drawing.Point(353, 9);
            this.currentTemperature.Name = "currentTemperature";
            this.currentTemperature.Size = new System.Drawing.Size(186, 24);
            this.currentTemperature.TabIndex = 15;
            this.currentTemperature.Text = "Current Temperature";
            // 
            // setCurrentTemperature
            // 
            this.setCurrentTemperature.AutoSize = true;
            this.setCurrentTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setCurrentTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setCurrentTemperature.Location = new System.Drawing.Point(620, 12);
            this.setCurrentTemperature.Name = "setCurrentTemperature";
            this.setCurrentTemperature.Size = new System.Drawing.Size(47, 22);
            this.setCurrentTemperature.TabIndex = 16;
            this.setCurrentTemperature.Text = "0000";
            // 
            // ACstatus
            // 
            this.ACstatus.AutoSize = true;
            this.ACstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ACstatus.Location = new System.Drawing.Point(353, 52);
            this.ACstatus.Name = "ACstatus";
            this.ACstatus.Size = new System.Drawing.Size(91, 24);
            this.ACstatus.TabIndex = 17;
            this.ACstatus.Text = "AC Status";
            // 
            // setACstatus
            // 
            this.setACstatus.AutoSize = true;
            this.setACstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setACstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setACstatus.Location = new System.Drawing.Point(634, 55);
            this.setACstatus.Name = "setACstatus";
            this.setACstatus.Size = new System.Drawing.Size(33, 22);
            this.setACstatus.TabIndex = 18;
            this.setACstatus.Text = "Off";
            // 
            // outputPower
            // 
            this.outputPower.AutoSize = true;
            this.outputPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.outputPower.Location = new System.Drawing.Point(353, 224);
            this.outputPower.Name = "outputPower";
            this.outputPower.Size = new System.Drawing.Size(125, 24);
            this.outputPower.TabIndex = 19;
            this.outputPower.Text = "Output Power";
            // 
            // setOutputPower
            // 
            this.setOutputPower.AutoSize = true;
            this.setOutputPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setOutputPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setOutputPower.Location = new System.Drawing.Point(620, 227);
            this.setOutputPower.Name = "setOutputPower";
            this.setOutputPower.Size = new System.Drawing.Size(47, 22);
            this.setOutputPower.TabIndex = 20;
            this.setOutputPower.Text = "0000";
            // 
            // lightStatus
            // 
            this.lightStatus.AutoSize = true;
            this.lightStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lightStatus.Location = new System.Drawing.Point(353, 95);
            this.lightStatus.Name = "lightStatus";
            this.lightStatus.Size = new System.Drawing.Size(105, 24);
            this.lightStatus.TabIndex = 21;
            this.lightStatus.Text = "Light Status";
            // 
            // setLightStatus
            // 
            this.setLightStatus.AutoSize = true;
            this.setLightStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setLightStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setLightStatus.Location = new System.Drawing.Point(634, 98);
            this.setLightStatus.Name = "setLightStatus";
            this.setLightStatus.Size = new System.Drawing.Size(33, 22);
            this.setLightStatus.TabIndex = 22;
            this.setLightStatus.Text = "Off";
            // 
            // doorStatus
            // 
            this.doorStatus.AutoSize = true;
            this.doorStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.doorStatus.Location = new System.Drawing.Point(353, 138);
            this.doorStatus.Name = "doorStatus";
            this.doorStatus.Size = new System.Drawing.Size(106, 24);
            this.doorStatus.TabIndex = 23;
            this.doorStatus.Text = "Door Status";
            // 
            // setDoorStatus
            // 
            this.setDoorStatus.AutoSize = true;
            this.setDoorStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setDoorStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setDoorStatus.Location = new System.Drawing.Point(607, 141);
            this.setDoorStatus.Name = "setDoorStatus";
            this.setDoorStatus.Size = new System.Drawing.Size(60, 22);
            this.setDoorStatus.TabIndex = 24;
            this.setDoorStatus.Text = "Closed";
            // 
            // nextStop
            // 
            this.nextStop.AutoSize = true;
            this.nextStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.nextStop.Location = new System.Drawing.Point(353, 181);
            this.nextStop.Name = "nextStop";
            this.nextStop.Size = new System.Drawing.Size(92, 24);
            this.nextStop.TabIndex = 25;
            this.nextStop.Text = "Next Stop";
            // 
            // setNextStop
            // 
            this.setNextStop.AutoSize = true;
            this.setNextStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setNextStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setNextStop.Location = new System.Drawing.Point(586, 184);
            this.setNextStop.Name = "setNextStop";
            this.setNextStop.Size = new System.Drawing.Size(81, 22);
            this.setNextStop.TabIndex = 26;
            this.setNextStop.Text = "Next Stop";
            // 
            // failureAlerts
            // 
            this.failureAlerts.AutoSize = true;
            this.failureAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.failureAlerts.Location = new System.Drawing.Point(12, 310);
            this.failureAlerts.Name = "failureAlerts";
            this.failureAlerts.Size = new System.Drawing.Size(120, 24);
            this.failureAlerts.TabIndex = 27;
            this.failureAlerts.Text = "Failure Alerts";
            // 
            // setFailureAlert
            // 
            this.setFailureAlert.AutoSize = true;
            this.setFailureAlert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setFailureAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setFailureAlert.Location = new System.Drawing.Point(298, 313);
            this.setFailureAlert.Name = "setFailureAlert";
            this.setFailureAlert.Size = new System.Drawing.Size(49, 22);
            this.setFailureAlert.TabIndex = 28;
            this.setFailureAlert.Text = "None";
            // 
            // TrainControllerUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 344);
            this.Controls.Add(this.setFailureAlert);
            this.Controls.Add(this.failureAlerts);
            this.Controls.Add(this.setNextStop);
            this.Controls.Add(this.nextStop);
            this.Controls.Add(this.setDoorStatus);
            this.Controls.Add(this.doorStatus);
            this.Controls.Add(this.setLightStatus);
            this.Controls.Add(this.lightStatus);
            this.Controls.Add(this.setOutputPower);
            this.Controls.Add(this.outputPower);
            this.Controls.Add(this.setACstatus);
            this.Controls.Add(this.ACstatus);
            this.Controls.Add(this.setCurrentTemperature);
            this.Controls.Add(this.currentTemperature);
            this.Controls.Add(this.setServiceBrake);
            this.Controls.Add(this.serviceBrake);
            this.Controls.Add(this.engineerEmergencyBrakeButton);
            this.Controls.Add(this.setEngineerEmergencyBrake);
            this.Controls.Add(this.engineerEmergencyBrake);
            this.Controls.Add(this.setPassengerEmergencyBrake);
            this.Controls.Add(this.passengerEmergencyBrake);
            this.Controls.Add(this.setInputSpeed);
            this.Controls.Add(this.inputSpeed);
            this.Controls.Add(this.setCurrentVelocity);
            this.Controls.Add(this.currentVelocity);
            this.Controls.Add(this.setCommandedSpeed);
            this.Controls.Add(this.commandedSpeed);
            this.Controls.Add(this.setAuthority);
            this.Controls.Add(this.AuthorityLabel);
            this.Name = "TrainControllerUserInterface";
            this.Text = "UserInterface";
            this.Load += new System.EventHandler(this.TrainControllerUserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AuthorityLabel;
        private System.Windows.Forms.Label setAuthority;
        private System.Windows.Forms.Label commandedSpeed;
        private System.Windows.Forms.Label setCommandedSpeed;
        private System.Windows.Forms.Label currentVelocity;
        private System.Windows.Forms.Label setCurrentVelocity;
        private System.Windows.Forms.Label inputSpeed;
        private System.Windows.Forms.TextBox setInputSpeed;
        private System.Windows.Forms.Label passengerEmergencyBrake;
        private System.Windows.Forms.Label setPassengerEmergencyBrake;
        private System.Windows.Forms.Label engineerEmergencyBrake;
        private System.Windows.Forms.Label setEngineerEmergencyBrake;
        private System.Windows.Forms.Button engineerEmergencyBrakeButton;
        private System.Windows.Forms.Label serviceBrake;
        private System.Windows.Forms.Label setServiceBrake;
        private System.Windows.Forms.Label currentTemperature;
        private System.Windows.Forms.Label setCurrentTemperature;
        private System.Windows.Forms.Label ACstatus;
        private System.Windows.Forms.Label setACstatus;
        private System.Windows.Forms.Label outputPower;
        private System.Windows.Forms.Label setOutputPower;
        private System.Windows.Forms.Label lightStatus;
        private System.Windows.Forms.Label setLightStatus;
        private System.Windows.Forms.Label doorStatus;
        private System.Windows.Forms.Label setDoorStatus;
        private System.Windows.Forms.Label nextStop;
        private System.Windows.Forms.Label setNextStop;
        private System.Windows.Forms.Label failureAlerts;
        private System.Windows.Forms.Label setFailureAlert;
    }
}