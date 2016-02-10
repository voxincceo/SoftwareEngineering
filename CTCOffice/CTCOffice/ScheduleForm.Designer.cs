﻿namespace CTCOffice
{
    partial class ScheduleForm
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
            this.listViewSchedules = new System.Windows.Forms.ListView();
            this.groupBoxSchedule = new System.Windows.Forms.GroupBox();
            this.labelInfrastructure = new System.Windows.Forms.Label();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.labelNewTime = new System.Windows.Forms.Label();
            this.newTimeBox = new System.Windows.Forms.RichTextBox();
            this.scheduleConfirmButton = new System.Windows.Forms.Button();
            this.groupBoxSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSchedules
            // 
            this.listViewSchedules.Location = new System.Drawing.Point(13, 13);
            this.listViewSchedules.Name = "listViewSchedules";
            this.listViewSchedules.Size = new System.Drawing.Size(527, 193);
            this.listViewSchedules.TabIndex = 0;
            this.listViewSchedules.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxSchedule
            // 
            this.groupBoxSchedule.Controls.Add(this.scheduleConfirmButton);
            this.groupBoxSchedule.Controls.Add(this.newTimeBox);
            this.groupBoxSchedule.Controls.Add(this.labelNewTime);
            this.groupBoxSchedule.Controls.Add(this.currentTimeLabel);
            this.groupBoxSchedule.Controls.Add(this.comboBox1);
            this.groupBoxSchedule.Controls.Add(this.labelCurrentTime);
            this.groupBoxSchedule.Controls.Add(this.labelInfrastructure);
            this.groupBoxSchedule.Location = new System.Drawing.Point(13, 213);
            this.groupBoxSchedule.Name = "groupBoxSchedule";
            this.groupBoxSchedule.Size = new System.Drawing.Size(223, 155);
            this.groupBoxSchedule.TabIndex = 1;
            this.groupBoxSchedule.TabStop = false;
            this.groupBoxSchedule.Text = "Edit Schedule";
            // 
            // labelInfrastructure
            // 
            this.labelInfrastructure.AutoSize = true;
            this.labelInfrastructure.Location = new System.Drawing.Point(7, 20);
            this.labelInfrastructure.Name = "labelInfrastructure";
            this.labelInfrastructure.Size = new System.Drawing.Size(72, 13);
            this.labelInfrastructure.TabIndex = 0;
            this.labelInfrastructure.Text = "Infrastructure:";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Location = new System.Drawing.Point(7, 51);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(121, 13);
            this.labelCurrentTime.TabIndex = 1;
            this.labelCurrentTime.Text = "Current Time to Station: ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Location = new System.Drawing.Point(182, 51);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(27, 13);
            this.currentTimeLabel.TabIndex = 3;
            this.currentTimeLabel.Text = "N/A";
            // 
            // labelNewTime
            // 
            this.labelNewTime.AutoSize = true;
            this.labelNewTime.Location = new System.Drawing.Point(6, 79);
            this.labelNewTime.Name = "labelNewTime";
            this.labelNewTime.Size = new System.Drawing.Size(106, 13);
            this.labelNewTime.TabIndex = 4;
            this.labelNewTime.Text = "New Time to Station:";
            // 
            // newTimeBox
            // 
            this.newTimeBox.Location = new System.Drawing.Point(118, 76);
            this.newTimeBox.Name = "newTimeBox";
            this.newTimeBox.Size = new System.Drawing.Size(99, 26);
            this.newTimeBox.TabIndex = 5;
            this.newTimeBox.Text = "";
            // 
            // scheduleConfirmButton
            // 
            this.scheduleConfirmButton.Location = new System.Drawing.Point(70, 126);
            this.scheduleConfirmButton.Name = "scheduleConfirmButton";
            this.scheduleConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.scheduleConfirmButton.TabIndex = 6;
            this.scheduleConfirmButton.Text = "Confirm";
            this.scheduleConfirmButton.UseVisualStyleBackColor = true;
            this.scheduleConfirmButton.Click += new System.EventHandler(this.scheduleConfirmButton_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 380);
            this.Controls.Add(this.groupBoxSchedule);
            this.Controls.Add(this.listViewSchedules);
            this.Name = "ScheduleForm";
            this.Text = "ScheduleForm";
            this.groupBoxSchedule.ResumeLayout(false);
            this.groupBoxSchedule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSchedules;
        private System.Windows.Forms.GroupBox groupBoxSchedule;
        private System.Windows.Forms.Button scheduleConfirmButton;
        private System.Windows.Forms.RichTextBox newTimeBox;
        private System.Windows.Forms.Label labelNewTime;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Label labelInfrastructure;
    }
}