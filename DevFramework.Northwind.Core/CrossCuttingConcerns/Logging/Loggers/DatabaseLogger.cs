using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Core.CrossCuttingConcerns.Logging.Log4Net;
using log4net;

namespace DevFramework.Northwind.Core.CrossCuttingConcerns.Logging.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }
    }
}
