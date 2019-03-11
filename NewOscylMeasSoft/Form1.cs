using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
using System.Threading;
using Oscyloskop;
using NewOscylMeasSoft;
using CsvHelper;
using System.Dynamic;
using System.Reflection;

namespace NewOscylMeasSoft
{
    public partial class Form1 : Form
    {

        double numberofpoints;
        Oscyloskop.Form1 oscillo;
        List<List<double>> WaveformArray;
        bool TriggerEdge = true;
        int TriggerCH;
        short TriggerVoltage;
        ushort TriggerHis;
        Thread Measure;
        ThreadStart MEASURE;
        Measurements measurements;
        StreamWriter FilepathWriter;
        StreamReader FilePathReader;
        PointPairList PPLsignal;
        string loadpath;
        string savepath;
        static double[] x = new double[2] { 0, 0 };
        static double[] y = new double[2] { -50, 50 };
        ZedGraph.LineItem lineItem2 = new ZedGraph.LineItem("cursorY2", x, y, Color.BlueViolet, ZedGraph.SymbolType.None,2);
        ZedGraph.LineItem lineItem1 = new ZedGraph.LineItem("cursorY1", x, y, Color.BlueViolet, ZedGraph.SymbolType.None,2);
        public List<double> WaveformRead()
        {
            return measurements.LoadGatheredWaveforms(loadpath, linecount);
        }
        int linecount = 1;
        List<double> CurrentWave;
        public Form1()
        {
            PPLsignal = new PointPairList();
            InitializeComponent();
            oscillo = new Oscyloskop.Form1();
            ZedSignal.GraphPane.XAxis.Scale.Min = 0;
            double.TryParse(NumberOfPointsBox.Text, out numberofpoints);
            ZedSignal.GraphPane.XAxis.Scale.Max = numberofpoints;
            ZedSignal.GraphPane.YAxis.Scale.Min = -50;
            ZedSignal.GraphPane.YAxis.Scale.Max = 50;
            ZedSignal.GraphPane.XAxis.Scale.MajorStep = 200;
            ZedSignal.GraphPane.YAxis.Scale.MajorStep = 10;
            ZedSignal.GraphPane.XAxis.Scale.MinorStep = 100;
            ZedSignal.GraphPane.YAxis.Scale.MinorStep = 5;
            ZedSignal.GraphPane.XAxis.Title.Text = "Number of points";
            ZedSignal.GraphPane.YAxis.Title.Text = "Signal";
            DataSlider.BackColor = Color.LightGray;
            ZedSignal.GraphPane.CurveList.Add(lineItem1);
            ZedSignal.GraphPane.CurveList.Add(lineItem2);
            WaveformArray = new List<List<double>>();
            CurrentWave = new List<double>();
            lineItem1.Label.IsVisible = false;
            lineItem2.Label.IsVisible = false;
            ZedSignal.Invalidate();
        }

        public Thread StartTheThread(string FilePath, int NumberOfMeasures = 500, int NumberOfPointsPerWF = 2048, bool Trigger = false, int ChannelTrig = 0, int ChannelSig = 0)
        {
            Measure = new Thread(() => measurements.GatherWaveforms(FilePath));
            Measure.Start();
            return Measure;
        }

        private void TriggerChannelChecker()
        {
            if (CH1Trigg.Checked)
                TriggerCH = 0;
            if (CH2Trigg.Checked)
                TriggerCH = 1;
            if (CH3Trigg.Checked)
                TriggerCH = 2;
            if (CH4Trigg.Checked)
                TriggerCH = 3;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oscillo.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void NumberOfPointsBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ZedSignal_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void NumberOfPointsBox_TextChanged_1(object sender, EventArgs e)
        {
            ZedSignal.GraphPane.XAxis.Scale.Min = 0;
            double.TryParse(NumberOfPointsBox.Text, out numberofpoints);
            ZedSignal.GraphPane.XAxis.Scale.Max = numberofpoints;
            ZedSignal.GraphPane.YAxis.Scale.Min = -50;
            ZedSignal.GraphPane.YAxis.Scale.Max = 50;
            ZedSignal.GraphPane.XAxis.Scale.MajorStep = 200;
            ZedSignal.GraphPane.YAxis.Scale.MajorStep = 10;
            ZedSignal.GraphPane.XAxis.Scale.MinorStep = 100;
            ZedSignal.GraphPane.YAxis.Scale.MinorStep = 5;
            TrackMin.Maximum = (int)numberofpoints - 1;
            TrackMax.Maximum = (int)numberofpoints - 1;
            ZedSignal.Invalidate();
        }

        private void TrackMin_Scroll(object sender, EventArgs e)
        {
            lineItem1.Clear();
            lineItem1.AddPoint(TrackMin.Value, 100);
            lineItem1.AddPoint(TrackMin.Value, -100);
            lineItem1.Label.IsVisible = false;
            ZedSignal.Update();
            ZedSignal.Invalidate();
            Bar1Label.Text = TrackMin.Value.ToString();
            
        }

        private void TrackMax_Scroll(object sender, EventArgs e)
        {
            lineItem2.Clear();
            lineItem2.AddPoint(TrackMax.Value, 100);
            lineItem2.AddPoint(TrackMax.Value, -100);
            lineItem2.Label.IsVisible = false;
            ZedSignal.Update();
            ZedSignal.Invalidate();
            Bar2Label.Text = TrackMax.Value.ToString();
        }

        private void ZedTrigger_Load(object sender, EventArgs e)
        {
            
        }

        private void TrackMin_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TriggON_CheckedChanged(object sender, EventArgs e)
        {
            if (TriggOFF.Checked)
            {
                TriggOptions.Enabled = false;
                CH1Trigg.Checked = false;
            }
            else
            {
                TriggOptions.Enabled = true;
                CH1Trigg.Checked = true;
                EdgeOptions.SelectedIndex = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StopBtn.Enabled = true;
            PauseBtn.Enabled = true;
            StartBtn.Enabled = false;
            StartBtn.Text = "Start";
            PauseBtn.BackColor = Color.Yellow;
            StopBtn.BackColor = Color.Red;
            StartBtn.BackColor = Color.White;
            StartTheThread(savepath);
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = true;
            PauseBtn.Enabled = false;
            StopBtn.Enabled = false;
            StartBtn.Text = "Start";
            PauseBtn.BackColor = Color.White;
            StopBtn.BackColor = Color.White;
            StartBtn.BackColor = Color.Green;
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Text = "Continue";
            StopBtn.Enabled = true;
            StartBtn.Enabled = true;
            PauseBtn.Enabled = false;
            PauseBtn.BackColor = Color.White;
            StopBtn.BackColor = Color.Red;
            StartBtn.BackColor = Color.Green;
        }

        private void EachMeasureSave_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void EdgeOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EdgeOptions.SelectedIndex == 0)
                TriggerEdge = true;
            else
                TriggerEdge = false;
        }

