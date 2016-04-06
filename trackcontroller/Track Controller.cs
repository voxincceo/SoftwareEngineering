using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrackController
{
    public partial class    TrackControllerForm : Form
    {
        internal static Label switchNumberLabel;
        TrainLine[] trainLines = new TrainLine[2];
        System.Timers.Timer globalTimer;
        //TrackModel trackModel = new TrackModel();
        //CTCOffice ctcOffice = new CTCOffice();


        public TrackControllerForm(System.Timers.Timer inTimer)
        {
            InitializeComponent();
            globalTimer = inTimer;
            //globalTimer
        }
        
        public void SetSystemSpeed()
        {
            //timer2 = inTimer;
        }

        public void show()
        {
            //pop up the module
        }

        public void SendModules(int inCTC, int inTrackModel)
        {
            //trackModel = inTrackModel;
            //ctcOffice = inCTC;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get info from track model


            TrainLine redLine = new TrainLine("Red", 6, 7, 2, 50, this);
            TrainLine greenLine = new TrainLine("Green", 8, 12, 3, 46, this);
            trainLines[0] = redLine;
            trainLines[1] = greenLine;
            timer2.Interval = 2000;
            timer2.Start();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void trainLineSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///comboBox1.SelectedIndex
            trainLines[trainLineSelect.SelectedIndex].populateForm();

        }
        // timer for testing
       

        public void switchBlockPanelMove(int inY)
        {
            SwitchBlockPanel.Location = new System.Drawing.Point(10, inY);
        }

        public void brokenRailPanelMove(int inY)
        {
            BrokenRailPanel.Location = new System.Drawing.Point(10, inY);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("timer");
            this.trainLines[0].updateForm(null, "speed");
            this.trainLines[1].updateForm(null, "authority");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String filePath = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                sr.Close();
            }


            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {

                }
            }
            catch
            {

            }
          

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
