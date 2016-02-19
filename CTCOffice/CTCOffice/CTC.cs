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

            InitializeErrorList();
            InitializeSystemList();
            InitializeTrackSegmentList();
            InitializeTrainList();
            InitializeSystemObjects();

            central = new ControlSystem();

            //testingForm = new TestingForm(this);
            //testingForm.Show();
        }

        void SystemTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ArrayList trainList = central.GetTrains();
            ArrayList segmentList = central.GetTrackSegments();
            int authority = 0, number = 0;
            double speed = 0;

            foreach (Train train in trainList)
            {
                if (train.GetSegment() == 0)
                {
                    number = train.GetNumber();

                    testingForm.updateTrainSegment(number, 1);      //should be set to first track outside yard
                    
                    foreach (TrackSegment segment in segmentList)   //this should be changed to the trains schedule
                    {
                        authority += segment.GetLength();
                    }
                    testingForm.UpdateTrainAuthority(number, authority);
                    train.SetAuthority(authority);

                    speed = (authority / (train.GetSchedule()["Station 2"] - 1.2) / 60);    //"station 2" text should be changed to train.GetNextStation()

                    if (speed > (double) central.GetTrackSegment(1).GetSpeedLimit() / 3.6)  //1 should be changed to first segment outside yard
                    {
                        testingForm.updateTrainSpeed(number, (double) central.GetTrackSegment(1).GetSpeedLimit()); //here agagin
                    }
                    else
                    {
                        testingForm.updateTrainSpeed(number, speed);
                    }

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        listViewTrains.Items[train.GetListNumber()].SubItems[4].Text = authority.ToString();
                        listViewTrains.Items[train.GetListNumber()].SubItems[3].Text = "East";          //assuming initial direction is east
                    }));
                    train.SetDirection("East");
                }
                else
                {
                    int closedSegment = 0, errorOnClosed = 0;
                    double newAuthority = 0;

                    if (train.GetAuthority() <= 0 && train.GetRouteSegments().GetEnd() == train.GetSegment() && train.GetTimeOnSchedule() >= train.GetSchedule()[train.GetRouteSegments().GetStationEnd()] * 60)
                    {
                        //Check to reverse route
                        Dictionary<string, double> schedule = new Dictionary<string,double>();
                        string direction, routingList;

                        if (train.GetRouteSegments().GetEnd() == train.GetRouteSegments().GetNumberOfSegmentsInRoute())
                        {
                            schedule.Add("Station 1", 2.4);     //changed to initial station
                            direction = "West";
                            routingList = "Station2:Station1";
                        }
                        else
                        {
                            schedule.Add("Station 2", 2.4);     //changed to initial final station
                            direction = "East";
                            routingList = "Station1:Station2";
                        }

                        train.SetDirection(direction);
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            listViewTrains.Items[train.GetListNumber()].SubItems[3].Text = direction;
                        }));
                        train.SetSchedule(schedule);
                        train.SetRouteSegments(central.GetRoute(routingList));
                        train.SetTimeOnSchedule(0);
                        train.SetPosition(0);
                    }

                    double leastAuthority = 100000000000;

                    foreach (KeyValuePair<int, TrackSegment> pair in train.GetRouteSegments().GetRoute())
                    {
                        if (pair.Value.GetOpenClosed().Equals("Closed") || pair.Value.GetFailure().Equals("Failure"))
                        {
                            closedSegment = 1;
                            if (pair.Value.Equals(central.GetTrackSegment(train.GetSegment())))
                            {
                                leastAuthority = 0;
                                errorOnClosed = 1;
                            }
                            else
                            {
                                if (errorOnClosed == 0)
                                {
                                    newAuthority = central.GetTrackSegment(train.GetSegment()).GetLength() - train.GetPosition();
                                    if(train.GetDirection().Equals("East"))
                                    {
                                        if (train.GetSegment() + 1 != train.GetRouteSegments().GetEnd() + 1)
                                        {
                                            for (int i = 1; !pair.Value.Equals(central.GetTrackSegment(train.GetSegment() + i)) && (train.GetSegment() + i) < train.GetRouteSegments().GetEnd() + 1; i++)
                                            {
                                                newAuthority += central.GetTrackSegment(train.GetSegment() + i).GetLength();
                                                if (train.GetSegment() + i + 1 > train.GetRouteSegments().GetEnd())
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (train.GetSegment() - 1 != 0)
                                        {
                                            for (int i = 1; !pair.Value.Equals(central.GetTrackSegment(train.GetSegment() - i)); i++)
                                            {
                                                newAuthority += central.GetTrackSegment(train.GetSegment() - i).GetLength();
                                                if (train.GetSegment() - i - 1 < 1)
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
                            if(train.GetDirection().Equals("East"))
                            {
                                newAuthority = central.GetTrackSegment(train.GetSegment()).GetLength() - train.GetPosition();
                                if (train.GetSegment() + 1 != train.GetRouteSegments().GetEnd() + 1)
                                {
                                    for (int i = 1; (train.GetSegment() + i) < train.GetRouteSegments().GetEnd() + 1; i++)
                                    {
                                        newAuthority += central.GetTrackSegment(train.GetSegment() + i).GetLength();
                                    }
                                }
                            }
                            else
                            {
                                newAuthority = central.GetTrackSegment(train.GetSegment()).GetLength() - train.GetPosition();
                                if (train.GetSegment() - 1 != 0)
                                {
                                    for (int i = 1; (train.GetSegment() - i) > 0; i++)
                                    {
                                        newAuthority += central.GetTrackSegment(train.GetSegment() - i).GetLength();
                                    }
                                }
                            }
                            if (newAuthority < leastAuthority)
                            {
                                leastAuthority = newAuthority;
                            }
                        }

                        testingForm.UpdateTrainAuthority(train.GetNumber(), leastAuthority);
                        train.SetAuthority(leastAuthority);
                    }

                    if (train.GetPosition() >= central.GetTrackSegment(train.GetSegment()).GetLength())
                    {
                        if (train.GetSegment() != train.GetRouteSegments().GetEnd())
                        {
                            int segmentNumber = 0;

                            train.SetPosition(train.GetPosition() - central.GetTrackSegment(train.GetSegment()).GetLength());

                            if(train.GetDirection().Equals("East"))
                            { 
                                segmentNumber = train.GetSegment() + 1;
                            }
                            else
                            {
                                segmentNumber = train.GetSegment() - 1;
                            }

                            testingForm.updateTrainSegment(train.GetNumber(), segmentNumber);
                        }
                    }

                    speed = (train.GetAuthority() / (train.GetSchedule()[train.GetRouteSegments().GetStationEnd()] - 1.2 - (train.GetTimeOnSchedule() / 60)) / 60);

                    speed *= 3.6;

                    if (speed > central.GetTrackSegment(train.GetSegment()).GetSpeedLimit() || speed < 0)
                    {
                        testingForm.updateTrainSpeed(train.GetNumber(), central.GetTrackSegment(train.GetSegment()).GetSpeedLimit());
                    }
                    else
                    {
                        if (train.GetAuthority() <= 0)
                        {
                            testingForm.updateTrainSpeed(train.GetNumber(), 0);
                        }
                        else
                        {
                            testingForm.updateTrainSpeed(train.GetNumber(), speed);
                        }
                    }
                    if (IsHandleCreated && !IsDisposed)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            int temporaryNumber = train.GetNumber(), listNumber = train.GetListNumber();
                            testingForm.UpdateTrainAuthority(train.GetNumber(), train.GetAuthority());
                            systemListView.Items[listNumber].SubItems[1].Text = (60 / central.GetTrain(temporaryNumber).GetSchedule()[central.GetTrain(temporaryNumber).GetRouteSegments().GetStationEnd()]).ToString();
                            listViewTrains.Items[listNumber].SubItems[4].Text = train.GetAuthority().ToString();
                            listViewTrains.Items[listNumber].SubItems[1].Text = train.GetSegment().ToString();
                            listViewTrains.Items[listNumber].SubItems[2].Text = train.GetSpeed().ToString();
                            systemGraphics.Refresh();
                        }));
                    }
                }
            }
        }

        public void SetTrainSegment(int train, int segment)
        {
            central.GetTrain(train).SetSegment(segment);
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewTrains.Items[0].SubItems[1].Text = segment.ToString();
            }));
        }

        public void SetTrainSpeed(int train, double speed)
        {
            central.GetTrain(train).SetTrainSpeed(speed);
            this.Invoke(new Action(() =>
            {
                listViewTrains.Items[0].SubItems[2].Text = speed.ToString();
            }));
        }

        public void InitializeSystemTrains(ArrayList trains)
        {
            Train temporaryTrain;
            ListViewItem temporaryTrainLVI;

            foreach (int number in trains)
            {
                central.CreateTrain(number);
                central.GetTrain(number).SetListNumber(central.GetNumberOfTrains() - 1);
                temporaryTrain = central.GetTrain(number);

                temporaryTrainLVI = new ListViewItem();
                temporaryTrainLVI.Text = temporaryTrain.GetNumber().ToString();
                temporaryTrainLVI.SubItems.Add(temporaryTrain.GetSegment().ToString());
                temporaryTrainLVI.SubItems.Add(temporaryTrain.GetSpeed().ToString());
                temporaryTrainLVI.SubItems.Add(temporaryTrain.GetDirection());
                temporaryTrainLVI.SubItems.Add(temporaryTrain.GetAuthority().ToString());

                listViewTrains.Items.Add(temporaryTrainLVI);
            }
        }

        public void InitializeSystemTrackSegments(ArrayList trackSegments)
        {
            TrackSegment temporarySegment;
            ListViewItem temporarySegmentLVI;

            foreach (int number in trackSegments)
            {
                central.CreateTrackSegment(number);
                temporarySegment = central.GetTrackSegment(number);

                switch (number)
                {
                    case 1:
                        temporarySegment.SetSpeedLimit(10);
                        temporarySegment.SetLength(35);
                        break;
                    case 2:
                        temporarySegment.SetSpeedLimit(35);
                        temporarySegment.SetLength(50);
                        break;
                    case 3:
                        temporarySegment.SetSpeedLimit(50);
                        temporarySegment.SetLength(150);
                        break;
                    case 4:
                        temporarySegment.SetSpeedLimit(35);
                        temporarySegment.SetLength(50);
                        break;
                    case 5:
                        temporarySegment.SetSpeedLimit(10);
                        temporarySegment.SetLength(35);
                        break;
                }

                temporarySegmentLVI = new ListViewItem();
                temporarySegmentLVI.Text = temporarySegment.GetNumber().ToString();
                temporarySegmentLVI.SubItems.Add(temporarySegment.GetLine());
                temporarySegmentLVI.SubItems.Add(temporarySegment.GetSpeedLimit().ToString());
                temporarySegmentLVI.SubItems.Add(temporarySegment.GetOpenClosed());
                temporarySegmentLVI.SubItems.Add(temporarySegment.GetFailure());
                temporarySegmentLVI.SubItems.Add(temporarySegment.GetSwitchDirection());

                listViewTrack.Items.Add(temporarySegmentLVI);
            }

            central.GenerateRoutes();
        }

        public void OpenCloseSegment(int number, string text)
        {
            central.GetTrackSegment(number).SetOpenClosed(text);
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewTrack.Items[number - 1].SubItems[3].Text = text;
            }));
        }

        public void StartSystemTest()
        {
            systemTimer = new System.Timers.Timer(50);
            systemTimer.Elapsed += SystemTimer_Elapsed;
            systemTimer.Enabled = true;

            central.GetTrain(1).SetTimeOnSchedule(0);
        }

        public void DevelopTestSchedule()
        {
            ArrayList route = new ArrayList();
            route.Add("Black");
            route.Add("Station 1");
            route.Add("Station 2");

            Dictionary<string, double> schedule = new Dictionary<string, double>();
            schedule.Add("Station 2", 2.4);

            central.UpdateTrainRoute(route, 1);
            central.UpdateTrainSchedule(schedule, 1);

            string stations = "Station1:Station2";

            central.GetTrain(1).SetRouteSegments(central.GetRoute(stations));
        }

        public void SetRouteFromForm(ArrayList route, int train)
        {
            central.UpdateTrainRoute(route, train);
        }

        public void SetScheduleFromForm(Dictionary<string, double> schedule, int train)
        {
            central.UpdateTrainSchedule(schedule, train);
        }

        private void ShowSampleModule()
        {
            Form sampleForm = new SampleModule();
            sampleForm.Show();
        }

        private void TrackModelButton_Click(object sender, EventArgs e)
        {
            ShowSampleModule();
        }

        private void TrainModelButton_Click(object sender, EventArgs e)
        {
            ShowSampleModule();
        }

        private void TrackControllerButton_Click(object sender, EventArgs e)
        {
            ShowSampleModule();
        }

        private void InitializeErrorList()
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

        private void InitializeSystemList()
        {
            systemListView.View = View.Details;

            systemListView.Columns.Add("System Component", 200);
            systemListView.Columns.Add("Status", 50);

            ListViewItem systemThroughputLVI = new ListViewItem();
            systemThroughputLVI.Text = "System Throughput (Trains per Hour)";
            systemThroughputLVI.SubItems.Add("N/A");

            ListViewItem trackHeaterLVI = new ListViewItem();
            trackHeaterLVI.Text = "Track Heater";
            trackHeaterLVI.SubItems.Add("Off");

            systemListView.Items.Add(systemThroughputLVI);
            systemListView.Items.Add(trackHeaterLVI);
        }

        private void InitializeTrackSegmentList()
        {
            listViewTrack.View = View.Details;

            listViewTrack.Columns.Add("Segment", 100);
            listViewTrack.Columns.Add("Line", 100);
            listViewTrack.Columns.Add("Speed Limit", 100);
            listViewTrack.Columns.Add("Open/Closed", 100);
            listViewTrack.Columns.Add("Failures", 100);
            listViewTrack.Columns.Add("Switch Direction", 100);
        }

        private void InitializeTrainList()
        {
            listViewTrains.View = View.Details;

            listViewTrains.Columns.Add("Train", 100);
            listViewTrains.Columns.Add("On Segment", 100);
            listViewTrains.Columns.Add("Speed", 100);
            listViewTrains.Columns.Add("Direction", 100);
            listViewTrains.Columns.Add("Authority", 100);
        }

        private void InitializeSystemObjects()
        {
            //call everyones object
        }

        private void OpenCloseButton_Click(object sender, EventArgs e)
        {
            if (listViewTrack.SelectedItems.Count > 0)
            {
                TrackSegment segment = central.GetTrackSegment(Int32.Parse(listViewTrack.SelectedItems[0].Text));
                string openClosed = segment.GetOpenClosed();

                if(openClosed.Equals("Open"))
                {

                    testingForm.updateSegment(segment.GetNumber(), "Closed");
                }
                else
                {
                    testingForm.updateSegment(segment.GetNumber(), "Open");
                }
            }
        }

        private void RouteButton_Click(object sender, EventArgs e)
        {
            if(listViewTrains.SelectedItems.Count > 0)
            {
                Train train = central.GetTrain(Int32.Parse(listViewTrains.SelectedItems[0].Text));
                Form routeForm = new RoutesForm(train.GetNumber(), train.GetRoute(), this);
                routeForm.Show();
            }
        }

        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            if (listViewTrains.SelectedItems.Count > 0)
            {
                Train train = central.GetTrain(Int32.Parse(listViewTrains.SelectedItems[0].Text));
                Form scheduleForm = new ScheduleForm(train.GetNumber(), train.GetLine(), train.GetSchedule(), this);
                scheduleForm.Show();
            }
        }

        private void ListViewTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTrack.SelectedItems.Count > 0)
            {
               string text = central.GetTrackSegment(Int32.Parse(listViewTrack.SelectedItems[0].Text)).GetOpenClosed();

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

        private void SystemGraphics_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush orangeBrush = new SolidBrush(Color.Orange);
            SolidBrush colorBrush;
            Pen trainPen = new Pen(Color.DeepSkyBlue, 4);
            int startX = 250, startY = 200;

            foreach (TrackSegment segment in central.GetTrackSegments())
            {
                if (segment.GetFailure().Equals("Failure"))
                {
                    colorBrush = redBrush;
                }
                else if (segment.GetOpenClosed().Equals("Closed"))
                {
                    colorBrush = orangeBrush;
                }
                else
                {
                    colorBrush = blackBrush;
                }

                e.Graphics.FillRectangle(colorBrush, new Rectangle(startX, startY, segment.GetLength(), 10));
                startX += segment.GetLength() + 5;
            }

            foreach (Train train in central.GetTrains())
            {
                int position = 0;

                if (train.GetDirection().Equals("East"))
                {
                    for (int i = 1; i < 6; i++)
                    {
                        if (train.GetSegment() > i)
                        {
                            position += central.GetTrackSegment(i).GetLength();
                        }
                        else if (train.GetSegment() == i)
                        {
                            position += (int)train.GetPosition();
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        if (train.GetSegment() > i)
                        {
                            position += central.GetTrackSegment(i).GetLength();
                        }
                        else if (train.GetSegment() == i)
                        {
                            position += central.GetTrackSegment(i).GetLength() - (int)train.GetPosition();
                        }
                    }
                }

                e.Graphics.DrawEllipse(trainPen, new Rectangle(250 + position, 197, 16, 16));
            }
        }

        private void CTC_FormClosed(object sender, FormClosedEventArgs e)
        {
            testingForm.Dispose();
        }

        public void SetTrackHeater(string text)
        {
            systemListView.Items[1].SubItems[1].Text = text;
        }

        public void SetTrackCiruitFailure(string text)
        {
            errorListView.Items[1].SubItems[1].Text = text;

            if (text.Equals("None"))
            {
                systemTimer.Start();
                central.GetTrain(1).Start();
            }
            else
            {
                systemTimer.Stop();
                central.GetTrain(1).Stop();
            }
        }

        public void SetPowerFailure(string text)
        {
            errorListView.Items[0].SubItems[1].Text = text;

            if (text.Equals("None"))
            {
                systemTimer.Start();
                central.GetTrain(1).Start();
            }
            else
            {
                systemTimer.Stop();
                central.GetTrain(1).Stop();
            }
        }

        public void SetTrackSegmentFailure(int number, string text)
        {
            central.UpdateSegmentFailure(number, text);
            listViewTrack.Items[number - 1].SubItems[4].Text = text;
        }

        private void ButtonDispatch_Click(object sender, EventArgs e)
        {
            TrainDispatch trainDispatch = new TrainDispatch(this);
            trainDispatch.Show();
        }
    }
}
