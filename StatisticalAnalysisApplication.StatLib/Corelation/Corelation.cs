using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib.Corelation
{
    public class Corelation
    {
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
            throw new NotImplementedException();
        }

        private double sumOfRanks(IEnumerable<double> ranks)
        {
            throw new NotImplementedException();
        }

        private double rank(IEnumerable<double> values)
        {
            throw new NotImplementedException();
        }


    }
}
