using System;
using Logger.Interfaces;
using Logger.Model;
using System.Configuration;

namespace Logger.Core.ProposedSolution
{
    class JobLogger
    {

        private readonly ILoggerConfiguration _loggerConfiguration;
        private readonly IConsoleAccess _consoleAccess;
        private readonly IDataAccess _dataAccess;
        private readonly IFileAccess _fileAccess;

        /// <summary>
        /// Constructor, sets the parameters
        /// </summary>
        /// <param name="loggerConfiguration">Logger Configuration Factory</param>
        /// <param name="consoleAccess">Console Factory</param>
        /// <param name="dataAccess">DB Data Factory</param>
        /// <param name="fileAccess">File Factory</param>
        public JobLogger(ILoggerConfiguration loggerConfiguration, IConsoleAccess consoleAccess, IDataAccess dataAccess, IFileAccess fileAccess)
        {
            this._dataAccess = dataAccess;
            this._consoleAccess = consoleAccess;
            this._fileAccess = fileAccess;

            this._loggerConfiguration = loggerConfiguration;
        }

        /// <summary>
        /// Checks the parameters and settings to see if they are well configured
        /// if not it throws an exception with a related message
        /// </summary>
        /// <param name="logData">Log Entity Object</param>
        private void CheckSettings(Log logData)
        {
            if (!logData.IsValidMessage())
            {
                throw new Exception("Message is invalid");
            }

            if (!_loggerConfiguration.ValidTypes())
            {
                throw new Exception("Can't process any type of log, must allow at least one kind");
            }

            if (!_loggerConfiguration.ValidOutput())
            {
                throw  new Exception("Invalid configuration");
            }

            if (_loggerConfiguration.LogsInConsole && _consoleAccess == null)
            {
                throw new Exception("The Console logger is not implemented");
            }

            if (_loggerConfiguration.LogsToDatabase && _dataAccess == null)
            {
                throw new Exception("The DB logger is not implemented");
            }

            if (_loggerConfiguration.LogsToFile && _fileAccess == null)
            {
                throw new Exception("The File logger is not implemented");
            }

            bool validType = true;
            switch (logData.LogType)
            {
                case LogTypes.Message:
                    if (!_loggerConfiguration.AcceptsMessageLogs)
                    {
                        validType = false;
                    }
                    break;
                case LogTypes.Error:
                    if (!_loggerConfiguration.AcceptsErrorLogs)
                    {
                        validType = false;
                    }
                    break;
                case LogTypes.Warning:
                    if (!_loggerConfiguration.AcceptsWarningLogs)
                    {
                        validType = false;
                    }
                    break;
                default:
                    throw  new Exception("Type in log object not configured");
            }

            if (!validType)
            {
                throw new Exception("The selected type of log for the log entity is not allowed by the logger configuration");
            }
        }

        public void LogMessage(Log logData)
        {
            CheckSettings(logData);

            if (_loggerConfiguration.LogsInConsole)
            {
                _consoleAccess.ShowConsole(logData);
            }

            if (_loggerConfiguration.LogsToDatabase)
            {
                _dataAccess.Save(logData, ConfigurationManager.ConnectionStrings["JobLogger"].ConnectionString);
            }

            if (_loggerConfiguration.LogsToFile)
            {
                _fileAccess.Save(logData, ConfigurationManager.AppSettings["LogFileDirectory"], ConfigurationManager.AppSettings["LogFileName"]);
            }
        }
    }
}
