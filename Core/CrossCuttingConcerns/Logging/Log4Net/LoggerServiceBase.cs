using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), 
                typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);
            this.log = LogManager.GetLogger(loggerRepository.Name, name);
        }

        public bool IsInfoEnabled => log.IsInfoEnabled;
        public bool IsWarnEnabled => log.IsWarnEnabled;
        public bool IsDebugEnabled => log.IsDebugEnabled;
        public bool IsFatalEnabled => log.IsFatalEnabled;
        public bool IsErrorEnabled => log.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if(IsInfoEnabled)
                log.Info(logMessage);
        }
        public void Debug(object logMessage)
        {
            if(IsDebugEnabled)
                log.Debug(logMessage);
        }
        public void Warn(object logMessage)
        {
            if(IsWarnEnabled)
                log.Warn(logMessage);
        }
        public void Fatal(object logMessage)
        {
            if(IsFatalEnabled)
                log.Fatal(logMessage);
        }
        public void Error(object logMessage)
        {
            if(IsErrorEnabled)
                log.Error(logMessage);
        }
    }
}
