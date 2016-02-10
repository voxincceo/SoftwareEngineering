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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Form testingForm = new TestingForm();
            testingForm.Show();

            initializeErrorList();
            initializeSystemList();
            initializeTrackSegmentList();
            initialzieTrainList();
        }

        private void showSampleModule()
        {
            Form sampleForm = new SampleModule();
            sampleForm.Show();
        }

        private void trackModelButton_Click(object sender, EventArgs e)
        {
            showSampleModule();
        }

        private void trainModelButton_Click(object sender, EventArgs e)
        {
            showSampleModule();
        }

        private void trackControllerButton_Click(object sender, EventArgs e)
        {
            showSampleModule();
        }

        private void trainControllerButton_Click(object sender, EventArgs e)
        {
            showSampleModule();
        }

        private void initializeErrorList()
        {
            errorListView.View = View.Details;

            errorListView.Columns.Add("Error Type", 150);
            errorListView.Columns.Add("Error Status", 150);

            ListViewItem powerFailureLVI = new ListViewItem();
            powerFailureLVI.Text = "Power Failure";
            powerFailureLVI.SubItems.Add("None");

            ListViewItem trackCircuitFailureLVI = new ListViewItem();
            trackCircuitFailureLVI.Text = "Track Circuit Failures";
            trackCircuitFailureLVI.SubItems.Add("None");

            ListViewItem trainFailureLVI = new ListViewItem();
            trainFailureLVI.Text = "Train Failures";
            trainFailureLVI.SubItems.Add("None");

            errorListView.Items.Add(powerFailureLVI);
            errorListView.Items.Add(trackCircuitFailureLVI);
            errorListView.Items.Add(trainFailureLVI);
        }

        private void initializeSystemList()
        {
            systemListView.View = View.Details;

            systemListView.Columns.Add("System Component", 200);
            systemListView.Columns.Add("Status", 50);

            ListViewItem systemThroughputLVI = new ListViewItem();
            systemThroughputLVI.Text = "System Throughput (Trains per Hour)";
            systemThroughputLVI.SubItems.Add("3");

            ListViewItem trackHeaterLVI = new ListViewItem();
            trackHeaterLVI.Text = "Track Heater";
            trackHeaterLVI.SubItems.Add("Off");

            systemListView.Items.Add(systemThroughputLVI);
            systemListView.Items.Add(trackHeaterLVI);
        }

        private void initializeTrackSegmentList()
        {
            listViewTrack.View = View.Details;

            listViewTrack.Columns.Add("Segment", 100);
            listViewTrack.Columns.Add("Line", 100);
            listViewTrack.Columns.Add("Open/Closed", 100);
            listViewTrack.Columns.Add("Failures", 100);
            listViewTrack.Columns.Add("Switch Direction", 100);
        }

        private void initialzieTrainList()
        {
            listViewTrains.View = View.Details;

            listViewTrains.Columns.Add("Train", 100);
            listViewTrains.Columns.Add("Speed", 100);
            listViewTrains.Columns.Add("Direction", 100);
            listViewTrains.Columns.Add("Left Doors", 100);
            listViewTrains.Columns.Add("Right Doors", 100);
            listViewTrains.Columns.Add("Passengers", 100);
            listViewTrains.Columns.Add("Lights", 100);
            listViewTrains.Columns.Add("Authority", 100);
            listViewTrains.Columns.Add("Failures", 100);

        }

        private void openCloseButton_Click(object sender, EventArgs e)
        {
            //send signal to open/close
        }

        private void routeButton_Click(object sender, EventArgs e)
        {
            Form routeForm = new RoutesForm();
            routeForm.Show();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            Form scheduleForm = new ScheduleForm();
            scheduleForm.Show();
        }
    }
}
