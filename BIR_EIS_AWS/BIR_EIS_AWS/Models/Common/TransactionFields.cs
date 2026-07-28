using Amazon.DynamoDBv2.DataModel;

namespace BIR_EIS_AWS.Models.Common
{
    [DynamoDBTable("jsonData")]
    public class TransactionFields
    {
        [DynamoDBHashKey]
        public string TranTypeCompInvoiceId { get; set; }

        public string CompInvoiceId { get; set; }

        public string IssueDtm { get; set; }

        public string EisUniqueId { get; set; }

        public string CorrYN { get; set; }

        public string DocType { get; set; }

        public string Rmk1 { get; set; }

        public string CorrectionCd { get; set; }

        public string PrevUniqueId { get; set; }

        public SellerInfo SellerInfo { get; set; }

        public BuyerInfo BuyerInfo { get; set; }

        public decimal VatSales { get; set; }

        public decimal OtherTaxRev { get; set; }

        public decimal OtherNonTaxCharge { get; set; }

        public decimal ExemptSales { get; set; }

        public decimal ZeroSales { get; set; }

        public decimal TotSalesAmt { get; set; }

        public Discount Discount { get; set; }

        public decimal TotNetSalesAftDisct { get; set; }

        public decimal VATAmt { get; set; }

        public decimal WithholdIncome { get; set; }

        public decimal WithholdBusVAT { get; set; }

        public decimal WithholdBusPT { get; set; }

        public decimal LocalTax { get; set; }

        public decimal ServiceCharge { get; set; }

        public decimal NetAmtPay { get; set; }

        public string PtuNum { get; set; }

        public string Min { get; set; }

        public string Msn { get; set; }

        public string PtuExpDt { get; set; }

        public string TranType { get; set; }

        public string FileName { get; set; }
    }

}
