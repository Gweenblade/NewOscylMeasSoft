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
        public static EventWaitHandle EWHprzestroj, EWHustawiono, EWHbreak, EWHendoftuning, EWHstart;
        obslugaNW WSU = new obslugaNW();
        public PointPairList PPLWSU = new PointPairList();
        public PointPairList PPLPIC = new PointPairList();
        public bool DrawTheGraph = false;

        private void WavemeterReadings(string FilePath1, int NumberOfMeasures = 500)
        {
            int i = 0;
        }
        public void GatherWaveforms(string FilePath1, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 10000, int Averages = 10, bool TriggerBtn = false)
        {

            EWHustawiono = new EventWaitHandle(false, EventResetMode.AutoReset, "USTAWIONO");
            EWHprzestroj = new EventWaitHandle(false, EventResetMode.AutoReset, "PRZESTROJ");
            EWHbreak = new EventWaitHandle(false, EventResetMode.AutoReset, "ZATRZYMAJ");
            EWHendoftuning = new EventWaitHandle(false, EventResetMode.AutoReset, "KONIEC");
           // EWHstart = new EventWaitHandle(false, EventResetMode.AutoReset, "START");
            int MeasureLoopIndicator;
            int i;
            bool WARNING, Ender = false;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StringBuilder SB = new StringBuilder();
            StringBuilder SBWSU = new StringBuilder();
            Stopwatch Stopwatch = new Stopwatch();
            double Wavenumber = 0;
            Stopwatch.Start();
            EWHprzestroj.Set();
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures || TriggerBtn == true; MeasureLoopIndicator++)
            {
                if (TriggerBtn == true)
                {
                    EWHustawiono.WaitOne();
                }
                for (int j = 0; j < Averages; j++)
                {
                    WaveformArray.Add(oscillo.odczyt()[0]);
                    var x = obslugaNW.odczytajPrazkiPierwszyIntenf();
                    PPLWSU.Clear();
                    PPLPIC.Clear();
                    SB.Append(Stopwatch.ElapsedMilliseconds + ":");
                    SBWSU.Append(Stopwatch.ElapsedMilliseconds + ":");
                    for (i = 0; i < WaveformArray[0].Count; i++)
                    {
                        SB.Append(WaveformArray[0][i] + ":");
                        PPLPIC.Add(i, WaveformArray[0][i]);
                    }
                    WaveformArray.Clear();
                    SB.Append("\r\n");
                    SBWSU.Append(obslugaNW.odczytNowegoWMcm(false) + ":" + obslugaNW.odczytszerokosci() + ":");
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
                    if (MeasureLoopIndicator % 50 == 0 || NumberOfMeasures - MeasureLoopIndicator < 50 || Ender == true)
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
                    if (TriggerBtn == true)
                    {
                        EWHprzestroj.Set();
                    }
                }

                if(Ender == true)
                {
                    MessageBox.Show("Koniec pomiaru");
                    break;
                }

            }
            Stopwatch.Stop();
            MessageBox.Show("Koniec");
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

