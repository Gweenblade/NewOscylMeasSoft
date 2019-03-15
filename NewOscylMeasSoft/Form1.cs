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
        static double[] x = new double[2] { 0, 0 };
        static double[] y = new double[2] { -50, 50 };
        ZedGraph.LineItem lineItem2 = new ZedGraph.LineItem("cursorY2", x, y, Color.BlueViolet, ZedGraph.SymbolType.None,2);
        ZedGraph.LineItem lineItem1 = new ZedGraph.LineItem("cursorY1", x, y, Color.BlueViolet, ZedGraph.SymbolType.None,2);
        bool userdoneupdater = false;
        LineItem LICorrect = new ZedGraph.LineItem("Correct measured wavelenghts", x,x, Color.Green, SymbolType.Circle);
        LineItem LINotCorrect = new ZedGraph.LineItem("Incorrect measured Wavelenghts", x,x, Color.Red, SymbolType.Circle);
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
            LICorrect.Line.IsVisible = false;
            LINotCorrect.Line.IsVisible = false;
            LICorrect.Symbol.Size = 2;
            LINotCorrect.Symbol.Size = 1;
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
            /*var records = new List<Foo>
            {
               new Foo { Id = 1, Name = "one" },
            };*/
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
            TEST(savepath);
           
            //measurements.LoadGatheredWaveforms(loadpath, DataSlider.Value);
        }

        private void DataSlider_Scroll(object sender, EventArgs e)
        {
           /* FrameLabel.Text = "Frame Number: " + DataSlider.Value.ToString();
            CurrentWave.Clear();
            CurrentWave = measurements.LoadGatheredWaveforms(loadpath, DataSlider.Value);
            int i;
            PPLsignal.Clear();
            for(i = 0; i < CurrentWave.Count; i++)
            {
                PPLsignal.Add(i, CurrentWave[i]);
            }
            ZedSignal.GraphPane.CurveList.Clear();
            ZedSignal.GraphPane.AddCurve("", PPLsignal, Color.Green);
            ZedSignal.GraphPane.AxisChange();
            ZedSignal.Update();
            ZedSignal.Invalidate();*/
        }

        public void TEST(string FilePath1, int NumberOfMeasures = 500, int NumberOfPointsPerWF = 2048, bool pause = false, bool STOP = false, bool Trigger = false, int ChannelTrig = 0, int ChannelSig = 0)
        {
            int MeasureLoopIndicator;
            int i;
            bool WARNING;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StreamWriter SW = new StreamWriter(FilePath1);
            StringBuilder SB = new StringBuilder();
            double Wavenumber = 0;
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures; MeasureLoopIndicator++)
            {
                WaveformArray.Add(oscillo.odczyt()[0]); // Poprawić kanał w razie czego TO JEST WAZNE
                /* WaveformArray = new List<List<double>> TYLKO DO TESTÓW, NIE MA ZNACZENIA JAK COS TO WYJEBAC
             { new List<double> { 1,2 },
             new List<double> { 3,4 },
             new List<double> { 5,6 }};*/
                /*  if (Wavecontrol.ReadCM() > 0) //Zabezpieczenie błędu z odczytem długości fali
                  {
                      Wavenumber = Wavecontrol.ReadCM();
                      WARNING = false;
                  }
                  else
                      WARNING = true;
                  SB.Append(Wavenumber + ":");*/
                SB.Append(Stopwatch.ElapsedMilliseconds + ":");
                for (i = 0; i < WaveformArray[0].Count; i++)// TUTAJ moze byc bubel zwiazany z iloscia elementów (dać -1 jak cos)
                {
                    SB.Append(WaveformArray[0][i] + ":");
                }/*
                if (WARNING == true) // Jeśli ostatni element listy jest równy -1, to oznacza że był problem z odczytem długości fali i założono 
                    SB.Append("-1");*/
                SB.Append("KONIEC LINI \r\n");
                WaveformArray.Clear();

                if (MeasureLoopIndicator % 50 == 0)
                {
                    SW.Write(SB);
                    SB.Clear();
                }
                if (NumberOfMeasures - MeasureLoopIndicator < 50)
                {
                    SW.Write(SB);
                    SB.Clear();
                }


            }
            Stopwatch.Stop();
            SW.Close();
            MessageBox.Show("KONIEc");
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (OpenFileDialog.FileName != null)
            {
                FilePathReader = new StreamReader(OpenFileDialog.FileName);
                loadpath = OpenFileDialog.FileName;
                linecount = File.ReadLines(loadpath).Count();
                FilePathReader.Dispose();
                DataSlider.Maximum = linecount;
                DataSlider.Minimum = 1;
            }
            else
                MessageBox.Show("Something went wrong..");
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
            LINotCorrect.Clear();
            LICorrect.Clear();
            Integral = measurements.IntegralCalculator(loadpath, TrackMin.Value, TrackMax.Value, linecount);
            for (int i = 0; i < Integral.Count(); i++)
                {
                    for (int j = 0; j < Integral[i].Count; j++)
                    {
                    using (StreamWriter SW = new StreamWriter(loadpath + "_Integral")) { SW.Write(Integral[i][j] + " "); };
                    }
                using (StreamWriter SW = new StreamWriter(loadpath + "_Integral")) { SW.Write("\r\n"); };
                if (Integral[i][2] == -1)
                    LINotCorrect.AddPoint(Integral[i][0], Integral[i][1]);
                else
                    LICorrect.AddPoint(Integral[i][0], Integral[i][1]);
                }
            ZedIntegral.GraphPane.CurveList.Clear();
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
                ZedSignal.GraphPane.AddCurve("", PPLsignal, Color.Blue,SymbolType.None);
                ZedSignal.GraphPane.AxisChange();
                ZedSignal.Update();
                ZedSignal.Invalidate();
            }
        }
    }
}
