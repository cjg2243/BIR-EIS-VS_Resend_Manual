namespace BIR_EIS_AWS.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string accreditationId { get; set; }

        public string userId { get; set; }

        public string authToken { get; set; }

        public string sessionKey { get; set; }

        public string tokenExpiry { get; set; }
    }
}
