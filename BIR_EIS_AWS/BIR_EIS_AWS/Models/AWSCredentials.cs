using Amazon;

namespace BIR_EIS_AWS.Models
{
    public class AWSCredentials
    {
        public RegionEndpoint AwsRegion { get; set; }

        public string AwsAccessKeyId { get; set; }

        public string AwsSecretAccessKey { get; set; }
    }
}
