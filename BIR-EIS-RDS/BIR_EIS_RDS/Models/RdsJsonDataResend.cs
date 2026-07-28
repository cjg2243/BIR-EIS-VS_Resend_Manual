using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIR_EIS_RDS.Models
{
    [Table("vGetResend")]
    public class RdsJsonDataResend
    {
        [Key]
        public int ID { get; set; }
        public string TranTypeCompInvoiceId { get; set; }

        public string CompInvoiceId { get; set; }

        public string IssueDtm { get; set; }

        public string EisUniqueId { get; set; }

        public string CorrYN { get; set; }

        public string TransClass { get; set; }

        public string DocType { get; set; }

        public string Rmk1 { get; set; }

        public string CorrectionCd { get; set; }

        public string PrevUniqueId { get; set; }

        public string SellerInfo_Tin { get; set; }

        public string SellerInfo_BranchCd { get; set; }

        public string SellerInfo_Type { get; set; }

        public string SellerInfo_RegNm { get; set; }

        public string SellerInfo_BusinessNm { get; set; }

        public string SellerInfo_Email { get; set; }

        public string SellerInfo_RegAddr { get; set; }

        public string BuyerInfo_Tin { get; set; }

        public string BuyerInfo_BranchCd { get; set; }

        public string BuyerInfo_RegNm { get; set; }

        public string BuyerInfo_BusinessNm { get; set; }

        public string BuyerInfo_Email { get; set; }

        public string BuyerInfo_RegAddr { get; set; }

        public string AirNum { get; set; }

        public string AirNumDt { get; set; }

        public string LadNum { get; set; }

        public string LadNumDt { get; set; }

        public decimal? TotNetItemSales { get; set; }

        //public decimal TotNetSalesAmt { get; set; }

        public string ForCur_Currency { get; set; }

        public int? ForCur_ConvRate { get; set; }

        public int? ForCur_ForexAmt { get; set; }

        public decimal? Discount_ScAmt { get; set; }

        public decimal? Discount_PwdAmt { get; set; }

        public decimal? Discount_RegAmt { get; set; }

        public decimal? Discount_SpeAmt { get; set; }

        public string Discount_Rmk2 { get; set; }

        public decimal? TotNetSalesAftDisct { get; set; }

        public decimal? VATAmt { get; set; }

        public decimal? WithholdIncome { get; set; }

        public decimal? WithholdBusVAT { get; set; }

        public decimal? WithholdBusPT { get; set; }

        public decimal? LocalTax { get; set; }

        public decimal? ServiceCharge { get; set; }

        public decimal? NetAmtPay { get; set; }

        public string PtuNum { get; set; }

        //public string PtuExpDt { get; set; }

        //public string TransDtm { get; set; }

        public decimal? VatSales { get; set; }

        public decimal? OtherTaxRev { get; set; }

        public decimal? OtherNonTaxCharge { get; set; }

        public decimal? ExemptSales { get; set; }

        public decimal? ZeroSales { get; set; }

        public decimal? TotSalesAmt { get; set; }

        public string Min { get; set; }

        public string Msn { get; set; }

        public string TranType { get; set; }

        public string FileName { get; set; }

        public string CompanyCode { get; set; }
    }
}
