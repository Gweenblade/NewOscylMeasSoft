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
using ADwin;
using ADwin.Driver;
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
        obsługaAdWina AW;
        Thread Measure, Graphdrawer,OscilloMeasure;
        ThreadStart MEASURE,GRAPHDRAWER;
        Measurements measurements;
        DataAnalysis DA;
        StreamWriter FilepathWriter;
        StreamReader FilePathReader;
        PointPairList PPLsignal, PPLInterferometer,PPLIntegralCorrect,PPLIntegralWrong;
        string loadpath;
        string savepath;
        private int howmanyaverages;
        public int HowManyAverages
        {
            get { return howmanyaverages; }
            set { howmanyaverages = value; }
        }
        static double[] xmin = new double[2] { 0, 0 };
        static double[] xmax = new double[2] { 0, 0 };
        static double[] y = new double[2] { -50, 50 };
        List<List<double>> ReadData = new List<List<double>>();
        List<List<double>> RawData = new List<List<double>>();
        List<List<double>> InteferogramData = new List<List<double>>();
        List<List<double>> CutoffAll = new List<List<double>>();
        ZedGraph.LineItem lineItem1 = new ZedGraph.LineItem("cursorY1", xmin, y, Color.White, ZedGraph.SymbolType.None, 2);
        ZedGraph.LineItem lineItem2 = new ZedGraph.LineItem("cursorY2", xmax, y, Color.White, ZedGraph.SymbolType.None, 2);
        ZedGraph.LineItem lineItem3 = new ZedGraph.LineItem("cursorY2", xmax, y, Color.White, ZedGraph.SymbolType.None, 2);
        PointPairList  PPLmax = new PointPairList();
        PointPairList PPLmin = new PointPairList();
        PointPairList PPLLine = new PointPairList();
        PointPairList CutoffPoints = new PointPairList();
        PointPairList BriefSpectrum = new PointPairList();
        bool userdoneupdater = false;
        bool userdoneupdateralldata = false;
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
        List<List<double>> AllPicoData;
        List<List<double>> AllWsuData;
        List<List<double>> AllDl100Data;
        List<List<double>> AllValuableData;
        List<List<double>> AveragedData;
        public Form1()
        {
            
            PPLsignal = new PointPairList();
            PPLIntegralCorrect = new PointPairList();
            PPLIntegralWrong = new PointPairList();
            PPLInterferometer = new PointPairList();
            InitializeComponent();
            DA = new DataAnalysis();
            AW = new obsługaAdWina(aDwinSystem1);
            oscillo = new Oscyloskop.Form1();
            ZedSignal.GraphPane.XAxis.Title.Text = "Number of points";
            ZedSignal.GraphPane.YAxis.Title.Text = "Signal";
            OscilloSignal.GraphPane.XAxis.Title.Text = "Number of point";
            OscilloSignal.GraphPane.YAxis.Title.Text = "Voltage (mV)";
            WavemeterSignal.GraphPane.XAxis.Title.Text = "Number of point";
            WavemeterSignal.GraphPane.YAxis.Title.Text = "Intensity (a.u.)";
            ZedBriefIntegral.GraphPane.XAxis.Title.Text = "Wavenumber (cm^-1)";
            ZedBriefIntegral.GraphPane.YAxis.Title.Text = "Total integral (a.u.)";
            OscilloSignal.GraphPane.Title.Text = "PicoScope";
            WavemeterSignal.GraphPane.Title.Text = "Wavemeter";
            DataSlider.BackColor = Color.LightGray;
            GRAPHDRAWER = new ThreadStart(GraphDrawer);
            Graphdrawer = new Thread(GRAPHDRAWER);
            ZedSignal.GraphPane.CurveList.Add(lineItem1);
            ZedSignal.GraphPane.CurveList.Add(lineItem2);
            ZedBriefIntegral.GraphPane.CurveList.Add(lineItem3);
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
            lineItem3.Label.IsVisible = false;
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
            BriefSpectrum.Add(measurements.PPLSPEC);
            ZedBriefIntegral.GraphPane.AddCurve("", BriefSpectrum, Color.BlueViolet, SymbolType.Diamond);
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
                    DL100reads.Text = "DL100 status. Current: " + ScalingParameters.VoltageToCurrent(AW.odczytPrad()) + ", Temperature: " + ScalingParameters.VoltageToTemp(AW.odczytTemp());
                    ZedBriefIntegral.Update();
                    ZedBriefIntegral.AxisChange();
                    ZedBriefIntegral.Invalidate();
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
            if (DataSaverDialog.FileName == "")
            {
                MessageBox.Show("Najpierw wybierz miejsce zapisu pliku, klikając przycisk 'Save'.");
            }
            else
            {
                //if (GraphDrawingsWithoutMeasures().IsAlive)
                //{
                //    GraphDrawingsWithoutMeasures().Abort();
                //    Thread.Sleep(150);
                //}
                int x, y;
                int.TryParse(MeasuresTB.Text, out x);
                int.TryParse(AveragesTB.Text, out y);
                bool z = false;
                if (int.TryParse(MeasuresTB.Text, out x) && int.TryParse(AveragesTB.Text, out y))
                {
                    StopBtn.Enabled = true;
                    PauseBtn.Enabled = true;
                    StartBtn.Text = "Start";
                    PauseBtn.BackColor = Color.Yellow;
                    StopBtn.BackColor = Color.Red;
                    StartBtn.BackColor = Color.White;
                    Graphdrawer.Start();
                    StartTheThread(savepath, oscillo, x, y, TriggerBtnOn.Checked);
                }
                else
                {
                    MessageBox.Show("Niepoprawne parametry");
                }
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Are you sure you want to stop measurements?", "OMG YOU ARE GOING TO STOP THE MEASUREMENTS!", MessageBoxButtons.YesNo);
            if (DR == DialogResult.Yes)
                Measure.Abort();
            else
                MessageBox.Show("Measurements were not stopped");
        }
        private bool x = true;
        private void PauseBtn_Click(object sender, EventArgs e)
        {            
            if(x)
            {
                PauseBtn.Text = "Continue";
                measurements.PauseFlag = true;
                x = false;
            }
            else
            {
                PauseBtn.Text = "Pause";
                measurements.PauseFlag = false;
                x = true;
            }
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

            }
            else
                MessageBox.Show("Something went wrong..");
        }

        public async Task PicoLoad()
        {
            if (RawData.Count > 0)
                RawData.Clear();
            TestLabel.Text += "Rozpoczęto wczytywanie danych.\n";
            await Task.Run(() =>
            {
                RawData = measurements.RegexReader(loadpath, FileSeparator.Text);
            });
            TestLabel.Text += "Wczytano dane!\n";
            IntegralBtn.Enabled = true;
            IntegralBtn.BackColor = Color.LightGreen;
        }
        public async Task WSULoad()
        {
            if (RawData.Count > 0)
                RawData.Clear();
            TestLabel.Text += "Rozpoczęto wczytywanie interferometru." + Environment.NewLine;
            await Task.Run(() =>
            {
                InteferogramData = measurements.RegexReader(InteferometerPathway.FileName, FileSeparator.Text);
            });
            TestLabel.Text += "Wczytano dane!" + Environment.NewLine;
            CutOffFunction.Enabled = true;
            CutOffFunction.BackColor = Color.LightGreen;
        }
        private void LoadData_Click(object sender, EventArgs e)
        {
            PicoLoad();
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

        public Thread GraphDrawingsWithoutMeasures(bool Trigger = false)
        {
            Measure = new Thread(() => measurements.NoMeasuresJustGraphs(Trigger = false));
            Measure.Start();
            return Measure;
        }
        private bool FlagForGraph = true;
        private void CheckOne_Click(object sender, EventArgs e)
        {
            if(FlagForGraph)
            {
                GraphDrawingsWithoutMeasures();
                FlagForGraph = false;
            }
            else
            {
                try
                {
                    GraphDrawingsWithoutMeasures().Abort();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                FlagForGraph = true;
            }
        }

        private void AveragesTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void CutOffFunction_Click(object sender, EventArgs e) // COS TUTAJ NIE GRA
        {
            int Max = 0;
            double k=0, dk=0;
            int n=0, m=0;
            int ave;
            int Maxtotal = 0;
            int.TryParse(ReadFilesAveTB.Text, out ave);
            StringBuilder SBave = new StringBuilder();
            for (int i = 1; i < AllWsuData.Count(); i++)
            {
                CutoffAll.Add(DA.CutoffFunction(AllWsuData[i], double.Parse(CutoffTB.Text), int.Parse(IgnoredColumnsForInteferometer.Text)));
                Maxtotal += Max;
                using (StreamWriter SW = new StreamWriter(OpenFileDialog.FileName + "_Inteferometer", true))
                {
                    for(int j = 0; j < int.Parse(IgnoredColumnsForInteferometer.Text); j++)
                    {
                        SW.Write(AllWsuData[i][j] + " ");
                    }
                    SW.Write(i + " " + Max + " " + DA.MaximumsUncertainty(Max) + Environment.NewLine);
                    SW.Flush();
                }
                if (AllWsuData[i][3] > 12810 && AllWsuData[i][3] < 12820) // zmienic centrymetry jak cos
                {
                    k += k + AllWsuData[i][3];
                    n += 1;
                }
                if (AllWsuData[i][4] > 0)
                {
                    dk += dk + AllWsuData[i][3];
                    m += 1;
                }
                if (i % ave == 0 && i > 0 && n > 0 && m > 0)
                {
                    SBave.Append(k / n + " " + dk / m + " ");
                    k = n = m = 0;
                    dk = 0;
                }
                if (i % ave == 0 && i > 0)
                    SBave.Append(Maxtotal / ave + Environment.NewLine);
            }
            using (StreamWriter SW = new StreamWriter(OpenFileDialog.FileName + "_InteferometerAverages", true))
                SW.Write(SBave);
        }

        private void FindInterferogram_Click(object sender, EventArgs e)
        {
            InteferometerPathway.ShowDialog();
            if(InteferometerPathway != null)
            {
                InteferometerSlider.Enabled = true;
                InteferometerSlider.BackColor = Color.PaleGreen;
                LoadInteferometer.Enabled = true;
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            WSULoad();
        }

        private void InteferometerPathway_FileOk(object sender, CancelEventArgs e)
        {
            if (InteferometerPathway.FileName != null)
            { 
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
            int IgnoredColumnsForData, IgnoredColumsForInterferometer;
            int.TryParse(IgnoredColumsForData.Text, out IgnoredColumnsForData);
            int.TryParse(IgnoredColumnsForInteferometer.Text, out IgnoredColumsForInterferometer);
            measurements.RegexReaderForSingleFile(out AllPicoData,out AllWsuData, out AllDl100Data, OpenFileDialog.FileName, ":", 0, 0);
            HowManyAverages = AllPicoData.Count() / AllDl100Data.Count();
            DataSlider.Maximum = AllDl100Data.Count();
            InteferometerSlider.Maximum = AllWsuData.Count();
            InteferometerSlider.Minimum = 1;
            DataSlider.Minimum = 1;
            double THmin = 0, THmax = 0;
            double.TryParse(THmaxTB.Text, out THmax);
            double.TryParse(THminTB.Text, out THmin);
            DA.DataSummary(out AllValuableData, AllPicoData, AllWsuData, AllDl100Data, THmin, THmax, IgnoredColumsForInterferometer, IgnoredColumnsForData);
            DA.Average(out AveragedData, AllValuableData);
            DataAnalysisTrackBar.Minimum = 0;
            MessageBox.Show(AllValuableData.Count.ToString());
            DataAnalysisTrackBar.Maximum = AllValuableData.Count() -1;
            PointPairList AllDataPPL = new PointPairList();
            for (int i = 0; i < AllValuableData.Count; i++)
            {
                AllDataPPL.Add(AllValuableData[i][7], AllValuableData[i][6]);
            }
            ZedBriefIntegral.GraphPane.CurveList.Clear();
            ZedBriefIntegral.GraphPane.AddCurve("", AllDataPPL, Color.Black, SymbolType.None);
            ZedBriefIntegral.Update();
            ZedBriefIntegral.AxisChange();
            ZedBriefIntegral.Invalidate();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
        }

        private void DataAnalysisTrackBar_ValueChanged(object sender, EventArgs e)
        {
            userdoneupdateralldata = true;
        }

        private void DataAnalysisTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (userdoneupdateralldata)
            {
                DL100Label.Text = AllValuableData[DataAnalysisTrackBar.Value][0].ToString() + " " + AllValuableData[DataAnalysisTrackBar.Value][1].ToString() + " " + AllValuableData[DataAnalysisTrackBar.Value][2].ToString();
                ZedInteferogram.AxisChange();
                ZedInteferogram.Update();
                ZedInteferogram.Invalidate();
            }
        }

        private void DataAnalysisTrackBar_Scroll(object sender, EventArgs e)
        {
            PPLLine.Clear();
            PPLLine.Add(TrackMax.Value, ZedBriefIntegral.GraphPane.YAxis.Scale.Min);
            PPLLine.Add(TrackMax.Value, ZedBriefIntegral.GraphPane.YAxis.Scale.Max);
            //LineItem LImax = ZedSignal.GraphPane.AddCurve("LImax", PPLmax, Color.Orange);
            lmax = ZedBriefIntegral.GraphPane.AddCurve("LImax", PPLLine, Color.Orange);
            //LImax.Label.IsVisible = false;
            lmax.Label.IsVisible = false;
            ZedBriefIntegral.AxisChange();
            ZedBriefIntegral.Update();
            ZedBriefIntegral.Invalidate();
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
                CurrentInteferometer = AllWsuData[InteferometerSlider.Value];
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
            if (OpenFileDialog.FileName != null)
            {
                LoadData.Enabled = true;
                DataSlider.Enabled = true;
                TrackMin.Enabled = true;
                TrackMax.Enabled = true;
                DataSlider.BackColor = Color.PaleGreen;
                TrackMin.BackColor = Color.LightBlue;
                TrackMax.BackColor = Color.LightBlue;
                PathToFileLabel.Text = "Path: " + OpenFileDialog.FileName;
            }
        }

        private void DataSlider_ValueChanged(object sender, EventArgs e)
        {
            userdoneupdater = true;
        }

        private void IntegralBtn_Click(object sender, EventArgs e) // INTEGRAL to samo co w check
        {
            PointPairList PPL;
            ZedIntegral.GraphPane.CurveList.Clear();
            ZedIntegral.GraphPane.GraphObjList.Clear();
            PointPairList PPLCorrect = new PointPairList();
            PointPairList PPLNotCorrect = new PointPairList();
            StringBuilder SB = new StringBuilder();
            StringBuilder SBAve = new StringBuilder();
            List<List<double>> AveragesOnIntegral = new List<List<double>> { };
            Integral = measurements.IntegralOnLists(AllPicoData, TrackMin.Value, TrackMax.Value);
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
            int m;
            if (int.TryParse(ReadFilesAveTB.Text, out m) && m > 1)
            {
                AveragesOnIntegral = measurements.IntegralOnListsAverages(RawData, TrackMin.Value, TrackMax.Value,m);
                for (int i = 0; i < AveragesOnIntegral.Count(); i++)
                {
                    for (int j = 0; j < AveragesOnIntegral[i].Count; j++)
                    {
                        SBAve.Append(AveragesOnIntegral[i][j] + " ");
                    }
                    SBAve.Append("\n");
                }
            }
            using (StreamWriter SW = new StreamWriter(loadpath + "_Integral")) { SW.Write(SB); }
            using (StreamWriter SW = new StreamWriter(loadpath + "_IntegralAveraged")) { SW.Write(SBAve); }
            LineItem CorrectCurve = ZedIntegral.GraphPane.AddCurve("Correct measured points", PPLCorrect, Color.Green, SymbolType.Circle);
            //LineItem IncorrectCurve = ZedIntegral.GraphPane.AddCurve("Incorrect measured points", PPLNotCorrect, Color.Red, SymbolType.Plus);
            CorrectCurve.Line.IsVisible = false;
            //IncorrectCurve.Line.IsVisible = false;
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
                CurrentWave = AllPicoData[DataSlider.Value];
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
