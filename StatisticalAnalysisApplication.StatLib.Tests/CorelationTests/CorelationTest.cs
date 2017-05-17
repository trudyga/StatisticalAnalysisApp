using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using StatisticalAnalysisApplication.StatLib.Corelation;
using StatisticalAnalysisApplication.StatLib;

namespace StatisticalAnalysisApplication.StatLib.Tests.CorelationTests
{
    [TestFixture(Author = "Vlad Sereda", 
        TestOf = typeof (Corelation.Corelation))]
    public class CorelationTest
    {
        private Corelation.Corelation corelation;

        [SetUp]
        public void SetUpTestMethods()
        {
            this.corelation = new Corelation.Corelation();
        }

        [Test]
        public void CendalMethod_emptyListRecieved_ShouldThrowException()
        {
            List<KeyValuePair<double, double>> samplePair = 
                new List<KeyValuePair<double, double>>();

            Assert.Throws<EmptySampleException>(
                () => corelation.CendalMethod(samplePair));
        }

        [Test]
        public void CendalMethod_sampleOrderedSamples_ShouldReturn1 ()
        {
            List<KeyValuePair<double, double>> samplePairs =
                new List<KeyValuePair<double, double>>(new KeyValuePair<double, double>[] {
                    new KeyValuePair<double, double>(1,1),
                    new KeyValuePair<double, double>(2,2),
                    new KeyValuePair<double, double>(3,3),
                    new KeyValuePair<double, double>(4,4),
                    new KeyValuePair<double, double>(5,5),
                    new KeyValuePair<double, double>(6,6),
                    new KeyValuePair<double, double>(7,7),
                    new KeyValuePair<double, double>(8,8),
                    new KeyValuePair<double, double>(9,9),
                    new KeyValuePair<double, double>(10,10)
                });

            var corelationFactor = corelation.CendalMethod(samplePairs);

            Assert.That(corelationFactor, Is.EqualTo(1));
        }

        [Test]
        public void CendalMethod_sampleOrderedSamples_ShouldReturnNeg1()
        {
            List<KeyValuePair<double, double>> samplePairs =
                new List<KeyValuePair<double, double>>(new KeyValuePair<double, double>[] {
                    new KeyValuePair<double, double>(1,10),
                    new KeyValuePair<double, double>(2,9),
                    new KeyValuePair<double, double>(3,8),
                    new KeyValuePair<double, double>(4,7),
                    new KeyValuePair<double, double>(5,6),
                    new KeyValuePair<double, double>(6,5),
                    new KeyValuePair<double, double>(7,4),
                    new KeyValuePair<double, double>(8,3),
                    new KeyValuePair<double, double>(9,2),
                    new KeyValuePair<double, double>(10,1)
                });

            var corelationFactor = corelation.CendalMethod(samplePairs);

            Assert.That(corelationFactor, Is.EqualTo(-1));
        }
    }
}
