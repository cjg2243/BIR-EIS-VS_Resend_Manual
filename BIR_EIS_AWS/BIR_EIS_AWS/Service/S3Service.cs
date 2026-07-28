using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BIR_EIS_AWS.Service
{
    public class S3Service
    {
        private readonly AmazonS3Client _s3Client;
        public S3Service(AmazonS3Client s3Client)
        {
            _s3Client = s3Client;
        }
        public async Task<GetObjectResponse> GetObjectAsync(string bucket, string key)
        {
            try
            {
                var request = new GetObjectRequest() { BucketName = bucket, Key = key };
                var getObjectResponse = await _s3Client.GetObjectAsync(request);
                if (getObjectResponse.HttpStatusCode == HttpStatusCode.OK)
                {
                    LambdaLogger.Log("Get object success! " + key);
                    return getObjectResponse;
                }
                else
                {
                    throw new Exception();
                };
            }
            catch (Exception ex)
            {
                LambdaLogger.Log("Error in getting object from S3: " + ex.ToString());
                return null;
            }

        }

        public async Task<string> MoveObjectAsync(string bucket, string key, string destinationBucket)
        {
            string result = "";
            try
            {
                // copy the file first to the destination folder
                var copyResponse = await _s3Client.CopyObjectAsync(bucket, key, destinationBucket, key);

                if (copyResponse.HttpStatusCode == HttpStatusCode.OK)
                {
                    var deleteRequest = new DeleteObjectRequest()
                    {
                        BucketName = bucket,
                        Key = key
                    };

                    // delete the file from the source folder
                    var deleteResponse = await _s3Client.DeleteObjectAsync(deleteRequest);
                    result = "Item successfully processed - " + key;
                }
                else
                {
                    result = "Error moving file. " + key;
                    throw new Exception("File not moved to destination bucket.");
                }

            }
            catch (Exception ex)
            {
                LambdaLogger.Log("Error in moving file " + ex.ToString());
            }

            return result;
        }
    }
}
