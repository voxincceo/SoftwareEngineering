using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrackController;

public class TrainLine
{
    List<Train> Trains = new List<Train>();
    private Switch[] switchStates;
    private Crossing[] crossingStates;
    private int numTrains;
    private String lineName;
    private Rail[] railStates;
    private TrackControllerForm tempForm;
    private Panel[] trainInfoPanels;

    /// constructor
	public TrainLine(String inLineName, int numTrains, int numSwitches, int numCrossings, int numRails, TrackControllerForm inTempForm)
    {

        this.lineName = inLineName;
        this.switchStates = new Switch[numSwitches];
        this.crossingStates = new Crossing[numCrossings];
        this.railStates = new Rail[numRails];
        this.tempForm = inTempForm;

        //initialize dummy test data
        for (int i = 0; i < numTrains; i++)
        {
           this.Trains.Add(new Train(i+1, "A", 23.4, 13.9));
        }
        for (int i = 0; i < switchStates.Length; i++)
        {
            switchStates[i] = new Switch(i+1, false);
        }
        for (int i = 0; i < crossingStates.Length; i++)
        {
            crossingStates[i] = new Crossing("H", false);
        }
        for (int i = 0; i < railStates.Length; i++)
        {
            if(i % 10 == 0)
            {
                railStates[i] = new Rail(i, true, true);
            }
            else
            {
                railStates[i] = new Rail(i, false, true);
            }
            
        }
       
    }

    /// private methods
    private void updateNumberOfTrains(int inNum)
    {
        this.numTrains = inNum;
    }
    private void addTrain(Train inTrain)
    {
        this.Trains.Add(inTrain);
    }

