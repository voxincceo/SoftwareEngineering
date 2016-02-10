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
    public partial class TestingForm : Form
    {
        public TestingForm()
        {
            InitializeComponent();
            initializeInputList();
            initializeOutputList();
        }

        private void initializeInputList()
        {
            listViewInputs.View = View.Details;

            listViewInputs.Columns.Add("Input Signal", 150);
            listViewInputs.Columns.Add("Current Value", 150);
        }

        private void initializeOutputList()
        {
            listViewOutputs.View = View.Details;

            listViewOutputs.Columns.Add("Output Signal", 150);
            listViewOutputs.Columns.Add("Current Value", 150);
        }
    }
}
