﻿using System;
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
        List<List<double>> WaveformArray;
        EventWaitHandle FileSaving, FileFree;
        public struct MeasurementParameters
        {
            string FilePath1;
            int NumberOfMeasures;
            int NumberOfPointsPerWF;
            bool pause;
            bool STOP;
            bool Trigger;
            int ChannelTrig;
            int ChannelSig;
        }
        public void GatherWaveforms(string FilePath1, int NumberOfMeasures = 500, int NumberOfPointsPerWF = 2048, bool pause = false, bool STOP = false, bool Trigger = false, int ChannelTrig = 0, int ChannelSig = 0)
        {
            int MeasureLoopIndicator;
            int i;
            bool WARNING;
            WaveformArray = new List<List<double>>();
            List<double> temp = new List<double>();
            StreamWriter SW = new StreamWriter(FilePath1);
            StringBuilder SB = new StringBuilder();
            double Wavenumber =0;
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures; MeasureLoopIndicator++)
            {

                WaveformArray.Add(oscillo.odczyt()[0]); // Poprawić kanał w razie czego TO JEST WAZNE
               /* WaveformArray = new List<List<double>> TYLKO DO TESTÓW, NIE MA ZNACZENIA JAK COS TO WYJEBAC
            { new List<double> { 1,2 },
            new List<double> { 3,4 },
            new List<double> { 5,6 }};*/
                if (Wavecontrol.ReadCM() > 0) //Zabezpieczenie błędu z odczytem długości fali
                {
                    Wavenumber = Wavecontrol.ReadCM();
                    WARNING = false;
                }
                else
                    WARNING = true;
                SB.Append(Wavenumber + ":");
                for (i = 0; i < WaveformArray[0].Count; i++)// TUTAJ moze byc bubel zwiazany z iloscia elementów (dać -1 jak cos)
                {
                    SB.Append(WaveformArray[0][i] + ":");
                }
                if (WARNING == true) // Jeśli ostatni element listy jest równy -1, to oznacza że był problem z odczytem długości fali i założono 
                    SB.Append("-1");
                SB.Append("\r\n");
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
            SW.Close();
        }

        public List<double> LoadGatheredWaveforms(string FilePath1, int ReadLineNumber)
        {
            
            List<double> temp = new List<double>();
            StreamReader SR = File.OpenText(FilePath1);
            var ReadLine = File.ReadLines(FilePath1).Skip(ReadLineNumber - 1).FirstOrDefault();
            string LineText = ReadLine.ToString();
           // MessageBox.Show("" + LineText + "   " + LineText.ElementAt(4));
            LineText.ElementAt(1);
            string DataInBetween;
            int i, last=0, j = 1;
            double converter;
            for( i = 0; i <= LineText.Length - 1; i++)
            {
               if(LineText.ElementAt(i) == ':' || i == LineText.Length - 1)
                {
                    if(i == LineText.Length - 1)
                    {
                        i = LineText.Length;
                    }
                    
                    DataInBetween = LineText.Substring(last, i - last);
                    MessageBox.Show("" + DataInBetween);
                    converter = double.Parse(DataInBetween);
                    temp.Add(converter);
                    last = i + 1;
                }

            }
            SR.Close();
            return temp;
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
                for (j = 0; From + i <= To; j++)
                {
                    LocalIntegral = LocalIntegral + Temp[From + i];
                }
                Wavenumber = Temp[0];
                Integral.Add(new List<double> {Wavenumber,LocalIntegral,Temp.Last()});
            }
            return Integral;
        }
    }
}
