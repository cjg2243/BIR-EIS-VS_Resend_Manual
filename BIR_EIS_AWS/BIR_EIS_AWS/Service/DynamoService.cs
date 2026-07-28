using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BIR_EIS_AWS.Service
{
    public class DynamoService
    {
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly DynamoDBContext _context;

        public DynamoService(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
            _context = new DynamoDBContext(dynamoDb);
        }

        public async Task<T> InsertOrUpdateAsync<T>(T model)
        {
            //var model = JsonSerializer.Deserialize<BIRFields>(json);
            //model.Message = Guid.NewGuid().ToString();
            //await Task.Run(() => _context.SaveAsync(model));
            await _context.SaveAsync(model);

            LambdaLogger.Log("Successfully inserted : " + model);
            return await _context.LoadAsync(model);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            return await _context.LoadAsync<T>(key, new DynamoDBContextConfig()
            {
                ConsistentRead = true
            });
        }

        public async Task<List<T>> ScanAsync<T>()
        {
            //example:
            //IEnumerable<Book> itemsWithWrongPrice = context.Scan<Book>(
            //  new ScanCondition("Price", ScanOperator.LessThan, price),
            //  new ScanCondition("ProductCategory", ScanOperator.Equal, "Book")
            // );

            return await Task.Run(() => _context.ScanAsync<T>(null).GetRemainingAsync());
        }

        public async Task<List<HyperLocalMapping>> ScanAsyncKeys<HyperLocalMapping>()
        {
            //example:
            //IEnumerable<Book> itemsWithWrongPrice = context.Scan<Book>(
            //  new ScanCondition("Price", ScanOperator.LessThan, price),
            //  new ScanCondition("ProductCategory", ScanOperator.Equal, "Book")
            // );

            return await Task.Run(() => _context.ScanAsync<HyperLocalMapping>(null).GetRemainingAsync());

        }

        //Manual/Test Put
        public async Task<PutItemResponse> PutItemAsync(string message)
        {
            PutItemRequest request = new PutItemRequest("BIRResponse"
                , new Dictionary<string, AttributeValue>()
                {
                    { "Message",new AttributeValue(){S = message }}
                });

            PutItemResponse result = await _dynamoDb.PutItemAsync(request);
            return result;
        }


    }
}
