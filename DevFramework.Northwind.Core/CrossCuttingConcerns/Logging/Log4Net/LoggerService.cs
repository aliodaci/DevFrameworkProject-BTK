using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class LoggerService
    {
        private ILog _log;

        public LoggerService(ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled
        {
            get { return _log.IsInfoEnabled; }
        }
        public bool IsDebugEnable => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public void Info(object logmessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logmessage);
            }
        }

        public void Debug(object logmessage)
        {
            if (IsDebugEnable)
            {
                _log.Debug(logmessage);
            }
        }
        public void Warn(object logmessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logmessage);
            }
        }

        public void Error(object logmessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logmessage);
            }
        }
    }
}
