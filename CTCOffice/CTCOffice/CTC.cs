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

            //InitializeGraphics();
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

                    speed = (authority / (train.getSchedule()["Station 2"] - 1.2) / 60);

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

                    if (train.getAuthority() <= 0 && train.GetRouteSegments().GetEnd() == train.getSegment() && train.getTimeOnSchedule() >= train.getSchedule()[train.GetRouteSegments().GetStationEnd()] * 60)
                    {
                        Dictionary<string, double> schedule = new Dictionary<string,double>();
                        string direction, routingList;

                        if (train.GetRouteSegments().GetEnd() == 5)
                        {
                            schedule.Add("Station 1", 2.4);
                            direction = "West";
                            routingList = "Station2:Station1";
                        }
                        else
                        {
                            schedule.Add("Station 2", 2.4);
                            direction = "East";
                            routingList = "Station1:Station2";
                        }

                        train.updateDirection(direction);
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            listViewTrains.Items[0].SubItems[3].Text = direction;
                        }));
                        train.changeSchedule(schedule);
                        train.ChangeRouteSegments(central.GetRoute(routingList));
                        train.setTimeOnSchedule(0);
                        train.updatePosition(0);
                    }

                    double leastAuthority = 100000000000;

                    foreach (KeyValuePair<int, TrackSegment> pair in train.GetRouteSegments().GetRoute())
                    {
                        if (pair.Value.getOpenClosed().Equals("Closed") || pair.Value.getFailure().Equals("Segment Failure"))
                        {
                            closedSegment = 1;
                            if (pair.Value.Equals(central.getTrackSegment(train.getSegment())))
                            {
                                leastAuthority = 0;
                                errorOnClosed = 1;
                            }
                            else
                            {
                                if (errorOnClosed == 0)
                                {
                                    newAuthority = central.getTrackSegment(train.getSegment()).getLength() - train.getPosition();
                                    if(train.getDirection().Equals("East"))
                                    {
                                        if (train.getSegment() + 1 != 6)
                                        {
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
                                    else
                                    {
                                        if (train.getSegment() - 1 != 0)
                                        {
                                            for (int i = 1; !pair.Value.Equals(central.getTrackSegment(train.getSegment() - i)); i++)
                                            {
                                                newAuthority += central.getTrackSegment(train.getSegment() - i).getLength();
                                                if (train.getSegment() + i - 1 < 1)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (newAuthority < leastAuthority)
                            {
                                leastAuthority = newAuthority;
                            }
                        }

                        if (closedSegment == 0)
                        {
                            if(train.getDirection().Equals("East"))
                            {
                                newAuthority = central.getTrackSegment(train.getSegment()).getLength() - train.getPosition();
                                if (train.getSegment() + 1 != 6)
                                {
                                    for (int i = 1; (train.getSegment() + i) < 6; i++)
                                    {
                                        newAuthority += central.getTrackSegment(train.getSegment() + i).getLength();
                                    }
                                }
                            }
                            else
                            {
                                newAuthority = central.getTrackSegment(train.getSegment()).getLength() - train.getPosition();
                                if (train.getSegment() - 1 != 0)
                                {
                                    for (int i = 1; (train.getSegment() - i) > 0; i++)
                                    {
                                        newAuthority += central.getTrackSegment(train.getSegment() - i).getLength();
                                    }
                                }
                            }
                            if (newAuthority < leastAuthority)
                            {
                                leastAuthority = newAuthority;
                            }
                        }

                        testingForm.UpdateTrainAuthority(train.getNumber(), leastAuthority);
                        train.updateAuthority(leastAuthority);
                    }

                    if (train.getPosition() >= central.getTrackSegment(train.getSegment()).getLength())
                    {
                        if (train.getSegment() != train.GetRouteSegments().GetEnd())
                        {
                            int segmentNumber = 0;

                            train.updatePosition(train.getPosition() - central.getTrackSegment(train.getSegment()).getLength());

                            if(train.getDirection().Equals("East"))
                            { 
                                segmentNumber = train.getSegment() + 1;
                            }
                            else
                            {
                                segmentNumber = train.getSegment() - 1;
                            }

                            testingForm.updateTrainSegment(train.getNumber(), segmentNumber);
                        }
                    }

                    speed = (train.getAuthority() / (train.getSchedule()[train.GetRouteSegments().GetStationEnd()] - 1.2 - (train.getTimeOnSchedule() / 60)) / 60);

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
                        systemGraphics.Refresh();
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

            central.getTrain(1).setTimeOnSchedule(0);
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

        public void UpdateGraphics()
        {

        }

        private void systemGraphics_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen trainPen = new Pen(Color.Red, 2);
            int startX = 250, startY = 200;

            foreach (TrackSegment segment in central.getTrackSegments())
            {
                e.Graphics.FillRectangle(drawBrush, new Rectangle(startX, startY, segment.getLength(), 10));
                startX += segment.getLength() + 5;
            }

            foreach (Train train in central.getTrains())
            {
                int position = 0;

                if (train.getDirection().Equals("East"))
                {
                    for (int i = 1; i < 6; i++)
                    {
                        if (train.getSegment() > i)
                        {
                            position += central.getTrackSegment(i).getLength();
                        }
                        else if (train.getSegment() == i)
                        {
                            position += (int)train.getPosition();
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        if (train.getSegment() > i)
                        {
                            position += central.getTrackSegment(i).getLength();
                        }
                        else if (train.getSegment() == i)
                        {
                            position += central.getTrackSegment(i).getLength() - (int)train.getPosition();
                        }
                    }
                }

                e.Graphics.DrawEllipse(trainPen, new Rectangle(250 + position, 196, 16, 16));
            }
        }
    }
}
