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
        private System.Timers.Timer systemTimer;

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

        void systemTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ArrayList trainList = central.getTrains();
            ArrayList segmentList = central.getTrackSegments();
            int authority = 0, number = 0;
            double speed = 0;

            foreach (Train train in trainList)
            {
                if (train.getSegment() == 0)
                {
                    number = train.getNumber();

                    testingForm.updateTrainSegment(number, 1);
                    
                    foreach (TrackSegment segment in segmentList)
                    {
                        authority += segment.getLength();
                    }
                    testingForm.UpdateTrainAuthority(number, authority);
                    train.updateAuthority(authority);

                    speed = (authority / (train.getSchedule()["Station 2"] - 1) / 60);

                    if (speed > (double) central.getTrackSegment(1).getSpeedLimit() / 3.6)
                    {
                        testingForm.updateTrainSpeed(number, (double) central.getTrackSegment(1).getSpeedLimit());
                    }
                    else
                    {
                        testingForm.updateTrainSpeed(number, speed);
                    }

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        listViewTrains.Items[0].SubItems[4].Text = authority.ToString();
                        listViewTrains.Items[0].SubItems[3].Text = "East";
                    }));
                    train.updateDirection("East");
                }
                else
                {
                    int closedSegment = 0, errorOnClosed = 0;
                    double newAuthority = 0;

                    foreach (KeyValuePair<int, TrackSegment> pair in train.GetRouteSegments().GetRoute())
                    {
                        if (pair.Value.getOpenClosed().Equals("Closed") || pair.Value.getFailure().Equals("Segment Failure"))
                        {
                            closedSegment = 1;
                            if (pair.Value.Equals(central.getTrackSegment(train.getSegment())))
                            {
                                newAuthority = 0;
                                errorOnClosed = 1;
                            }
                            else
                            {
                                if (errorOnClosed == 0)
                                {
                                    newAuthority = central.getTrackSegment(train.getSegment()).getLength() - train.getPosition();
                                    for (int i = 1; !pair.Value.Equals(central.getTrackSegment(train.getSegment() + i)) && (train.getSegment() + i) < 6; i++)
                                    {
                                        newAuthority += central.getTrackSegment(train.getSegment() + i).getLength();
                                        if (train.getSegment() + i + 1 > 5)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (closedSegment == 0)
                        {
                            newAuthority = central.getTrackSegment(train.getSegment()).getLength() - train.getPosition();
                            for (int i = 1; (train.getSegment() + i) < 6; i++)
                            {
                                newAuthority += central.getTrackSegment(train.getSegment() + i).getLength();
                            }
                        }

                        testingForm.UpdateTrainAuthority(train.getNumber(), newAuthority);
                        train.updateAuthority(newAuthority);
                    }

                    if (train.getPosition() >= central.getTrackSegment(train.getSegment()).getLength())
                    {
                        if (train.getSegment() != 5)
                        {
                            train.updatePosition(train.getPosition() - central.getTrackSegment(train.getSegment()).getLength());
                            testingForm.updateTrainSegment(train.getNumber(), train.getSegment() + 1);
                        }
                    }

                    speed = (train.getAuthority() / (train.getSchedule()["Station 2"] - 1 - (train.getTimeOnSchedule() / 60)) / 60);

                    speed *= 3.6;

                    if (speed > central.getTrackSegment(train.getSegment()).getSpeedLimit() || speed < 0)
                    {
                        testingForm.updateTrainSpeed(train.getNumber(), central.getTrackSegment(train.getSegment()).getSpeedLimit());
                    }
                    else
                    {
                        if (train.getAuthority() <= 0)
                        {
                            testingForm.updateTrainSpeed(train.getNumber(), 0);
                        }
                        else
                        {
                            testingForm.updateTrainSpeed(train.getNumber(), speed);
                        }
                    }

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        testingForm.UpdateTrainAuthority(train.getNumber(), train.getAuthority());
                        listViewTrains.Items[0].SubItems[4].Text = train.getAuthority().ToString();
                        listViewTrains.Items[0].SubItems[1].Text = train.getSegment().ToString();
                        listViewTrains.Items[0].SubItems[2].Text = train.getSpeed().ToString();
                    }));
                }
            }
        }

        public void trainSegment(int train, int segment)
        {
            central.getTrain(train).updateSegment(segment);
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewTrains.Items[0].SubItems[1].Text = segment.ToString();
            }));
        }

        public void trainSpeed(int train, double speed)
        {
            central.getTrain(train).updateTrainSpeed(speed);
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewTrains.Items[0].SubItems[2].Text = speed.ToString();
            }));
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
                        temporarySegment.setLength(35);
                        break;
                    case 2:
                        temporarySegment.updateSpeedLimit(35);
                        temporarySegment.setLength(50);
                        break;
                    case 3:
                        temporarySegment.updateSpeedLimit(50);
                        temporarySegment.setLength(150);
                        break;
                    case 4:
                        temporarySegment.updateSpeedLimit(35);
                        temporarySegment.setLength(50);
                        break;
                    case 5:
                        temporarySegment.updateSpeedLimit(10);
                        temporarySegment.setLength(35);
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

            central.GenerateRoutes();
        }

        public void openCloseSegment(int number, string text)
        {
            central.getTrackSegment(number).updateOpenClosed(text);
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewTrack.Items[number - 1].SubItems[3].Text = text;
            }));
        }

        public void startSystemTest()
        {
            systemTimer = new System.Timers.Timer(50);
            systemTimer.Elapsed += systemTimer_Elapsed;
            systemTimer.Enabled = true;
        }

        public void DevelopTestSchedule()
        {
            ArrayList route = new ArrayList();
            route.Add("Black");
            route.Add("Station 1");
            route.Add("Station 2");

            Dictionary<string, double> schedule = new Dictionary<string, double>();
            schedule.Add("Station 2", 2.4);

            central.updateTrainRoute(route, 1);
            central.updateTrainSchedule(schedule, 1);

            string stations = "Station1:Station2";

            central.getTrain(1).ChangeRouteSegments(central.GetRoute(stations));
        }

        public void updateRouteFromForm(ArrayList route, int train)
        {
            central.updateTrainRoute(route, train);
        }

        public void updateScheduleFromForm(Dictionary<string, double> schedule, int train)
        {
            central.updateTrainSchedule(schedule, train);
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
            if(listViewTrains.SelectedItems.Count > 0)
            {
                Train train = central.getTrain(Int32.Parse(listViewTrains.SelectedItems[0].Text));
                Form routeForm = new RoutesForm(train.getNumber(), train.getRoute(), this);
                routeForm.Show();
            }
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            if (listViewTrains.SelectedItems.Count > 0)
            {
                Train train = central.getTrain(Int32.Parse(listViewTrains.SelectedItems[0].Text));
                Form scheduleForm = new ScheduleForm(train.getNumber(), train.getLine(), train.getSchedule(), this);
                scheduleForm.Show();
            }
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
