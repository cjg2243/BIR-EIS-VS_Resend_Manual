using System;
using Amazon.DynamoDBv2.DataModel;

namespace BIR_EIS_AWS.Models
{
    [DynamoDBTable("HyperlocalMapping")]
    public class HyperLocalMapping
    {
        [DynamoDBHashKey]
        public string HyperlocalBranch { get; set; }

        public string BranchCode { get; set; }
    }

}
