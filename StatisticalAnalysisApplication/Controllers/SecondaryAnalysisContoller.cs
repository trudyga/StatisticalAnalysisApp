using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using StatisticalAnalysisApplication.StatLib;
using StatisticalAnalysisApplication.StatLib.Regression;
using StatisticalAnalysisApplication.StatLib.Graph;

using StatisticalAnalysisApplication.Models;
using StatisticalAnalysisApplication.Filters.Exception;

namespace StatisticalAnalysisApplication.Controllers
{
    [SampleExceptionFilter]
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class SecondaryAnalysisContoller: ApiController
    {
        [HttpPost]
        [Route("api/secondaryAnalysis/linearFunc")]
        public LinearFunction CalcLinearFunction([FromBody]List<KeyValuePair<double, double>> sampleData)
        {
            LinearFunctionIndentificator indentificator = 
                new LinearFunctionIndentificator();
            return indentificator.LeastSquareMethod(sampleData);
        }
    }
}