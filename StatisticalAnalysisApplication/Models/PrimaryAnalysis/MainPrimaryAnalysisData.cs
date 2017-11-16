/// <summary>
/// This File represents Main Primary analysis Model class
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StatisticalAnalysisApplication.StatLib;

namespace StatisticalAnalysisApplication.Models.PrimaryAnalysis
{
    /// <summary>
    /// Instance of this class store primary analysis result data in a structured format
    /// </summary>
    public class MainPrimaryAnalysisResult
    {
        /// <summary>
        /// Create object with default (0) value to all of primary analysis characteristics
        /// </summary>
        public MainPrimaryAnalysisResult()
        {
            this.MathExpectation = Dispersion = StandartDeviation
                = AssymetryFactor = ExessentialFactor = 0;
        }

        /// <summary>
        /// Initialize the instance's mathematical characteristic with calculated results for passed data set
        /// </summary>
        /// <param name="sampleData">List of sample numbers</param>
        /// <param name="op">Object that holds main statistical analisis operations</param>
        public MainPrimaryAnalysisResult(IEnumerable<double> sampleData, MainOperations op)
        {
            this.MathExpectation = op.MathematicalExpectation(sampleData);
            this.Dispersion = op.Dispersion(sampleData);
            this.StandartDeviation = op.StandartDeviation(sampleData);
            this.AssymetryFactor = op.AssymetryFactor(sampleData);
            this.ExessentialFactor = op.ExessentialFactor(sampleData);
        }

        /// <summary>
        /// Get/Set Math exceptation omponent value
        /// </summary>
        /// <returns>Value of Math exceptation</returns>
        public double MathExpectation
        {
            get { return mathExpectation; }
            set {
                if (value >= 0)
                    mathExpectation = value;
                else
                    throw new ArgumentException("Math expectation can't be negative");
            }
        }
        
        /// <summary>
        /// Get/Set Dispersion component value
        /// </summary>
        /// <returns>Value of sample dispersion</returns>
        public double Dispersion
        {
            get { return dispersion; }
            set
            {
                if (value >= 0)
                    dispersion = value;
                else
                    throw new ArgumentException("Dispersion can't be negative");
            }
        }

        /// <summary>
        /// Get/Set StandartDeviation component value
        /// </summary>
        /// <returns>Standart deviation value of the sample</returns>
        public double StandartDeviation
        {
            get { return standartDeviation; }
            set
            {
                if (value >= 0)
                    standartDeviation = value;
                else
                    throw new ArgumentException("Square root deviation can't be negative");
            }
        }

        /// <summary>
        /// Get/Set AssymetryFactor component value
        /// </summary>
        /// <returns>Assymentry factor value of the sample</returns>
        public double AssymetryFactor
        {
            get { return assymetryFactor; }
            set { assymetryFactor = value; }
        }

        /// <summary>
        /// Get/SEt ExessentialFactor component value
        /// </summary>
        /// <returns>Exessential factor value of the sample</returns>
        public double ExessentialFactor
        {
            get { return exessentialFactor; }
            set { exessentialFactor = value; }
        }

        private double mathExpectation;
        private double dispersion;
        private double standartDeviation;
        private double assymetryFactor;
        private double exessentialFactor;
    }
}