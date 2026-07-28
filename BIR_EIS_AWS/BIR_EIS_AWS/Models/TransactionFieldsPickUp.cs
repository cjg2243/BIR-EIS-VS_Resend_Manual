namespace BIR_EIS_AWS.Models
{
    public class TransactionFieldsPickUp
    {
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

        public decimal? VatSales { get; set; }

        public decimal? OtherTaxRev { get; set; }

        public decimal? OtherNonTaxCharge { get; set; }

        public decimal? ExemptSales { get; set; }

        public decimal? ZeroSales { get; set; }

        public decimal? TotSalesAmt { get; set; }

        public Discount Discount { get; set; }

        public decimal? TotNetSalesAftDisct { get; set; }

        public decimal? VATAmt { get; set; }

        public decimal? WithholdIncome { get; set; }

        public decimal? WithholdBusVAT { get; set; }

        public decimal? WithholdBusPT { get; set; }

        public decimal? LocalTax { get; set; }

        public decimal? ServiceCharge { get; set; }

        public decimal? NetAmtPay { get; set; }

        public string PtuNum { get; set; }

        public string Min { get; set; }

        public string Msn { get; set; }

        public string PtuExpDt { get; set; }

        public string TranType { get; set; }

        public string TranTypeCompInvoiceId { get; set; }

        public string FileName { get; set; }
    }

    public class SellerInfo
    {
        public string Tin { get; set; }

        public string BranchCd { get; set; }

        public string Type { get; set; }

        public string RegNm { get; set; }

        public string BusinessNm { get; set; }

        public string Email { get; set; }

        public string RegAddr { get; set; }
    }

    public class BuyerInfo
    {
        public string Tin { get; set; }

        public string BranchCd { get; set; }

        public string Type { get; set; }

        public string RegNm { get; set; }

        public string BusinessNm { get; set; }

        public string Email { get; set; }

        public string RegAddr { get; set; }

        public string DevAddr { get; set; }
    }

    public class Discount
    {
        public decimal? ScAmt { get; set; }

        public decimal? PwdAmt { get; set; }

        public decimal? RegAmt { get; set; }

        public decimal? SpeAmt { get; set; }

        public string Rmk2 { get; set; }
    }

}
