using Amazon.DynamoDBv2.DataModel;

namespace BIR_EIS_AWS.Models
{
    [DynamoDBTable("Keys")]
    public class Keys
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("keyName")]
        public string keyName { get; set; }

        public string value { get; set; }
    }
}
