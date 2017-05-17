using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

using StatisticalAnalysisApplication.StatLib.Regression;
using StatisticalAnalysisApplication.StatLib.Corelation;
using StatisticalAnalysisApplication.Filters.Exception;

namespace StatisticalAnalysisApplication.Controllers
{
    [SampleExceptionFilter]
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class SecondaryAnalysisController : ApiController
    {
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