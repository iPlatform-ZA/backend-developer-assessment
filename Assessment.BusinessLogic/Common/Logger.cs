using System.Diagnostics;

namespace Assessment.BusinessLogic.Common
{
    public static class Logger
    {
        public static void LogEvent(string message)
        {
            EventLog.WriteEntry("Assessment Web API", message);
        }
    }
}
