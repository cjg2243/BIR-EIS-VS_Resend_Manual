using Newtonsoft.Json;

namespace BIR_EIS_AWS.Models.Common
{
    public class CommonResponse
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public CommonResponse() { }

        public CommonResponse(string status, string data, ErrorDetails errorDetails, string tranType)
        {
            this.status = status;
            this.data = data;
            this.errorDetails = errorDetails;
            TranType = tranType;
        }

        public string status { get; set; }

        public string data { get; set; }

        public string TranType { get; set; }

        public string TranTypeCompInvoiceId { get; set; }

        public ErrorDetails errorDetails { get; set; }
    }
}
