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
        List<List<double>> WaveformArray;
        EventWaitHandle FileSaving, FileFree;
        public void GatherWaveforms(string FilePath1, int NumberOfMeasures = 500, int NumberOfPointsPerWF = 2048, bool pause = false, bool STOP = false, bool Trigger = false, int ChannelTrig = 0, int ChannelSig = 0)
        {
            int MeasureLoopIndicator;
            int i;
            bool WARNING;
            List<double> temp = WaveformArray[NumberOfPointsPerWF];
            StreamWriter SW = new StreamWriter(FilePath1);
            StringBuilder SB = new StringBuilder();
            var csv = new CsvWriter(SW);
            double Wavenumber =0;
            for (MeasureLoopIndicator = 0; MeasureLoopIndicator < NumberOfMeasures; MeasureLoopIndicator++)
            {

                WaveformArray.Add(oscillo.odczyt()[0]);
                if (Wavecontrol.ReadCM() > 0) //Zabezpieczenie błedu
                {
                    Wavenumber = Wavecontrol.ReadCM();
                    SB.Append(MeasureLoopIndicator + ":" + Wavenumber + ":");
                    WARNING = false;
                }
                else
                {
                    SB.Append(MeasureLoopIndicator + ":" + Wavenumber + ":");
                    WARNING = true;
                }
                temp = WaveformArray[NumberOfPointsPerWF];
                for (i = 0; i < temp.Count; i++)
                {
                    SB.Append(temp[i] + ":");
                }
                if (WARNING == true)
                    SB.Append("-1");
                SB.Append("\r\n");


                if (MeasureLoopIndicator % 50 == 0)
                {
                    //SW.Write(SB);
                    csv.WriteRecords(WaveformArray);

                    SB.Clear();
                }
                if (NumberOfMeasures - MeasureLoopIndicator < 50)
                {
                    //SW.Write(SB);
                    SB.Clear();
                }
            
            //FilePath.Close();
            }
        }

        public List<double> LoadGatheredWaveforms(string FilePath1, int ReadLineNumber)
        {
            
            List<double> temp = new List<double>();
            foreach (double item in temp)
            {
                // Do something with item
            }
            StreamReader SR = File.OpenText(FilePath1);
            var ReadLine = File.ReadLines(FilePath1).Skip(ReadLineNumber - 1).FirstOrDefault();
            string LineText = ReadLine.ToString();
           // MessageBox.Show("" + LineText + "   " + LineText.ElementAt(4));
            LineText.ElementAt(1);
            string DataInBetween;
            int i, last=0, j = 1;
            double converter,wavelenght = 0;
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
            return temp;
        }
    }
}
