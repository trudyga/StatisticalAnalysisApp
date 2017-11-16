/// <summary>
/// File hold numeric sample normalization alogirthm
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib
{
    /// <summary>
    /// Instances of the class Normalize values in numeric sample
    /// </summary>
    public class Normalization
    {
        /// <summary>
        /// Method marks coarse values in 
        /// sample numeric data with boolean key
        /// </summary>
        /// <param name="sampleData">List of sample numeric data</param>
        /// <returns>List of Pairs with boolean key that indicates weather value is coarse or not</returns>
        public IEnumerable<KeyValuePair<bool, double>> MarkCoarseValues
            (IEnumerable<double> sampleData)
        {
            if (sampleData.Count() == 0)
                throw new EmptySampleException();

            List<KeyValuePair<bool, double>> markedSample = 
                new List<KeyValuePair<bool, double>>(sampleData.Count());

            MainOperations op = new MainOperations();
            double mathExpect = op.MathematicalExpectation(sampleData);
            double deviation = op.StandartDeviation(sampleData);
            const double kvantil = 1.96;
            
            foreach (var value in sampleData)
            {
                double t = Math.Abs(value - mathExpect) / deviation;
                markedSample.Add(new KeyValuePair<bool, double>(
                    t >= kvantil, value));
            }

            return markedSample;
        }
    }
}
