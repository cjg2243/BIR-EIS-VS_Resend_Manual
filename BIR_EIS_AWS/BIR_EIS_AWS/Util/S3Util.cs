using BIR_EIS_AWS.Models;
using LumenWorks.Framework.IO.Csv;
using System;

namespace BIR_EIS_AWS.Util
{
    enum Field
    {
        CompInvoiceId,
        IssueDtm,
        EisUniqueId,
        CorrYN,
        DocType,
        Rmk1,
        CorrectionCd,
        PrevUniqueId,
        SellerInfo_Tin,
        SellerInfo_BranchCd,
        SellerInfo_Type,
        SellerInfo_RegNm,
        SellerInfo_BusinessNm,
        SellerInfo_Email,
        SellerInfo_RegAddr,
        VatSales,
        OtherTaxRev,
        OtherNonTaxCharge,
        ExemptSales,
        ZeroSales,
        TotSalesAmt,
        Discount_ScAmt,
        Discount_PwdAmt,
        Discount_RegAmt,
        Discount_SpeAmt,
        TotNetSalesAftDisct,
        VATAmt,
        Withholdincome,
        WithholdBusVAT,
        WithholdBusPT,
        LocalTax,
        ServiceCharge,
        NetAmtPay,
        PtuNum,
        Min,
        Msn,
        PtuExpDt
    }

    public static class S3Util
    {
        public static TransactionFieldsPickUp Mapper(CsvReader content)
        {
            var model = new TransactionFieldsPickUp();
            var sellerInfo = new SellerInfo();
            var discount = new Discount();

            //model.Table = content[(int)Field.Table];
            model.CompInvoiceId = content[(int)Field.CompInvoiceId];
            model.IssueDtm = content[(int)Field.IssueDtm];
            model.EisUniqueId = content[(int)Field.EisUniqueId];
            model.CorrYN = content[(int)Field.CorrYN];
            model.DocType = content[(int)Field.DocType];
            model.Rmk1 = content[(int)Field.Rmk1];
            model.CorrectionCd = content[(int)Field.CorrectionCd];
            model.PrevUniqueId = content[(int)Field.PrevUniqueId];
            sellerInfo.Tin = content[(int)Field.SellerInfo_Tin];
            sellerInfo.BranchCd = content[(int)Field.SellerInfo_BranchCd];
            sellerInfo.Type = content[(int)Field.SellerInfo_Type];
            sellerInfo.RegNm = content[(int)Field.SellerInfo_RegNm];
            sellerInfo.BusinessNm = content[(int)Field.SellerInfo_BusinessNm];
            sellerInfo.Email = content[(int)Field.SellerInfo_Email];
            sellerInfo.RegAddr = content[(int)Field.SellerInfo_RegAddr];
            model.VatSales = Convert.ToDecimal(content[(int)Field.VatSales]);
            model.OtherTaxRev = Convert.ToDecimal(content[(int)Field.OtherTaxRev]);
            model.OtherNonTaxCharge = Convert.ToDecimal(content[(int)Field.OtherNonTaxCharge]);
            model.ExemptSales = Convert.ToDecimal(content[(int)Field.ExemptSales]);
            model.ZeroSales = Convert.ToDecimal(content[(int)Field.ZeroSales]);
            model.TotSalesAmt = Convert.ToDecimal(content[(int)Field.TotSalesAmt]);
            discount.ScAmt = Convert.ToDecimal(content[(int)Field.Discount_ScAmt]);
            discount.PwdAmt = Convert.ToDecimal(content[(int)Field.Discount_PwdAmt]);
            discount.RegAmt = Convert.ToDecimal(content[(int)Field.Discount_RegAmt]);
            discount.SpeAmt = Convert.ToDecimal(content[(int)Field.Discount_SpeAmt]);
            model.TotNetSalesAftDisct = Convert.ToDecimal(content[(int)Field.TotNetSalesAftDisct]);
            model.VATAmt = Convert.ToDecimal(content[(int)Field.VATAmt]);
            model.WithholdIncome = Convert.ToDecimal(content[(int)Field.Withholdincome]);
            model.WithholdBusVAT = Convert.ToDecimal(content[(int)Field.WithholdBusVAT]);
            model.WithholdBusPT = Convert.ToDecimal(content[(int)Field.WithholdBusPT]);
            model.LocalTax = Convert.ToDecimal(content[(int)Field.LocalTax]);
            model.ServiceCharge = Convert.ToDecimal(content[(int)Field.ServiceCharge]);
            model.NetAmtPay = Convert.ToDecimal(content[(int)Field.NetAmtPay]);
            model.PtuNum = content[(int)Field.PtuNum];
            model.Min = content[(int)Field.Min];
            model.Msn = content[(int)Field.Msn];
            model.PtuExpDt = content[(int)Field.PtuExpDt];

            model.SellerInfo = sellerInfo;
            model.Discount = discount;

            return model;
        }
    }
}
