using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;

namespace Provider.Infra
{
    public class LogHelper
    {
        public static void WriteLog(Exception ex)
        {
            var log = log4net.LogManager.GetLogger("Loggering");

            log.Error("Error", ex);
        }

        public static void WriteLog(string msg)
        {
            var log = log4net.LogManager.GetLogger("Loggering");
            log.Error(msg);
        }
    }
}
