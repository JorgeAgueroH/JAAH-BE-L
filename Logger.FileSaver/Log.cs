using System;
using Logger.Interfaces;
using System.IO;

namespace Logger.FileSaver
{
    public class Log : IFileAccess
    {
        private const string FileExtension = ".txt";
        public void Save(Model.Log logData, string pathToFile, string fileName)
        {
            var file = string.Format("{0}{1}{2}{3}", pathToFile, fileName, DateTime.Now.ToShortDateString(),
                FileExtension);

            if (!Directory.Exists(pathToFile))
            {
                var logContent = string.Format("{0}{1}", DateTime.Now.ToShortDateString(), logData.Message);

                if (!File.Exists(file))
                {
                    logContent = string.Format("{0}{1}", File.ReadAllText(file), logContent);
                }

                File.WriteAllText(file, logContent);    
            }
            else
            {
                throw  new Exception(string.Format("The Logs Directory {0} does not exists", pathToFile));
            }
        }
    }
}
