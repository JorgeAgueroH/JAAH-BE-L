using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logger.Model
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        public string Message { get; set; }

        public LogTypes LogType { get; set; }

        public bool IsValidMessage()
        {
            return !(string.IsNullOrEmpty(Message));
        }
    }

    public enum LogTypes
    {
        Message,
        Warning,
        Error
    }
}
