using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NewOscylMeasSoft
{
    class DataAnalysis
    {
        public List<double> CutoffFunction(List<double> WSUsignal, double CutoffValue, int IgnoredColumns = 0)
        {
            double Max = WSUsignal.Max(); // TUTAJ JEST BLAD
            for (int i = IgnoredColumns; i < WSUsignal.Count; i++)
            {
                WSUsignal[i] = WSUsignal[i] - (CutoffValue / 100 * Max);
                if (WSUsignal[i] < 0)
                    WSUsignal[i] = 0;
            }
            return WSUsignal;
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
    }
}
