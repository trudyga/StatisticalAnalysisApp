using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using StatisticalAnalisysApplication.StatLib;

namespace StatisticalAnalysisApplication.StatLib.Tests
{
    [TestFixture(Author = "Vlad Sereda", 
        Description = "Testing methods of main operation class")]
    class MainOperationsTest
    {
        private MainOperations op;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            op = new MainOperations();
        }

        // MathematicalExpectation section
        [Test(Author = "Vlad Sereda")]
        public void MathematicalExpectation_emptyListResieved_ShouldThrowException()
        {
            // assert
            List<double> sample = new List<double>();

            Assert.Throws<EmptySampleException>(() =>
            {
                op.MathematicalExpectation(sample);
            });
        }

        [Test(Author = "Vlad Sereda")]
        public void MathematicalExpectation_1and2and3and4and5_ShouldBe3()
        {
            List<double> sample = new List<double>(new double[] { 1, 2, 3, 4, 5 });

            double mathExpect = op.MathematicalExpectation(sample);

            Assert.AreEqual(3, mathExpect);
        }

        // Dispersion section
        [Test(Author = "Vlad Sereda")]
        public void DispersionTest_emptyListResieved_ShouldThrowException()
        {
            List<double> sample = new List<double>();

            Assert.Throws<EmptySampleException>(() =>
            {
                op.Dispersion(sample);
            });
        }

        [Test(Author = "Vlad Sereda")]
        public void DispersionTest_1and2and3and4and5_ShouldBe2dot5()
        {
            List<double> sample = new List<double>(new double[] { 1, 2, 3, 4, 5 });

            double dispersion = op.Dispersion(sample);
            double expected = 2.5;

            Assert.AreEqual(expected, dispersion, 0.001);
        }

        // StandartDeviation section
        [Test(Author = "Vlad Sereda")]
        public void StandartDeviationTest_emptyListResieved_ShouldThrowException()
        {
            List<double> sample = new List<double>();

            Assert.Throws<EmptySampleException>(() =>
            {
                op.StandartDeviation(sample);
            });
        }

        [Test(Author = "Vlad Sereda")]
        public void StandartDeviationTest_1and2and3and4and5_ShouldBe1dot581()
        {
            List<double> sample = new List<double>(new double[] { 1, 2, 3, 4, 5 });

            double deviation = op.StandartDeviation(sample);
            double expected = 1.581;

            Assert.AreEqual(expected, deviation, 0.001);
        }

        // AssymetryFactor section
        [Test(Author = "Vlad Sereda")]
        public void AssymetryFactorTest_emptyListResieved_ShouldThrowException()
        {
            List<double> sample = new List<double>();

            Assert.Throws<EmptySampleException>(() =>
            {
                op.AssymetryFactor(sample);
            });
        }

        [Test(Author = "Vlad Sereda")]
        public void AssymetryFactorTest_1and2and3and4and5_ShouldBe0()
        {
            List<double> sample = new List<double>(new double[] { 1, 2, 3, 4, 5 });

            double assymetry = op.AssymetryFactor(sample);
            double expected = 0;

            Assert.AreEqual(expected, assymetry);
        }
        
        // ExessentialFactor section
        [Test(Author = "Vlad Sereda")]
        public void ExessentialFactorTest_emptyListResieved_ShouldThrowException()
        {
            List<double> sample = new List<double>();

            Assert.Throws<EmptySampleException>(() =>
            {
                op.ExessentialFactor(sample);
            });
        }
    }
}
