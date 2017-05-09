using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StatisticalAnalysisApplication.StatLib.Graph;

namespace StatisticalAnalysisApplication.Models.PraphsData
{
    public class GistogramData
    {
        public GistogramData()
        {
            DividedSample = new Dictionary<Range, int>();
        }

        public GistogramData(IEnumerable<double> sampleData, Gistogram gistogramOp)
        {
            DividedSample = gistogramOp.DivideByClasses(sampleData);
        }

        public IDictionary<Range, int> DividedSample { get; set; }
    }
}