namespace CTCOffice
{
    partial class CTC
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.moduleBox = new System.Windows.Forms.GroupBox();
            this.trainModelButton = new System.Windows.Forms.Button();
            this.trackControllerButton = new System.Windows.Forms.Button();
            this.trackModelButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.systemGraphics = new System.Windows.Forms.PictureBox();
            this.errorListView = new System.Windows.Forms.ListView();
            this.systemListView = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openCloseButton = new System.Windows.Forms.Button();
            this.listViewTrack = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDispatch = new System.Windows.Forms.Button();
            this.routeButton = new System.Windows.Forms.Button();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.listViewTrains = new System.Windows.Forms.ListView();
            this.buttonTrainController = new System.Windows.Forms.Button();
            this.moduleBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemGraphics)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 85);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(692, 200);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // moduleBox
            // 
            this.moduleBox.Controls.Add(this.flowLayoutPanel1);
            this.moduleBox.Controls.Add(this.trainModelButton);
            this.moduleBox.Controls.Add(this.trackControllerButton);
            this.moduleBox.Controls.Add(this.trackModelButton);
            this.moduleBox.Location = new System.Drawing.Point(3, 418);
            this.moduleBox.Name = "moduleBox";
            this.moduleBox.Size = new System.Drawing.Size(219, 86);
            this.moduleBox.TabIndex = 0;
            this.moduleBox.TabStop = false;
            this.moduleBox.Text = "Modules";
            // 
            // trainModelButton
            // 
            this.trainModelButton.Location = new System.Drawing.Point(112, 19);
            this.trainModelButton.Name = "trainModelButton";
            this.trainModelButton.Size = new System.Drawing.Size(100, 25);
            this.trainModelButton.TabIndex = 2;
            this.trainModelButton.Text = "Train Model";
            this.trainModelButton.UseVisualStyleBackColor = true;
            this.trainModelButton.Click += new System.EventHandler(this.TrainModelButton_Click);
            // 
            // trackControllerButton
            // 
            this.trackControllerButton.Location = new System.Drawing.Point(6, 57);
            this.trackControllerButton.Name = "trackControllerButton";
            this.trackControllerButton.Size = new System.Drawing.Size(100, 25);
            this.trackControllerButton.TabIndex = 1;
            this.trackControllerButton.Text = "Track Controller";
            this.trackControllerButton.UseVisualStyleBackColor = true;
            this.trackControllerButton.Click += new System.EventHandler(this.TrackControllerButton_Click);
            // 
            // trackModelButton
            // 
            this.trackModelButton.Location = new System.Drawing.Point(6, 19);
            this.trackModelButton.Name = "trackModelButton";
            this.trackModelButton.Size = new System.Drawing.Size(100, 25);
            this.trackModelButton.TabIndex = 0;
            this.trackModelButton.Text = "Track Model";
            this.trackModelButton.UseVisualStyleBackColor = true;
            this.trackModelButton.Click += new System.EventHandler(this.TrackModelButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(877, 533);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.systemGraphics);
            this.tabPage1.Controls.Add(this.errorListView);
            this.tabPage1.Controls.Add(this.systemListView);
            this.tabPage1.Controls.Add(this.moduleBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(869, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // systemGraphics
            // 
            this.systemGraphics.Location = new System.Drawing.Point(9, 7);
            this.systemGraphics.Name = "systemGraphics";
            this.systemGraphics.Size = new System.Drawing.Size(854, 405);
            this.systemGraphics.TabIndex = 3;
            this.systemGraphics.TabStop = false;
            this.systemGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.SystemGraphics_Paint);
            // 
            // errorListView
            // 
            this.errorListView.Location = new System.Drawing.Point(500, 418);
            this.errorListView.Name = "errorListView";
            this.errorListView.Size = new System.Drawing.Size(363, 86);
            this.errorListView.TabIndex = 2;
            this.errorListView.UseCompatibleStateImageBehavior = false;
            // 
            // systemListView
            // 
            this.systemListView.Location = new System.Drawing.Point(228, 418);
            this.systemListView.Name = "systemListView";
            this.systemListView.Size = new System.Drawing.Size(265, 86);
            this.systemListView.TabIndex = 1;
            this.systemListView.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.openCloseButton);
            this.tabPage2.Controls.Add(this.listViewTrack);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(869, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Track Segments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openCloseButton
            // 
            this.openCloseButton.Location = new System.Drawing.Point(6, 476);
            this.openCloseButton.Name = "openCloseButton";
            this.openCloseButton.Size = new System.Drawing.Size(100, 25);
            this.openCloseButton.TabIndex = 3;
            this.openCloseButton.Text = "Open/Close";
            this.openCloseButton.UseVisualStyleBackColor = true;
            this.openCloseButton.Click += new System.EventHandler(this.OpenCloseButton_Click);
            // 
            // listViewTrack
            // 
            this.listViewTrack.Location = new System.Drawing.Point(4, 4);
            this.listViewTrack.Name = "listViewTrack";
            this.listViewTrack.Size = new System.Drawing.Size(862, 466);
            this.listViewTrack.TabIndex = 0;
            this.listViewTrack.UseCompatibleStateImageBehavior = false;
            this.listViewTrack.SelectedIndexChanged += new System.EventHandler(this.ListViewTrack_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonTrainController);
            this.tabPage3.Controls.Add(this.buttonDispatch);
            this.tabPage3.Controls.Add(this.routeButton);
            this.tabPage3.Controls.Add(this.scheduleButton);
            this.tabPage3.Controls.Add(this.listViewTrains);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(869, 507);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Trains";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonDispatch
            // 
            this.buttonDispatch.Location = new System.Drawing.Point(216, 479);
            this.buttonDispatch.Name = "buttonDispatch";
            this.buttonDispatch.Size = new System.Drawing.Size(100, 25);
            this.buttonDispatch.TabIndex = 5;
            this.buttonDispatch.Text = "Dispatch Train";
            this.buttonDispatch.UseVisualStyleBackColor = true;
            this.buttonDispatch.Click += new System.EventHandler(this.ButtonDispatch_Click);
            // 
            // routeButton
            // 
            this.routeButton.Location = new System.Drawing.Point(110, 479);
            this.routeButton.Name = "routeButton";
            this.routeButton.Size = new System.Drawing.Size(100, 25);
            this.routeButton.TabIndex = 4;
            this.routeButton.Text = "Edit Route";
            this.routeButton.UseVisualStyleBackColor = true;
            this.routeButton.Click += new System.EventHandler(this.RouteButton_Click);
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(4, 479);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(100, 25);
            this.scheduleButton.TabIndex = 2;
            this.scheduleButton.Text = "Edit Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);
            // 
            // listViewTrains
            // 
            this.listViewTrains.Location = new System.Drawing.Point(4, 4);
            this.listViewTrains.Name = "listViewTrains";
            this.listViewTrains.Size = new System.Drawing.Size(862, 469);
            this.listViewTrains.TabIndex = 0;
            this.listViewTrains.UseCompatibleStateImageBehavior = false;
            // 
            // buttonTrainController
            // 
            this.buttonTrainController.Location = new System.Drawing.Point(322, 479);
            this.buttonTrainController.Name = "buttonTrainController";
            this.buttonTrainController.Size = new System.Drawing.Size(100, 25);
            this.buttonTrainController.TabIndex = 6;
            this.buttonTrainController.Text = "View Controller";
            this.buttonTrainController.UseVisualStyleBackColor = true;
            // 
            // CTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 557);
            this.Controls.Add(this.tabControl);
            this.Name = "CTC";
            this.Text = "CTC Office";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CTC_FormClosed);
            this.moduleBox.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.systemGraphics)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox moduleBox;
        private System.Windows.Forms.Button trackControllerButton;
        private System.Windows.Forms.Button trackModelButton;
        private System.Windows.Forms.Button trainModelButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listViewTrack;
        private System.Windows.Forms.ListView listViewTrains;
        private System.Windows.Forms.Button openCloseButton;
        private System.Windows.Forms.Button routeButton;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.ListView errorListView;
        private System.Windows.Forms.ListView systemListView;
        private System.Windows.Forms.PictureBox systemGraphics;
        private System.Windows.Forms.Button buttonDispatch;
        private System.Windows.Forms.Button buttonTrainController;
    }
}

