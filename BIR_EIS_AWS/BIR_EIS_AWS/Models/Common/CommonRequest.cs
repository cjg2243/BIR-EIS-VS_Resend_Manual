using Newtonsoft.Json;

namespace BIR_EIS_AWS.Models.Common
{
    public class CommonRequest
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public CommonRequest() { }

        public CommonRequest(string data, bool forceRefreshToken, string submitId)
        {
            this.data = data;
            this.forceRefreshToken = forceRefreshToken;
            this.submitId = submitId;
        }

        public string data { get; set; }


        public bool? forceRefreshToken { get; set; }


        public string submitId { get; set; }
    }
}
