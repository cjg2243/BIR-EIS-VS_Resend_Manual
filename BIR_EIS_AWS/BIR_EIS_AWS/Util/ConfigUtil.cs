using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Lambda;
using Amazon.S3;
using Amazon.SQS;
using BIR_EIS_AWS.Models;
using System;

namespace BIR_EIS_AWS.Util
{
    public class ConfigUtil
    {
        public readonly Settings _settings;

        public ConfigUtil()
        {
            _settings = SetSettings();
        }

        public Settings SetSettings()
        {
            var credentials = SetCredentials();
            var config = SetConfig(credentials);

            return new Settings()
            {
                AmazonS3Config = config,
                AWSCredentials = credentials,
                AmazonS3Client = SetS3Client(config, credentials),
                AmazonSQSConfig = SetSQSConfig(credentials),
                AmazonSQSClient = SetSQSClient(credentials),
                AmazonDynamoClient = SetDynamoClient(credentials),
                AmazonLambdaClient = SetLambdaClient(credentials)
            };
        }

        private AWSCredentials SetCredentials()
        {
#if DEBUG
            return new AWSCredentials()
            {
                AwsRegion = (RegionEndpoint)typeof(RegionEndpoint).GetField("APSoutheast1").GetValue(null),
                AwsAccessKeyId = "AKIAZDSSHIE2DTCVPU42",
                AwsSecretAccessKey = "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"
                AwsAccessKeyId = "XXXXXXXX",
                AwsSecretAccessKey = "XXXXXXXX"
            };
#else
            return new AWSCredentials()
            {
                AwsRegion = (RegionEndpoint)typeof(RegionEndpoint).GetField("APSoutheast1").GetValue(null),
                AwsAccessKeyId = Environment.GetEnvironmentVariable("awsaccesskey"),
                AwsSecretAccessKey = Environment.GetEnvironmentVariable("awssecretkey")
            };
#endif
        }
        private AmazonS3Config SetConfig(AWSCredentials credentials)
        {
            return new AmazonS3Config()
            {
                ServiceURL = "",
                RegionEndpoint = credentials.AwsRegion
            };
        }

        public AmazonS3Client SetS3Client(AmazonS3Config config, AWSCredentials credentials)
        {
            return new AmazonS3Client(credentials.AwsAccessKeyId,
                credentials.AwsSecretAccessKey,
                config);
        }

        private AmazonSQSConfig SetSQSConfig(AWSCredentials credentials)
        {
#if DEBUG
            return new AmazonSQSConfig()
            {
                RegionEndpoint = credentials.AwsRegion,
                ServiceURL = "https://sqs.ap-southeast-1.amazonaws.com/483255486329/BIR_EIS_SQS"
            };
#else
            return new AmazonSQSConfig()
            {
                RegionEndpoint = RegionEndpoint.APSoutheast1,
                ServiceURL = Environment.GetEnvironmentVariable("sqsUrl")
            };
#endif

        }

        private AmazonSQSClient SetSQSClient(AWSCredentials credentials)
        {
#if DEBUG
            return new AmazonSQSClient(credentials.AwsAccessKeyId
                , credentials.AwsSecretAccessKey
                , credentials.AwsRegion);
#else
            return new AmazonSQSClient(credentials.AwsAccessKeyId
                , credentials.AwsSecretAccessKey
                , RegionEndpoint.APSoutheast1);
#endif
        }

        private AmazonDynamoDBClient SetDynamoClient(AWSCredentials credentials)
        {
#if DEBUG
            return new AmazonDynamoDBClient(credentials.AwsAccessKeyId
                , credentials.AwsSecretAccessKey
                , RegionEndpoint.APSoutheast1);
#else
            return new AmazonDynamoDBClient(credentials.AwsAccessKeyId
                , credentials.AwsSecretAccessKey
                , RegionEndpoint.APSoutheast1);
#endif
        }

        private AmazonLambdaClient SetLambdaClient(AWSCredentials credentials)
        {
            return new AmazonLambdaClient(credentials.AwsAccessKeyId,
                credentials.AwsSecretAccessKey,
                credentials.AwsRegion);
        }

        public class Settings
        {
            public AmazonS3Config AmazonS3Config { get; set; }

            public AWSCredentials AWSCredentials { get; set; }

            public AmazonS3Client AmazonS3Client { get; set; }

            public AmazonSQSConfig AmazonSQSConfig { get; set; }

            public AmazonSQSClient AmazonSQSClient { get; set; }

            public AmazonDynamoDBClient AmazonDynamoClient { get; set; }

            public AmazonLambdaClient AmazonLambdaClient { get; set; }
        }
    }
}