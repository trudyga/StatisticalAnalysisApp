/// <summary>
/// This file holds operations handlers for primary analysis routes of the server
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using StatisticalAnalysisApplication.StatLib;
using StatisticalAnalysisApplication.StatLib.Graph;

using StatisticalAnalysisApplication.Models.PrimaryAnalysis;
using StatisticalAnalysisApplication.Filters.Exception;

namespace StatisticalAnalysisApplication.Controllers
{
    /// <summary>
    /// PrimaryAnalysis Controller class of the Web Api
    /// </summary>
    [SampleExceptionFilter]
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class PrimaryAnalysisController : ApiController
    {
        /// <summary>
        /// Test method to ansure server is working
        /// </summary>
        /// <returns>Sample string stub</returns>
        [HttpGet]
        [Route("api/value")]
        public string GetValue()
        {
            return "Value returned from server";
        }

        /// <summary>
        /// The controller method which analyze the sample data list that was passed to 
        /// api/primaryAnalysis/analyze POST Server's web api method
        /// </summary>
        /// <param name="sampleData">Sample numeric data to perform statistical analysis on</param>
        /// <returns>HTTP Response Object with results of primary statisical analysis</returns>
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

        /// <summary>
        /// The controller method that analyze the sample data list passed to
        /// api/primaryAnalysis/gistogram
        /// and produce data that is needed for gistoram rendering
        /// </summary>
        /// <param name="sampleData">Sample numeric data to perform statistical analysis on</param>
        /// <returns>HTTP Response Object with gistogram data object</returns>
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
