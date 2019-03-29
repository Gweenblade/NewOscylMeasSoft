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
using System.Diagnostics;
namespace NewOscylMeasSoft
{
    public partial class Form1 : Form
    {
        double numberofpoints;
        Oscyloskop.Form1 oscillo;
        List<List<double>> WaveformArray, Integral;
        bool TriggerEdge = true;
        int TriggerCH;
        short TriggerVoltage;
        ushort TriggerHis;
        Thread Measure, Aw;
        ThreadStart MEASURE;
        Measurements measurements;
        StreamWriter FilepathWriter;
        StreamReader FilePathReader;
        PointPairList PPLsignal,PPLIntegralCorrect,PPLIntegralWrong;
        string loadpath;
        string savepath;
        static double[] xmin = new double[2] { 0, 0 };
        static double[] xmax = new double[2] { 0, 0 };
        static double[] y = new double[2] { -50, 50 };
        List<List<double>> ReadData = new List<List<double>>();
        ZedGraph.LineItem lineItem1 = new ZedGraph.LineItem("cursorY1", xmin, y, Color.White, ZedGraph.SymbolType.None, 2);
        ZedGraph.LineItem lineItem2 = new ZedGraph.LineItem("cursorY2", xmax, y, Color.White, ZedGraph.SymbolType.None, 2);
        PointPairList  PPLmax = new PointPairList();
        PointPairList PPLmin = new PointPairList();
        bool userdoneupdater = false;
        public List<double> WaveformRead()
        {
            return measurements.LoadGatheredWaveforms(loadpath, linecount);
        }
        int linecount = 1;
        List<double> CurrentWave;
        public Form1()
        {
            PPLsignal = new PointPairList();
            PPLIntegralCorrect = new PointPairList();
            PPLIntegralWrong = new PointPairList();
            InitializeComponent();
            oscillo = new Oscyloskop.Form1();
            double.TryParse(NumberOfPointsBox.Text, out numberofpoints);
            ZedSignal.GraphPane.XAxis.Title.Text = "Number of points";
            ZedSignal.GraphPane.YAxis.Title.Text = "Signal";
            DataSlider.BackColor = Color.LightGray;
            ZedSignal.GraphPane.CurveList.Add(lineItem1);
            ZedSignal.GraphPane.CurveList.Add(lineItem2);
            ZedSignal.GraphPane.YAxis.Scale.Max = 5500;
            ZedSignal.GraphPane.YAxis.Scale.Min = -5500;
            ZedSignal.GraphPane.YAxis.Scale.MajorStep = 1000;
            ZedSignal.GraphPane.YAxis.Scale.MinorStep = 250;


            WaveformArray = new List<List<double>>();
            CurrentWave = new List<double>();
            lineItem1.Label.IsVisible = false;
            lineItem2.Label.IsVisible = false;
            ZedSignal.Invalidate();
        }

        public Thread StartTheThread(string FilePath, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 500, int NumberOfPointsPerWF = 2048, bool Trigger = false, int ChannelTrig = 0, int ChannelSig = 0)
        {
            Measure = new Thread(() => measurements.GatherWaveforms(FilePath, oscillo));
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
        private void LineZedSignalRedrawer()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            measurements = new Measurements();
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
            double.TryParse(NumberOfPointsBox.Text, out numberofpoints);
            TrackMin.Maximum = (int)numberofpoints - 1;
            TrackMax.Maximum = (int)numberofpoints - 1;
            ZedSignal.Invalidate();
        }
        LineItem lmin = new LineItem("init");
        LineItem lmax = new LineItem("init");
        private void TrackMin_Scroll(object sender, EventArgs e)// Z jakegos dziwnego powodu tak działa lepiej.
        {
            PPLmin.Clear();
            PPLmin.Add(TrackMin.Value, ZedSignal.GraphPane.YAxis.Scale.Min);
            PPLmin.Add(TrackMin.Value, ZedSignal.GraphPane.YAxis.Scale.Max);
           // LineItem LImin = ZedSignal.GraphPane.AddCurve("LImin", PPLmin, Color.Orange);
            lmin = ZedSignal.GraphPane.AddCurve("min", PPLmin, Color.Orange);
            //LImin.Label.IsVisible = false;
            lmin.Label.IsVisible = false;
            ZedSignal.AxisChange();
            ZedSignal.Update();
            ZedSignal.Invalidate();
            Bar1Label.Text = TrackMin.Value.ToString();
        }

        private void TrackMax_Scroll(object sender, EventArgs e)
        {
       
            PPLmax.Clear();
            PPLmax.Add(TrackMax.Value, ZedSignal.GraphPane.YAxis.Scale.Min);
            PPLmax.Add(TrackMax.Value, ZedSignal.GraphPane.YAxis.Scale.Max);
            //LineItem LImax = ZedSignal.GraphPane.AddCurve("LImax", PPLmax, Color.Orange);
            lmax = ZedSignal.GraphPane.AddCurve("LImax", PPLmax, Color.Orange);
            //LImax.Label.IsVisible = false;
            lmax.Label.IsVisible = false;
            ZedSignal.AxisChange();
            ZedSignal.Update();
            ZedSignal.Invalidate();
            Bar2Label.Text = TrackMax.Value.ToString();
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
            StartTheThread(savepath,oscillo);
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
            savepath = DataSaverDialog.FileName;
            PathToFileLabel.Text = savepath;
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
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
            OpenFileDialog.ShowDialog();
        }

