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
        private int trainNumber;
        private Train train;
        private ArrayList segments;
        private CTC office;

        public RoutesForm(Train number, ArrayList segmentList, CTC update)
        {
            train = number;
            trainNumber = train.GetNumber();
            segments = segmentList;
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
                    message = "The segments cannot be identical.";
                    title = "Error";
                }
                else
                {
                    message = "Route changed to Start: " + comboBoxStart.SelectedItem.ToString() + " to End: " + comboBoxEnd.SelectedItem.ToString();
                    title = "Confirm";

                    office.SetRouteFromForm(trainNumber, int.Parse(comboBoxEnd.SelectedItem.ToString()));
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
            routeLVI.Text = train.GetLine();
            routeLVI.SubItems.Add(train.GetRouteSegments().GetStart().ToString());
            routeLVI.SubItems.Add(train.GetRouteSegments().GetEnd().ToString());

            listViewRoutes.Items.Add(routeLVI);

            foreach(TrackSegment s in segments)
            {
                comboBoxStart.Items.Add(s.GetNumber().ToString());
                comboBoxEnd.Items.Add(s.GetNumber().ToString());
            }
        }

        private void UpdateRoute()
        {
            listViewRoutes.Items[0].SubItems[1].Text = train.GetRouteSegments().GetStart().ToString();
            listViewRoutes.Items[0].SubItems[2].Text = train.GetRouteSegments().GetEnd().ToString();
        }
    }
}
