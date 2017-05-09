using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib.Graph
{
    public class Gistogram
    {
        /// <summary>
        /// The method divides sample data into classes
        /// and defines the amount of items in each class
        /// </summary>
        /// <param name="sampleData">List of numeric sample data</param>
        /// <returns>Dictionary<Range, int></returns>
        public IDictionary<Range, int> DivideByClasses(
            IEnumerable<double> sampleData)
        {
            if (sampleData.Count() == 0)
                throw new EmptySampleException();

            int amountOfClasses = (int)Math.Sqrt(sampleData.Count());
            amountOfClasses = amountOfClasses % 2 == 0 ? amountOfClasses - 1 : amountOfClasses;

            double lowerBound = sampleData.Min();
            double higherBound = sampleData.Max();
            double step = (higherBound - lowerBound) / amountOfClasses;

            IDictionary<Range, int> divided = new Dictionary<Range, int>(amountOfClasses);

            for (int i = 0; i < amountOfClasses; i++)
            {
                double lower = lowerBound + i * step;
                double upper = lower + step;
                int amountOfValues = sampleData.Count(val => 
                    val >= lower && val <= upper);

                divided.Add(new KeyValuePair<Range, int>(new Range(lower, upper), amountOfValues));
            }

            return divided;
        }
    }
}
