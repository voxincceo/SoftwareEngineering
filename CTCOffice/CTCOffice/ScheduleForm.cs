using System;
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
    public partial class ScheduleForm : Form
    {
        private int train;
        private string line;
        private Dictionary<string, double> schedule;
        private CTC office;

        public ScheduleForm(int number, string trainLine, Dictionary<string, double> trainSchedule, CTC update)
        {
            train = number;
            line = trainLine;
            schedule = trainSchedule;
            office = update;

            InitializeComponent();
            InitializeScheduleList();

            this.Text = "Train " + number.ToString();
            this.Update();
        }

        private void ScheduleConfirmButton_Click(object sender, EventArgs e)
        {
            double resultDouble = 0;
            int resutltInt = 0, result = 0;
            string message = "", title = "";

            if (double.TryParse(newTimeBox.Text, out resultDouble))
            {
                result = 1;
            }
            else if(int.TryParse(newTimeBox.Text, out resutltInt))
            {
                result = 2;
            }
            else
            {
                message = "Invalid input";
                title = "Error";
            }

            if (result != 0)
            {
                if (result == 2)
                {
                    resultDouble = resutltInt;
                }
                schedule[comboBoxStation.Text] = resultDouble;

                office.SetScheduleFromForm(schedule, train);

                foreach (ListViewItem lvi in listViewSchedules.Items)
                {
                    if (comboBoxStation.Text.Equals(lvi.SubItems[1].Text))
                    {
                        lvi.SubItems[2].Text = resultDouble.ToString();
                    }
                }

                message = "Confirmed time to " + comboBoxStation.Text + " is now: " + resultDouble.ToString() + " minutes";
                title = "Confirmed";
            }

            MessageBox.Show(message, title);
        }

        private void InitializeScheduleList()
        {
            listViewSchedules.View = View.Details;

            listViewSchedules.Columns.Add("Line", 100);
            listViewSchedules.Columns.Add("Infrastructure", 100);
            listViewSchedules.Columns.Add("Total Time To Station With Dwell (Minutes)", 230);

            foreach (KeyValuePair<string, double> pair in schedule)
            {
                ListViewItem scheduleLVI = new ListViewItem();
                scheduleLVI.Text = line;
                scheduleLVI.SubItems.Add(pair.Key);
                scheduleLVI.SubItems.Add(pair.Value.ToString());

                listViewSchedules.Items.Add(scheduleLVI);

                comboBoxStation.Items.Add(pair.Key);
            }
        }

        private void ComboBoxStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTimeLabel.Text = schedule[comboBoxStation.SelectedItem.ToString()].ToString();
        }
    }
}
