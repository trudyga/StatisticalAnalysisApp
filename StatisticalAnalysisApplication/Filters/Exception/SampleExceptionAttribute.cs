using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;

using StatisticalAnalysisApplication.StatLib;

namespace StatisticalAnalysisApplication.Filters.Exception
{
    public class SampleExceptionFilterAttribute :  ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null && 
                actionExecutedContext.Exception is EmptySampleException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
        }
    }
}