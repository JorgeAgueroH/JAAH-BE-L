
using System.Data.Entity;
namespace Logger.DAL
{
    public class LoggerContext : DbContext
    {
        public LoggerContext(string conecction)
            : base(conecction)
        {
        }

        public DbSet<Model.Log> LogSet { get; set; }
    }
}