        private void SetTriggerButton_Click(object sender, EventArgs e)
        {
        }

        private void LoadingData_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName != null)
            {
                FilePathReader = new StreamReader(OpenFileDialog.FileName);
                loadpath = OpenFileDialog.FileName;
                linecount = File.ReadLines(loadpath).Count();
                DataSlider.Maximum = linecount;
                DataSlider.Minimum = 1;
            }
            else
                MessageBox.Show("Something went wrong..");
        }

        private void ReadDataBtn_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DataSaverDialog.ShowDialog();
        }

        public class Foo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        void funkcjatestowa()
        {
            var records = new List<dynamic>();
            records = new List<dynamic> { 1, 2, 3, 4, 5, 6 };
            dynamic record = new ExpandoObject();
            record.Id = 1;
            record.Name = "one";
            records.Add(record);

            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(records);
            }
        }

        private void DataSaverDialog_FileOk(object sender, CancelEventArgs e)
        {
            /*var records = new List<Foo>
            {
               new Foo { Id = 1, Name = "one" },
            };*/
            savepath = DataSaverDialog.FileName;
            PathToFileLabel.Text = savepath;
            StreamWriter SW = new StreamWriter(savepath);
            CsvWriter csvr = new CsvWriter(SW);
            List<double> lista = new List<double> { 1, 2, 3, 4, 5, 6 };
            StringBuilder SB = new StringBuilder();
            int i = 0;
            for(i = 0; i<=200000; i++)
            {
                SB.Append(i + ":");
                if(i % 50000 == 0 && i != 0)
                {
                    SB.Append(Environment.NewLine);
                    SW.Write(SB);
                    SB.Clear();
                }
            }
            MessageBox.Show("Popetli");
            SW.Flush();
            SW.Close();
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            WaveformArray.Add(oscillo.odczyt()[0]);
            List<double> temp = WaveformArray[0];
            for (int i = 0; i < temp.Count; i++)
            {
                // PPL.Add(i, temp[i]);
                MessageBox.Show(" " + i + " " + temp[i]);
                TestLabel.Text = TestLabel.Text + " " + i + " " + temp[i];
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            measurements.LoadGatheredWaveforms(loadpath, 1);   
        }

        private void WavemeterInit_Click(object sender, EventArgs e)
        {

        }

private void button1_Click_3(object sender, EventArgs e)
        {
            measurements = new Measurements();
            measurements.LoadGatheredWaveforms(loadpath, DataSlider.Value);
        }

        private void DataSlider_Scroll(object sender, EventArgs e)
        {
            FrameLabel.Text = "Frame Number: " + DataSlider.Value.ToString();
        }

        private void DataSlider_DragDrop(object sender, DragEventArgs e)
        {
            CurrentWave.Clear();
            CurrentWave = WaveformRead();
            int i = 0;
            foreach(int value in CurrentWave) // TO TRZEBA SPRAWDZIC
            {
                i++;
                PPLsignal.Add(i, CurrentWave[value]);
            }
            ZedSignal.GraphPane.CurveList.Clear();
            ZedSignal.GraphPane.AddCurve("", PPLsignal, Color.Green);
            ZedSignal.GraphPane.AxisChange();
            ZedSignal.Update();
            ZedSignal.Invalidate();
        }
    }
}
