namespace CTCOffice
{
    partial class TestingForm
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
            this.listViewInputs = new System.Windows.Forms.ListView();
            this.listViewOutputs = new System.Windows.Forms.ListView();
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboBoxSegments = new System.Windows.Forms.ComboBox();
            this.breakSegmentButton = new System.Windows.Forms.Button();
            this.buttonPower = new System.Windows.Forms.Button();
            this.buttonCircuit = new System.Windows.Forms.Button();
            this.buttonHeater = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewInputs
            // 
            this.listViewInputs.Location = new System.Drawing.Point(13, 13);
            this.listViewInputs.Name = "listViewInputs";
            this.listViewInputs.Size = new System.Drawing.Size(350, 518);
            this.listViewInputs.TabIndex = 0;
            this.listViewInputs.UseCompatibleStateImageBehavior = false;
            // 
            // listViewOutputs
            // 
            this.listViewOutputs.Location = new System.Drawing.Point(370, 13);
            this.listViewOutputs.Name = "listViewOutputs";
            this.listViewOutputs.Size = new System.Drawing.Size(350, 518);
            this.listViewOutputs.TabIndex = 1;
            this.listViewOutputs.UseCompatibleStateImageBehavior = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 537);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(92, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start Test";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // comboBoxSegments
            // 
            this.comboBoxSegments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSegments.FormattingEnabled = true;
            this.comboBoxSegments.Location = new System.Drawing.Point(110, 537);
            this.comboBoxSegments.Name = "comboBoxSegments";
            this.comboBoxSegments.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSegments.TabIndex = 3;
            this.comboBoxSegments.SelectedIndexChanged += new System.EventHandler(this.comboBoxSegments_SelectedIndexChanged);
            // 
            // breakSegmentButton
            // 
            this.breakSegmentButton.Location = new System.Drawing.Point(237, 536);
            this.breakSegmentButton.Name = "breakSegmentButton";
            this.breakSegmentButton.Size = new System.Drawing.Size(89, 23);
            this.breakSegmentButton.TabIndex = 4;
            this.breakSegmentButton.Text = "Change State";
            this.breakSegmentButton.UseVisualStyleBackColor = true;
            this.breakSegmentButton.Click += new System.EventHandler(this.breakSegmentButton_Click);
            // 
            // buttonPower
            // 
            this.buttonPower.Location = new System.Drawing.Point(332, 536);
            this.buttonPower.Name = "buttonPower";
            this.buttonPower.Size = new System.Drawing.Size(89, 23);
            this.buttonPower.TabIndex = 5;
            this.buttonPower.Text = "Power Failure";
            this.buttonPower.UseVisualStyleBackColor = true;
            this.buttonPower.Click += new System.EventHandler(this.buttonPower_Click);
            // 
            // buttonCircuit
            // 
            this.buttonCircuit.Location = new System.Drawing.Point(427, 536);
            this.buttonCircuit.Name = "buttonCircuit";
            this.buttonCircuit.Size = new System.Drawing.Size(93, 23);
            this.buttonCircuit.TabIndex = 6;
            this.buttonCircuit.Text = "Circuit Failure";
            this.buttonCircuit.UseVisualStyleBackColor = true;
            this.buttonCircuit.Click += new System.EventHandler(this.buttonCircuit_Click);
            // 
            // buttonHeater
            // 
            this.buttonHeater.Location = new System.Drawing.Point(526, 536);
            this.buttonHeater.Name = "buttonHeater";
            this.buttonHeater.Size = new System.Drawing.Size(96, 23);
            this.buttonHeater.TabIndex = 7;
            this.buttonHeater.Text = "Heater Status";
            this.buttonHeater.UseVisualStyleBackColor = true;
            this.buttonHeater.Click += new System.EventHandler(this.buttonHeater_Click);
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 570);
            this.Controls.Add(this.buttonHeater);
            this.Controls.Add(this.buttonCircuit);
            this.Controls.Add(this.buttonPower);
            this.Controls.Add(this.breakSegmentButton);
            this.Controls.Add(this.comboBoxSegments);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listViewOutputs);
            this.Controls.Add(this.listViewInputs);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestingForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewInputs;
        private System.Windows.Forms.ListView listViewOutputs;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxSegments;
        private System.Windows.Forms.Button breakSegmentButton;
        private System.Windows.Forms.Button buttonPower;
        private System.Windows.Forms.Button buttonCircuit;
        private System.Windows.Forms.Button buttonHeater;

    }
}