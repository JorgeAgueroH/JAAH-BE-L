using Logger.Interfaces;

namespace Logger.Core.ProposedSolution
{
    public class JobLoggerConfiguration : ILoggerConfiguration
    {

        public bool AcceptsMessageLogs { get; set; }

        public bool AcceptsWarningLogs { get; set; }

        public bool AcceptsErrorLogs { get; set; }

        public bool LogsToDatabase { get; set; }

        public bool LogsToFile { get; set; }

        public bool LogsInConsole { get; set; }

        public JobLoggerConfiguration(bool acceptsMessageLogs, bool acceptsWarningLogs, bool acceptsErrorLogs,
            bool logsToDatabase, bool logsToFile, bool logsInConsole)
        {
            this.AcceptsErrorLogs = acceptsErrorLogs;
            this.AcceptsMessageLogs = acceptsMessageLogs;
            this.AcceptsWarningLogs = acceptsWarningLogs;
            this.LogsInConsole = logsInConsole;
            this.LogsToDatabase = logsToDatabase;
            this.LogsToFile = logsToFile;
        }


        public bool ValidTypes()
        {
            if (!AcceptsErrorLogs && !AcceptsMessageLogs && !AcceptsWarningLogs)
            {
                return false;
            }
            return true;
        }

        public bool ValidOutput()
        {
            if (!LogsInConsole && !LogsToDatabase && !LogsToFile)
            {
                return false;
            }
            return true;
        }
    }
}