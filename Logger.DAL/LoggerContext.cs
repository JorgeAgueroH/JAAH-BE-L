
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Logger.DAL
{
    public class LoggerContext : DbContext
    {
        public LoggerContext(string conecction)
            : base(conecction)
        {
        }

        public DbSet<Model.Log> LogSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}