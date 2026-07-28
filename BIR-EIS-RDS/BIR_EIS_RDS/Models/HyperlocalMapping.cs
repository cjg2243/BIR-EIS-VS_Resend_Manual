using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIR_EIS_RDS.Models
{
    [Table("HyperlocalMappingVS")]
    public class HyperlocalMapping
    {
        [Key]
        public int ID { get; set; }

        public string HyperlocalBranch { get; set; }
        public string BranchCode { get; set; }
    }
}
