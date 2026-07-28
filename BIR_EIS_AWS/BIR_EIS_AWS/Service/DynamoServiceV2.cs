using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using BIR_EIS_AWS.Models;

namespace BIR_EIS_AWS.Service
{
    public static class DynamoServiceV2
    {
        public static string InsertOrUpdateAsync(IAmazonDynamoDB dynamoDb, RecordCount model, string partitionKey)
        {
            using (DynamoDBContext context = new DynamoDBContext(dynamoDb))
            {
                try
                {
                    LambdaLogger.Log("model RecordCount : " + JsonConvert.SerializeObject(model, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

                    RecordCount decryptedInvResponse1 = GetAsync<RecordCount>(partitionKey, dynamoDb).Result;
                    LambdaLogger.Log("RecordCount: " + JsonConvert.SerializeObject(decryptedInvResponse1, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

                    if (decryptedInvResponse1 != null)
                    {
                        /*LambdaLogger.Log("Delete start");
                        context.DeleteAsync<RecordCount>(partitionKey);
                        LambdaLogger.Log("Delete end");*/
                    }

                    context.SaveAsync(model);
                    LambdaLogger.Log("Successfully inserted RecordCount : " + JsonConvert.SerializeObject(model, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                }
                catch (Exception ex)
                {
                    LambdaLogger.Log("ERROR InsertOrUpdateAsync RecordCount : " + ex.Message);
                }
            }
            return "InsertOrUpdateAsync";
        }


        public static List<Keys> ScanAsyncKeys<Keys>(IAmazonDynamoDB dynamoDb)
        {
            List<Keys> keyvalues = new List<Keys>();
            using (DynamoDBContext context = new DynamoDBContext(dynamoDb))
            {
                try
                {
                    keyvalues = context.ScanAsync<Keys>(null).GetRemainingAsync().Result;
                }
                catch (Exception ex)
                {
                    LambdaLogger.Log("ERROR ScanAsyncKeys V2 : " + ex.Message);
                }
            }
            return keyvalues;
        }

        public static List<HyperLocalMapping> ScanAsyncHyperlocal<HyperLocalMapping>(IAmazonDynamoDB dynamoDb)
        {
            List<HyperLocalMapping> keyvalues = new List<HyperLocalMapping>();
            using (DynamoDBContext context = new DynamoDBContext(dynamoDb))
            {
                try
                {
                    keyvalues = context.ScanAsync<HyperLocalMapping>(null).GetRemainingAsync().Result;
                }
                catch (Exception ex)
                {
                    LambdaLogger.Log("ERROR ScanAsyncHyperlocal V2 : " + ex.Message);
                }
            }
            return keyvalues;
        }


        public static async Task<T> GetAsync<T>(string key, IAmazonDynamoDB dynamoDb)
        {
            using (DynamoDBContext context = new DynamoDBContext(dynamoDb))
            {
                return await context.LoadAsync<T>(key, new DynamoDBContextConfig()
                {
                    ConsistentRead = true
                });
            }
        }

    }


}
