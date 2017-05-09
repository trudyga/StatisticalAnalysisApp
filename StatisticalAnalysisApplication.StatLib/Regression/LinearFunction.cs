using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib.Regression
{
    public class LinearFunction
    {
        public LinearFunction()
        {
            B1 = 0;
            B2 = 0;
        }

        public LinearFunction(double b1, double b2)
        {
            B1 = b1;
            B2 = b2;
        }

        public double B1 { get; set; }
        public double B2 { get; set; }

        public double Calc(double x)
        {
            return B1 + B2 * x;
        }
    }
}
