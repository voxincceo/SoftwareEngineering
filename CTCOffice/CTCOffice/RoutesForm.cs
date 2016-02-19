using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CTCOffice
{
    public partial class RoutesForm : Form
    {
        private int train;
        private ArrayList route;
        private CTC office;

        public RoutesForm(int number, ArrayList trainRoute, CTC update)
        {
            train = number;
            route = trainRoute;
            office = update;

            InitializeComponent();
            InitializeRouteList();

            this.Text = "Train " + number.ToString();
            this.Update();
        }

        private void ConfirmRouteButton_Click(object sender, EventArgs e)
        {
            string message, title;

            if(comboBoxStart.SelectedItem != null && comboBoxEnd.SelectedItem != null)
            {
                if (comboBoxStart.SelectedItem.Equals(comboBoxEnd.SelectedItem))
                {
                    message = "The stations cannot be identical.";
                    title = "Error";
                }
                else
                {
                    message = "Route changed to Start: " + comboBoxStart.SelectedItem.ToString() + " to End: " + comboBoxEnd.SelectedItem.ToString();
                    title = "Confirm";
                    ArrayList newRoute = new ArrayList();
                    newRoute.Add(route[0]);
                    newRoute.Add(comboBoxStart.SelectedItem.ToString());
                    newRoute.Add(comboBoxEnd.SelectedItem.ToString());

                    office.SetRouteFromForm(newRoute, train);
                    route = newRoute;
                    UpdateRoute();
                }
            }
            else
            {
                message = "Please pick a station for both start and end.";
                title = "Error";
            }


            MessageBox.Show(message, title);

        }

        private void InitializeRouteList()
        {
            listViewRoutes.View = View.Details;

            listViewRoutes.Columns.Add("Line", 100);
            listViewRoutes.Columns.Add("Start", 100);
            listViewRoutes.Columns.Add("End", 100);

            ListViewItem routeLVI = new ListViewItem();
            routeLVI.Text = route[0].ToString();
            routeLVI.SubItems.Add(route[1].ToString());
            routeLVI.SubItems.Add(route[2].ToString());

            listViewRoutes.Items.Add(routeLVI);

            comboBoxStart.Items.Add(route[1].ToString());
            comboBoxStart.Items.Add(route[2].ToString());
            comboBoxEnd.Items.Add(route[1].ToString());
            comboBoxEnd.Items.Add(route[2].ToString());
        }

        private void UpdateRoute()
        {
            listViewRoutes.Items[0].SubItems[1].Text = route[1].ToString();
            listViewRoutes.Items[0].SubItems[2].Text = route[2].ToString();
        }
    }
}
