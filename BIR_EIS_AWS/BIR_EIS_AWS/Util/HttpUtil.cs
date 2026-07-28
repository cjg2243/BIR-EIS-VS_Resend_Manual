using System.Net.Http;

namespace BIR_EIS_AWS.Util
{
    public static class HttpUtil
    {
        /// <summary>
        /// Create HttpClient for Authentication API
        /// </summary>
        /// <param name="accreditationId"></param>
        /// <param name="applicationId"></param>
        /// <param name="auth"></param>
        /// <param name="dt"></param>
        /// <returns>HttpClient</returns>
        public static HttpClient AuthenticationClient(string accreditationId, string applicationId, string auth, string datetime)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("accreditationId", accreditationId);
            client.DefaultRequestHeaders.Add("applicationId", applicationId);
            client.DefaultRequestHeaders.Add("authorization", "Bearer " + auth);
            client.DefaultRequestHeaders.Add("datetime", datetime);
            return client;
        }

        public static HttpClient InvoiceClient(string accreditationId, string applicationId, string auth, string token, string dtime)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("accreditationId", accreditationId);
            client.DefaultRequestHeaders.Add("applicationId", applicationId);
            client.DefaultRequestHeaders.Add("authToken", token);
            client.DefaultRequestHeaders.Add("authorization", auth);
            client.DefaultRequestHeaders.Add("datetime", dtime);
            return client;
        }


        public static HttpClient InquiryClient(string accreditationId, string applicationId, string auth, string token, string dtime)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("accreditationId", accreditationId);
            client.DefaultRequestHeaders.Add("applicationId", applicationId);
            client.DefaultRequestHeaders.Add("authToken", token);
            client.DefaultRequestHeaders.Add("authorization", auth);
            client.DefaultRequestHeaders.Add("datetime", dtime);

            return client;
        }
    }
}
