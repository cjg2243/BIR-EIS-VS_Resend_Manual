using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIR_EIS_RDS.Models
{
    [Table("IesErrorLogsVS")]
    public class RdsIesErrorLog
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateUploaded { get; set; }
        public string ModuleName { get; set; }
        public string FileName { get; set; }
        public string ErrorLog { get; set; }
    }
}
