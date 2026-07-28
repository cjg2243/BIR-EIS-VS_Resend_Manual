using System;
using Amazon.DynamoDBv2.DataModel;

namespace BIR_EIS_AWS.Models
{
    [DynamoDBTable("RecordCount")]
    public class RecordCount
    {
        [DynamoDBHashKey]
        public string FileName { get; set; }

        public string TranType { get; set; }

        public int RecCount { get; set; }

        public DateTime DateUpladed { get; set; }

        public int InvResponse { get; set; }

        public int InqResponse01 { get; set; }

        public int InqResponse02 { get; set; }
    }

}
