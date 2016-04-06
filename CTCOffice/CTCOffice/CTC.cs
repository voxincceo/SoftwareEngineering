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
using TrackModelPrototype;
using TheTrainModule;
using TrainController;
using TrackController;

namespace CTCOffice
{
    public partial class CTC : Form
    {
        private ControlSystem central;
        private TestingForm testingForm;
        private RCS.RCS formParent;
        private TrackControllerForm trackController;
        private TrackModelForm trackModel;
        private TrainControllerForm trainController;
        private TrainModel trainModel;
        private System.Timers.Timer systemTimer;
        private int systemSpeed;

        public CTC(RCS.RCS main)
        {
            InitializeComponent();
            systemTimer = new System.Timers.Timer(50);

            InitializeSystemComponents();
            InitializeErrorList();
            InitializeSystemList();
            InitializeTrackSegmentList();
            InitializeTrainList();

            central = new ControlSystem();
            ParseTrackFile("SystemPrototype.csv");
            formParent = main;

            systemSpeed = 1;
            StartSystemTest();

            //testingForm = new TestingForm(this);
            //testingForm.Show();
        }

        private void ParseTrackFile(string filename)
        {
            string line;
            string[] segment;
            TrackSegment tempSegment;
            ArrayList parsedSegments = new ArrayList();

            System.IO.StreamReader file = new System.IO.StreamReader("../../" + filename); //go up from bin\debug\
            while ((line = file.ReadLine()) != null)
            {
                segment = line.Split(',');

                central.CreateTrackSegment(int.Parse(segment[2]));
                tempSegment = central.GetTrackSegment(int.Parse(segment[2]));

                tempSegment.SetLine(segment[0]);
                tempSegment.SetLength(int.Parse(segment[3]));
                tempSegment.SetSpeedLimit(int.Parse(segment[5]));
                if(segment[6] != "")
                {
                    tempSegment.SetIsStation(true);
                }

                parsedSegments.Add(tempSegment);
            }

            InitializeSystemTrackSegments(parsedSegments);
        }

        void SystemTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateSystem();
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

