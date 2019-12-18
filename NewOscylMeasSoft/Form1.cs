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
using System.Text.RegularExpressions;
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
        Thread Measure, Graphdrawer,OscilloMeasure;
        ThreadStart MEASURE,GRAPHDRAWER;
        Measurements measurements;
        DataAnalysis DA;
        StreamWriter FilepathWriter;
        StreamReader FilePathReader;
        PointPairList PPLsignal, PPLInterferometer,PPLIntegralCorrect,PPLIntegralWrong;
        string loadpath;
        string savepath;
        static double[] xmin = new double[2] { 0, 0 };
        static double[] xmax = new double[2] { 0, 0 };
        static double[] y = new double[2] { -50, 50 };
        List<List<double>> ReadData = new List<List<double>>();
        List<List<double>> RawData = new List<List<double>>();
        List<List<double>> InteferogramData = new List<List<double>>();
        List<List<double>> CutoffAll = new List<List<double>>();
        ZedGraph.LineItem lineItem1 = new ZedGraph.LineItem("cursorY1", xmin, y, Color.White, ZedGraph.SymbolType.None, 2);
        ZedGraph.LineItem lineItem2 = new ZedGraph.LineItem("cursorY2", xmax, y, Color.White, ZedGraph.SymbolType.None, 2);
        PointPairList  PPLmax = new PointPairList();
        PointPairList PPLmin = new PointPairList();
        PointPairList CutoffPoints = new PointPairList();
        PointPairList BriefSpectrum = new PointPairList();
        bool userdoneupdater = false;
        bool userdoneupdaterinteferometer = false;
        obslugaNW WMU = new obslugaNW();
        public List<double> WaveformRead()
        {
            return measurements.LoadGatheredWaveforms(loadpath, linecount);
        }
        int linecount = 1;
        List<double> CurrentWave;
        List<double> CurrentInteferometer;
        List<double> AfterCutoff;
        public Form1()
        {
            
            PPLsignal = new PointPairList();
            PPLIntegralCorrect = new PointPairList();
            PPLIntegralWrong = new PointPairList();
            PPLInterferometer = new PointPairList();
            InitializeComponent();
            DA = new DataAnalysis();
            oscillo = new Oscyloskop.Form1();
            ZedSignal.GraphPane.XAxis.Title.Text = "Number of points";
            ZedSignal.GraphPane.YAxis.Title.Text = "Signal";
            OscilloSignal.GraphPane.XAxis.Title.Text = "Number of point";
            OscilloSignal.GraphPane.YAxis.Title.Text = "Voltage (mV)";
            WavemeterSignal.GraphPane.XAxis.Title.Text = "Number of point";
            WavemeterSignal.GraphPane.YAxis.Title.Text = "Intensity (a.u.)";
            OscilloSignal.GraphPane.Title.Text = "PicoScope";
            WavemeterSignal.GraphPane.Title.Text = "Wavemeter";
            DataSlider.BackColor = Color.LightGray;
            GRAPHDRAWER = new ThreadStart(GraphDrawer);
            Graphdrawer = new Thread(GRAPHDRAWER);
            ZedSignal.GraphPane.CurveList.Add(lineItem1);
            ZedSignal.GraphPane.CurveList.Add(lineItem2);
            ZedSignal.GraphPane.YAxis.Scale.Max = 5000;
            ZedSignal.GraphPane.YAxis.Scale.Min = -5000;
            ZedSignal.GraphPane.YAxis.Scale.MajorStep = 1000;
            ZedSignal.GraphPane.YAxis.Scale.MinorStep = 250;
            ZedIntegral.GraphPane.XAxis.Title.Text = "Time (ms)";
            ZedIntegral.GraphPane.YAxis.Title.Text = "Counts (a.u.)";
            ZedSignal.GraphPane.Title.Text = "Waveform";
            ZedIntegral.GraphPane.Title.Text = "Spectrum";
            WaveformArray = new List<List<double>>();
            CurrentWave = new List<double>();
            CurrentInteferometer = new List<double>();
            AfterCutoff = new List<double>();
            lineItem1.Label.IsVisible = false;
            lineItem2.Label.IsVisible = false;
            ZedSignal.Invalidate();
        }

        public Thread StartTheThread(string FilePath, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 500, int Averages = 10, bool Trigger = false)
        {
            if (TriggerBtnOn.Checked)
                NumberOfMeasures = 1000000;
            Measure = new Thread(() => measurements.GatherWaveforms(FilePath, oscillo, NumberOfMeasures, Averages, TriggerBtnOn.Checked));
            Measure.Start();
            return Measure;
        }
        public Thread JustPICO(string FilePath, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 500, int Averages = 10, bool Trigger = false)
        {
            if (TriggerBtnOn.Checked)
                NumberOfMeasures = 1000000;
            Measure = new Thread(() => measurements.PicoMeasures(FilePath, oscillo, NumberOfMeasures, Averages, TriggerBtnOn.Checked));
            Measure.Start();
            return Measure;
        }
        public Thread JustWSU(string FilePath, int NumberOfMeasures = 500, int Averages = 10, bool Trigger = false)
        {
            if (TriggerBtnOn.Checked)
                NumberOfMeasures = 1000000;
            Measure = new Thread(() => measurements.WSUmeasures(FilePath, NumberOfMeasures, Averages, TriggerBtnOn.Checked));
            Measure.Start();
            return Measure;
        }
        public Thread StartTheThread2() // DO USUNIECIA
        {
            Measure = new Thread(() => Rysowaniewykresów());
            Measure.Start();
            return Measure;
        }
        public Thread OnlyOscilloMeasures(string FilePath, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 500, int Averages = 10, bool Trigger = false) // DO USUNIECIA
        {
            OscilloMeasure = new Thread(() => measurements.OnlyOscilloMeasurements(FilePath,oscillo,NumberOfMeasures,Averages,Trigger));
            OscilloMeasure.Start();
            return OscilloMeasure;
        }
        public void GraphDrawer()// TO TRZEBA ZROBIC
        {
            int i = 1;
            LineItem LBriefIntegral;
            LBriefIntegral = ZedBriefIntegral.GraphPane.AddCurve("", BriefSpectrum, Color.BlueViolet, SymbolType.Circle);
            LBriefIntegral.Line.IsVisible = false;
            while (true)
            {
                if(measurements.DrawTheGraph == true)
                {
                    measurements.DrawTheGraph = false;
                    WavemeterSignal.GraphPane.CurveList.Clear();
                    OscilloSignal.GraphPane.CurveList.Clear();
                    ZedBriefIntegral.GraphPane.CurveList.Clear();
                    WavemeterSignal.GraphPane.AddCurve("", measurements.PPLWSU, Color.Red, SymbolType.None);
                    OscilloSignal.GraphPane.AddCurve("", measurements.PPLPIC, Color.DarkBlue, SymbolType.None);
                    if(measurements.IntegralPico != 0 && measurements.CurrentWavelenght > 0)
                    {
                        ZedBriefIntegral.GraphPane.AddCurve("", measurements.PPLSPEC,Color.Red,SymbolType.None);
                        measurements.CurrentWavelenght = 0;
                        measurements.IntegralPico = 0;
                        ZedBriefIntegral.Update();
                        ZedBriefIntegral.AxisChange();
                        ZedBriefIntegral.Invalidate();
                    }
                    WavemeterSignal.AxisChange();
                    OscilloSignal.AxisChange();
                    WavemeterSignal.Invalidate();
                    OscilloSignal.Invalidate();
                    MeasurementNumberLabel.Text = "Number of measures: " + i;
                    i++;
                }

            }
            
        }

        private void Rysowaniewykresów() // DO USUNIECIA
        {
            PointPairList PPLCorrect = new PointPairList();
            for (int i = 0; i < 10000; i++)
            {
                PPLCorrect.Add(i, i);
            }
           GraphDrawer();
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
            numberofpoints = RawData[0].Count();
            TrackMin.Maximum = (int)numberofpoints - 1;
            TrackMax.Maximum = (int)numberofpoints - 1;
            ZedSignal.Invalidate();
        }
        LineItem lmin = new LineItem("init");
        LineItem lmax = new LineItem("init");
        private object interferometerlabel;

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
            int x, y;
            int.TryParse(MeasuresTB.Text, out x);
            int.TryParse(AveragesTB.Text, out y);
            bool z = false;
            if (DataSaverDialog.FileName == "")
                DataSaverDialog.ShowDialog();
            if (int.TryParse(MeasuresTB.Text, out x) && int.TryParse(AveragesTB.Text, out y))
            {
                Graphdrawer.Start();
                StartTheThread(savepath, oscillo, x, y, TriggerBtnOn.Checked);
            }
            else
            {
                MessageBox.Show("Niepoprawne parametry");
            }
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
            DialogResult DR = MessageBox.Show("Are you sure you want to stop measurements?", "OMG YOU ARE GOING TO STOP THE MEASUREMENTS!", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
                Measure.Abort();
            else
                MessageBox.Show("Measurements were not stopped");
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


        private void DataSaverDialog_FileOk(object sender, CancelEventArgs e)
        {
            savepath = DataSaverDialog.FileName;
            PathToFileLabel.Text = savepath;
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


        private void LoadData_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RawData.Count().ToString());
            if (RawData.Count > 0)
                RawData.Clear();
            RawData = measurements.RegexReader(loadpath, FileSeparator.Text);
        }

        private void PathToFileLabel_Click(object sender, EventArgs e)
        {

        }

        private void TestLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e) 
        {
            ForRandomDataReads.ShowDialog();
            StringBuilder SBRandomData = new StringBuilder();
            List<List<double>> ForDataAnalysis = new List<List<double>>();
            List<List<double>> NewList = new List<List<double>>();
            List<double> STDlist = new List<double>();
            ForDataAnalysis = measurements.RegexReader(ForRandomDataReads.FileName, FileSeparator.Text);
            double lastT, lastC, SumMax = 0;
            MessageBox.Show("" + ForDataAnalysis.Count() + " " + ForDataAnalysis[0].Count() + " " + ForDataAnalysis[1].Count());
            lastT = ForDataAnalysis[0][1];
            lastC = ForDataAnalysis[0][2];
            int ave = int.Parse(ReadFilesAveTB.Text);
            for (int i = 0; i < ForDataAnalysis.Count(); i++)
            {
                
                if(lastT == ForDataAnalysis[i][1] && lastC == ForDataAnalysis[i][2])
                {
                    SumMax = SumMax + ForDataAnalysis[i][6];
               //     MessageBox.Show("" + ForDataAnalysis[i][6]);
                    STDlist.Add(ForDataAnalysis[i][6]);
                }
                else
                {
                    SBRandomData.Append("" + lastT + " " + lastC + " " + ForDataAnalysis[i-ave][3] + " " + ForDataAnalysis[i][3] + " " + SumMax / ave + " " + DA.getStandardDeviation(STDlist) +Environment.NewLine);
                    using (StreamWriter SW = new StreamWriter(ForRandomDataReads.FileName + " Results", true))
                    {
                        SW.Write(SBRandomData);
                    }
                    SBRandomData.Clear();
                    STDlist.Clear();
                    SumMax = ForDataAnalysis[i][6];
                    lastT = ForDataAnalysis[i][1];
                    lastC = ForDataAnalysis[i][2];
                }
            }
        }

        private void CheckOne_Click(object sender, EventArgs e)
        {
            var x = obslugaNW.odczytajPrazkiPierwszyIntenf();
            StringBuilder SB = new StringBuilder();
            PointPairList PPL = new PointPairList();
            int i = 0;
            foreach (var z in x)
            {
                SB.Append(z + "\n");
                PPL.Add(i, z);
                i++;
            }
            TestLabel.Text = SB.ToString();
            WavemeterSignal.GraphPane.CurveList.Clear();
            WavemeterSignal.GraphPane.AddCurve("", PPL, Color.Red, SymbolType.None);
            WavemeterSignal.AxisChange();
            WavemeterSignal.Update();
            WavemeterSignal.Invalidate();

        }

        private void AveragesTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void CutOffFunction_Click(object sender, EventArgs e) // COS TUTAJ NIE GRA
        {
            CutoffSaver.ShowDialog();
            int Max = 0;
            for (int i = 1; i < InteferogramData.Count(); i++)
            {
                CutoffAll.Add(DA.CutoffFunction(InteferogramData[i], double.Parse(CutoffTB.Text), int.Parse(IgnoredColumnsForInteferometer.Text)));
                Max = DA.MaximumsCounter(CutoffAll[i-1]);
                using (StreamWriter SW = new StreamWriter(CutoffSaver.FileName + " Inteferometer", true))
                {
                    for(int j = 0; j < int.Parse(IgnoredColumnsForInteferometer.Text); j++)
                    {
                        SW.Write(InteferogramData[i][j] + " ");
                    }
                    SW.Write(i + " " + Max + " " + DA.MaximumsUncertainty(Max) + Environment.NewLine);
                    SW.Flush();
                }
            }
        }

        private void FindInterferogram_Click(object sender, EventArgs e)
        {
            InteferometerPathway.ShowDialog();
            LoadInteferometer.Enabled = true;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            InteferogramData = measurements.RegexReader(InteferometerPathway.FileName, FileSeparator.Text);
            TestLabel.Text = "Dane wczytane." + Environment.NewLine + "Plik:" + InteferometerPathway.FileName + Environment.NewLine + "Wielkość tablicy:" + InteferogramData.Count()
                + Environment.NewLine + "Wielkość listy:" + InteferogramData[200].Count();
        }

        private void InteferometerPathway_FileOk(object sender, CancelEventArgs e)
        {
            if (InteferometerPathway.FileName != null)
            {
                using (FilePathReader = new StreamReader(InteferometerPathway.FileName))
                {
                    InteferometerSlider.Maximum = File.ReadLines(InteferometerPathway.FileName).Count();
                    InteferometerSlider.Minimum = 1;
                }
            }
            else
                MessageBox.Show("Something went wrong..");
        }

        private void InteferometerSlider_Scroll(object sender, EventArgs e)
        {

        }

        private void InteferometerSlider_ValueChanged(object sender, EventArgs e)
        {
            userdoneupdaterinteferometer = true;
        }

        private void ShowOneInterferometer_Click(object sender, EventArgs e)
        {

        }

        private void CutoffTest_Click(object sender, EventArgs e)
        {
            CutoffSaver.ShowDialog();
            string line;
            double Max;
            int CounterOfMax = 0;
            List<List<double>> ReadDataInDoubles = new List<List<double>>();
            string[] Test;
            int i;
            List<string> StringList = new List<string>();
            List<double> DoubleList = new List<double>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream FS = File.Open(InteferometerPathway.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream BS = new BufferedStream(FS))
                {
                    using (StreamReader SR = new StreamReader(BS))
                    {
                        while ((line = SR.ReadLine()) != null)
                        {
                            StringList = Regex.Split(line, FileSeparator.Text).ToList();
                            for (i = int.Parse(IgnoredColumnsForInteferometer.Text); i < StringList.Count - 1; i++)
                            {
                                DoubleList.Add(double.Parse(StringList[i]));
                            }
                            ReadDataInDoubles.Add(DoubleList);
                            if(ReadDataInDoubles.Count > 100)
                            {
                                for(int k = 0; k <100;k++)
                                {
                                    Max = ReadDataInDoubles[k].Max();
                                    CounterOfMax = 0;
                                    for (int j = 0; j < ReadDataInDoubles[k].Count;  j++)
                                    {
                                        if (ReadDataInDoubles[k][j] < (double.Parse(CutoffTB.Text) / 100) * Max)
                                            ReadDataInDoubles[k][j] = 0;
                                        if (j > 1 && ReadDataInDoubles[k][j] - ReadDataInDoubles[k][j - 1] == 0)
                                            CounterOfMax++;
                                    }
                                    using (StreamWriter SW = new StreamWriter(CutoffSaver.FileName + " Inteferometer", true))
                                    {
                                        SW.Write(k + " " + stopwatch.ElapsedMilliseconds + " " + i + Environment.NewLine);
                                        SW.Flush();
                                    }
                                }
                              
                                ReadDataInDoubles.Clear();
                            }
                            //DoubleList = new List<double>();
                            //StringList = new List<string>();
                        }
                    }
                }
            }
            stopwatch.Stop();
            MessageBox.Show("" + stopwatch.ElapsedMilliseconds + " " + ReadDataInDoubles[1].Count);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Measure != null)
            {
                if (Measure.IsAlive) Measure.Abort();
            }
            if(Graphdrawer != null)
            {
                if (Graphdrawer.IsAlive) Graphdrawer.Abort();
            }
            Environment.Exit(Environment.ExitCode);
        }

        private void OnlyPico_Click(object sender, EventArgs e)
        {
            int x, y;
            int.TryParse(MeasuresTB.Text, out x);
            int.TryParse(AveragesTB.Text, out y);
            bool z = false;
            if (DataSaverDialog.FileName == "")
                DataSaverDialog.ShowDialog();
            if (int.TryParse(MeasuresTB.Text, out x) && int.TryParse(AveragesTB.Text, out y))
            {
                Graphdrawer.Start();
                OnlyOscilloMeasures(savepath, oscillo, x, y, TriggerBtnOn.Checked);
            }
            else
            {
                MessageBox.Show("Niepoprawne parametry");
            }
        }

        private void NewMeasureButton_Click(object sender, EventArgs e)
        {
            int x, y;
            int.TryParse(MeasuresTB.Text, out x);
            int.TryParse(AveragesTB.Text, out y);
            bool z = false;
            if (DataSaverDialog.FileName == "")
                DataSaverDialog.ShowDialog();
            if (int.TryParse(MeasuresTB.Text, out x) && int.TryParse(AveragesTB.Text, out y))
            {
                Graphdrawer.Start();
                JustPICO(savepath, oscillo, x, y, TriggerBtnOn.Checked);
                JustWSU(savepath, x, y, TriggerBtnOn.Checked);
            }
            else
            {
                MessageBox.Show("Niepoprawne parametry");
            }
        }

        private void ZedSignal_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            //LineItem LBriefIntegral;
            //LBriefIntegral = ZedBriefIntegral.GraphPane.AddCurve("bla", BriefSpectrum, Color.BlueViolet, SymbolType.Diamond);
            //BriefSpectrum.Add(measurements.CurrentWavelenght, measurements.IntegralPico);
            //for (int i = 0; i < 100; i++)
            //{
            //    BriefSpectrum.Add(i, i);
            //    measurements.CurrentWavelenght = 0;
            //    measurements.IntegralPico = 0;
            //    LBriefIntegral.Line.IsVisible = false;
            //    ZedBriefIntegral.Update();
            //    ZedBriefIntegral.AxisChange();
            //    ZedBriefIntegral.Invalidate();
            //}

        }

        private void TriggerBtnOn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
        }

        private void InteferometerSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (userdoneupdaterinteferometer)
            {
                InteferometerParameters.Text = "";
                userdoneupdaterinteferometer = false;
                FrameInteferometer.Text = "Frame Number: " + InteferometerSlider.Value.ToString();
                CurrentInteferometer.Clear();
                CurrentInteferometer = measurements.SingleLineReader(InteferometerPathway.FileName, InteferometerSlider.Value);
                PPLInterferometer.Clear();
                for(int i = 0; i < int.Parse(IgnoredColumnsForInteferometer.Text); i++)
                {
                    InteferometerParameters.Text += CurrentInteferometer[i] + " ";
                }
                for (int i = int.Parse(IgnoredColumnsForInteferometer.Text); i < CurrentInteferometer.Count; i++)
                {
                    PPLInterferometer.Add(i, CurrentInteferometer[i]);
                }
                ZedInteferogram.GraphPane.CurveList.Clear();
                ZedInteferogram.GraphPane.AddCurve("", PPLInterferometer, Color.Blue, SymbolType.None);
                ZedInteferogram.AxisChange();
                ZedInteferogram.Update();
                ZedInteferogram.Invalidate();
            }
        }

        private void FindFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            LoadData.Enabled = true;
            DataSlider.BackColor = Color.PaleGreen;
            TrackMin.BackColor = Color.LightBlue;
            TrackMax.BackColor = Color.LightBlue;
            PathToFileLabel.Text = "Path: " + OpenFileDialog.FileName;
        }

        private void DataSlider_ValueChanged(object sender, EventArgs e)
        {
            userdoneupdater = true;
        }

        private void IntegralBtn_Click(object sender, EventArgs e) // INTEGRAL to samo co w check
        {
            if (RawData.Count() != 0)
            {
                PointPairList PPL;
                ZedIntegral.GraphPane.CurveList.Clear();
                ZedIntegral.GraphPane.GraphObjList.Clear();
                PointPairList PPLCorrect = new PointPairList();
                PointPairList PPLNotCorrect = new PointPairList();
                StringBuilder SB = new StringBuilder();
                Integral = measurements.IntegralOnLists(RawData, TrackMin.Value, TrackMax.Value);
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
            else
                LoadData.PerformClick();
        }

        private void DataSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (userdoneupdater)
            {
                userdoneupdater = false;
                FrameLabel.Text = "Frame Number: " + DataSlider.Value.ToString();
                CurrentWave.Clear();
                CurrentWave = measurements.SingleLineReader(loadpath, DataSlider.Value);
                TrackMin.Maximum = CurrentWave.Count();
                TrackMax.Maximum = CurrentWave.Count();
                PPLsignal.Clear();
                for (int i = int.Parse(IgnoredColumsForData.Text); i < CurrentWave.Count; i++)
                {
                    PPLsignal.Add(i, CurrentWave[i]);
                }
                ZedSignal.GraphPane.CurveList.Clear();
                ZedSignal.GraphPane.AddCurve("", PPLsignal, Color.Blue,SymbolType.None);
                ZedSignal.AxisChange();
                ZedSignal.Update();
                ZedSignal.Invalidate();
            }
        }
    }
}
