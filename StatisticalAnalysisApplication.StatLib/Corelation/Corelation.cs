/// <summary>
/// File hold program logic for dealing with corelation factor of sample data value pairs
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib.Corelation
{
    public class Corelation
    {
        /// <summary>
        /// Calculation corelation coeficient by applying candal method to list of numeric value pairs
        /// </summary>
        /// <param name="sampleDataPair"></param>
        /// <returns></returns>
        public double CendalMethod(IEnumerable<KeyValuePair<double, double>> sampleDataPair)
        {
            if (sampleDataPair.Count() == 0)
                throw new EmptySampleException();

            // first sort by keys
            // and calculate sum of ranks by values
            sampleDataPair.OrderBy(v => v.Key);


            // then sort by values
            // and calculate sum of ranks by keys

            // result is (firstSum + secondsSum)/(amount*(amount - 1))
            return this.CoefWithAbnormDistr(sampleDataPair.ToList());
        }

        /// <summary>
        /// Return Cendal Coeficient with abnormal distribution
        /// </summary>
        /// <param name="sampleDataPair"></param>
        /// <returns></returns>
        private double CoefWithAbnormDistr(List<KeyValuePair<double, double>> sampleDataPair)
        {
            List<double> rangValX = new List<double>();
            List<double> rangValY = new List<double>();
            double rang = 0;

            sampleDataPair.OrderBy(pair => pair.Value);
            double val;
            for (int i = 0; i < sampleDataPair.Count - 1; i++)
            {
                val = -1;
                for (int j = i + 1; j < sampleDataPair.Count; j++)
                {
                    if (sampleDataPair[j].Key > sampleDataPair[i].Key)
                    {
                        val = 1;
                        break;
                    }
                }
                rangValX.Add(val);
            }
            rangValX.Add(-1);
            sampleDataPair.OrderBy(pair => pair.Key);
            for (int i = 0; i < sampleDataPair.Count - 1; i++)
            {
                val = -1;
                for (int j = i + 1; j < sampleDataPair.Count; j++)
                {
                    if (sampleDataPair[j].Value > sampleDataPair[i].Value)
                    {
                        val = 1;
                        break;
                    }
                }
                rangValY.Add(val);
            }
            rangValY.Add(-1);
            for (int i = 0; i < sampleDataPair.Count(); i++)
                rang += (rangValX[i] + rangValY[i]);
            var correlationCoeficient = (2.0 * rang) / (sampleDataPair.Count * (sampleDataPair.Count - 1));
            return correlationCoeficient;
        }
    }
}
