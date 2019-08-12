using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NewOscylMeasSoft
{
    class DataAnalysis
    {
        public double[] CutoffFunction(double[] WSUsignal, double CutoffValue)
        {
            double Max = 0;
            for (int i = 0; i < WSUsignal.Length; i++)
            {
                if (Max < WSUsignal[i])
                    Max = WSUsignal[i];
            }
            for (int i = 0; i < WSUsignal.Length; i++)
            {
                WSUsignal[i] = WSUsignal[i] - (CutoffValue / 100 * Max);
                if (WSUsignal[i] < 0)
                    WSUsignal[i] = 0;
            }
            return WSUsignal;
        }
        public int MaximumsCounter(double[] CutoffArray)
        {
            int CounterofMax = 0;
            for (int i = 0; i < CutoffArray.Length; i++)
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
    }
}
