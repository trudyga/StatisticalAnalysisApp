using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalisysApplication.StatLib
{
    public class MainOperations
    {
        /// <summary>
        /// Method calculates mathematical expectation value 
        /// of the sample data list
        /// </summary>
        /// <param name="sampleData">List of sample numeric data</param>
        /// <returns>Value of mathematical expectations</returns>
        public double MathematicalExpectation(IEnumerable<double> sampleData)
        {
            if (sampleData.Count() == 0)
                throw new EmptySampleException();

            var n = sampleData.Count();
            double sum = 0;
            foreach (var val in sampleData)
            {
                sum += val;
            }

            return sum / n;
        }

        /// <summary>
        /// Method calculates standart square deviation value
        /// of the sample data list 
        /// </summary>
        /// <param name="sampleData">List of sample numeric data</param>
        /// <returns>Value of standart square deviation</returns>
        public double StandartDeviation(IEnumerable<double> sampleData)
        {
            if (sampleData.Count() == 0)
                throw new EmptySampleException();

            return Math.Sqrt(Dispersion(sampleData));
        }

        /// <summary>
        /// Method calculates dispersion value
        /// of the sample data list
        /// </summary>
        /// <param name="sampleData">List of sample numeric data</param>
        /// <returns>Value of dispersion</returns>
        public double Dispersion(IEnumerable<double> sampleData)
        {
            if (sampleData.Count() == 0)
                throw new EmptySampleException();

            var n = sampleData.Count();

            double sum = 0;
            var mathExpect = MathematicalExpectation(sampleData);

            foreach(var value in sampleData)
            {
                sum += Math.Pow((value - mathExpect), 2);
            }

            return sum / (n - 1);
        }

        /// <summary>
        /// Method calculates assymetry factor
        /// of the sample data list
        /// </summary>
        /// <param name="sampleData">List of sample numeric data</param>
        /// <returns>Assymetry factor</returns>
        public double AssymetryFactor(IEnumerable<double> sampleData)
        {
            if (sampleData.Count() == 0)
                throw new EmptySampleException();

            var n = sampleData.Count();
            double stdDeviation = StandartDeviation(sampleData);
            double mathExpect = MathematicalExpectation(sampleData);

            double sum = 0;
            foreach (var value in sampleData)
            {
                sum += Math.Pow((value - mathExpect), 3);
            }

            double result = sum / (n * Math.Pow(stdDeviation, 3));
            return result;
        }

        /// <summary>
        /// Method calculates exessential factor
        /// of the sample data list
        /// </summary>
        /// <param name="sampleData">List of sample numeric data</param>
        /// <returns>Exessential factor</returns>
        public double ExessentialFactor(IEnumerable<double> sampleData)
        {
            if (sampleData.Count() == 0)
                throw new EmptySampleException();

            var n = sampleData.Count();
            double stdDeviation = StandartDeviation(sampleData);
            double mathExpect = MathematicalExpectation(sampleData);

            double sum = 0;
            foreach (var value in sampleData)
            {
                sum += Math.Pow((value - mathExpect), 4);
            }

            double result = sum / (n * Math.Pow(stdDeviation, 4));
            return result;
        }
    }
}
