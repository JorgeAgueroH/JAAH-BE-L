using Logger.Model;

namespace Logger.Interfaces
{
    public interface IFileAccess
    {
        void Save(Log logData, string pathToFile, string fileName);
    }
}