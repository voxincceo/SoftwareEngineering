namespace CTCOffice
{
    partial class SampleModule
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
            this.sampleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sampleLabel
            // 
            this.sampleLabel.AutoSize = true;
            this.sampleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleLabel.Location = new System.Drawing.Point(53, 108);
            this.sampleLabel.Name = "sampleLabel";
            this.sampleLabel.Size = new System.Drawing.Size(596, 39);
            this.sampleLabel.TabIndex = 0;
            this.sampleLabel.Text = "This will be a module once integrated.";
            // 
            // SampleModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 464);
            this.Controls.Add(this.sampleLabel);
            this.Name = "SampleModule";
            this.Text = "SampleModule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sampleLabel;
    }
}