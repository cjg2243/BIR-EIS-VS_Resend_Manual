using System.Collections.Generic;

namespace BIR_EIS_AWS.Models.Common
{
    public class DataDto
    {
        public string accreditationId { get; set; }

        public string userId { get; set; }

        public string refSubmitId { get; set; }

        public string ackId { get; set; }

        public string responseDtm { get; set; }

        public string processStatusCode { get; set; }

        public string failReasonStatusCode { get; set; }

        public int totalCountQuantity { get; set; }

        public int successCountQuantity { get; set; }

        public int failCountQuantity { get; set; }

        public List<ProcessedDocuments> processedDocuments { get; set; }
    }
}
