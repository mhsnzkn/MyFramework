using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        // log4net.config dosyasinda belirtilen logger adi
        const string name = "DatabaseLogger";
        public DatabaseLogger(string name) : base(name)
        {
        }
    }
}
