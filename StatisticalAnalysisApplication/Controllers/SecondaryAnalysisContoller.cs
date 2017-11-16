/// <summary>
/// This file holds operations handlers for secondary statistical analysis routes of the server
/// </summary>
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

using StatisticalAnalysisApplication.StatLib.Regression;
using StatisticalAnalysisApplication.StatLib.Corelation;
using StatisticalAnalysisApplication.Filters.Exception;

namespace StatisticalAnalysisApplication.Controllers
{
    /// <summary>
    /// SecondaryAnalysis Controller class of the Web Api
    /// </summary>
    [SampleExceptionFilter]
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class SecondaryAnalysisController : ApiController
    {
        /// <summary>
        /// The controller method that analyze list of number pairs passed to
        /// api/secondaryAnalysis/linearFunc
        /// and produce linear function data of numeric data sample
        /// </summary>
        /// <param name="samplePairs">List of numeric pairs of values to analyze</param>
        /// <returns>HTTP Response Object with linear function data object</returns>
        [HttpPost]
        [Route("api/secondaryAnalysis/linearFunc")]
        public IHttpActionResult CalcLinearFunction([FromBody]List<KeyValuePair<double, double>> samplePairs)
        {
            LinearFunctionIndentificator indentificator = 
                new LinearFunctionIndentificator();

            if (samplePairs.Count == 0)
            {
                return BadRequest("Sample pairs should contain values");
            }

            return Ok<LinearFunction>(indentificator.LeastSquareMethod(samplePairs));
        }

        /// <summary>
        /// The controller method that analyze list of number pairs passed to
        /// api/secondaryAnalysis/corelation
        /// and produce corelation factor value
        /// </summary>
        /// <param name="samplePairs">List of numeric pairs of values to analyze</param>
        /// <returns>HTTP Response Object with corelation factor numeric value</returns>
        [HttpPost]
        [Route("api/secondaryAnalysis/corelation")]
        public IHttpActionResult CalcCorelation([FromBody]List<KeyValuePair<double,double>> samplePairs)
        {
            Corelation corelation = new Corelation();

            if (samplePairs.Count == 0)
            {
                return BadRequest("Sample pairs should contain values");
            }
            return Ok<double>(corelation.CendalMethod(samplePairs));
        }
    }
}