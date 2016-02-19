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
    public partial class TestingForm : Form
    {
        ArrayList trains, segments;
        CTC CTCOffice;

        public TestingForm(CTC update)
        {
            InitializeComponent();

            CTCOffice = update;

            initializeInputList();
            initializeOutputList();
            initializeTrainsAndTrack();

            breakSegmentButton.Enabled = false;

            CTCOffice.DevelopTestSchedule();
        }

        private void initializeTrainsAndTrack()
        {
            buttonCircuit.Enabled = false;
            buttonPower.Enabled = false;

            comboBoxSegments.Items.Add("Track 1");
            comboBoxSegments.Items.Add("Track 2");
            comboBoxSegments.Items.Add("Track 3");
            comboBoxSegments.Items.Add("Track 4");
            comboBoxSegments.Items.Add("Track 5");

            trains = new ArrayList();
            segments = new ArrayList();

            trains.Add(1);

            segments.Add(1);
            segments.Add(2);
            segments.Add(3);
            segments.Add(4);
            segments.Add(5);

            CTCOffice.InitializeSystemTrains(trains);
            CTCOffice.InitializeSystemTrackSegments(segments);
        }

        private void initializeInputList()
        {
            listViewInputs.View = View.Details;

            listViewInputs.Columns.Add("Input Signal", 200);
            listViewInputs.Columns.Add("Current Value", 150);

            ListViewItem trainOneSpeedLVI = new ListViewItem();
            trainOneSpeedLVI.Text = "Train 1 Speed:";
            trainOneSpeedLVI.SubItems.Add("0");

            ListViewItem trainOneSegmentLVI = new ListViewItem();
            trainOneSegmentLVI.Text = "Train 1 Segment:";
            trainOneSegmentLVI.SubItems.Add("0");

            ListViewItem trackHeaterStatusLVI = new ListViewItem();
            trackHeaterStatusLVI.Text = "Track Heater:";
            trackHeaterStatusLVI.SubItems.Add("Off");

            ListViewItem trackSegmentOneLineLVI = new ListViewItem();
            trackSegmentOneLineLVI.Text = "Track Segment 1 Line:";
            trackSegmentOneLineLVI.SubItems.Add("Black");

            ListViewItem trackSegmentOneOpenLVI = new ListViewItem();
            trackSegmentOneOpenLVI.Text = "Track Segment 1 Open:";
            trackSegmentOneOpenLVI.SubItems.Add("Open");

            ListViewItem trackSegmentOneFailureLVI = new ListViewItem();
            trackSegmentOneFailureLVI.Text = "Track Segment 1 Failure:";
            trackSegmentOneFailureLVI.SubItems.Add("None");

            ListViewItem trackSegmentOneSwitchLVI = new ListViewItem();
            trackSegmentOneSwitchLVI.Text = "Track Segment 1 Switch Direction:";
            trackSegmentOneSwitchLVI.SubItems.Add("N/A");

            ListViewItem trackSegmentTwoLineLVI = new ListViewItem();
            trackSegmentTwoLineLVI.Text = "Track Segment 2 Line:";
            trackSegmentTwoLineLVI.SubItems.Add("Black");

            ListViewItem trackSegmentTwoOpenLVI = new ListViewItem();
            trackSegmentTwoOpenLVI.Text = "Track Segment 2 Open:";
            trackSegmentTwoOpenLVI.SubItems.Add("Open");

            ListViewItem trackSegmentTwoFailureLVI = new ListViewItem();
            trackSegmentTwoFailureLVI.Text = "Track Segment 2 Failure:";
            trackSegmentTwoFailureLVI.SubItems.Add("None");

            ListViewItem trackSegmentTwoSwitchLVI = new ListViewItem();
            trackSegmentTwoSwitchLVI.Text = "Track Segment 2 Switch Direction:";
            trackSegmentTwoSwitchLVI.SubItems.Add("N/A");

            ListViewItem trackSegmentThreeLineLVI = new ListViewItem();
            trackSegmentThreeLineLVI.Text = "Track Segment 3 Line:";
            trackSegmentThreeLineLVI.SubItems.Add("Black");

            ListViewItem trackSegmentThreeOpenLVI = new ListViewItem();
            trackSegmentThreeOpenLVI.Text = "Track Segment 3 Open:";
            trackSegmentThreeOpenLVI.SubItems.Add("Open");

            ListViewItem trackSegmentThreeFailureLVI = new ListViewItem();
            trackSegmentThreeFailureLVI.Text = "Track Segment 3 Failure:";
            trackSegmentThreeFailureLVI.SubItems.Add("None");

            ListViewItem trackSegmentThreeSwitchLVI = new ListViewItem();
            trackSegmentThreeSwitchLVI.Text = "Track Segment 3 Switch Direction:";
            trackSegmentThreeSwitchLVI.SubItems.Add("N/A");

            ListViewItem trackSegmentFourLineLVI = new ListViewItem();
            trackSegmentFourLineLVI.Text = "Track Segment 4 Line:";
            trackSegmentFourLineLVI.SubItems.Add("Black");

            ListViewItem trackSegmentFourOpenLVI = new ListViewItem();
            trackSegmentFourOpenLVI.Text = "Track Segment 4 Open:";
            trackSegmentFourOpenLVI.SubItems.Add("Open");

            ListViewItem trackSegmentFourFailureLVI = new ListViewItem();
            trackSegmentFourFailureLVI.Text = "Track Segment 4 Failure:";
            trackSegmentFourFailureLVI.SubItems.Add("None");

            ListViewItem trackSegmentFourSwitchLVI = new ListViewItem();
            trackSegmentFourSwitchLVI.Text = "Track Segment 4 Switch Direction:";
            trackSegmentFourSwitchLVI.SubItems.Add("N/A");

            ListViewItem trackSegmentFiveLineLVI = new ListViewItem();
            trackSegmentFiveLineLVI.Text = "Track Segment 5 Line:";
            trackSegmentFiveLineLVI.SubItems.Add("Black");

            ListViewItem trackSegmentFiveOpenLVI = new ListViewItem();
            trackSegmentFiveOpenLVI.Text = "Track Segment 5 Open:";
            trackSegmentFiveOpenLVI.SubItems.Add("Open");

            ListViewItem trackSegmentFiveFailureLVI = new ListViewItem();
            trackSegmentFiveFailureLVI.Text = "Track Segment 5 Failure:";
            trackSegmentFiveFailureLVI.SubItems.Add("None");

            ListViewItem trackSegmentFiveSwitchLVI = new ListViewItem();
            trackSegmentFiveSwitchLVI.Text = "Track Segment 5 Switch Direction:";
            trackSegmentFiveSwitchLVI.SubItems.Add("N/A");

            ListViewItem powerFailureLVI = new ListViewItem();
            powerFailureLVI.Text = "Power Failure";
            powerFailureLVI.SubItems.Add("None");

            ListViewItem trackCircuitFailureLVI = new ListViewItem();
            trackCircuitFailureLVI.Text = "Track Circuit Failures";
            trackCircuitFailureLVI.SubItems.Add("None");


            listViewInputs.Items.Add(trainOneSpeedLVI);
            listViewInputs.Items.Add(trainOneSegmentLVI);

            listViewInputs.Items.Add(trackHeaterStatusLVI);

            listViewInputs.Items.Add(trackSegmentOneLineLVI);
            listViewInputs.Items.Add(trackSegmentOneOpenLVI);
            listViewInputs.Items.Add(trackSegmentOneFailureLVI);
            listViewInputs.Items.Add(trackSegmentOneSwitchLVI);

            listViewInputs.Items.Add(trackSegmentTwoLineLVI);
            listViewInputs.Items.Add(trackSegmentTwoOpenLVI);
            listViewInputs.Items.Add(trackSegmentTwoFailureLVI);
            listViewInputs.Items.Add(trackSegmentTwoSwitchLVI);

            listViewInputs.Items.Add(trackSegmentThreeLineLVI);
            listViewInputs.Items.Add(trackSegmentThreeOpenLVI);
            listViewInputs.Items.Add(trackSegmentThreeFailureLVI);
            listViewInputs.Items.Add(trackSegmentThreeSwitchLVI);

            listViewInputs.Items.Add(trackSegmentFourLineLVI);
            listViewInputs.Items.Add(trackSegmentFourOpenLVI);
            listViewInputs.Items.Add(trackSegmentFourFailureLVI);
            listViewInputs.Items.Add(trackSegmentFourSwitchLVI);

            listViewInputs.Items.Add(trackSegmentFiveLineLVI);
            listViewInputs.Items.Add(trackSegmentFiveOpenLVI);
            listViewInputs.Items.Add(trackSegmentFiveFailureLVI);
            listViewInputs.Items.Add(trackSegmentFiveSwitchLVI);

            listViewInputs.Items.Add(powerFailureLVI);
            listViewInputs.Items.Add(trackCircuitFailureLVI);
        }

        private void initializeOutputList()
        {
            listViewOutputs.View = View.Details;

            listViewOutputs.Columns.Add("Output Signal", 220);
            listViewOutputs.Columns.Add("Current Value", 150);

            ListViewItem trainOneSpeedLVI = new ListViewItem();
            trainOneSpeedLVI.Text = "Train 1 Suggested Speed:";
            trainOneSpeedLVI.SubItems.Add("N/A");

            ListViewItem trainOneAuthorityLVI = new ListViewItem();
            trainOneAuthorityLVI.Text = "Train 1 Suggested Authority:";
            trainOneAuthorityLVI.SubItems.Add("N/A");

            ListViewItem segmentOneOpenCloseLVI = new ListViewItem();
            segmentOneOpenCloseLVI.Text = "Track Segment 1 Open/Close Signal:";
            segmentOneOpenCloseLVI.SubItems.Add("N/A");

            ListViewItem segmentTwoOpenCloseLVI = new ListViewItem();
            segmentTwoOpenCloseLVI.Text = "Track Segment 2 Open/Close Signal:";
            segmentTwoOpenCloseLVI.SubItems.Add("N/A");

            ListViewItem segmentThreeOpenCloseLVI = new ListViewItem();
            segmentThreeOpenCloseLVI.Text = "Track Segment 3 Open/Close Signal:";
            segmentThreeOpenCloseLVI.SubItems.Add("N/A");

            ListViewItem segmentFourOpenCloseLVI = new ListViewItem();
            segmentFourOpenCloseLVI.Text = "Track Segment 4 Open/Close Signal:";
            segmentFourOpenCloseLVI.SubItems.Add("N/A");

            ListViewItem segmentFiveOpenCloseLVI = new ListViewItem();
            segmentFiveOpenCloseLVI.Text = "Track Segment 5 Open/Close Signal:";
            segmentFiveOpenCloseLVI.SubItems.Add("N/A");

            listViewOutputs.Items.Add(trainOneSpeedLVI);
            listViewOutputs.Items.Add(trainOneAuthorityLVI);
            listViewOutputs.Items.Add(segmentOneOpenCloseLVI);
            listViewOutputs.Items.Add(segmentTwoOpenCloseLVI);
            listViewOutputs.Items.Add(segmentThreeOpenCloseLVI);
            listViewOutputs.Items.Add(segmentFourOpenCloseLVI);
            listViewOutputs.Items.Add(segmentFiveOpenCloseLVI);

        }

        public void updateSegment(int number, string text)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewOutputs.Items[number + 1].SubItems[1].Text = text;
            }));
            UpdateSegmentInput(number, text);
        }

        private void UpdateSegmentInput(int number, string text)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewInputs.Items[4 * number].SubItems[1].Text = text;
            }));
            CTCOffice.OpenCloseSegment(number, text);
        }

        public void updateTrainSegment(int number, int segment)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                listViewInputs.Items[1].SubItems[1].Text = segment.ToString();
            }));
            CTCOffice.SetTrainSegment(number, segment);
        }

        public void updateTrainSpeed(int number, double speed)
        {
            if (IsHandleCreated && !IsDisposed)
            {
                listViewOutputs.Invoke(new Action(() =>
                {
                    listViewOutputs.Items[0].SubItems[1].Text = speed.ToString();
                }));
                updateTrainSpeedInput(number, speed);
            }
        }

        private void updateTrainSpeedInput(int number, double speed)
        {
            if (IsHandleCreated && !IsDisposed)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    listViewInputs.Items[0].SubItems[1].Text = speed.ToString();
                }));
                CTCOffice.SetTrainSpeed(number, speed);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonPower.Enabled = true;
            buttonCircuit.Enabled = true;
            CTCOffice.StartSystemTest();
        }

        public void UpdateTrainAuthority(int number, double authority)
        {
            if (IsHandleCreated && !IsDisposed)
            {
                listViewOutputs.Invoke(new Action(() =>
                {
                    listViewOutputs.Items[1].SubItems[1].Text = authority.ToString();
                }));
            }
        }

        private void TestingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CTCOffice.Close();
        }

        private void breakSegmentButton_Click(object sender, EventArgs e)
        {
            string trackSegment = comboBoxSegments.SelectedItem.ToString();
            string status;

            status = listViewInputs.Items[(4 * (int)Char.GetNumericValue(trackSegment[6])) + 1].SubItems[1].Text;

            if(status.Equals("None"))
            {
                status = "Failure";
            }
            else
            {
                status = "None";
            }

            listViewInputs.Items[(4 * (int)Char.GetNumericValue(trackSegment[6])) + 1].SubItems[1].Text = status;
            CTCOffice.SetTrackSegmentFailure((int)Char.GetNumericValue(trackSegment[6]), status);
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            string currentText = listViewInputs.Items[23].SubItems[1].Text;
            string newText;

            if (currentText.Equals("None"))
            {
                newText = "Failure";
            }
            else
            {
                newText = "None";
            }

            listViewInputs.Items[23].SubItems[1].Text = newText;
            CTCOffice.SetPowerFailure(newText);
        }

        private void buttonCircuit_Click(object sender, EventArgs e)
        {
            string currentText = listViewInputs.Items[24].SubItems[1].Text;
            string newText;

            if (currentText.Equals("None"))
            {
                newText = "Failure";
            }
            else
            {
                newText = "None";
            }

            listViewInputs.Items[24].SubItems[1].Text = newText;
            CTCOffice.SetTrackCiruitFailure(newText);
        }

        private void buttonHeater_Click(object sender, EventArgs e)
        {
            string currentText = listViewInputs.Items[2].SubItems[1].Text;
            string newText;

            if (currentText.Equals("Off"))
            {
                newText = "On";
            }
            else
            {
                newText = "Off";
            }

            listViewInputs.Items[2].SubItems[1].Text = newText;
            CTCOffice.SetTrackHeater(newText);
        }

        private void comboBoxSegments_SelectedIndexChanged(object sender, EventArgs e)
        {
            breakSegmentButton.Enabled = true;
        }
    }
}