        public void SetTrainAuthority(int train, double authority)
        {
            central.GetTrain(train).SetAuthority(authority);
            this.Invoke(new Action(() =>
            {
                listViewTrains.Items[0].SubItems[4].Text = authority.ToString();
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
                central.GetTrain(number).SetSegment(1); //first from yard
                DevelopTestSchedule(number);                //check this for actual schedules ?
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
            //TrackSegment temporarySegment;
            ListViewItem temporarySegmentLVI;

            foreach (TrackSegment temporarySegment in trackSegments)
            {
                /*central.CreateTrackSegment(number);
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
                */
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
            central.GenerateStations();
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
            systemTimer.Elapsed += SystemTimer_Elapsed;
            systemTimer.Enabled = true;

            //central.GetTrain(1).SetTimeOnSchedule(0);
        }

        public void DevelopTestSchedule(int number)
        {
            //dead from testfrom
           /*ArrayList route = new ArrayList();
            route.Add("Black");
            route.Add("Station 1");
            route.Add("Station 2");
            */
            Dictionary<int, double> schedule = new Dictionary<int, double>();
            schedule.Add(5, 2.4);
            schedule.Add(13, 8.4);
            central.SetTrainSchedule(number, schedule);

            /*
            central.SetTrainRoute(route, 1);
           

            string stations = "Station1:Station2";

            central.GetTrain(1).SetRoute(central.GetRoute(stations));*/
        }

        public void SetRouteFromForm(int number, int destination)
        {
            Train train = central.GetTrain(number);
            train.SetDestination(destination);
            central.UpdateTrainRoute(train.GetNumber());
        }

        public void SetScheduleFromForm(Dictionary<int, double> schedule, int train)
        {
            central.SetTrainSchedule(train, schedule);
        }

        /*private void ShowSampleModule()
        {
            Form sampleForm = new SampleModule();
            sampleForm.Show();
        }*/

        private void TrackModelButton_Click(object sender, EventArgs e)
        {
            trackModel.Show();
        }

        private void TrainModelButton_Click(object sender, EventArgs e)
        {
            trainModel.Show();
        }

        private void TrackControllerButton_Click(object sender, EventArgs e)
        {
            trackController.Show();
        }

        private void InitializeSystemComponents()
        {
            trackController = new TrackControllerForm(systemTimer);
            trackModel = new TrackModelForm();
            trainModel = new TrainModel(systemTimer);
            trainController = new TrainControllerForm(systemTimer);

            //trackController.SetSystemSpeed(systemSpeed);
            //trackModel.SetSystemSpeed(systemSpeed);
            //trainModel.SetSystemSpeed(systemSpeed);
            //trainController.SetSystemSpeed(systemSpeed);

            //trackController.SendModules(this, trackModel);
            trackModel.SendModules(trackController, trainModel);
            trainModel.SendModules(trackModel, trainController);
            trainController.SendModules(trainModel);
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

        private void OpenCloseButton_Click(object sender, EventArgs e)
        {
            if (listViewTrack.SelectedItems.Count > 0)
            {
                TrackSegment segment = central.GetTrackSegment(Int32.Parse(listViewTrack.SelectedItems[0].Text));
                string openClosed = segment.GetOpenClosed();

                if(openClosed.Equals("Open"))
                {

                    //trackController.SuggestSegmentOpenclosed(segment.GetNumber(), "Closed");
                    OpenCloseSegment(segment.GetNumber(), "Closed");
                }
                else
                {
                    //trackController.SuggestSegmentOpenclosed(segment.GetNumber(), "Open");
                    OpenCloseSegment(segment.GetNumber(), "Open");
                }
            }
        }

        private void RouteButton_Click(object sender, EventArgs e)
        {
            if(listViewTrains.SelectedItems.Count > 0)
            {
                Train train = central.GetTrain(Int32.Parse(listViewTrains.SelectedItems[0].Text));
                Form routeForm = new RoutesForm(train, central.GetTrackSegments(), this);
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
            int startX = 0, startY = 200;

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

                e.Graphics.FillRectangle(colorBrush, new Rectangle(startX, startY, segment.GetLength() / 2, 10));
                startX += (segment.GetLength() / 2) + 5;
            }

            foreach (Train train in central.GetTrains())
            {
                int position = 0;

                if (train.GetDirection().Equals("East"))
                {
                    for (int i = 1; i < train.GetSegment() + 1; i++)
                    {
                        if (train.GetSegment() > i)
                        {
                            position += (central.GetTrackSegment(i).GetLength() / 2);
                        }
                        else if (train.GetSegment() == i)
                        {
                            position += ((int)(train.GetPosition() / 2));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < train.GetSegment() + 1; i++)
                    {
                        if (train.GetSegment() > i)
                        {
                            position += central.GetTrackSegment(i).GetLength() / 2;
                        }
                        else if (train.GetSegment() == i)
                        {
                            position += (central.GetTrackSegment(i).GetLength() / 2) - ((int)(train.GetPosition() / 2));
                        }
                    }
                }

                e.Graphics.DrawEllipse(trainPen, new Rectangle(0 + position, 197, 16, 16));
            }
        }

        private void CTC_FormClosed(object sender, FormClosedEventArgs e)
        {
            //testingForm.Dispose();
            formParent.Dispose();
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
            central.SetSegmentFailure(number, text);
            listViewTrack.Items[number - 1].SubItems[4].Text = text;
        }

        private void ButtonDispatch_Click(object sender, EventArgs e)
        {
            TrainDispatch trainDispatch = new TrainDispatch(this);
            trainDispatch.Show();
        }

        private void UpdateSystem()
        {
            ArrayList trainList = central.GetTrains();
            ArrayList segmentList; // = central.GetTrackSegments();
            int authority = 0, number = 0;
            double speed = 0;

            foreach (Train train in trainList)
            {
                if (train.GetActiveRoute() == 0)
                {

                    /*number = train.GetNumber();
                    segmentList = train.GetRouteSegments().GetRoute(1);

                    //testingForm.updateTrainSegment(number, 1);      //should be set to first track outside yard * gets handled by the track controller

                    foreach (TrackSegment segment in segmentList)   //this should be changed to the trains schedule
                    {
                        authority += segment.GetLength();
                    }
                    trackController.UpdateTrainAuthority(number, authority);
                    train.SetAuthority(authority);

                    speed = (authority / (train.GetSchedule()[train.GetNextStation()] - 1.2) / 60);    //"station 2" text should be changed to train.GetNextStation()

                    if (speed > (double)central.GetTrackSegment(1).GetSpeedLimit() / 3.6)  //1 should be changed to first segment outside yard
                    {
                        trackController.updateTrainSpeed(number, (double)central.GetTrackSegment(1).GetSpeedLimit()); //here agagin
                    }
                    else
                    {
                        testingForm.updateTrainSpeed(number, speed);
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        listViewTrains.Items[train.GetListNumber()].SubItems[4].Text = authority.ToString();
                        listViewTrains.Items[train.GetListNumber()].SubItems[3].Text = "East";          //assuming initial direction is east
                    }));
                    train.SetDirection("East");*/
                }
                else
                {
                    int closedSegment = 0, errorOnClosed = 0;
                    double newAuthority = 0;

                    /*if (train.GetAuthority() <= 0 && train.GetRouteSegments().GetEnd() == train.GetSegment() && train.GetTimeOnSchedule() >= train.GetSchedule()[train.GetRouteSegments().GetStationEnd()] * 60)
                    {
                        //Check to reverse route
                        Dictionary<string, double> schedule = new Dictionary<string, double>();
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
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            listViewTrains.Items[train.GetListNumber()].SubItems[3].Text = direction;
                        }));
                        train.SetSchedule(schedule);
                        train.SetRoute(central.GetRoute(routingList));
                        train.SetTimeOnSchedule(0);
                        train.SetPosition(0);
                    }*/

                    double leastAuthority = 100000000000;
                    
                    foreach (TrackSegment s in train.GetRouteSegments().GetRoute(train.GetActiveRoute()))
                    {
                        if (s.GetOpenClosed().Equals("Closed") ||s.GetFailure().Equals("Failure"))
                        {
                            closedSegment = 1;
                            if (s.Equals(central.GetTrackSegment(train.GetSegment())))
                            {
                                leastAuthority = 0;
                                errorOnClosed = 1;
                            }
                            else
                            {
                                if (errorOnClosed == 0)
                                {
                                    newAuthority = central.GetTrackSegment(train.GetSegment()).GetLength() - train.GetPosition();
                                    if (train.GetDirection().Equals("East"))
                                    {
                                        if (train.GetSegment() + 1 != train.GetRouteSegments().GetEnd() + 1)
                                        {
                                            for (int i = 1; !s.Equals(central.GetTrackSegment(train.GetSegment() + i)) && (train.GetSegment() + i) < train.GetRouteSegments().GetEnd() + 1; i++)
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
                                            for (int i = 1; !s.Equals(central.GetTrackSegment(train.GetSegment() - i)); i++)
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
                            if (train.GetDirection().Equals("East"))
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
                    }

                    //trackController.SuggestTrainAuthority(train.GetNumber(), leastAuthority);
                    SetTrainAuthority(train.GetNumber(), leastAuthority);

                    if (train.GetPosition() >= central.GetTrackSegment(train.GetSegment()).GetLength())
                    {
                        if (train.GetSegment() != train.GetRouteSegments().GetEnd())
                        {
                            int segmentNumber = 0;

                            train.SetPosition(train.GetPosition() - central.GetTrackSegment(train.GetSegment()).GetLength());

                            if (train.GetDirection().Equals("East"))
                            {
                                segmentNumber = train.GetSegment() + 1;
                            }
                            else
                            {
                                segmentNumber = train.GetSegment() - 1;
                            }

                            //testingForm.updateTrainSegment(train.GetNumber(), segmentNumber);
                        }
                    }

                    speed = (train.GetAuthority() / (train.GetSchedule()[train.GetRouteSegments().GetEnd()] - 1.2 - (train.GetTimeOnSchedule() / 60)) / 60);

                    speed *= 3.6;

                    if (speed > central.GetTrackSegment(train.GetSegment()).GetSpeedLimit() || speed < 0)
                    {
                        //trackController.SuggestTrainSpeed(train.GetNumber(), central.GetTrackSegment(train.GetSegment()).GetSpeedLimit());
                        SetTrainSpeed(train.GetNumber(), central.GetTrackSegment(train.GetSegment()).GetSpeedLimit());
                    }
                    else
                    {
                        if (train.GetAuthority() <= 0)
                        {
                            //trackController.SuggestTrainSpeed(train.GetNumber(), 0);
                            SetTrainSpeed(train.GetNumber(), 0);
                        }
                        else
                        {
                            //trackController.SuggestTrainSpeed(train.GetNumber(), speed);
                            SetTrainSpeed(train.GetNumber(), speed);
                        }
                    }

                    if (train.GetDestination() == 0)
                    {
                        SetTrainSpeed(train.GetNumber(), 0);
                        SetTrainAuthority(train.GetNumber(), 0);
                        //trackController.SuggestTrainSpeed(train.GetNumber(), 0);
                        //trackController.SuggestTrainAuthority(train.GetNumber(), 0);

                        train.SetActiveRoute(0);
                    }

                    if (IsHandleCreated && !IsDisposed)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            int temporaryNumber = train.GetNumber(), listNumber = train.GetListNumber();
                            //trackController.SuggestTrainAuthority(train.GetNumber(), train.GetAuthority());
                            systemListView.Items[listNumber].SubItems[1].Text = (60 / central.GetTrain(temporaryNumber).GetSchedule()[central.GetTrain(temporaryNumber).GetRouteSegments().GetEnd()]).ToString();
                            listViewTrains.Items[listNumber].SubItems[4].Text = train.GetAuthority().ToString();
                            listViewTrains.Items[listNumber].SubItems[1].Text = train.GetSegment().ToString();
                            listViewTrains.Items[listNumber].SubItems[2].Text = train.GetSpeed().ToString();
                            systemGraphics.Refresh();
                        }));
                    }
                }
            }
        }
    }
}
