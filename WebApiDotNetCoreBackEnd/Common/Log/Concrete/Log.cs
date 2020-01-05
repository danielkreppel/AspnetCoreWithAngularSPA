using Common.Log.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Common.Log.Concrete
{
    public class Log : ILog
    {
        public void LogError(Exception ex)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Error(ex.Message);
        }
    }
}
