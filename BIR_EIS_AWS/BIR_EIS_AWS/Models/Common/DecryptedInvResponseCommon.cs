using Newtonsoft.Json;

namespace BIR_EIS_AWS.Models.Common
{
    public class DecryptedInvResponseCommon
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public DecryptedInvResponseCommon() { }

        public string TranTypeCompInvoiceId { get; set; }

        public string refSubmitId { get; set; }

        public string accreditationId { get; set; }

        public string userId { get; set; }

        public string ackId { get; set; }

        public string responseDtm { get; set; }

        public string description { get; set; }

        public string TranType { get; set; }

        public ErrorDetails errorDetails { get; set; }

        public string FileName { get; set; }

        public string BranchCode { get; set; }

        public string Min { get; set; }

        public string EisUniqueId { get; set; }
    }
}
