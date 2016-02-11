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
            this.buttonStart.Location = new System.Drawing.Point(274, 537);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(182, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start Test";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 570);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listViewOutputs);
            this.Controls.Add(this.listViewInputs);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewInputs;
        private System.Windows.Forms.ListView listViewOutputs;
        private System.Windows.Forms.Button buttonStart;

    }
}