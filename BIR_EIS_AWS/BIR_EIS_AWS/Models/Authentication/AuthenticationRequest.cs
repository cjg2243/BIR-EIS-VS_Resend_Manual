using Newtonsoft.Json;

namespace BIR_EIS_AWS.Models.Authentication
{
    public class AuthenticationRequest
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public AuthenticationRequest()
        {

        }
        public AuthenticationRequest(string userId, string password, string authKey)
        {
            this.userId = userId;
            this.password = password;
            this.authKey = authKey;
        }

        public string userId { get; set; }

        public string password { get; set; }

        public string authKey { get; set; }
    }
}
