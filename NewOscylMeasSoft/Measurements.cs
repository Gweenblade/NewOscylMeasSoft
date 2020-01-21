using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;
using System.IO;
using Laser;
using Oscyloskop;
using CsvHelper;
using System.Text.RegularExpressions;

namespace NewOscylMeasSoft
{
    class Measurements
    {
        Oscyloskop.Form1 oscillo = new Oscyloskop.Form1();
        Form1 form1 = new Form1();
        NewOscylMeasSoft.Form1 MAIN = new NewOscylMeasSoft.Form1();
        List<List<double>> WaveformArray, Integral = null;
        public static EventWaitHandle EWHprzestroj, EWHustawiono, EWHbreak, EWHendoftuning, EWHstart, PICOready, WSUready;
        obslugaNW WSU = new obslugaNW();
        public double IntegralPico;
        public double CurrentWavelenght;
        public PointPairList PPLWSU = new PointPairList();
        public PointPairList PPLPIC = new PointPairList();
        public PointPairList PPLSPEC = new PointPairList();
        public bool DrawTheGraph = false, WSUmarker = false, PICOmarker = false;
        public double SUMPICO;
        private bool pauseflag = false;
        private bool InterferometerReading = false;

        public bool PauseFlag
        {
            get { return pauseflag; }
            set { pauseflag = PauseFlag; }
        }
        public void PicoMeasures(string FilePath, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 10000, int Averages = 10, bool TriggerBtn = false)
        {

            EWHustawiono = new EventWaitHandle(false, EventResetMode.AutoReset, "USTAWIONO");
            EWHprzestroj = new EventWaitHandle(false, EventResetMode.AutoReset, "PRZESTROJ");
            EWHbreak = new EventWaitHandle(false, EventResetMode.AutoReset, "ZATRZYMAJ");
            EWHendoftuning = new EventWaitHandle(false, EventResetMode.AutoReset, "KONIEC");
            PICOready = new EventWaitHandle(false, EventResetMode.AutoReset, "PICOready");
            WSUready = new EventWaitHandle(false, EventResetMode.AutoReset, "WSUready");
            // EWHstart = new EventWaitHandle(false, EventResetMode.AutoReset, "START");
            int MeasureLoopIndicator;
            int i;
            bool WARNING, Ender = false;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StringBuilder SB = new StringBuilder();
            Stopwatch Stopwatch = new Stopwatch();
            double SUMPICO;
            long SW1, SW2, SW3;
            Stopwatch.Start();
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures || TriggerBtn == true; MeasureLoopIndicator++)
            {
                if (TriggerBtn == true)
                {
                    EWHprzestroj.Set();
                    EWHustawiono.WaitOne();
                }
                for (int j = 0; j < Averages; j++)
                {
                    if(PauseFlag == true)
                    {
                        Thread.Sleep(50);
                    }
                    SW1 = Stopwatch.ElapsedMilliseconds;
                    if(TriggerBtn == true)
                    {
                        PICOready.Set();
                        WSUready.WaitOne();
                    }
                    WaveformArray.Add(oscillo.odczyt()[0]);
                    IntegralPico = WaveformArray[0].Sum();
                    SW2 = Stopwatch.ElapsedMilliseconds;
                    PPLPIC.Clear();
                    SB.Append(SW1 + ":" + SW2 + ":");
                    for (i = 0; i < WaveformArray[0].Count; i++)
                    {
                        SB.Append(WaveformArray[0][i] + ":");
                        PPLPIC.Add(i, WaveformArray[0][i]);
                    }
                    WaveformArray.Clear();
                    SB.Append("\r\n");
                    i = 0;
                    DrawTheGraph = true;
                    if (EWHbreak.WaitOne(1) || EWHendoftuning.WaitOne(1))
                    {
                        Ender = true;
                    }
                    if (MeasureLoopIndicator % 5 == 0 || NumberOfMeasures - MeasureLoopIndicator < 50 || Ender == true)
                    {
                        using (StreamWriter SW = new StreamWriter(FilePath + "PICO", true))
                        {
                            SW.Write(SB);
                            SW.Flush();
                        }
                        SB.Clear();
                    }
                }
                if (Ender == true)
                {
                    MessageBox.Show("Koniec pomiaru");
                    break;
                }
            }
            Stopwatch.Stop();
            MessageBox.Show("Koniec");
        }

