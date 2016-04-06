namespace CTCOffice
{
    partial class TrainDispatch
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
            this.labelNumber = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.MaskedTextBox();
            this.buttonDispatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(13, 16);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(74, 13);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "Train Number:";
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(94, 13);
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(100, 20);
            this.numberBox.TabIndex = 1;
            // 
            // buttonDispatch
            // 
            this.buttonDispatch.Location = new System.Drawing.Point(61, 39);
            this.buttonDispatch.Name = "buttonDispatch";
            this.buttonDispatch.Size = new System.Drawing.Size(75, 23);
            this.buttonDispatch.TabIndex = 4;
            this.buttonDispatch.Text = "Dispatch";
            this.buttonDispatch.UseVisualStyleBackColor = true;
            this.buttonDispatch.Click += new System.EventHandler(this.ButtonDispatch_Click);
            // 
            // TrainDispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 81);
            this.Controls.Add(this.buttonDispatch);
            this.Controls.Add(this.numberBox);
            this.Controls.Add(this.labelNumber);
            this.Name = "TrainDispatch";
            this.Text = "TrainDispatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.MaskedTextBox numberBox;
        private System.Windows.Forms.Button buttonDispatch;
    }
}