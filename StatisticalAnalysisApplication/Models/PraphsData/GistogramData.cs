/// <summary>
/// This File Represents Gistogram Data Model class
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StatisticalAnalysisApplication.StatLib.Graph;

namespace StatisticalAnalysisApplication.Models.PraphsData
{
    ///
    /// <summary> Instance of this class store gitstogram data in structured format </summary>
    ///
    public class GistogramData
    {
        /// <summary>
        /// Create empty instance
        /// </summary>
        public GistogramData()
        {
            DividedSample = new Dictionary<Range, int>();
        }

        /// <summary>
        /// Create Instance 
        /// </summary>
        /// <param name="sampleData"> List of numbers fo gistogram </param>
        /// <param name="gistogramOp">Class instance that holds operations for gistogram</param>
        public GistogramData(IEnumerable<double> sampleData, Gistogram gistogramOp)
        {
            DividedSample = gistogramOp.DivideByClasses(sampleData);
        }

        public IDictionary<Range, int> DividedSample { get; set; }
    }
}