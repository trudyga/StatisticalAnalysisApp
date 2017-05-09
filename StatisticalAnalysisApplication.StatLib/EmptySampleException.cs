using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticalAnalysisApplication.StatLib
{
    public class EmptySampleException: Exception
    {
        public EmptySampleException()
            : base("Empty sample data was recieved for statistical analisys")
        { }

        public EmptySampleException(string message)
            : base(message)
        {
            
        }
    }
}
