using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Core.CrossCuttingConcern.Logging.Log4net.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
