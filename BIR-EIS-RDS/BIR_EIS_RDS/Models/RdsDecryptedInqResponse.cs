using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIR_EIS_RDS.Models
{
    [Table("DecryptedInqResponseVS")]
    public class RdsDecryptedInqResponse
    {
        [Key]
        public int ID { get; set; }

        public string TranTypeCompInvoiceId { get; set; }

        public string TranTypeRefSubmitId { get; set; }

        public string refSubmitId { get; set; }

        public string accreditationId { get; set; }

        public string userId { get; set; }

        public string ackId { get; set; }

        public string responseDtm { get; set; }

        public string processStatusCode { get; set; }

        public string failReasonStatusCode { get; set; }

        public int totalCountQuantity { get; set; }

        public int successCountQuantity { get; set; }

        public int failCountQuantity { get; set; }

        public string description { get; set; }

        public string TranType { get; set; }

        public string ProcessedDocuments_invoiceUid { get; set; }

        public string ProcessedDocuments_resultStatusCode { get; set; }

        public string ProcessedDocuments_description { get; set; }

        public string FileName { get; set; }

        public string Min { get; set; }

        public string BranchCode { get; set; }

        public string EisUniqueId { get; set; }
    }
}
