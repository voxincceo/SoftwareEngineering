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
    public partial class RoutesForm : Form
    {
        public RoutesForm()
        {
            InitializeComponent();
            initializeRouteList();
        }

        private void confirmRouteButton_Click(object sender, EventArgs e)
        {
            //ask to confirm route
            //change route
        }

        private void initializeRouteList()
        {
            listViewRoutes.View = View.Details;

            listViewRoutes.Columns.Add("Line", 100);
            listViewRoutes.Columns.Add("Start", 100);
            listViewRoutes.Columns.Add("End", 100);
        }
    }
}
