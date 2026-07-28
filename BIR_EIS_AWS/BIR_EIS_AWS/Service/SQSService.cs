using Amazon.Lambda.Core;
using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BIR_EIS_AWS.Service
{
    public class SQSService
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly string _sqsUrl;
        public SQSService(IAmazonSQS sqsClient, string sqsUrl)
        {
            _sqsClient = sqsClient;
            _sqsUrl = sqsUrl;
        }

        public async Task<SendMessageResponse> SendMessageAsync(string message, string key)
        {
            try
            {
                var request = new SendMessageRequest()
                {
                    QueueUrl = _sqsUrl,
                    MessageBody = message
                };

                var sendMessageResponse = await _sqsClient.SendMessageAsync(request);
                if (sendMessageResponse.HttpStatusCode == HttpStatusCode.OK)
                {
                    LambdaLogger.Log("Send message success! " + key);
                    return sendMessageResponse;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                LambdaLogger.Log("Error in sending message to SQS: " + ex.ToString());
                return null;
            }

        }
    }
}
