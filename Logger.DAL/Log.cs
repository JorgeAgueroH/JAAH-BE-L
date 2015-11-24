using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Interfaces;

namespace Logger.DAL
{
    public class Log : IDataAccess
    {
        public void Save(Model.Log logData, string connectionString)
        {
            LoggerContext db = new LoggerContext(connectionString);

            db.LogSet.Add(logData);
            db.SaveChanges();
        }
    }
}