        public void WSUmeasures(string FilePath, int NumberOfMeasures = 10000, int Averages = 10, bool TriggerBtn = false)
        {
            EWHustawiono = new EventWaitHandle(false, EventResetMode.AutoReset, "USTAWIONO");
            EWHprzestroj = new EventWaitHandle(false, EventResetMode.AutoReset, "PRZESTROJ");
            EWHbreak = new EventWaitHandle(false, EventResetMode.AutoReset, "ZATRZYMAJ");
            EWHendoftuning = new EventWaitHandle(false, EventResetMode.AutoReset, "KONIEC");
            PICOready = new EventWaitHandle(false, EventResetMode.AutoReset, "PICOready");
            WSUready = new EventWaitHandle(false, EventResetMode.AutoReset, "WSUready");
            // EWHstart = new EventWaitHandle(false, EventResetMode.AutoReset, "START");
            int MeasureLoopIndicator;
            int i;
            bool WARNING, Ender = false;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StringBuilder SBWSU = new StringBuilder();
            Stopwatch Stopwatch = new Stopwatch();
            double Wavenumber = 0;
            long SW1, SW2, SW3;
            Stopwatch.Start();
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures || TriggerBtn == true; MeasureLoopIndicator++)
            {
                if (TriggerBtn)
                {
                    EWHprzestroj.Set();
                    EWHustawiono.WaitOne();
                }
                for (int j = 0; j < Averages; j++)
                {
                    if (TriggerBtn)
                    {
                        WSUready.Set();
                        PICOready.WaitOne();
                    }
                    SW2 = Stopwatch.ElapsedMilliseconds;
                    var x = obslugaNW.odczytajPrazkiPierwszyIntenf();
                    SW3 = Stopwatch.ElapsedMilliseconds;
                    PPLWSU.Clear();
                    SBWSU.Append(SW2 + ":" + SW3 + ":");
                    SBWSU.Append(obslugaNW.odczytNowegoWMcm(false) + ":" + obslugaNW.odczytszerokosci() + ":");
                    CurrentWavelenght = obslugaNW.odczytNowegoWMcm(false);
                    i = 0;
                    foreach (var z in x)
                    {
                        SBWSU.Append(z.ToString() + ":");
                        PPLWSU.Add(i, z);
                        i++;
                    }
                    DrawTheGraph = true;
                    SBWSU.Append("\r\n");
                    if (EWHbreak.WaitOne(1) || EWHendoftuning.WaitOne(1))
                    {
                        Ender = true;
                    }
                    if (MeasureLoopIndicator % 5 == 0 || NumberOfMeasures - MeasureLoopIndicator < 50 || Ender == true)
                    {
                        using (StreamWriter SW = new StreamWriter(FilePath + "WSU", true))
                        {
                            SW.Write(SBWSU);
                            SW.Flush();
                        }
                        SBWSU.Clear();
                    }

                }
                if (Ender == true)
                {
                    MessageBox.Show("Koniec pomiaru");
                    break;
                }
            }
            Stopwatch.Stop();
            MessageBox.Show("Koniec");
        }

        public void OnlyOscilloMeasurements(string FilePath1, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 10000, int Averages = 10, bool TriggerBtn = false)
        {
            int MeasureLoopIndicator;
            int i;
            bool WARNING, Ender = false;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StringBuilder SB = new StringBuilder();
            StringBuilder SBWSU = new StringBuilder();
            Stopwatch Stopwatch = new Stopwatch();
            double Wavenumber = 0, SUMPICO;
            long SW1, SW2;
            Stopwatch.Start();
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures; MeasureLoopIndicator++)
            {
                for (int j = 0; j < Averages; j++)
                {
                    SW1 = Stopwatch.ElapsedMilliseconds;
                    WaveformArray.Add(oscillo.odczyt()[0]);
                    SW2 = Stopwatch.ElapsedMilliseconds;
                    PPLPIC.Clear();
                    SB.Append(SW1 + ":" + SW2 + ":");
                    for (i = 0; i < WaveformArray[0].Count; i++)
                    {
                        SB.Append(WaveformArray[0][i] + ":");
                        PPLPIC.Add(i, WaveformArray[0][i]);
                    }
                    SUMPICO = WaveformArray[0].Sum();
                    WaveformArray.Clear();
                    SB.Append("\r\n");
                    i = 0;
                    DrawTheGraph = true;
                    if (EWHbreak.WaitOne(1) || EWHendoftuning.WaitOne(1))
                    {
                        Ender = true;
                    }
                    if (MeasureLoopIndicator % 5 == 0 || NumberOfMeasures - MeasureLoopIndicator < 50 || Ender == true)
                    {
                        using (StreamWriter SW = new StreamWriter(FilePath1 + "PICO", true))
                        {
                            SW.Write(SB);
                            SW.Flush();
                        }
                        SB.Clear();
                    }

                }
                if (Ender == true)
                {
                    MessageBox.Show("Koniec pomiaru");
                    break;
                }
            }
            Stopwatch.Stop();
            MessageBox.Show("Koniec");
        }
        
        private async Task<List<double>> GetWaveformAsync()
        {
            List<double> list = await Task.Run(() => oscillo.odczyt()[0]);
            return list;
        }

        private async Task<Array> GetInteferometer()
        {
            Array x = await Task.Run(() => obslugaNW.odczytajPrazkiPierwszyIntenf());
            InterferometerReading = true;
            return x;
        }
        public async void GatherWaveforms(string FilePath1, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 10000, int Averages = 10, bool TriggerBtn = false)
        {

            EWHustawiono = new EventWaitHandle(false, EventResetMode.AutoReset, "USTAWIONO");
            EWHprzestroj = new EventWaitHandle(false, EventResetMode.AutoReset, "PRZESTROJ");
            EWHbreak = new EventWaitHandle(false, EventResetMode.AutoReset, "ZATRZYMAJ");
            EWHendoftuning = new EventWaitHandle(false, EventResetMode.AutoReset, "KONIEC");
           // EWHstart = new EventWaitHandle(false, EventResetMode.AutoReset, "START");
            int MeasureLoopIndicator;
            int i;
            short[] interferometer = new short[2048];
            bool WARNING, Ender = false;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StringBuilder SB = new StringBuilder();
            StringBuilder SBWSU = new StringBuilder();
            Stopwatch Stopwatch = new Stopwatch();
            double Wavenumber = 0;
            long SW1, SW2, SW3;
            Stopwatch.Start();
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures || TriggerBtn == true; MeasureLoopIndicator++)
            {
                if (TriggerBtn == true)
                {
                    EWHprzestroj.Set();
                    EWHustawiono.WaitOne();
                }
                for (int j = 0; j < Averages; j++)
                {
                    SW1 = Stopwatch.ElapsedMilliseconds;
                    //var x = await GetInteferometer();
                    Task<Array> d = GetInteferometer();
                    SW2 = Stopwatch.ElapsedMilliseconds;
                    WaveformArray.Add(oscillo.odczyt()[0]);
                    var x = await d;
                    // WaveformArray.Add(await GetWaveformAsync());
                    // var x = obslugaNW.odczytajPrazkiPierwszyIntenf();
                    SW3 = Stopwatch.ElapsedMilliseconds;
                    PPLWSU.Clear();
                    PPLPIC.Clear();
                    SB.Append(SW1 + ":" + SW2 + ":");
                    SBWSU.Append(SW2 + ":" + SW3 + ":");
                    //while (!InterferometerReading) { }
                    InterferometerReading = false;
                    for (i = 0; i < WaveformArray[0].Count; i++)
                    {
                        SB.Append(WaveformArray[0][i] + ":");
                        PPLPIC.Add(i, WaveformArray[0][i]);
                    }
                    SUMPICO = WaveformArray[0].Sum();
                    WaveformArray.Clear();
                    SB.Append("\r\n");
                    SBWSU.Append(obslugaNW.odczytNowegoWMcm(false) + ":" + obslugaNW.odczytszerokosci() + ":");
                    i = 0;
                    foreach (var z in x)
                    {
                        SBWSU.Append(z.ToString() + ":");
                        PPLWSU.Add(i, (double) z); // TUTAJ DODALEM CASTA
                        i++;
                    }
                    
                    if (obslugaNW.odczytNowegoWMcm(false) > 0 && obslugaNW.odczytNowegoWMcm(false) < 20000)// usunac true jak działa
                        PPLSPEC.Add(obslugaNW.odczytNowegoWMcm(false), SUMPICO);
                    DrawTheGraph = true;
                    SBWSU.Append("\r\n");
                    if (EWHbreak.WaitOne(1) || EWHendoftuning.WaitOne(1))
                    {
                        Ender = true;
                    }
                    if (MeasureLoopIndicator % 5 == 0 || NumberOfMeasures - MeasureLoopIndicator < 50 || Ender == true)
                    {
                        using (StreamWriter SW = new StreamWriter(FilePath1 + "PICO", true))
                        {
                            SW.Write(SB);
                            SW.Flush();
                        }
                        using (StreamWriter SW = new StreamWriter(FilePath1 + "WSU", true))
                        {
                            SW.Write(SBWSU);
                            SW.Flush();
                        }
                        SB.Clear();
                        SBWSU.Clear();
                    }

                }
                if(Ender)
                {
                    MessageBox.Show("Koniec pomiaru");
                    break;
                }
            }
            Stopwatch.Stop();
            MessageBox.Show("Koniec");
        }

        public async void NoMeasuresJustGraphs(bool TriggerBtn = false)
        {
            EWHustawiono = new EventWaitHandle(false, EventResetMode.AutoReset, "USTAWIONO");
            EWHprzestroj = new EventWaitHandle(false, EventResetMode.AutoReset, "PRZESTROJ");
            EWHbreak = new EventWaitHandle(false, EventResetMode.AutoReset, "ZATRZYMAJ");
            EWHendoftuning = new EventWaitHandle(false, EventResetMode.AutoReset, "KONIEC");
            // EWHstart = new EventWaitHandle(false, EventResetMode.AutoReset, "START");
            bool WARNING, Ender = false;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StringBuilder SB = new StringBuilder();
            StringBuilder SBWSU = new StringBuilder();
            Stopwatch Stopwatch = new Stopwatch();
            double Wavenumber = 0;
            long SW1, SW2, SW3;
            Stopwatch.Start();
            for (;true;)
            {
                if (TriggerBtn == true)
                {
                    EWHprzestroj.Set();
                    EWHustawiono.WaitOne();
                }
                var x = await Task.Run(() => obslugaNW.odczytajPrazkiPierwszyIntenf());
                WaveformArray.Add(oscillo.odczyt()[0]);
                PPLWSU.Clear();
                PPLPIC.Clear();
                InterferometerReading = false;
                int i;
                for (i = 0; i < WaveformArray[0].Count; i++)
                {
                    PPLPIC.Add(i, WaveformArray[0][i]);
                }
                WaveformArray.Clear();
                i = 0;
                foreach (var z in x)
                {
                    PPLWSU.Add(i, (double)z); // TUTAJ DODALEM CASTA
                    i++;
                }
                DrawTheGraph = true;
                if (EWHbreak.WaitOne(1) || EWHendoftuning.WaitOne(1))
                {
                    Ender = true;
                }
                if (Ender)
                {
                    MessageBox.Show("Koniec pomiaru");
                    break;
                }
            }
            Stopwatch.Stop();
        }
        public List<double> LoadGatheredWaveforms(string FilePath1, int ReadLineNumber)
        {
            using (StreamReader SR = File.OpenText(FilePath1))
            {
                List<double> temp = new List<double>();
                var ReadLine = File.ReadLines(FilePath1).Skip(ReadLineNumber - 1).FirstOrDefault();
                string LineText = ReadLine.ToString();
                // MessageBox.Show("" + LineText + "   " + LineText.ElementAt(4));
                LineText.ElementAt(1);
                string DataInBetween;
                int i, last = 0, j = 1;
                double converter = 0;
                int indexfordelete;
                for (i = 0; i < LineText.Length - 1; i++)
                {
                    if (LineText.ElementAt(i) == ':' || i == LineText.Length - 1)
                    {
                        if (i == LineText.Length - 1)
                        {
                            i = LineText.Length;
                        }

                        DataInBetween = LineText.Substring(last, i - last);

                        //MessageBox.Show("" + DataInBetween);
                        converter = double.Parse(DataInBetween);
                        temp.Add(converter);
                        last = i + 1;
                    }

                }
                SR.Close();
                return temp;
            }
        }

        public List<List<double>> IntegralCalculator(string FilePath1,int From, int To,int filelenght)
        {
            List<List<double>> Integral = new List<List<double>>();
            List<double> Temp = new List<double>();
            int i,j;
            double LocalIntegral = 0;
            double Wavenumber;
            for (i = 0; i < filelenght - 1; i++)
            {
                Temp = LoadGatheredWaveforms(FilePath1, i);
                for (j = 0; From + j <= To; j++)
                {
                    LocalIntegral = LocalIntegral + Temp[From + j];
                }
                Wavenumber = Temp[0];
                Integral.Add(new List<double> {Wavenumber,LocalIntegral,Temp.Last()});
            }
            return Integral;
        }

        public List<List<double>> FixedIntegral(string FilePath1, int From, int To)
        {
            int i, last = 0;
            double converter;
            string DataInBetween;
            List<double> temp = new List<double>();
            List<List<double>> ReadData = new List<List<double>>();
            List<List<double>> Integral = new List<List<double>>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream FS = File.Open(FilePath1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream BS = new BufferedStream(FS))
                {
                    using (StreamReader SR = new StreamReader(BS))
                    {
                        string line;
                        while ((line = SR.ReadLine()) != null)
                        {
                            last = 0;
                            for (i = 0; i < line.Length - 1; i++)
                            {
                                if (line.ElementAt(i) == ':' || i == line.Length - 1)
                                {
                                    if (i == line.Length - 1)
                                    {
                                        i = line.Length;
                                    }
                                    DataInBetween = line.Substring(last, i - last);
                                    converter = double.Parse(DataInBetween);
                                    temp.Add(converter);
                                    last = i + 1;
                                }
                            }
                            Integral.Add(new List<double> {temp[0], temp.Skip(From - 1).Take(To).Sum() });
                        }
                    }
                }
            }
            stopwatch.Stop();
            MessageBox.Show("Done" + stopwatch.ElapsedMilliseconds);
            return Integral;
        }


        public List<List<double>> RegexReader(string FilePath1, string Separator, int IgnoredColumns = 0) // DO DALSZEJ DIAGNOSTKI.
        {
            string line;
            List<List<double>> ReadDataInDoubles = new List<List<double>>();
            string[] Test;
            int i, j;
            List<string> StringList = new List<string>();
            List<double> DoubleList = new List<double>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream FS = File.Open(FilePath1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream BS = new BufferedStream(FS))
                {
                    using (StreamReader SR = new StreamReader(BS))
                    {
                        while ((line = SR.ReadLine()) != null)
                        {
                            StringList = Regex.Split(line, Separator).ToList();
                            for (i = IgnoredColumns; i < StringList.Count - 1; i++)
                            {
                               DoubleList.Add(double.Parse(StringList[i]));
                            }
                            ReadDataInDoubles.Add(DoubleList);
                            DoubleList = new List<double>();
                            StringList = new List<string>();
                        }
                    }
                }
            }
            stopwatch.Stop();
            return ReadDataInDoubles;
        }

        public List<List<double>> IntegralOnLists(List<List<double>> RawData,int From,int To)
        {
            List<List<double>> IntegralData = new List<List<double>>();
            int HowMany = To - From;
            double Average;
            for (int i = 0; i < RawData.Count; i++)
            {
                Average = RawData[i].Skip(From - 1).Take(HowMany).Sum() / HowMany;
                IntegralData.Add(new List<double> { RawData[i][0], RawData[i].Skip(From - 1).Take(HowMany).Sum() , Average});
            }
            return IntegralData;
        }
        public List<double> SingleLineReader(string FilePath, int ReadLineNumber, int IgnoredColumns = 0)
        {
            List<double> temp = new List<double>();
            List<string> StringList = new List<string>();
            using (FileStream FS = File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream BS = new BufferedStream(FS))
                {
                    using (StreamReader SR = new StreamReader(BS))
                    {
                        var ReadLine = File.ReadLines(FilePath).Skip(ReadLineNumber - 1).FirstOrDefault();
                        StringList = Regex.Split(ReadLine, ":").ToList();
                        for (int i = IgnoredColumns; i < StringList.Count - 1; i++)
                            temp.Add(double.Parse(StringList[i]));
                    }
                }
            }
        return temp;
        }
    }
}

