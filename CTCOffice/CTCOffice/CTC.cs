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
    public partial class CTC : Form
    {
        private ControlSystem central;
        private TestingForm testingForm;

        public CTC()
        {
            InitializeComponent();

            initializeErrorList();
            initializeSystemList();
            initializeTrackSegmentList();
            initialzieTrainList();

            central = new ControlSystem();

            testingForm = new TestingForm(this);
            testingForm.Show();
        }

        public void initializeSystemTrains(ArrayList trains)
        {
            Train temporaryTrain;
            ListViewItem temporaryTrainLVI;

            foreach (int number in trains)
            {
                central.createTrain(number);
                temporaryTrain = central.getTrain(number);

                temporaryTrainLVI = new ListViewItem();
                temporaryTrainLVI.Text = temporaryTrain.getNumber().ToString();
                temporaryTrainLVI.SubItems.Add(temporaryTrain.getSegment().ToString());
                temporaryTrainLVI.SubItems.Add(temporaryTrain.getSpeed().ToString());
                temporaryTrainLVI.SubItems.Add(temporaryTrain.getDirection());
                temporaryTrainLVI.SubItems.Add(temporaryTrain.getAuthority().ToString());

                listViewTrains.Items.Add(temporaryTrainLVI);
            }
        }

        public void initializeSystemTrackSegments(ArrayList trackSegments)
        {
            TrackSegment temporarySegment;
            ListViewItem temporarySegmentLVI;

            foreach (int number in trackSegments)
            {
                central.createTrackSegment(number);
                temporarySegment = central.getTrackSegment(number);

                switch (number)
                {
                    case 1:
                        temporarySegment.updateSpeedLimit(10);
                        break;
                    case 2:
                        temporarySegment.updateSpeedLimit(35);
                        break;
                    case 3:
                        temporarySegment.updateSpeedLimit(50);
                        break;
                    case 4:
                        temporarySegment.updateSpeedLimit(35);
                        break;
                    case 5:
                        temporarySegment.updateSpeedLimit(10);
                        break;
                }

                temporarySegmentLVI = new ListViewItem();
                temporarySegmentLVI.Text = temporarySegment.getNumber().ToString();
                temporarySegmentLVI.SubItems.Add(temporarySegment.getLine());
                temporarySegmentLVI.SubItems.Add(temporarySegment.getSpeedLimit().ToString());
                temporarySegmentLVI.SubItems.Add(temporarySegment.getOpenClosed());
                temporarySegmentLVI.SubItems.Add(temporarySegment.getFailure());
                temporarySegmentLVI.SubItems.Add(temporarySegment.getSwitchDirection());

                listViewTrack.Items.Add(temporarySegmentLVI);
            }
        }

        public void openCloseSegment(int number, string text)
        {
            central.getTrackSegment(number).updateOpenClosed(text);

            listViewTrack.Items[number - 1].SubItems[3].Text = text;
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

            errorListView.Items.Add(powerFailureLVI);
            errorListView.Items.Add(trackCircuitFailureLVI);
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
            listViewTrack.Columns.Add("Speed Limit", 100);
            listViewTrack.Columns.Add("Open/Closed", 100);
            listViewTrack.Columns.Add("Failures", 100);
            listViewTrack.Columns.Add("Switch Direction", 100);
        }

        private void initialzieTrainList()
        {
            listViewTrains.View = View.Details;

            listViewTrains.Columns.Add("Train", 100);
            listViewTrains.Columns.Add("On Segment", 100);
            listViewTrains.Columns.Add("Speed", 100);
            listViewTrains.Columns.Add("Direction", 100);
            listViewTrains.Columns.Add("Authority", 100);
        }

        private void openCloseButton_Click(object sender, EventArgs e)
        {
            if (listViewTrack.SelectedItems.Count > 0)
            {
                TrackSegment segment = central.getTrackSegment(Int32.Parse(listViewTrack.SelectedItems[0].Text));
                string openClosed = segment.getOpenClosed();

                if(openClosed.Equals("Open"))
                {

                    testingForm.updateSegment(segment.getNumber(), "Closed");
                }
                else
                {
                    testingForm.updateSegment(segment.getNumber(), "Open");
                }
            }
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

        private void listViewTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTrack.SelectedItems.Count > 0)
            {
               string text = central.getTrackSegment(Int32.Parse(listViewTrack.SelectedItems[0].Text)).getOpenClosed();

               if (text.Equals("Open"))
               {
                   openCloseButton.Text = "Close";
               }
               else
               {
                   openCloseButton.Text = "Open";
               }
            }
        }
    }
}
