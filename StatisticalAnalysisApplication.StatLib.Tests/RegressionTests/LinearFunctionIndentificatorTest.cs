using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StatisticalAnalysisApplication.StatLib.Regression;
using NUnit.Framework;

namespace StatisticalAnalysisApplication.StatLib.Tests.RegressionTests
{
    [TestFixture(Author= "Vlad Sereda")]
    class LinearFunctionIndentificatorTest
    {
        private LinearFunctionIndentificator indentificator;

        [SetUp]
        public void SetUpTestUnit()
        {
            this.indentificator = new LinearFunctionIndentificator();
        }

        [Test(Author= "Vlad Sereda")]
        public void LeastSquareMethod_emptySamplePairList_ShouldThrowException() {
            List<KeyValuePair<double,double>> samplePairValues = 
                new List<KeyValuePair<double,double>>();
            
            Assert.Throws<EmptySampleException>(() => 
                indentificator.LeastSquareMethod(samplePairValues));
        }

        [Test(Author = "Vlad Sereda")]
        public void LeastSquareMethod_samplePairList_ShouldCalculateCorrect()
        {
            List<KeyValuePair<double, double>> samplePairValues =
                new List<KeyValuePair<double, double>>(new KeyValuePair<double, double>[] {
                    new KeyValuePair<double, double>(60.0, 170.0),
                    new KeyValuePair<double, double>(70.0, 170.0),
                    new KeyValuePair<double, double>(80.0, 181.0)
                });

            LinearFunction lF = indentificator.LeastSquareMethod(samplePairValues);

            Assert.True(lF.B1 == -166.8 && lF.B2 == 1.36);
        }
    }
}
