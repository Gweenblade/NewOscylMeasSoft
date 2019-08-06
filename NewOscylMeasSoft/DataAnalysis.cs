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
            double[] CutoffArray;
            CutoffArray = new double[WSUsignal.Length];
            for(int i = 0; i < WSUsignal.Length; i++)
            {
                CutoffArray[i] = WSUsignal[i];
                CutoffArray[i] = CutoffArray[i] - (CutoffArray[i] * CutoffValue / 100);
                if (CutoffArray[i] < 0)
                    CutoffArray[i] = 0;
            }
            return CutoffArray;
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
    }
}
