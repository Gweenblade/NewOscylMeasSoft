using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOscylMeasSoft
{
    static class ScalingParameters
    {
        public static int SkalNaTemp(double t)
        {
            double V;
            int POM;
            V = 2993.56 - 200.641 * t - 0.062 * t * t + 0.0008 * t * t * t;
            POM = Convert.ToInt32(V);
            return POM;
        }

        public static int SkalNaPrad(double A)
        {
            double V;
            int POM;
            V = 96.0343 + 130.417 * A - 0.0282 * A * A + 0.0004 * A * A * A;
            POM = Convert.ToInt32(V);
            return POM;
        }
        public static double VoltageToTemp(int V)
        {
            return 14.85408 - 0.00495 * V;
        }

        public static double VoltageToCurrent(int V)
        {
            return -0.70252 + 0.00768 * V;
        }
    }
}