    //event handlers for radio buttons
    private void Switch_Radio_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton r = (RadioButton)sender;
        if (r.Checked == true)
        {
            //do something
            //change switch state
            Console.WriteLine("switch checked");
            this.updateForm(sender, "switch");
        }
        
    }

    private void Crossing_Radio_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton r = (RadioButton)sender;
        if (r.Checked == true)
        {
            //do something
            Console.WriteLine("radio changed");
            this.updateForm(sender, "crossing");
        }

    }

    //public methods
    public void populateForm()
    {
        trainInfoPanels = new Panel[Trains.Count];

        //Form tempForm = TrackController.TrackControllerForm.ActiveForm;
        Console.WriteLine(this.lineName);
        int downPos = 65;

        //populare the list of train information
        for(int i = 0; i < Trains.Count; i++)
        {
            Panel tempTrainInfoPanel = new Panel();
            tempTrainInfoPanel.Height = 15;
            tempTrainInfoPanel.Width = 500;

            Label tempTrainNumberLabel = new Label();
            tempTrainNumberLabel.Height = 15;
            tempTrainNumberLabel.Width = 30;
            tempTrainNumberLabel.Text = Trains[i].getTrainNumber().ToString() + '.';

            Label tempBlockLabel = new Label();
            tempBlockLabel.Height = 15;
            tempBlockLabel.Width = 100;
            tempBlockLabel.Text = "Current Block:  " + Trains[i].getBlockPosition();
            tempBlockLabel.Location = new System.Drawing.Point(70, 0);

            Label tempAuthorityLabel = new Label();
            tempAuthorityLabel.Height = 15;
            tempAuthorityLabel.Width = 100;
            tempAuthorityLabel.Text = "Authority:  " + Trains[i].getAuthority().ToString() + " feet";
            tempAuthorityLabel.Location = new System.Drawing.Point(170, 0);

            Label tempSpeedLabel = new Label();
            tempSpeedLabel.Height = 15;
            tempSpeedLabel.Width = 100;
            tempSpeedLabel.Text = "Speed:  " + Trains[i].getSpeed().ToString() + " m/h";
            tempSpeedLabel.Location = new System.Drawing.Point(270, 0);

            tempTrainInfoPanel.Location = new System.Drawing.Point(15, downPos);
            tempTrainInfoPanel.Controls.Add(tempTrainNumberLabel);
            tempTrainInfoPanel.Controls.Add(tempBlockLabel);
            tempTrainInfoPanel.Controls.Add(tempAuthorityLabel);
            tempTrainInfoPanel.Controls.Add(tempSpeedLabel);

            

            tempForm.Controls.Add(tempTrainInfoPanel);
            downPos = downPos + 15;
        }


        downPos = downPos + 15;
        tempForm.switchBlockPanelMove(downPos);
        downPos = downPos + 40;
        int newDownPos = 0;


        //populate switch state controls
        for (int i = 0; i < switchStates.Length; i++)
        {
            if (tempForm.Controls.Find("switch" + i, true).Length > 0) ;
            {
                Control[] tempControls = tempForm.Controls.Find("switch" + i, true);
                for (int j = 0; j < tempControls.Length; j++)
                {
                    tempForm.Controls.Remove(tempControls[j]);
                    tempControls[j].Dispose();
                }
            }

            Panel tempSwitchPanel = new Panel();
            tempSwitchPanel.Height = 20;
            tempSwitchPanel.Width = 200;
            tempSwitchPanel.Name = "switch"+i.ToString();

            Label tempSwitchNumberLabel = new Label();
            tempSwitchNumberLabel.Height = 20;
            tempSwitchNumberLabel.Width = 20;
            tempSwitchNumberLabel.Text = switchStates[i].getSwitchNum().ToString() + ". ";
            tempSwitchNumberLabel.Location = new System.Drawing.Point(70, 0);

            Label tempRadioLabel1 = new Label();
            tempRadioLabel1.Height = 20;
            tempRadioLabel1.Width = 25;
            tempRadioLabel1.Text = "On:";
            tempRadioLabel1.Location = new System.Drawing.Point(90, 0);

            RadioButton tempRadio1 = new RadioButton();
            tempRadio1.Text = "On: ";
            tempRadio1.Width = 20;
            tempRadio1.Height = 20;
            tempRadio1.Name = i.ToString();
            tempRadio1.CheckedChanged += new System.EventHandler(this.Switch_Radio_CheckedChanged);
            tempRadio1.Location = new System.Drawing.Point(115,0);

            Label tempRadioLabel2 = new Label();
            tempRadioLabel2.Height = 20;
            tempRadioLabel2.Width = 25;
            tempRadioLabel2.Text = "Off:";
            tempRadioLabel2.Location = new System.Drawing.Point(140, 0);

            RadioButton tempRadio2 = new RadioButton();
            tempRadio2.Text = "Off: ";
            tempRadio2.Width = 20;
            tempRadio2.Height = 20;
            tempRadio2.Name = i.ToString();
            tempRadio2.CheckedChanged += new System.EventHandler(this.Switch_Radio_CheckedChanged);
            tempRadio2.Location = new System.Drawing.Point(165, 0);

            if (switchStates[i].getState() == true)
            {
                tempRadio1.Checked = true;
            }
            else
            {
                tempRadio2.Checked = true;
            }

            tempSwitchPanel.Location = new System.Drawing.Point(15, downPos + newDownPos);
            tempSwitchPanel.Controls.Add(tempSwitchNumberLabel);
            tempSwitchPanel.Controls.Add(tempRadioLabel1);
            tempSwitchPanel.Controls.Add(tempRadio1);
            tempSwitchPanel.Controls.Add(tempRadioLabel2);
            tempSwitchPanel.Controls.Add(tempRadio2);

            tempForm.Controls.Add(tempSwitchPanel);
            newDownPos = newDownPos + 20;
        }
        int newDownPos2 = 0;

        //populate crossing state controls
        for (int i = 0; i < crossingStates.Length; i++)
        {
            if (tempForm.Controls.Find("crossing" + i, true).Length > 0) ;
            {
                Control[] tempControls = tempForm.Controls.Find("crossing" + i, true);
                for (int j = 0; j < tempControls.Length; j++)
                {
                    tempForm.Controls.Remove(tempControls[j]);
                    tempControls[j].Dispose();
                }
            }

            Panel tempCrossingPanel = new Panel();
            tempCrossingPanel.Height = 20;
            tempCrossingPanel.Width = 250;
            tempCrossingPanel.Name = "crossing" + i.ToString();
           

            Label tempCrossingNumberLabel = new Label();
            tempCrossingNumberLabel.Height = 20;
            tempCrossingNumberLabel.Width = 20;
            tempCrossingNumberLabel.Text = crossingStates[i].getBlockNumber() + ". ";
            tempCrossingNumberLabel.Location = new System.Drawing.Point(70, 0);

            Label tempRadioLabel1b = new Label();
            tempRadioLabel1b.Height = 20;
            tempRadioLabel1b.Width = 25;
            tempRadioLabel1b.Text = "On:";
            tempRadioLabel1b.Location = new System.Drawing.Point(90, 0);

            RadioButton tempRadio1b = new RadioButton();
            tempRadio1b.Text = "On: ";
            tempRadio1b.Width = 20;
            tempRadio1b.Height = 20;
            tempRadio1b.Name = i.ToString();
            tempRadio1b.CheckedChanged += new System.EventHandler(this.Crossing_Radio_CheckedChanged);
            tempRadio1b.Location = new System.Drawing.Point(115, 0);

            Label tempRadioLabel2b = new Label();
            tempRadioLabel2b.Height = 20;
            tempRadioLabel2b.Width = 25;
            tempRadioLabel2b.Text = "Off:";
            tempRadioLabel2b.Location = new System.Drawing.Point(140, 0);

            RadioButton tempRadio2b = new RadioButton();
            tempRadio2b.Text = "Off: ";
            tempRadio2b.Width = 20;
            tempRadio2b.Height = 20;
            tempRadio2b.Name = i.ToString();
            tempRadio2b.CheckedChanged += new System.EventHandler(this.Crossing_Radio_CheckedChanged);
            tempRadio2b.Location = new System.Drawing.Point(165, 0);

            if (crossingStates[i].getState() == true)
            {
                tempRadio1b.Checked = true;
            }
            else
            {
                tempRadio2b.Checked = true;
            }

            tempCrossingPanel.Location = new System.Drawing.Point(190, downPos + newDownPos2);
            tempCrossingPanel.Controls.Add(tempCrossingNumberLabel);
            tempCrossingPanel.Controls.Add(tempRadioLabel1b);
            tempCrossingPanel.Controls.Add(tempRadio1b);
            tempCrossingPanel.Controls.Add(tempRadioLabel2b);
            tempCrossingPanel.Controls.Add(tempRadio2b);

            tempForm.Controls.Add(tempCrossingPanel);
            newDownPos2 = newDownPos2 + 20;
        }
        downPos = downPos + newDownPos;
        tempForm.brokenRailPanelMove(downPos);

        //populate list of broken rails
        downPos = downPos + 55;
        for (int i = 0; i < railStates.Length; i++)
        {
            
            if (railStates[i].getBroken() == true)
            {
                
                Panel tempBrokenRailPanel = new Panel();
                tempBrokenRailPanel.Height = 20;
                tempBrokenRailPanel.Width = 200;

                Label tempBrokenRailLabel = new Label();
                tempBrokenRailLabel.Text = railStates[i].getBlockNumber().ToString();
                tempBrokenRailLabel.Height = 20;
                tempBrokenRailLabel.Width = 20;

                Label tempBrokenRainLabel2 = new Label();
                tempBrokenRainLabel2.Text = "Broken";
                tempBrokenRainLabel2.Height = 20;
                tempBrokenRainLabel2.Width = 100;
                tempBrokenRainLabel2.Location = new System.Drawing.Point(40, 0);

                tempBrokenRailPanel.Location = new System.Drawing.Point(15, downPos);
                tempBrokenRailPanel.Controls.Add(tempBrokenRailLabel);
                tempBrokenRailPanel.Controls.Add(tempBrokenRainLabel2);

                tempForm.Controls.Add(tempBrokenRailPanel);
                downPos = downPos + 20;
            }
            
        }
    }

    public void updateForm(object inobj, String whatChanged)
    {
        Random rnd = new Random();

        if (whatChanged== "switch")
        {
            var r = (RadioButton)inobj;

            int tempdex = Int32.Parse(r.Name);

            this.switchStates[tempdex].setState(false);


            Console.WriteLine("update form called and its swtich");
        }
        if (whatChanged == "crossing")
        {
            var r = (RadioButton)inobj;

            Console.WriteLine("update form called and its crossing");



            int tempdex = Int32.Parse(r.Name);

            this.crossingStates[tempdex].setState(false);
        }
        if (whatChanged == "speed")
        {
            Console.WriteLine("speed changed");
            Train[] tempTrains = this.Trains.ToArray();

            for(int i = 0; i < tempTrains.Length; i++)
            {
                tempTrains[i].setSpeed((double)rnd.Next(1,40)*1.1);
            }
        }
        if (whatChanged == "authority")
        {
            
            Train[] tempTrains = this.Trains.ToArray();

            for (int i = 0; i < tempTrains.Length; i++)
            {
                tempTrains[i].setSpeed((double)rnd.Next(1, 40) * 1.1);
            }
            Console.WriteLine("authority changed");
        }

    }
}
