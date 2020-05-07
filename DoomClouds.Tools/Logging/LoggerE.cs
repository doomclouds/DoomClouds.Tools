using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace DoomClouds.Tools.Logging
{
    public class LoggerE : ILoggerE
    {
        private static ILogger _nLog;

        public LoggerE()
        {
            _nLog = LogManager.GetCurrentClassLogger();
        }

        public virtual void Trace(string message)
        {
            _nLog.Trace(message);
        }

        public virtual void Debug(string message)
        {
            _nLog.Debug(message);
        }

        public virtual void Info(string message)
        {
            _nLog.Info(message);
        }

        public virtual void Warn(string message)
        {
            _nLog.Warn(message);
        }

        public virtual void Error(string message)
        {
            _nLog.Error(message);
        }

        public virtual void Fatal(string message)
        {
            _nLog.Fatal(message);
        }
    }
}
