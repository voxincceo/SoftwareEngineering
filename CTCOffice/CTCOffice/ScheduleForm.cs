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
        public ScheduleForm()
        {
            InitializeComponent();
            initializeScheduleList();
        }

        private void scheduleConfirmButton_Click(object sender, EventArgs e)
        {
            //show confirm dialog
            //update schedule
        }

        private void initializeScheduleList()
        {
            listViewSchedules.View = View.Details;

            listViewSchedules.Columns.Add("Line", 100);
            listViewSchedules.Columns.Add("Infrastructure", 100);
            listViewSchedules.Columns.Add("Total Time To Station With Dwell (Minutes)", 230);
        }
    }
}
