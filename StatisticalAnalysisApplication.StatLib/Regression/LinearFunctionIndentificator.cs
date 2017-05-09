using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib.Regression
{
    public class LinearFunctionIndentificator
    {
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
