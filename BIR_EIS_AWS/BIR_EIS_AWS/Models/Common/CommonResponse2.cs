using Newtonsoft.Json;

namespace BIR_EIS_AWS.Models.Common
{
    public class CommonResponse2
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public string status { get; set; }

        public DataDto data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorDetails errorDetails { get; set; }

        public string FileName { get; set; }

    }
}
