namespace TheTrainModule
{
    partial class TrainModelForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainModelForm));
            this.trainInformationMenu = new System.Windows.Forms.MenuStrip();
            this.selectATrainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.trainToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.trainText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.powerText = new System.Windows.Forms.TextBox();
            this.accelerationText = new System.Windows.Forms.TextBox();
            this.velocityText = new System.Windows.Forms.TextBox();
            this.brakesText = new System.Windows.Forms.TextBox();
            this.crewText = new System.Windows.Forms.TextBox();
            this.passengerText = new System.Windows.Forms.TextBox();
            this.tempText = new System.Windows.Forms.TextBox();
            this.doorsText = new System.Windows.Forms.TextBox();
            this.lightsText = new System.Windows.Forms.TextBox();
            this.blockText = new System.Windows.Forms.TextBox();
            this.stationText = new System.Windows.Forms.TextBox();
            this.failureText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.activeText = new System.Windows.Forms.TextBox();
            this.timerBox = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.selectAFailureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noFailuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engineFailureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signalPickupFailureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brakeFailureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainInformationMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // trainInformationMenu
            // 
            this.trainInformationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectATrainMenu,
            this.trainToolStripMenuItem1,
            this.selectAFailureToolStripMenuItem});
            this.trainInformationMenu.Location = new System.Drawing.Point(0, 0);
            this.trainInformationMenu.Name = "trainInformationMenu";
            this.trainInformationMenu.Size = new System.Drawing.Size(571, 24);
            this.trainInformationMenu.TabIndex = 0;
            this.trainInformationMenu.Text = "trainInformationMenu";
            // 
            // selectATrainMenu
            // 
            this.selectATrainMenu.Name = "selectATrainMenu";
            this.selectATrainMenu.Size = new System.Drawing.Size(90, 20);
            this.selectATrainMenu.Text = "Select A Train";
            this.selectATrainMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TrainChosen);
            // 
            // trainToolStripMenuItem1
            // 
            this.trainToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalInformationToolStripMenuItem});
            this.trainToolStripMenuItem1.Name = "trainToolStripMenuItem1";
            this.trainToolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
            this.trainToolStripMenuItem1.Text = "Train";
            // 
            // generalInformationToolStripMenuItem
            // 
            this.generalInformationToolStripMenuItem.Name = "generalInformationToolStripMenuItem";
            this.generalInformationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generalInformationToolStripMenuItem.Text = "General Information";
            this.generalInformationToolStripMenuItem.Click += new System.EventHandler(this.generalInformationToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Displaying Information for ";
            // 
            // trainText
            // 
            this.trainText.Enabled = false;
            this.trainText.Location = new System.Drawing.Point(238, 36);
            this.trainText.Name = "trainText";
            this.trainText.Size = new System.Drawing.Size(100, 20);
            this.trainText.TabIndex = 2;
            this.trainText.Text = "No Train Chosen";
            this.trainText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Power (W)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Acceleration (mph/s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Velocity (mph)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Brakes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Crew Count";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Passenger Count";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Temperature (℉)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Doors";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(303, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Lights";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(303, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "CurrentBlock";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(303, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Next Station";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(303, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Failure";
            // 
            // powerText
            // 
            this.powerText.Enabled = false;
            this.powerText.Location = new System.Drawing.Point(132, 72);
            this.powerText.Name = "powerText";
            this.powerText.Size = new System.Drawing.Size(100, 20);
            this.powerText.TabIndex = 16;
            // 
            // accelerationText
            // 
            this.accelerationText.Enabled = false;
            this.accelerationText.Location = new System.Drawing.Point(132, 100);
            this.accelerationText.Name = "accelerationText";
            this.accelerationText.Size = new System.Drawing.Size(100, 20);
            this.accelerationText.TabIndex = 17;
            // 
            // velocityText
            // 
            this.velocityText.Enabled = false;
            this.velocityText.Location = new System.Drawing.Point(132, 128);
            this.velocityText.Name = "velocityText";
            this.velocityText.Size = new System.Drawing.Size(100, 20);
            this.velocityText.TabIndex = 18;
            // 
            // brakesText
            // 
            this.brakesText.Enabled = false;
            this.brakesText.Location = new System.Drawing.Point(132, 155);
            this.brakesText.Name = "brakesText";
            this.brakesText.Size = new System.Drawing.Size(100, 20);
            this.brakesText.TabIndex = 19;
            // 
            // crewText
            // 
            this.crewText.Enabled = false;
            this.crewText.Location = new System.Drawing.Point(132, 181);
            this.crewText.Name = "crewText";
            this.crewText.Size = new System.Drawing.Size(100, 20);
            this.crewText.TabIndex = 20;
            // 
            // passengerText
            // 
            this.passengerText.Enabled = false;
            this.passengerText.Location = new System.Drawing.Point(132, 207);
            this.passengerText.Name = "passengerText";
            this.passengerText.Size = new System.Drawing.Size(100, 20);
            this.passengerText.TabIndex = 21;
            // 
            // tempText
            // 
            this.tempText.Enabled = false;
            this.tempText.Location = new System.Drawing.Point(417, 72);
            this.tempText.Name = "tempText";
            this.tempText.Size = new System.Drawing.Size(100, 20);
            this.tempText.TabIndex = 22;
            // 
            // doorsText
            // 
            this.doorsText.Enabled = false;
            this.doorsText.Location = new System.Drawing.Point(417, 100);
            this.doorsText.Name = "doorsText";
            this.doorsText.Size = new System.Drawing.Size(100, 20);
            this.doorsText.TabIndex = 23;
            // 
            // lightsText
            // 
            this.lightsText.Enabled = false;
            this.lightsText.Location = new System.Drawing.Point(417, 128);
            this.lightsText.Name = "lightsText";
            this.lightsText.Size = new System.Drawing.Size(100, 20);
            this.lightsText.TabIndex = 24;
            // 
            // blockText
            // 
            this.blockText.Enabled = false;
            this.blockText.Location = new System.Drawing.Point(417, 155);
            this.blockText.Name = "blockText";
            this.blockText.Size = new System.Drawing.Size(100, 20);
            this.blockText.TabIndex = 25;
            // 
            // stationText
            // 
            this.stationText.Enabled = false;
            this.stationText.Location = new System.Drawing.Point(417, 181);
            this.stationText.Name = "stationText";
            this.stationText.Size = new System.Drawing.Size(100, 20);
            this.stationText.TabIndex = 26;
            // 
            // failureText
            // 
            this.failureText.Enabled = false;
            this.failureText.Location = new System.Drawing.Point(417, 207);
            this.failureText.Name = "failureText";
            this.failureText.Size = new System.Drawing.Size(100, 20);
            this.failureText.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Passenger Emergency Brake";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(257, 263);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 186);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(344, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = ":";
            // 
            // activeText
            // 
            this.activeText.Enabled = false;
            this.activeText.Location = new System.Drawing.Point(364, 36);
            this.activeText.Name = "activeText";
            this.activeText.Size = new System.Drawing.Size(100, 20);
            this.activeText.TabIndex = 32;
            this.activeText.Text = "ACTIVE/INACTIVE";
            this.activeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerBox
            // 
            this.timerBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerBox.Location = new System.Drawing.Point(482, 4);
            this.timerBox.Name = "timerBox";
            this.timerBox.ReadOnly = true;
            this.timerBox.Size = new System.Drawing.Size(89, 13);
            this.timerBox.TabIndex = 33;
            this.timerBox.Text = "00:00:00";
            this.timerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selectAFailureToolStripMenuItem
            // 
            this.selectAFailureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noFailuresToolStripMenuItem,
            this.engineFailureToolStripMenuItem,
            this.signalPickupFailureToolStripMenuItem,
            this.brakeFailureToolStripMenuItem});
            this.selectAFailureToolStripMenuItem.Name = "selectAFailureToolStripMenuItem";
            this.selectAFailureToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.selectAFailureToolStripMenuItem.Text = "Select A Failure";
            this.selectAFailureToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FailureChosen);
            // 
            // noFailuresToolStripMenuItem
            // 
            this.noFailuresToolStripMenuItem.Name = "noFailuresToolStripMenuItem";
            this.noFailuresToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.noFailuresToolStripMenuItem.Text = "No Failures";
            // 
            // engineFailureToolStripMenuItem
            // 
            this.engineFailureToolStripMenuItem.Name = "engineFailureToolStripMenuItem";
            this.engineFailureToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.engineFailureToolStripMenuItem.Text = "Engine Failure";
            // 
            // signalPickupFailureToolStripMenuItem
            // 
            this.signalPickupFailureToolStripMenuItem.Name = "signalPickupFailureToolStripMenuItem";
            this.signalPickupFailureToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.signalPickupFailureToolStripMenuItem.Text = "Signal Pickup Failure";
            // 
            // brakeFailureToolStripMenuItem
            // 
            this.brakeFailureToolStripMenuItem.Name = "brakeFailureToolStripMenuItem";
            this.brakeFailureToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.brakeFailureToolStripMenuItem.Text = "Brake Failure";
            // 
            // TrainModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(571, 452);
            this.Controls.Add(this.timerBox);
            this.Controls.Add(this.activeText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.failureText);
            this.Controls.Add(this.stationText);
            this.Controls.Add(this.blockText);
            this.Controls.Add(this.lightsText);
            this.Controls.Add(this.doorsText);
            this.Controls.Add(this.tempText);
            this.Controls.Add(this.passengerText);
            this.Controls.Add(this.crewText);
            this.Controls.Add(this.brakesText);
            this.Controls.Add(this.velocityText);
            this.Controls.Add(this.accelerationText);
            this.Controls.Add(this.powerText);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trainText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trainInformationMenu);
            this.MainMenuStrip = this.trainInformationMenu;
            this.Name = "TrainModelForm";
            this.Text = "Train Model";
            this.trainInformationMenu.ResumeLayout(false);
            this.trainInformationMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip trainInformationMenu;
        private System.Windows.Forms.ToolStripMenuItem selectATrainMenu;
        private System.Windows.Forms.ToolStripMenuItem trainToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem generalInformationToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox trainText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox powerText;
        private System.Windows.Forms.TextBox accelerationText;
        private System.Windows.Forms.TextBox velocityText;
        private System.Windows.Forms.TextBox brakesText;
        private System.Windows.Forms.TextBox crewText;
        private System.Windows.Forms.TextBox passengerText;
        private System.Windows.Forms.TextBox tempText;
        private System.Windows.Forms.TextBox doorsText;
        private System.Windows.Forms.TextBox lightsText;
        private System.Windows.Forms.TextBox blockText;
        private System.Windows.Forms.TextBox stationText;
        private System.Windows.Forms.TextBox failureText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox activeText;
        private System.Windows.Forms.TextBox timerBox;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem selectAFailureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noFailuresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engineFailureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signalPickupFailureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brakeFailureToolStripMenuItem;
    }
}

