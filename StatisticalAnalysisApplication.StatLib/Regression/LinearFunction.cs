/// <summary>
/// File hold linear function entity class
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib.Regression
{
    /// <summary>
    /// Linear function etitity class
    /// </summary>
    public class LinearFunction
    {
        public LinearFunction()
        {
            B1 = 0;
            B2 = 0;
        }
        /// <summary>
        /// Linear function entity constuction
        /// y = b1 + x * b2
        /// </summary>
        /// <param name="b1">Free coeficient</param>
        /// <param name="b2">Dependent coeficient</param>
        public LinearFunction(double b1, double b2)
        {
            B1 = b1;
            B2 = b2;
        }

        public double B1 { get; set; }
        public double B2 { get; set; }

        /// <summary>
        /// Calculate the calue of linear function for {x}
        /// </summary>
        /// <param name="x">Linear function variable value</param>
        /// <returns>Value of the linear function in {x} point</returns>
        public double Calc(double x)
        {
            return B1 + B2 * x;
        }
    }
}
