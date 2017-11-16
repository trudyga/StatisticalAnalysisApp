/// <summary>
/// File holds an algorithm for correct linear function detection
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib.Regression
{
    /// <summary>
    /// Linear Function Indentificator class
    /// </summary>
    public class LinearFunctionIndentificator
    {
        /// <summary>
        /// Identificate linear function by means of least square method
        /// </summary>
        /// <param name="sampleDataPair">List of numeric pairs</param>
        /// <returns>Linear function object</returns>
        public LinearFunction LeastSquareMethod(IEnumerable<KeyValuePair<double, double>> sampleDataPair) {
            if (sampleDataPair.Count() == 0)
                throw new EmptySampleException();

            MainOperations op = new MainOperations();

            IEnumerable<double> xValues = sampleDataPair.Select(v => v.Key);
            IEnumerable<double> yValues = sampleDataPair.Select(v => v.Value);

            double xMathExpect = op.MathematicalExpectation(xValues);
            double yMathExpect = op.MathematicalExpectation(yValues);

            double firstSum = 0;
            double secondSum = 0;
            foreach (var value in sampleDataPair)
            {
                firstSum += ((value.Value - yMathExpect)*(value.Key - xMathExpect));
                secondSum += (Math.Pow((value.Key - xMathExpect), 2));
            }

            double b2 = firstSum / secondSum;
            double b1 = yMathExpect - b2 * xMathExpect;

            return new LinearFunction(b1, b2);
        }
    }
}
