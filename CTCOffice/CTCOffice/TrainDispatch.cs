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
            int number = 0, result = 0, segment = 0;
            string message = "", title = "";
            ArrayList train = new ArrayList();
            Train newTrain = new Train();

            if (stationBox.Text != null)
            {
                if (int.TryParse(numberBox.Text, out number))
                {
                    if (int.TryParse(stationBox.Text, out segment))
                    {
                        message = "Train " + number.ToString() + " confirmed at station " + segment.ToString();
                        title = "Dispatch";
                        result = 1;
                    }
                    else
                    {
                        message = "Please enter a valid segment number";
                        title = "Error";
                    }
                }
                else
                {
                    message = "Please enter a valid train number";
                    title = "Error";
                }
            }

            MessageBox.Show(message, title);
            if (result == 1)
            {
                train.Add(number);
                office.InitializeSystemTrains(train);
                office.SetTrainSegment(number, segment);
            }
        }
    }
}
