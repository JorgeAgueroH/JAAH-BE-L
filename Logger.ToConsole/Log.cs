using System;
using Logger.Interfaces;
using Logger.Model;

namespace Logger.ToConsole
{
    public class Log : IConsoleAccess
    {
        public void ShowConsole(Model.Log logData)
        {
            switch (logData.LogType)
            {
                case LogTypes.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogTypes.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogTypes.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine(DateTime.Now.ToShortDateString() + logData.Message);
        }
    }
}
