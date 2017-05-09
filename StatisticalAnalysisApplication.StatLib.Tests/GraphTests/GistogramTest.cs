using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StatisticalAnalysisApplication.StatLib.Graph;
using NUnit.Framework;

namespace StatisticalAnalysisApplication.StatLib.Tests.GraphTests
{
    [TestFixture(Author = "Vlad Sereda")]
    class GistogramTest
    {
        private Gistogram gistogram;
        
        [SetUp]
        public void SetUpTestMethods()
        {
            gistogram = new Gistogram();
        }

        [Test(Author = "Vlad Sereda")]
        public void DivideByClasses_emptySampleList_ShouldThrowException()
        {
            List<double> emptySample = new List<double>();

            Assert.Throws<EmptySampleException>(
                () => gistogram.DivideByClasses(emptySample));
        }

        [Test(Author = "Vlad Sereda")]
        [TestCase(new double[] { 1,2,3,4,5,6,7,8,9,10})]
        [TestCase(new double[] { 1 })]
        [TestCase(new double[] { 1,2,3,4,5,6,-2, 32,13, 131,131})]
        public void DivideByClasses_sampleListDataValues_shouldBeDividedIntoSquareRootAmountOfClasses(
            IEnumerable<double> sample)
        {
            var classesList = gistogram.DivideByClasses(sample);
            int amountOfClasses = (int)Math.Sqrt(sample.Count());
            amountOfClasses = amountOfClasses % 2 == 0 ?
                amountOfClasses - 1 : amountOfClasses;

            Assert.That(classesList.Count, Is.EqualTo(amountOfClasses));
        }

    }
}
