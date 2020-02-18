using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewOscylMeasSoft
{
    class DataAnalysis
    {
        public List<double> CutoffFunction(List<double> WSUsignal, double CutoffValue, int IgnoredColumns = 0)
        {
            List<double> NEWLIST = new List<double>();
            for (int j = IgnoredColumns; j < WSUsignal.Count(); j++)
            {
                NEWLIST.Add(WSUsignal[j]);
            }
            double Max = NEWLIST.Max();
            for (int i = 0; i < NEWLIST.Count; i++)
            {
                NEWLIST[i] = NEWLIST[i] - (CutoffValue / 100 * Max);
                if (NEWLIST[i] < 0)
                    NEWLIST[i] = 0;
            }
            return NEWLIST;
        }
        public int MaximumsCounter(List<double> CutoffArray)
        {
            int CounterofMax = 0;
            for (int i = 1; i < CutoffArray.Count; i++)
            {
                if (CutoffArray[i] > 0 && CutoffArray[i - 1] == 0)
                    CounterofMax++;
            }
            return CounterofMax;
        }
        public double MaximumsUncertainty(int CounterofMAX)
        {
            return Math.Sqrt(CounterofMAX);
        }
        public double getStandardDeviation(List<double> doubleList)
        {
            double average = doubleList.Average();
            double sumOfDerivation = 0;
            foreach (double value in doubleList)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / doubleList.Count;
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }
        public void DataSummary(out List<List<double>> AllValuableData, List<List<double>> Picodata, List<List<double>> Wsudata,
            List<List<double>> Dl100Data, double THmin, double THmax, int IgnoredForWsu = 5, int IgnoredforPico = 3)
        {
            AllValuableData = new List<List<double>>();
            double tempsumpico, tempsumwsu;
            int help;
            for (int i = 0; i < Picodata.Count() - 1; i++)
            {
                if (Wsudata[i][3] > THmin && Wsudata[i][3] < THmax)
                {
                    List<double> temp = new List<double>();
                    foreach (double d in Dl100Data[i / Dl100Data.Count()])
                    {
                        temp.Add(d);
                    }
                    for (int j = 0; j < IgnoredforPico; j++)
                    {
                        temp.Add(Picodata[i][j]);
                    }
                    temp.Add(Picodata[i].Skip(IgnoredforPico - 1).Sum());
                    temp.Add(Wsudata[i][3]);
                    AllValuableData.Add(temp);
                }
            }
        }

        public void Average(out List<List<double>> AveragedData, List<List<double>> NotAveragedData)
        {
            AveragedData = new List<List<double>>();
            double tempsumdata = 0;
            int k = 0;
            double tempsumwavelenght = 0;
            for (int i = 0; i < NotAveragedData.Count; i++)
            {
                if (i == 0 || NotAveragedData[i][2] == NotAveragedData[i - 1][2])
                {
                    tempsumdata += NotAveragedData[i][3]; // MIEJSCE W KTORYM CHYBA BEDZIE SUMA SYGNALOW Z PICOSCOPU
                    tempsumwavelenght += NotAveragedData[i][4];
                    k++;
                }
                else
                {
                    List<double> temp = new List<double>();
                    tempsumwavelenght = tempsumwavelenght / k;
                    tempsumdata = tempsumdata / k;
                    for (int j = 0; j < 3; j++)
                    {
                        temp.Add(NotAveragedData[i - 1][j]);
                    }
                    temp.Add(tempsumwavelenght);
                    temp.Add(tempsumdata);
                    AveragedData.Add(temp);
                    tempsumdata = NotAveragedData[i][3]; // MIEJSCE W KTORYM CHYBA BEDZIE SUMA SYGNALOW Z PICOSCOPU
                    tempsumwavelenght = NotAveragedData[i][4];
                    k = 1;
                }
            }
        }
    }
}
