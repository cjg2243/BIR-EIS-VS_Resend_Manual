using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIR_EIS_RDS.Models
{
    [Table("configs")]
    public class Configs
    {
        [Key]
        public int ID { get; set; }
        public string CompanyCode { get; set; }
        public string TransType { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string AccreditationId { get; set; }
        public string ApplicationId { get; set; }
        public string KeyId { get; set; }
        public string AppKey { get; set; }
        public string AuthKey { get; set; }
        public string SessionKey { get; set; }
    }
}
