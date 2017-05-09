using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using StatisticalAnalysisApplication.StatLib;
using StatisticalAnalysisApplication.StatLib.Graph;

using StatisticalAnalysisApplication.Models.PrimaryAnalysis;
using StatisticalAnalysisApplication.Filters.Exception;

namespace StatisticalAnalysisApplication.Controllers
{
    [SampleExceptionFilter]
    public class PrimaryAnalysisController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Analyze([FromBody]List<double> sampleData)
        {
            MainOperations op = new MainOperations();
            Normalization normalization = new Normalization();

            MainPrimaryAnalysisResult analysisResult =
                    new MainPrimaryAnalysisResult(sampleData, op);

            var markedCoarseSampleData = normalization.MarkCoarseValues(sampleData);
            var withoutCoarseAnalysisResult = new MainPrimaryAnalysisResult(
                markedCoarseSampleData.Where(val => !val.Key).Select(
                    val => val.Value), op);

            var result = new
            {
                AnalysisResult = analysisResult,
                CoarseMarkedSample = markedCoarseSampleData,
                WithoutCoarseValuesAnaysisResult = withoutCoarseAnalysisResult
            };

            return Ok<object>(result);
        }

        [HttpPost]
        [Route("api/primaryAnalysis/gistogram")]
        public IHttpActionResult CalculateGistogramData([FromBody]List<double> sampleData)
        {
            Gistogram gistogramOp = new Gistogram();

            var dividedByClassesSample = gistogramOp.DivideByClasses(sampleData);

            var result = new
            {
                Classes = dividedByClassesSample.ToList()
            };

            return Ok(result);
        }
    }
}
