namespace TrackModelPrototype
{
    partial class TrackModelForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lineControl = new System.Windows.Forms.TabControl();
            this.redLine = new System.Windows.Forms.TabPage();
            this.redLineBlocks = new System.Windows.Forms.ListBox();
            this.greenLine = new System.Windows.Forms.TabPage();
            this.greenLineBlocks = new System.Windows.Forms.ListBox();
            this.browseTrackFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lineLabel = new System.Windows.Forms.Label();
            this.sectionLabel = new System.Windows.Forms.Label();
            this.blockLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.updateSimulation = new System.Windows.Forms.Button();
            this.powerFailure = new System.Windows.Forms.CheckBox();
            this.trackCircuit = new System.Windows.Forms.CheckBox();
            this.brokenRail = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.comauthLabel = new System.Windows.Forms.Label();
            this.comspeedLabel = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            this.lightsLabel = new System.Windows.Forms.Label();
            this.heaterLabel = new System.Windows.Forms.Label();
            this.arrowdirLabel = new System.Windows.Forms.Label();
            this.switchBlock = new System.Windows.Forms.Label();
            this.cumelevationLabel = new System.Windows.Forms.Label();
            this.elevationLabel = new System.Windows.Forms.Label();
            this.infrastructureLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.gradeLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.viewBlock = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.trainPresent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.updateTemperature = new System.Windows.Forms.Button();
            this.newTempLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lineControl.SuspendLayout();
            this.redLine.SuspendLayout();
            this.greenLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Track Model";
            // 
            // lineControl
            // 
            this.lineControl.Controls.Add(this.redLine);
            this.lineControl.Controls.Add(this.greenLine);
            this.lineControl.Location = new System.Drawing.Point(12, 12);
            this.lineControl.Name = "lineControl";
            this.lineControl.SelectedIndex = 0;
            this.lineControl.Size = new System.Drawing.Size(283, 780);
            this.lineControl.TabIndex = 1;
            // 
            // redLine
            // 
            this.redLine.BackColor = System.Drawing.Color.White;
            this.redLine.Controls.Add(this.redLineBlocks);
            this.redLine.Location = new System.Drawing.Point(8, 39);
            this.redLine.Name = "redLine";
            this.redLine.Padding = new System.Windows.Forms.Padding(3);
            this.redLine.Size = new System.Drawing.Size(267, 733);
            this.redLine.TabIndex = 0;
            this.redLine.Text = "Red Line";
            // 
            // redLineBlocks
            // 
            this.redLineBlocks.FormattingEnabled = true;
            this.redLineBlocks.ItemHeight = 25;
            this.redLineBlocks.Items.AddRange(new object[] {
            "Section A Block 1",
            "Section B Block 1",
            "Section C Block 1",
            "Section D Block 1",
            "Section E Block 1"});
            this.redLineBlocks.Location = new System.Drawing.Point(6, 0);
            this.redLineBlocks.Name = "redLineBlocks";
            this.redLineBlocks.Size = new System.Drawing.Size(255, 729);
            this.redLineBlocks.TabIndex = 11;
            // 
            // greenLine
            // 
            this.greenLine.BackColor = System.Drawing.Color.White;
            this.greenLine.Controls.Add(this.greenLineBlocks);
            this.greenLine.Location = new System.Drawing.Point(8, 39);
            this.greenLine.Name = "greenLine";
            this.greenLine.Padding = new System.Windows.Forms.Padding(3);
            this.greenLine.Size = new System.Drawing.Size(267, 733);
            this.greenLine.TabIndex = 1;
            this.greenLine.Text = "Green Line";
            // 
            // greenLineBlocks
            // 
            this.greenLineBlocks.FormattingEnabled = true;
            this.greenLineBlocks.ItemHeight = 25;
            this.greenLineBlocks.Items.AddRange(new object[] {
            "Section A Block 1",
            "Section B Block 1",
            "Section C Block 1",
            "Section D Block 1",
            "Section E Block 1"});
            this.greenLineBlocks.Location = new System.Drawing.Point(6, 4);
            this.greenLineBlocks.Name = "greenLineBlocks";
            this.greenLineBlocks.Size = new System.Drawing.Size(255, 729);
            this.greenLineBlocks.TabIndex = 2;
            this.greenLineBlocks.SelectedIndexChanged += new System.EventHandler(this.greenLineBlocks_SelectedIndexChanged);
            // 
            // browseTrackFile
            // 
            this.browseTrackFile.Location = new System.Drawing.Point(876, 486);
            this.browseTrackFile.Name = "browseTrackFile";
            this.browseTrackFile.Size = new System.Drawing.Size(106, 41);
            this.browseTrackFile.TabIndex = 2;
            this.browseTrackFile.Text = "Browse";
            this.browseTrackFile.UseVisualStyleBackColor = true;
            this.browseTrackFile.Click += new System.EventHandler(this.browse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(840, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Upload Track File";
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Location = new System.Drawing.Point(497, 71);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(118, 25);
            this.lineLabel.TabIndex = 4;
            this.lineLabel.Text = "Green Line";
            this.lineLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // sectionLabel
            // 
            this.sectionLabel.AutoSize = true;
            this.sectionLabel.Location = new System.Drawing.Point(672, 71);
            this.sectionLabel.Name = "sectionLabel";
            this.sectionLabel.Size = new System.Drawing.Size(104, 25);
            this.sectionLabel.TabIndex = 5;
            this.sectionLabel.Text = "Section B";
            // 
            // blockLabel
            // 
            this.blockLabel.AutoSize = true;
            this.blockLabel.Location = new System.Drawing.Point(831, 71);
            this.blockLabel.Name = "blockLabel";
            this.blockLabel.Size = new System.Drawing.Size(83, 25);
            this.blockLabel.TabIndex = 6;
            this.blockLabel.Text = "Block 4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(850, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 25);
            this.label10.TabIndex = 7;
            this.label10.Text = "Failure Modes";
            // 
            // updateSimulation
            // 
            this.updateSimulation.Location = new System.Drawing.Point(817, 365);
            this.updateSimulation.Name = "updateSimulation";
            this.updateSimulation.Size = new System.Drawing.Size(219, 39);
            this.updateSimulation.TabIndex = 8;
            this.updateSimulation.Text = "Update Simulation";
            this.updateSimulation.UseVisualStyleBackColor = true;
            this.updateSimulation.Click += new System.EventHandler(this.update_sim_Click);
            // 
            // powerFailure
            // 
            this.powerFailure.AutoSize = true;
            this.powerFailure.Location = new System.Drawing.Point(855, 304);
            this.powerFailure.Name = "powerFailure";
            this.powerFailure.Size = new System.Drawing.Size(176, 29);
            this.powerFailure.TabIndex = 17;
            this.powerFailure.Text = "Power Failure";
            this.powerFailure.UseVisualStyleBackColor = true;
            // 
            // trackCircuit
            // 
            this.trackCircuit.AutoSize = true;
            this.trackCircuit.Location = new System.Drawing.Point(855, 253);
            this.trackCircuit.Name = "trackCircuit";
            this.trackCircuit.Size = new System.Drawing.Size(237, 29);
            this.trackCircuit.TabIndex = 18;
            this.trackCircuit.Text = "Track Circuit Failure";
            this.trackCircuit.UseVisualStyleBackColor = true;
            // 
            // brokenRail
            // 
            this.brokenRail.AutoSize = true;
            this.brokenRail.Location = new System.Drawing.Point(855, 203);
            this.brokenRail.Name = "brokenRail";
            this.brokenRail.Size = new System.Drawing.Size(155, 29);
            this.brokenRail.TabIndex = 19;
            this.brokenRail.Text = "Broken Rail";
            this.brokenRail.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 25);
            this.label11.TabIndex = 20;
            this.label11.Text = "Length (m)";
            this.label11.Click += new System.EventHandler(this.label11_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(352, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 25);
            this.label12.TabIndex = 21;
            this.label12.Text = "Grade (%)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(352, 273);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 25);
            this.label13.TabIndex = 22;
            this.label13.Text = "Speed Limit (mph)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(352, 328);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 25);
            this.label14.TabIndex = 23;
            this.label14.Text = "Infrastructure";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(352, 385);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 25);
            this.label15.TabIndex = 24;
            this.label15.Text = "Elevation (M)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(352, 440);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(252, 25);
            this.label16.TabIndex = 25;
            this.label16.Text = "Cumulative Elevation (M)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(352, 494);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(134, 25);
            this.label17.TabIndex = 26;
            this.label17.Text = "Switch Block";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(352, 551);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(158, 25);
            this.label18.TabIndex = 27;
            this.label18.Text = "Arrow Direction";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(352, 607);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 25);
            this.label19.TabIndex = 28;
            this.label19.Text = "Track Heater";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(352, 668);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 25);
            this.label20.TabIndex = 29;
            this.label20.Text = "Lights";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(352, 722);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(134, 25);
            this.label21.TabIndex = 30;
            this.label21.Text = "Temperature";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(352, 778);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(201, 25);
            this.label22.TabIndex = 31;
            this.label22.Text = "Commanded Speed";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(352, 837);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(224, 25);
            this.label23.TabIndex = 32;
            this.label23.Text = "Commanded Authority";
            // 
            // comauthLabel
            // 
            this.comauthLabel.AutoSize = true;
            this.comauthLabel.Location = new System.Drawing.Point(634, 837);
            this.comauthLabel.Name = "comauthLabel";
            this.comauthLabel.Size = new System.Drawing.Size(83, 25);
            this.comauthLabel.TabIndex = 46;
            this.comauthLabel.Text = "Not Set";
            this.comauthLabel.Click += new System.EventHandler(this.label26_Click);
            // 
            // comspeedLabel
            // 
            this.comspeedLabel.AutoSize = true;
            this.comspeedLabel.Location = new System.Drawing.Point(634, 778);
            this.comspeedLabel.Name = "comspeedLabel";
            this.comspeedLabel.Size = new System.Drawing.Size(83, 25);
            this.comspeedLabel.TabIndex = 45;
            this.comspeedLabel.Text = "Not Set";
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Location = new System.Drawing.Point(634, 722);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(57, 25);
            this.tempLabel.TabIndex = 44;
            this.tempLabel.Text = "41°F";
            // 
            // lightsLabel
            // 
            this.lightsLabel.AutoSize = true;
            this.lightsLabel.Location = new System.Drawing.Point(634, 668);
            this.lightsLabel.Name = "lightsLabel";
            this.lightsLabel.Size = new System.Drawing.Size(51, 25);
            this.lightsLabel.TabIndex = 43;
            this.lightsLabel.Text = "Red";
            // 
            // heaterLabel
            // 
            this.heaterLabel.AutoSize = true;
            this.heaterLabel.Location = new System.Drawing.Point(634, 607);
            this.heaterLabel.Name = "heaterLabel";
            this.heaterLabel.Size = new System.Drawing.Size(54, 25);
            this.heaterLabel.TabIndex = 42;
            this.heaterLabel.Text = "OFF";
            this.heaterLabel.Click += new System.EventHandler(this.label30_Click);
            // 
            // arrowdirLabel
            // 
            this.arrowdirLabel.AutoSize = true;
            this.arrowdirLabel.Location = new System.Drawing.Point(634, 551);
            this.arrowdirLabel.Name = "arrowdirLabel";
            this.arrowdirLabel.Size = new System.Drawing.Size(63, 25);
            this.arrowdirLabel.TabIndex = 41;
            this.arrowdirLabel.Text = "Head";
            // 
            // switchBlock
            // 
            this.switchBlock.AutoSize = true;
            this.switchBlock.Location = new System.Drawing.Point(634, 494);
            this.switchBlock.Name = "switchBlock";
            this.switchBlock.Size = new System.Drawing.Size(47, 25);
            this.switchBlock.TabIndex = 40;
            this.switchBlock.Text = "N/A";
            // 
            // cumelevationLabel
            // 
            this.cumelevationLabel.AutoSize = true;
            this.cumelevationLabel.Location = new System.Drawing.Point(634, 440);
            this.cumelevationLabel.Name = "cumelevationLabel";
            this.cumelevationLabel.Size = new System.Drawing.Size(24, 25);
            this.cumelevationLabel.TabIndex = 39;
            this.cumelevationLabel.Text = "5";
            // 
            // elevationLabel
            // 
            this.elevationLabel.AutoSize = true;
            this.elevationLabel.Location = new System.Drawing.Point(634, 385);
            this.elevationLabel.Name = "elevationLabel";
            this.elevationLabel.Size = new System.Drawing.Size(24, 25);
            this.elevationLabel.TabIndex = 38;
            this.elevationLabel.Text = "2";
            // 
            // infrastructureLabel
            // 
            this.infrastructureLabel.AutoSize = true;
            this.infrastructureLabel.Location = new System.Drawing.Point(568, 328);
            this.infrastructureLabel.Name = "infrastructureLabel";
            this.infrastructureLabel.Size = new System.Drawing.Size(47, 25);
            this.infrastructureLabel.TabIndex = 37;
            this.infrastructureLabel.Text = "N/A";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(634, 273);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(36, 25);
            this.speedLabel.TabIndex = 36;
            this.speedLabel.Text = "55";
            // 
            // gradeLabel
            // 
            this.gradeLabel.AutoSize = true;
            this.gradeLabel.Location = new System.Drawing.Point(634, 213);
            this.gradeLabel.Name = "gradeLabel";
            this.gradeLabel.Size = new System.Drawing.Size(24, 25);
            this.gradeLabel.TabIndex = 35;
            this.gradeLabel.Text = "2";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(634, 159);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(48, 25);
            this.lengthLabel.TabIndex = 34;
            this.lengthLabel.Text = "100";
            // 
            // viewBlock
            // 
            this.viewBlock.Location = new System.Drawing.Point(80, 809);
            this.viewBlock.Name = "viewBlock";
            this.viewBlock.Size = new System.Drawing.Size(137, 52);
            this.viewBlock.TabIndex = 51;
            this.viewBlock.Text = "View Block";
            this.viewBlock.UseVisualStyleBackColor = true;
            this.viewBlock.Click += new System.EventHandler(this.view_block_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 886);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 53;
            this.label3.Text = "Train Present";
            // 
            // trainPresent
            // 
            this.trainPresent.AutoSize = true;
            this.trainPresent.Location = new System.Drawing.Point(634, 895);
            this.trainPresent.Name = "trainPresent";
            this.trainPresent.Size = new System.Drawing.Size(65, 25);
            this.trainPresent.TabIndex = 54;
            this.trainPresent.Text = "False";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(982, 601);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 25);
            this.label4.TabIndex = 58;
            this.label4.Text = "°F";
            // 
            // updateTemperature
            // 
            this.updateTemperature.Location = new System.Drawing.Point(808, 649);
            this.updateTemperature.Name = "updateTemperature";
            this.updateTemperature.Size = new System.Drawing.Size(240, 39);
            this.updateTemperature.TabIndex = 57;
            this.updateTemperature.Text = "Update Temperature";
            this.updateTemperature.UseVisualStyleBackColor = true;
            this.updateTemperature.Click += new System.EventHandler(this.updateTemperature_Click);
            // 
            // newTempLength
            // 
            this.newTempLength.Location = new System.Drawing.Point(876, 598);
            this.newTempLength.Name = "newTempLength";
            this.newTempLength.Size = new System.Drawing.Size(100, 31);
            this.newTempLength.TabIndex = 56;
            this.newTempLength.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(843, 558);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 25);
            this.label5.TabIndex = 55;
            this.label5.Text = "Edit Temperature";
            // 
            // TrackModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 954);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.updateTemperature);
            this.Controls.Add(this.newTempLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trainPresent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.viewBlock);
            this.Controls.Add(this.comauthLabel);
            this.Controls.Add(this.comspeedLabel);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.lightsLabel);
            this.Controls.Add(this.heaterLabel);
            this.Controls.Add(this.arrowdirLabel);
            this.Controls.Add(this.switchBlock);
            this.Controls.Add(this.cumelevationLabel);
            this.Controls.Add(this.elevationLabel);
            this.Controls.Add(this.infrastructureLabel);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.gradeLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.brokenRail);
            this.Controls.Add(this.trackCircuit);
            this.Controls.Add(this.powerFailure);
            this.Controls.Add(this.updateSimulation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.blockLabel);
            this.Controls.Add(this.sectionLabel);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseTrackFile);
            this.Controls.Add(this.lineControl);
            this.Controls.Add(this.label1);
            this.Name = "TrackModelForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.lineControl.ResumeLayout(false);
            this.redLine.ResumeLayout(false);
            this.greenLine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl lineControl;
        private System.Windows.Forms.TabPage redLine;
        private System.Windows.Forms.TabPage greenLine;
        private System.Windows.Forms.Button browseTrackFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.Label sectionLabel;
        private System.Windows.Forms.Label blockLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button updateSimulation;
        private System.Windows.Forms.CheckBox powerFailure;
        private System.Windows.Forms.CheckBox trackCircuit;
        private System.Windows.Forms.CheckBox brokenRail;
        private System.Windows.Forms.ListBox redLineBlocks;
        private System.Windows.Forms.ListBox greenLineBlocks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label comauthLabel;
        private System.Windows.Forms.Label comspeedLabel;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label lightsLabel;
        private System.Windows.Forms.Label heaterLabel;
        private System.Windows.Forms.Label arrowdirLabel;
        private System.Windows.Forms.Label switchBlock;
        private System.Windows.Forms.Label cumelevationLabel;
        private System.Windows.Forms.Label elevationLabel;
        private System.Windows.Forms.Label infrastructureLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label gradeLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Button viewBlock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label trainPresent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updateTemperature;
        private System.Windows.Forms.TextBox newTempLength;
        private System.Windows.Forms.Label label5;
    }
}