        private void DataSlider_Scroll(object sender, EventArgs e)
        {
        }


        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (OpenFileDialog.FileName != null)
            {
                using (FilePathReader = new StreamReader(OpenFileDialog.FileName))
                {
                    loadpath = OpenFileDialog.FileName;
                    linecount = File.ReadLines(loadpath).Count();
                    DataSlider.Maximum = linecount;
                    DataSlider.Minimum = 1;
                }
            }
            else
                MessageBox.Show("Something went wrong..");
        }

        private void Checkone_Click(object sender, EventArgs e)
        {
            PointPairList PPL;
            ZedIntegral.GraphPane.CurveList.Clear();
            ZedIntegral.GraphPane.GraphObjList.Clear();
            PointPairList PPLCorrect = new PointPairList();
            PointPairList PPLNotCorrect = new PointPairList();
            StringBuilder SB = new StringBuilder();
            Integral = measurements.FixedIntegral(loadpath, TrackMin.Value, TrackMax.Value);
            for (int i = 0; i < Integral.Count(); i++)
            {
                for (int j = 0; j < Integral[i].Count; j++)
                {
                    SB.Append(Integral[i][j] + " ");
                }
                SB.Append("\n");
                PPLCorrect.Add(Integral[i][0], Integral[i][1]);
                PPLNotCorrect.Add(Integral[i][0], Integral[i][1]);
            }
            using (StreamWriter SW = new StreamWriter(loadpath + "_Integral")) { SW.Write(SB); }
            LineItem CorrectCurve = ZedIntegral.GraphPane.AddCurve("Correct measured points", PPLCorrect, Color.Green, SymbolType.Circle);
            LineItem IncorrectCurve = ZedIntegral.GraphPane.AddCurve("Incorrect measured points", PPLNotCorrect, Color.Red, SymbolType.Plus);
            CorrectCurve.Line.IsVisible = false;
            IncorrectCurve.Line.IsVisible = false;
            ZedIntegral.AxisChange();
            ZedIntegral.Update();
            ZedIntegral.Invalidate();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            measurements.RegexReader(loadpath, 5, 25);
           // measurements.JustReadReges(loadpath);
        }

        private void DataSlider_ValueChanged(object sender, EventArgs e)
        {
            userdoneupdater = true;
        }

        private void AWinit_Click(object sender, EventArgs e)
        {
        }

        private void IntegralBtn_Click(object sender, EventArgs e)
        {
            PointPairList PPL;
            ZedIntegral.GraphPane.CurveList.Clear();
            ZedIntegral.GraphPane.GraphObjList.Clear();
            PointPairList PPLCorrect = new PointPairList();
            PointPairList PPLNotCorrect = new PointPairList();
            StringBuilder SB = new StringBuilder();
            Integral = measurements.IntegralCalculator(loadpath, TrackMin.Value, TrackMax.Value, linecount);
            for (int i = 0; i < Integral.Count(); i++)
            {
                for (int j = 0; j < Integral[i].Count; j++)
                {
                    SB.Append(Integral[i][j] + " ");
                }
                SB.Append("\n");
                PPLCorrect.Add(Integral[i][0], Integral[i][1]);
                PPLNotCorrect.Add(Integral[i][0], Integral[i][1]);
            }
            using (StreamWriter SW = new StreamWriter(loadpath + "_Integral")) { SW.Write(SB); }
            LineItem CorrectCurve = ZedIntegral.GraphPane.AddCurve("Correct measured points", PPLCorrect, Color.Green, SymbolType.Circle);
            LineItem IncorrectCurve = ZedIntegral.GraphPane.AddCurve("Incorrect measured points", PPLNotCorrect, Color.Red, SymbolType.Plus);
            CorrectCurve.Line.IsVisible = false;
            IncorrectCurve.Line.IsVisible = false;
            ZedIntegral.AxisChange();
            ZedIntegral.Update();
            ZedIntegral.Invalidate();

        }

        private void DataSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (userdoneupdater)
            {
                userdoneupdater = false;
                FrameLabel.Text = "Frame Number: " + DataSlider.Value.ToString();
                CurrentWave.Clear();
                CurrentWave = measurements.LoadGatheredWaveforms(loadpath, DataSlider.Value);
                int i;
                PPLsignal.Clear();
                for (i = 0; i < CurrentWave.Count; i++)
                {
                    PPLsignal.Add(i, CurrentWave[i]);
                }
                ZedSignal.GraphPane.CurveList.Clear();
                ZedSignal.GraphPane.AddCurve("", PPLsignal, Color.Blue,SymbolType.Diamond);
                ZedSignal.AxisChange();
                ZedSignal.Update();
                ZedSignal.Invalidate();
            }
        }
    }
}
