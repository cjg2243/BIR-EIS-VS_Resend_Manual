namespace BIR_EIS_AWS.Models.Common
{
    public class DecryptedResponse
    {

        public string accreditationId { get; set; }

        public string userId { get; set; }

        public string refSubmitId { get; set; }

        public string ackId { get; set; }

        public string responseDtm { get; set; }

        public string description { get; set; }

        public ErrorDetails errorDetails { get; set; }

    }
}
