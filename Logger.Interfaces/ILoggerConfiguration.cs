namespace Logger.Interfaces
{
    public interface ILoggerConfiguration
    {
        bool AcceptsMessageLogs { get; set; }
        bool AcceptsWarningLogs { get; set; }
        bool AcceptsErrorLogs { get; set; }
        bool LogsToDatabase { get; set; }
        bool LogsToFile { get; set; }
        bool LogsInConsole { get; set; }

        bool ValidTypes();
        bool ValidOutput();
    }
}