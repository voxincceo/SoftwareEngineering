namespace TrackController
{
    partial class TrackControllerForm
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
            this.SwitchesLabel = new System.Windows.Forms.Label();
            this.SwitchNumberLabel = new System.Windows.Forms.Label();
            this.CrossingLabel = new System.Windows.Forms.Label();
            this.LineLabel = new System.Windows.Forms.Label();
            this.BlockNumberLabel = new System.Windows.Forms.Label();
            this.TrainsLabel = new System.Windows.Forms.Label();
            this.trainLineSelect = new System.Windows.Forms.ComboBox();
            this.BrokenRailsLabel = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.BlockLabel = new System.Windows.Forms.Label();
            this.SwitchBlockPanel = new System.Windows.Forms.Panel();
            this.BrokenRailPanel = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.PLCButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SwitchBlockPanel.SuspendLayout();
            this.BrokenRailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SwitchesLabel
            // 
            this.SwitchesLabel.AutoSize = true;
            this.SwitchesLabel.Location = new System.Drawing.Point(91, 9);
            this.SwitchesLabel.Name = "SwitchesLabel";
            this.SwitchesLabel.Size = new System.Drawing.Size(53, 13);
            this.SwitchesLabel.TabIndex = 2;
            this.SwitchesLabel.Text = "Switches:";
            // 
            // SwitchNumberLabel
            // 
            this.SwitchNumberLabel.AutoSize = true;
            this.SwitchNumberLabel.Location = new System.Drawing.Point(3, 9);
            this.SwitchNumberLabel.Name = "SwitchNumberLabel";
            this.SwitchNumberLabel.Size = new System.Drawing.Size(79, 13);
            this.SwitchNumberLabel.TabIndex = 3;
            this.SwitchNumberLabel.Text = "Switch Number";
            // 
            // CrossingLabel
            // 
            this.CrossingLabel.AutoSize = true;
            this.CrossingLabel.Location = new System.Drawing.Point(269, 9);
            this.CrossingLabel.Name = "CrossingLabel";
            this.CrossingLabel.Size = new System.Drawing.Size(50, 13);
            this.CrossingLabel.TabIndex = 4;
            this.CrossingLabel.Text = "Crossing:";
            // 
            // LineLabel
            // 
            this.LineLabel.AutoSize = true;
            this.LineLabel.Location = new System.Drawing.Point(12, 7);
            this.LineLabel.Name = "LineLabel";
            this.LineLabel.Size = new System.Drawing.Size(30, 13);
            this.LineLabel.TabIndex = 12;
            this.LineLabel.Text = "Line:";
            // 
            // BlockNumberLabel
            // 
            this.BlockNumberLabel.AutoSize = true;
            this.BlockNumberLabel.Location = new System.Drawing.Point(189, 9);
            this.BlockNumberLabel.Name = "BlockNumberLabel";
            this.BlockNumberLabel.Size = new System.Drawing.Size(74, 13);
            this.BlockNumberLabel.TabIndex = 13;
            this.BlockNumberLabel.Text = "Block Number";
            // 
            // TrainsLabel
            // 
            this.TrainsLabel.AutoSize = true;
            this.TrainsLabel.Location = new System.Drawing.Point(13, 47);
            this.TrainsLabel.Name = "TrainsLabel";
            this.TrainsLabel.Size = new System.Drawing.Size(36, 13);
            this.TrainsLabel.TabIndex = 33;
            this.TrainsLabel.Text = "Trains";
            // 
            // trainLineSelect
            // 
            this.trainLineSelect.FormattingEnabled = true;
            this.trainLineSelect.Items.AddRange(new object[] {
            "Red Line",
            "Green Line"});
            this.trainLineSelect.Location = new System.Drawing.Point(12, 23);
            this.trainLineSelect.Name = "trainLineSelect";
            this.trainLineSelect.Size = new System.Drawing.Size(121, 21);
            this.trainLineSelect.TabIndex = 41;
            this.trainLineSelect.SelectedIndexChanged += new System.EventHandler(this.trainLineSelect_SelectedIndexChanged);
            // 
            // BrokenRailsLabel
            // 
            this.BrokenRailsLabel.AutoSize = true;
            this.BrokenRailsLabel.Location = new System.Drawing.Point(3, 9);
            this.BrokenRailsLabel.Name = "BrokenRailsLabel";
            this.BrokenRailsLabel.Size = new System.Drawing.Size(67, 13);
            this.BrokenRailsLabel.TabIndex = 46;
            this.BrokenRailsLabel.Text = "Broken Rails";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(0, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(0, 13);
            this.label31.TabIndex = 48;
            // 
            // BlockLabel
            // 
            this.BlockLabel.AutoSize = true;
            this.BlockLabel.Location = new System.Drawing.Point(3, 22);
            this.BlockLabel.Name = "BlockLabel";
            this.BlockLabel.Size = new System.Drawing.Size(34, 13);
            this.BlockLabel.TabIndex = 49;
            this.BlockLabel.Text = "Block";
            // 
            // SwitchBlockPanel
            // 
            this.SwitchBlockPanel.Controls.Add(this.SwitchNumberLabel);
            this.SwitchBlockPanel.Controls.Add(this.SwitchesLabel);
            this.SwitchBlockPanel.Controls.Add(this.BlockNumberLabel);
            this.SwitchBlockPanel.Controls.Add(this.CrossingLabel);
            this.SwitchBlockPanel.Location = new System.Drawing.Point(12, 63);
            this.SwitchBlockPanel.Name = "SwitchBlockPanel";
            this.SwitchBlockPanel.Size = new System.Drawing.Size(372, 30);
            this.SwitchBlockPanel.TabIndex = 50;
            this.SwitchBlockPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BrokenRailPanel
            // 
            this.BrokenRailPanel.Controls.Add(this.BlockLabel);
            this.BrokenRailPanel.Controls.Add(this.BrokenRailsLabel);
            this.BrokenRailPanel.Location = new System.Drawing.Point(12, 229);
            this.BrokenRailPanel.Name = "BrokenRailPanel";
            this.BrokenRailPanel.Size = new System.Drawing.Size(74, 43);
            this.BrokenRailPanel.TabIndex = 51;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // PLCButton
            // 
            this.PLCButton.Location = new System.Drawing.Point(305, 23);
            this.PLCButton.Name = "PLCButton";
            this.PLCButton.Size = new System.Drawing.Size(79, 23);
            this.PLCButton.TabIndex = 52;
            this.PLCButton.Text = "Import PLC";
            this.PLCButton.UseVisualStyleBackColor = true;
            this.PLCButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // TrackControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(430, 652);
            this.Controls.Add(this.PLCButton);
            this.Controls.Add(this.BrokenRailPanel);
            this.Controls.Add(this.SwitchBlockPanel);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.trainLineSelect);
            this.Controls.Add(this.TrainsLabel);
            this.Controls.Add(this.LineLabel);
            this.Name = "TrackControllerForm";
            this.Text = "Track Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SwitchBlockPanel.ResumeLayout(false);
            this.SwitchBlockPanel.PerformLayout();
            this.BrokenRailPanel.ResumeLayout(false);
            this.BrokenRailPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SwitchesLabel;
        private System.Windows.Forms.Label SwitchNumberLabel;
        private System.Windows.Forms.Label CrossingLabel;
        private System.Windows.Forms.Label LineLabel;
        private System.Windows.Forms.Label BlockNumberLabel;
        private System.Windows.Forms.Label TrainsLabel;
        private System.Windows.Forms.ComboBox trainLineSelect;
        private System.Windows.Forms.Label BrokenRailsLabel;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label BlockLabel;
        private System.Windows.Forms.Panel SwitchBlockPanel;
        private System.Windows.Forms.Panel BrokenRailPanel;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button PLCButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

