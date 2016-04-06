using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTCOffice
{
    public partial class TrainDispatch : Form
    {
        private CTC office;

        public TrainDispatch(CTC update)
        {
            InitializeComponent();
            office = update;
        }

        private void ButtonDispatch_Click(object sender, EventArgs e)
        {
            int number = 0, result = 0;
            string message = "", title = "";
            ArrayList train = new ArrayList();
            Train newTrain = new Train();

   
            if (int.TryParse(numberBox.Text, out number))
            {

                message = "Train " + number.ToString() + " confirmed.";
                title = "Dispatch";
                result = 1;
            }
            else
            {
                message = "Please enter a valid train number";
                title = "Error";
            }

            MessageBox.Show(message, title);
            if (result == 1)
            {
                train.Add(number);
                office.InitializeSystemTrains(train);
                office.SetTrainSegment(number, 1);
                this.Dispose();
            }
        }
    }
}
