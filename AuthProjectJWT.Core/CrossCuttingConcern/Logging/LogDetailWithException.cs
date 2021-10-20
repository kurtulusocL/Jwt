using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Core.CrossCuttingConcern.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}
