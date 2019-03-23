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

namespace NewOscylMeasSoft
{
    class Measurements
    {
        Oscyloskop.Form1 oscillo = new Oscyloskop.Form1();
        Form1 form1 = new Form1();
        NewOscylMeasSoft.Form1 MAIN = new NewOscylMeasSoft.Form1();
        List<List<double>> WaveformArray, Integral = null;
        EventWaitHandle FileSaving, FileFree;


        public void GatherWaveforms(string FilePath1, Oscyloskop.Form1 oscillo, int NumberOfMeasures = 500, int NumberOfPointsPerWF = 2048, bool pause = false, bool STOP = false, bool Trigger = false, int ChannelTrig = 0, int ChannelSig = 0)
        {
            int MeasureLoopIndicator;
            int i;
            bool WARNING;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StringBuilder SB = new StringBuilder();
            Stopwatch Stopwatch = new Stopwatch();
            double Wavenumber =0;
            Stopwatch.Start();
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures; MeasureLoopIndicator++)
            {
                WaveformArray.Add(oscillo.odczyt()[0]); // Poprawić kanał w razie czego TO JEST WAZNE
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
                SB.Append("\r\n");
                WaveformArray.Clear();
                
                if (MeasureLoopIndicator % 50 == 0 || NumberOfMeasures - MeasureLoopIndicator < 50)
                {
                    using (StreamWriter SW = new StreamWriter(FilePath1, true))
                    {
                        SW.Write(SB);
                        SW.Flush();
                    }
                    SB.Clear();
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

        public List<List<double>> JustReadingData(string FilePath1)
        {
            int i, last = 0;
            double converter;
            string DataInBetween;
            List<double> temp = new List<double>();
            List<List<double>> ReadData = new List<List<double>>();
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
                            ReadData.Add(temp);
                        }
                    }
                }
            }
            stopwatch.Stop();
            MessageBox.Show("Done" + stopwatch.ElapsedMilliseconds);
            return Integral;
        }
    }
}

