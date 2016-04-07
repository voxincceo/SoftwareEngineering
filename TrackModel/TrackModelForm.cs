using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using TheTrainModule;
using TrackController;

namespace TrackModelPrototype
{
    public partial class TrackModelForm : Form
    {
        Track track;
        TrackControllerForm trackController;
        TrainModelForm trainModel;
        public TrackModelForm()
        {
            InitializeComponent();
            track = new Track();
        }
        
        public void SendModules(TrackControllerForm trackControllerForm, TrainModelForm trainModelForm)
        {
            trackController = trackControllerForm;
            trainModel = trainModelForm;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void blockNumbersR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            string sourceFile = openFileDialog1.FileName;
            //track.LoadTrack(sourceFile);

            //DataTable dT = ImportDataFromExcel(sourceFile);
            //InsertDataIntoSQLServer(dT);

            redLineBlocks.Items.Clear();
            greenLineBlocks.Items.Clear();

            foreach (Block red in track.redBlocks)
            {
                redLineBlocks.Items.Add("Section: " + red.GetSectionName() + " Block: " + red.GetBlockNumber());
            }
            foreach (Block green in track.greenBlocks)
            {
                greenLineBlocks.Items.Add("Section: " + green.GetSectionName() + " Block: " + green.GetBlockNumber());
            }

        }

        private void update_sim_Click(object sender, EventArgs e)
        {
            string a = "OFF", b = "OFF", c = "OFF";
            if (brokenRail.Checked == true)
            {
                a = "ON";
            }
            if (trackCircuit.Checked == true)
            {
                b = "ON";
            }
            if (powerFailure.Checked == true)
            {
                c = "ON";
            }

            string errorSims = "Broken Rail: " + a + ", Track Circuit Failure: " + b + ", Power Failure: " + c;

            //TestForm testForm = new TestForm();
            //testForm.Show();
            //testForm.label34.Text = errorSims;
            //testForm.Refresh();

        }

        private void view_block_Click(object sender, EventArgs e)
        {
            int block;
            Block curBlock;
            if (lineControl.SelectedTab.Text.Equals("Green Line"))
            {
                if (greenLineBlocks.SelectedIndex != -1)
                {
                    //Get block number selected, find in arraylist
                    string[] g = greenLineBlocks.Text.Split(':');
                    block = Int32.Parse(g[2]);
                    curBlock = (Block)track.greenBlocks[block-1];
                    //Console.WriteLine(block);
                    lineLabel.Text = "Green Line";
                    sectionLabel.Text = "Section " + curBlock.GetSectionName();
                    blockLabel.Text = "Block " + curBlock.GetBlockNumber();
                    lengthLabel.Text = curBlock.GetBlockLength().ToString();
                    gradeLabel.Text = curBlock.GetGrade().ToString();
                    speedLabel.Text = curBlock.GetSpeedLimit().ToString();
                    infrastructureLabel.Text = curBlock.GetStation();
                    elevationLabel.Text = curBlock.GetElevation().ToString();
                    cumelevationLabel.Text = curBlock.GetCumulativeElevation().ToString();
                    switchBlock.Text = curBlock.GetSwitchBlock();
                    arrowdirLabel.Text = curBlock.GetArrow();
                }
            }
            else if (lineControl.SelectedTab.Text.Equals("Red Line"))
            {
                if (redLineBlocks.SelectedIndex != -1)
                {
                    //Get block number selected, find in arraylist
                    string[] r = redLineBlocks.Text.Split(':');
                    block = Int32.Parse(r[2]);
                    curBlock = (Block)track.redBlocks[block-1];
                    //Console.WriteLine(block);
                    lineLabel.Text = "Red Line";
                    sectionLabel.Text = "Section " + curBlock.GetSectionName();
                    blockLabel.Text = "Block " + curBlock.GetBlockNumber();
                    lengthLabel.Text = curBlock.GetBlockLength().ToString();
                    gradeLabel.Text = curBlock.GetGrade().ToString();
                    speedLabel.Text = curBlock.GetSpeedLimit().ToString();
                    infrastructureLabel.Text = curBlock.GetStation();
                    elevationLabel.Text = curBlock.GetElevation().ToString();
                    cumelevationLabel.Text = curBlock.GetCumulativeElevation().ToString();
                    switchBlock.Text = curBlock.GetSwitchBlock();
                    arrowdirLabel.Text = curBlock.GetArrow();
                }
            }         
        }                           

        /*private void testWindow_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            testForm.Show();   
        }*/    

        private void updateTemperature_Click(object sender, EventArgs e)
        {
            tempLabel.Text = newTempLength.Text + "°F";
            int temp = Convert.ToInt32(newTempLength.Text);

            if (temp < 35)
            {
                heaterLabel.Text = "ON";
            }
            else if (temp > 39)
            {
                heaterLabel.Text = "OFF";
            }
        }

        private void greenLineBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CommandedSpeed(int trainId, double speed)
        {
            trainModel.SetCommandedSpeed(trainId, (int)speed);
        }

        public void CommandedAuthority(int trainId, double authority)
        {
            trainModel.SetAuthority(trainId, (int)authority);
        }
    }

}
