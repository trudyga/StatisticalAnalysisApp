using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StatisticalAnalysisApplication.StatLib;

namespace StatisticalAnalysisApplication.Models.PrimaryAnalysis
{
    public class MainPrimaryAnalysisResult
    {
        public MainPrimaryAnalysisResult()
        {
            this.MathExpectation = Dispersion = StandartDeviation
                = AssymetryFactor = ExessentialFactor = 0;
        }

        public MainPrimaryAnalysisResult(IEnumerable<double> sampleData, MainOperations op)
        {
            this.MathExpectation = op.MathematicalExpectation(sampleData);
            this.Dispersion = op.Dispersion(sampleData);
            this.StandartDeviation = op.StandartDeviation(sampleData);
            this.AssymetryFactor = op.AssymetryFactor(sampleData);
            this.ExessentialFactor = op.ExessentialFactor(sampleData);
        }

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

        public double AssymetryFactor
        {
            get { return assymetryFactor; }
            set { assymetryFactor = value; }
        }

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