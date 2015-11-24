using Logger.Model;
namespace Logger.Interfaces
{
    public interface IDataAccess
    {
        void Save(Log logData, string connectionString);
    }
}
