namespace CTCOffice
{
    partial class RoutesForm
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
            this.listViewRoutes = new System.Windows.Forms.ListView();
            this.groupBoxRoutes = new System.Windows.Forms.GroupBox();
            this.labelStartStation = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.labelEndStation = new System.Windows.Forms.Label();
            this.confirmRouteButton = new System.Windows.Forms.Button();
            this.groupBoxRoutes.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewRoutes
            // 
            this.listViewRoutes.Location = new System.Drawing.Point(13, 13);
            this.listViewRoutes.Name = "listViewRoutes";
            this.listViewRoutes.Size = new System.Drawing.Size(558, 163);
            this.listViewRoutes.TabIndex = 0;
            this.listViewRoutes.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxRoutes
            // 
            this.groupBoxRoutes.Controls.Add(this.confirmRouteButton);
            this.groupBoxRoutes.Controls.Add(this.labelEndStation);
            this.groupBoxRoutes.Controls.Add(this.comboBox2);
            this.groupBoxRoutes.Controls.Add(this.comboBox1);
            this.groupBoxRoutes.Controls.Add(this.labelStartStation);
            this.groupBoxRoutes.Location = new System.Drawing.Point(13, 183);
            this.groupBoxRoutes.Name = "groupBoxRoutes";
            this.groupBoxRoutes.Size = new System.Drawing.Size(200, 121);
            this.groupBoxRoutes.TabIndex = 1;
            this.groupBoxRoutes.TabStop = false;
            this.groupBoxRoutes.Text = "Edit Route";
            // 
            // labelStartStation
            // 
            this.labelStartStation.AutoSize = true;
            this.labelStartStation.Location = new System.Drawing.Point(10, 20);
            this.labelStartStation.Name = "labelStartStation";
            this.labelStartStation.Size = new System.Drawing.Size(32, 13);
            this.labelStartStation.TabIndex = 0;
            this.labelStartStation.Text = "Start:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(73, 49);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // labelEndStation
            // 
            this.labelEndStation.AutoSize = true;
            this.labelEndStation.Location = new System.Drawing.Point(10, 52);
            this.labelEndStation.Name = "labelEndStation";
            this.labelEndStation.Size = new System.Drawing.Size(29, 13);
            this.labelEndStation.TabIndex = 3;
            this.labelEndStation.Text = "End:";
            // 
            // confirmRouteButton
            // 
            this.confirmRouteButton.Location = new System.Drawing.Point(56, 92);
            this.confirmRouteButton.Name = "confirmRouteButton";
            this.confirmRouteButton.Size = new System.Drawing.Size(75, 23);
            this.confirmRouteButton.TabIndex = 4;
            this.confirmRouteButton.Text = "Confirm";
            this.confirmRouteButton.UseVisualStyleBackColor = true;
            this.confirmRouteButton.Click += new System.EventHandler(this.confirmRouteButton_Click);
            // 
            // RoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 316);
            this.Controls.Add(this.groupBoxRoutes);
            this.Controls.Add(this.listViewRoutes);
            this.Name = "RoutesForm";
            this.Text = "RoutesForm";
            this.groupBoxRoutes.ResumeLayout(false);
            this.groupBoxRoutes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewRoutes;
        private System.Windows.Forms.GroupBox groupBoxRoutes;
        private System.Windows.Forms.Label labelEndStation;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelStartStation;
        private System.Windows.Forms.Button confirmRouteButton;
    }
}