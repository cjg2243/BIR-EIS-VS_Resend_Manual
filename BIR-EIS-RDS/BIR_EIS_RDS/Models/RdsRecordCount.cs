using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIR_EIS_RDS.Models
{
    [Table("RecordCountVS")]
    public class RdsRecordCount
    {
        [Key]
        public int ID { get; set; }
        public string FileName { get; set; }

        public string TranType { get; set; }

        public int RecCount { get; set; }

        public DateTime DateUpladed { get; set; }

        public int InvResponse { get; set; }

        public int InqResponse01 { get; set; }

        public int InqResponse02 { get; set; }
    }

}
