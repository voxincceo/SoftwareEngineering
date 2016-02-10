namespace CTCOffice
{
    partial class Form1
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
            this.trainControllerButton = new System.Windows.Forms.Button();
            this.trainModelButton = new System.Windows.Forms.Button();
            this.trackControllerButton = new System.Windows.Forms.Button();
            this.trackModelButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.errorListView = new System.Windows.Forms.ListView();
            this.systemListView = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openCloseButton = new System.Windows.Forms.Button();
            this.segmentLabel = new System.Windows.Forms.Label();
            this.listBoxSegments = new System.Windows.Forms.ListBox();
            this.listViewTrack = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.routeButton = new System.Windows.Forms.Button();
            this.labelTrains = new System.Windows.Forms.Label();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.listBoxTrains = new System.Windows.Forms.ListBox();
            this.listViewTrains = new System.Windows.Forms.ListView();
            this.moduleBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.moduleBox.Controls.Add(this.trainControllerButton);
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
            // trainControllerButton
            // 
            this.trainControllerButton.Location = new System.Drawing.Point(112, 57);
            this.trainControllerButton.Name = "trainControllerButton";
            this.trainControllerButton.Size = new System.Drawing.Size(100, 25);
            this.trainControllerButton.TabIndex = 3;
            this.trainControllerButton.Text = "Train Controller";
            this.trainControllerButton.UseVisualStyleBackColor = true;
            this.trainControllerButton.Click += new System.EventHandler(this.trainControllerButton_Click);
            // 
            // trainModelButton
            // 
            this.trainModelButton.Location = new System.Drawing.Point(112, 19);
            this.trainModelButton.Name = "trainModelButton";
            this.trainModelButton.Size = new System.Drawing.Size(100, 25);
            this.trainModelButton.TabIndex = 2;
            this.trainModelButton.Text = "Train Model";
            this.trainModelButton.UseVisualStyleBackColor = true;
            this.trainModelButton.Click += new System.EventHandler(this.trainModelButton_Click);
            // 
            // trackControllerButton
            // 
            this.trackControllerButton.Location = new System.Drawing.Point(6, 57);
            this.trackControllerButton.Name = "trackControllerButton";
            this.trackControllerButton.Size = new System.Drawing.Size(100, 25);
            this.trackControllerButton.TabIndex = 1;
            this.trackControllerButton.Text = "Track Controller";
            this.trackControllerButton.UseVisualStyleBackColor = true;
            this.trackControllerButton.Click += new System.EventHandler(this.trackControllerButton_Click);
            // 
            // trackModelButton
            // 
            this.trackModelButton.Location = new System.Drawing.Point(6, 19);
            this.trackModelButton.Name = "trackModelButton";
            this.trackModelButton.Size = new System.Drawing.Size(100, 25);
            this.trackModelButton.TabIndex = 0;
            this.trackModelButton.Text = "Track Model";
            this.trackModelButton.UseVisualStyleBackColor = true;
            this.trackModelButton.Click += new System.EventHandler(this.trackModelButton_Click);
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
            this.tabPage2.Controls.Add(this.segmentLabel);
            this.tabPage2.Controls.Add(this.listBoxSegments);
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
            this.openCloseButton.Location = new System.Drawing.Point(129, 318);
            this.openCloseButton.Name = "openCloseButton";
            this.openCloseButton.Size = new System.Drawing.Size(100, 25);
            this.openCloseButton.TabIndex = 3;
            this.openCloseButton.Text = "Open/Close";
            this.openCloseButton.UseVisualStyleBackColor = true;
            this.openCloseButton.Click += new System.EventHandler(this.openCloseButton_Click);
            // 
            // segmentLabel
            // 
            this.segmentLabel.AutoSize = true;
            this.segmentLabel.Location = new System.Drawing.Point(3, 302);
            this.segmentLabel.Name = "segmentLabel";
            this.segmentLabel.Size = new System.Drawing.Size(54, 13);
            this.segmentLabel.TabIndex = 2;
            this.segmentLabel.Text = "Segments";
            // 
            // listBoxSegments
            // 
            this.listBoxSegments.FormattingEnabled = true;
            this.listBoxSegments.Location = new System.Drawing.Point(3, 318);
            this.listBoxSegments.Name = "listBoxSegments";
            this.listBoxSegments.Size = new System.Drawing.Size(120, 186);
            this.listBoxSegments.TabIndex = 1;
            // 
            // listViewTrack
            // 
            this.listViewTrack.Location = new System.Drawing.Point(4, 4);
            this.listViewTrack.Name = "listViewTrack";
            this.listViewTrack.Size = new System.Drawing.Size(862, 284);
            this.listViewTrack.TabIndex = 0;
            this.listViewTrack.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.routeButton);
            this.tabPage3.Controls.Add(this.labelTrains);
            this.tabPage3.Controls.Add(this.scheduleButton);
            this.tabPage3.Controls.Add(this.listBoxTrains);
            this.tabPage3.Controls.Add(this.listViewTrains);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(869, 507);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Trains";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // routeButton
            // 
            this.routeButton.Location = new System.Drawing.Point(130, 350);
            this.routeButton.Name = "routeButton";
            this.routeButton.Size = new System.Drawing.Size(100, 25);
            this.routeButton.TabIndex = 4;
            this.routeButton.Text = "Edit Route";
            this.routeButton.UseVisualStyleBackColor = true;
            this.routeButton.Click += new System.EventHandler(this.routeButton_Click);
            // 
            // labelTrains
            // 
            this.labelTrains.AutoSize = true;
            this.labelTrains.Location = new System.Drawing.Point(4, 299);
            this.labelTrains.Name = "labelTrains";
            this.labelTrains.Size = new System.Drawing.Size(36, 13);
            this.labelTrains.TabIndex = 3;
            this.labelTrains.Text = "Trains";
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(130, 318);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(100, 25);
            this.scheduleButton.TabIndex = 2;
            this.scheduleButton.Text = "Edit Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // listBoxTrains
            // 
            this.listBoxTrains.FormattingEnabled = true;
            this.listBoxTrains.Location = new System.Drawing.Point(4, 318);
            this.listBoxTrains.Name = "listBoxTrains";
            this.listBoxTrains.Size = new System.Drawing.Size(120, 186);
            this.listBoxTrains.TabIndex = 1;
            // 
            // listViewTrains
            // 
            this.listViewTrains.Location = new System.Drawing.Point(4, 4);
            this.listViewTrains.Name = "listViewTrains";
            this.listViewTrains.Size = new System.Drawing.Size(862, 284);
            this.listViewTrains.TabIndex = 0;
            this.listViewTrains.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 557);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "CTC Office";
            this.moduleBox.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox moduleBox;
        private System.Windows.Forms.Button trackControllerButton;
        private System.Windows.Forms.Button trackModelButton;
        private System.Windows.Forms.Button trainModelButton;
        private System.Windows.Forms.Button trainControllerButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listViewTrack;
        private System.Windows.Forms.ListView listViewTrains;
        private System.Windows.Forms.Label segmentLabel;
        private System.Windows.Forms.ListBox listBoxSegments;
        private System.Windows.Forms.Button openCloseButton;
        private System.Windows.Forms.Button routeButton;
        private System.Windows.Forms.Label labelTrains;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.ListBox listBoxTrains;
        private System.Windows.Forms.ListView errorListView;
        private System.Windows.Forms.ListView systemListView;
    }
}

