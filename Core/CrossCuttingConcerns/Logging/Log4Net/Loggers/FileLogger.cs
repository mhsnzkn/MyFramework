using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        // log4net.config dosyasinda belirtilen logger adi
        const string name = "JsonFileLogger";
        public FileLogger(string name) : base(name)
        {
        }
    }
}
