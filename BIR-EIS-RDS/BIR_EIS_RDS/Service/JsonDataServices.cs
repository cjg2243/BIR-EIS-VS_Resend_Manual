using Amazon.Lambda.Core;
using BIR_EIS_RDS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace BIR_EIS_RDS.Service
{
    public class JsonDataServices
    {
        public static List<RdsJsonData> GetAll()
        {
            using (var ctx = new BIREISDBContext())
            {
                return ctx.JsonDatas.ToList();
            }
        }

        public static int Save_JsonData(RdsJsonData jsonData, string TranTypeCompInvoiceId, string min, string branchCode, string fName, string EisUniqueId)
        {
            using (var ctx = new BIREISDBContext())
            {
                RdsJsonData rec = ctx.JsonDatas.Where(m => m.TranTypeCompInvoiceId == TranTypeCompInvoiceId
                    && m.Min == min && m.SellerInfo_BranchCd == branchCode && m.FileName == fName
                    && m.EisUniqueId == EisUniqueId).FirstOrDefault();

                if (rec == null)
                {
                    ctx.Entry(jsonData).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                else
                {
                    rec.AirNum = jsonData.AirNum;
                    rec.AirNumDt = jsonData.AirNumDt;
                    rec.CompInvoiceId = jsonData.CompInvoiceId;
                    rec.CorrectionCd = jsonData.CorrectionCd;
                    rec.CorrYN = jsonData.CorrYN;
                    rec.Discount_PwdAmt = jsonData.Discount_PwdAmt;
                    rec.Discount_RegAmt = jsonData.Discount_RegAmt;
                    rec.Discount_ScAmt = jsonData.Discount_ScAmt;
                    rec.Discount_SpeAmt = jsonData.Discount_SpeAmt;
                    rec.DocType = jsonData.DocType;
                    rec.EisUniqueId = jsonData.EisUniqueId;
                    rec.ExemptSales = jsonData.ExemptSales;
                    rec.FileName = jsonData.FileName;
                    rec.ForCur_ConvRate = jsonData.ForCur_ConvRate;
                    rec.ForCur_Currency = jsonData.ForCur_Currency;
                    rec.ForCur_ForexAmt = jsonData.ForCur_ForexAmt;
                    rec.IssueDtm = jsonData.IssueDtm;
                    rec.LadNum = jsonData.LadNum;
                    rec.LadNumDt = jsonData.LadNumDt;
                    rec.LocalTax = jsonData.LocalTax == null ? 0 : jsonData.LocalTax;
                    rec.Min = jsonData.Min;
                    rec.Msn = jsonData.Msn;
                    rec.NetAmtPay = jsonData.NetAmtPay;
                    rec.OtherNonTaxCharge = jsonData.OtherNonTaxCharge;
                    rec.OtherTaxRev = jsonData.OtherTaxRev;
                    rec.PrevUniqueId = jsonData.PrevUniqueId;
                    rec.PtuNum = jsonData.PtuNum;
                    rec.Rmk1 = jsonData.Rmk1;
                    rec.SellerInfo_BranchCd = jsonData.SellerInfo_BranchCd;
                    rec.SellerInfo_BusinessNm = jsonData.SellerInfo_BusinessNm;
                    rec.SellerInfo_Email = jsonData.SellerInfo_Email;
                    rec.SellerInfo_RegAddr = jsonData.SellerInfo_RegAddr;
                    rec.SellerInfo_RegNm = jsonData.SellerInfo_RegNm;
                    rec.SellerInfo_Tin = jsonData.SellerInfo_Tin;
                    rec.SellerInfo_Type = jsonData.SellerInfo_Type;
                    rec.ServiceCharge = jsonData.ServiceCharge;
                    rec.TotNetItemSales = jsonData.TotNetItemSales;
                    rec.TotNetSalesAftDisct = jsonData.TotNetSalesAftDisct;
                    rec.TotSalesAmt = jsonData.TotSalesAmt;
                    rec.TransClass = jsonData.TransClass;
                    rec.TranType = jsonData.TranType;
                    rec.TranTypeCompInvoiceId = jsonData.TranTypeCompInvoiceId;
                    rec.VATAmt = jsonData.VATAmt;
                    rec.VatSales = jsonData.VatSales;
                    rec.WithholdBusPT = jsonData.WithholdBusPT;
                    rec.WithholdBusVAT = jsonData.WithholdBusVAT;
                    rec.WithholdIncome = jsonData.WithholdIncome;
                    rec.ZeroSales = jsonData.ZeroSales;

                    ctx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                return ctx.SaveChanges();
            }
        }

        public static int Save_RdsRecordCount(RdsRecordCount rdsRecordCount, string fName)
        {
            using (var ctx = new BIREISDBContext())
            {
                RdsRecordCount rec = ctx.RdsRecordCounts.Where(m => m.FileName == fName).FirstOrDefault();

                if (rec == null)
                {
                    ctx.Entry(rdsRecordCount).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                else
                {
                    rec.DateUpladed = rdsRecordCount.DateUpladed;
                    rec.RecCount = rdsRecordCount.RecCount;
                    rec.InvResponse = 0;
                    rec.InqResponse01 = 0;
                    rec.InqResponse02 = 0;
                    ctx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                return ctx.SaveChanges();
            }
        }

        public static int Save_ErrorLogs(RdsIesErrorLog rdsIesErrorLog)
        {
            using (var ctx = new BIREISDBContext())
            {
                ctx.Entry(rdsIesErrorLog).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                return ctx.SaveChanges();
            }
        }

        public static int Save_DecryptedInvResponse(RdsDecryptedInvResponse decryptedInvResponse, string tranTypeCompInvoiceId, string branchCode, string min, string EisUniqueId)
        {
            LambdaLogger.Log("tranTypeCompInvoiceId : " + tranTypeCompInvoiceId);
            LambdaLogger.Log("branchCode : " + branchCode);
            LambdaLogger.Log("min : " + min);
            LambdaLogger.Log("EisUniqueId : " + EisUniqueId);

            using (var ctx = new BIREISDBContext())
            {
                RdsDecryptedInvResponse rec = ctx.DecryptedInvResponses.Where(m => m.TranTypeCompInvoiceId == tranTypeCompInvoiceId
                    && m.BranchCode == branchCode && m.Min == min
                    && m.EisUniqueId == EisUniqueId).FirstOrDefault();

                if (rec == null)
                {
                    rec = ctx.DecryptedInvResponses.Where(m => m.TranTypeCompInvoiceId == tranTypeCompInvoiceId
                        && m.BranchCode == branchCode && m.Min == min).FirstOrDefault();
                }

                if (rec == null)
                {
                    ctx.Entry(decryptedInvResponse).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                else
                {
                    rec.accreditationId = decryptedInvResponse.accreditationId;
                    rec.ackId = decryptedInvResponse.ackId;
                    rec.description = decryptedInvResponse.description;
                    rec.ErrorCode = decryptedInvResponse.ErrorCode;
                    rec.ErrorMessage = decryptedInvResponse.ErrorMessage;
                    rec.FileName = decryptedInvResponse.FileName;
                    rec.responseDtm = decryptedInvResponse.responseDtm;
                    rec.TranType = decryptedInvResponse.TranType;
                    rec.TranTypeCompInvoiceId = decryptedInvResponse.TranTypeCompInvoiceId;
                    rec.userId = decryptedInvResponse.userId;
                    rec.EisUniqueId = decryptedInvResponse.EisUniqueId;

                    ctx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                return ctx.SaveChanges();
            }
        }

        public static int Save_DecryptedInqResponse(RdsDecryptedInqResponse decryptedInqResponse, string tranTypeCompInvoiceId, string BranchCode, string min, string EisUniqueId)
        {
            LambdaLogger.Log("BranchCode : " + BranchCode);
            LambdaLogger.Log("Min : " + min);

            using (var ctx = new BIREISDBContext())
            {
                RdsDecryptedInqResponse rec = ctx.DecryptedInqResponse.Where(m => m.TranTypeCompInvoiceId == tranTypeCompInvoiceId
                    && m.BranchCode == BranchCode && m.Min == min
                    && m.EisUniqueId == EisUniqueId).FirstOrDefault();

                if (rec == null)
                {
                    rec = ctx.DecryptedInqResponse.Where(m => m.TranTypeCompInvoiceId == tranTypeCompInvoiceId
                        && m.BranchCode == BranchCode && m.Min == min).FirstOrDefault();
                }

                if (rec == null)
                {
                    ctx.Entry(decryptedInqResponse).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                else
                {
                    rec.accreditationId = decryptedInqResponse.accreditationId;
                    rec.ackId = decryptedInqResponse.ackId;
                    rec.description = decryptedInqResponse.description;
                    rec.failCountQuantity = decryptedInqResponse.failCountQuantity;
                    rec.failReasonStatusCode = decryptedInqResponse.failReasonStatusCode;
                    rec.FileName = decryptedInqResponse.FileName;
                    rec.ProcessedDocuments_description = decryptedInqResponse.ProcessedDocuments_description;
                    rec.ProcessedDocuments_invoiceUid = decryptedInqResponse.ProcessedDocuments_invoiceUid;
                    rec.ProcessedDocuments_resultStatusCode = decryptedInqResponse.ProcessedDocuments_resultStatusCode;
                    rec.processStatusCode = decryptedInqResponse.processStatusCode;
                    rec.refSubmitId = decryptedInqResponse.refSubmitId;
                    rec.responseDtm = decryptedInqResponse.responseDtm;
                    rec.successCountQuantity = decryptedInqResponse.successCountQuantity;
                    rec.totalCountQuantity = decryptedInqResponse.totalCountQuantity;
                    rec.TranType = decryptedInqResponse.TranType;
                    rec.TranTypeCompInvoiceId = decryptedInqResponse.TranTypeCompInvoiceId;
                    rec.TranTypeRefSubmitId = decryptedInqResponse.TranTypeRefSubmitId;
                    rec.userId = decryptedInqResponse.userId;
                    rec.Min = min;
                    rec.BranchCode = BranchCode;
                    rec.EisUniqueId = EisUniqueId;

                    ctx.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                return ctx.SaveChanges();
            }
        }

        public static bool InvSubmitted(string tranTypeCompInvoiceId, string fileName, string branchCode)
        {
            bool invSubmitted = true;

            using (var ctx = new BIREISDBContext())
            {
                RdsDecryptedInvResponse rec = ctx.DecryptedInvResponses.Where(m => m.TranTypeCompInvoiceId == tranTypeCompInvoiceId
                    && m.FileName == fileName && m.BranchCode == branchCode).FirstOrDefault();

                if (rec == null)
                {
                    invSubmitted = false;
                }

            }

            return invSubmitted;
        }


        public static List<RdsJsonDataResend> GetResend(string tranType, string tranDate)
        {
            List<RdsJsonDataResend> rec = new List<RdsJsonDataResend>();

            LambdaLogger.Log("CompanyCode :" + tranType.Replace("POS-", ""));

            var recTmp = new List<RdsJsonDataResend>();

            using (var ctx = new BIREISDBContext())
            {
                recTmp = ctx.JsonResend.Where(m => m.CompanyCode == tranType.Replace("POS-", "")
                    && m.IssueDtm == tranDate).ToList();

                foreach (var data in recTmp)
                {
                    RdsJsonDataResend r = new RdsJsonDataResend();
                    r.ID = data.ID;
                    r.TranTypeCompInvoiceId = data.TranTypeCompInvoiceId;
                    r.CompInvoiceId = data.CompInvoiceId;
                    r.IssueDtm = data.IssueDtm;
                    r.EisUniqueId = data.EisUniqueId;
                    r.CorrYN = data.CorrYN;
                    r.TransClass = data.TransClass;
                    r.DocType = data.DocType;
                    r.Rmk1 = data.Rmk1;
                    r.CorrectionCd = data.CorrectionCd;
                    r.PrevUniqueId = data.PrevUniqueId;
                    r.SellerInfo_Tin = data.SellerInfo_Tin;
                    r.SellerInfo_BranchCd = data.SellerInfo_BranchCd;
                    r.SellerInfo_Type = data.SellerInfo_Type;
                    r.SellerInfo_RegNm = data.SellerInfo_RegNm;
                    r.SellerInfo_BusinessNm = data.SellerInfo_BusinessNm;
                    r.SellerInfo_Email = data.SellerInfo_Email;
                    r.SellerInfo_RegAddr = data.SellerInfo_RegAddr;
                    r.BuyerInfo_Tin = data.BuyerInfo_Tin;
                    r.BuyerInfo_BranchCd = data.BuyerInfo_BranchCd;
                    r.BuyerInfo_RegNm = data.BuyerInfo_RegNm;
                    r.BuyerInfo_BusinessNm = data.BuyerInfo_BusinessNm;
                    r.BuyerInfo_Email = data.BuyerInfo_Email;
                    r.BuyerInfo_RegAddr = data.BuyerInfo_RegAddr;
                    r.AirNum = data.AirNum;
                    r.AirNumDt = data.AirNumDt;
                    r.LadNum = data.LadNum;
                    r.LadNumDt = data.LadNumDt;
                    r.TotNetItemSales = data.TotNetItemSales;
                    r.ForCur_Currency = data.ForCur_Currency;
                    r.ForCur_ConvRate = data.ForCur_ConvRate;
                    r.ForCur_ForexAmt = data.ForCur_ForexAmt;
                    r.Discount_ScAmt = data.Discount_ScAmt;
                    r.Discount_PwdAmt = data.Discount_PwdAmt;
                    r.Discount_RegAmt = data.Discount_RegAmt;
                    r.Discount_SpeAmt = data.Discount_SpeAmt;
                    r.Discount_Rmk2 = data.Discount_Rmk2;
                    r.TotNetSalesAftDisct = data.TotNetSalesAftDisct;
                    r.VATAmt = data.VATAmt;
                    r.WithholdIncome = data.WithholdIncome;
                    r.WithholdBusVAT = data.WithholdBusVAT;
                    r.WithholdBusPT = data.WithholdBusPT;
                    r.LocalTax = data.LocalTax;
                    r.ServiceCharge = data.ServiceCharge;
                    r.NetAmtPay = data.NetAmtPay;
                    r.PtuNum = data.PtuNum;
                    r.VatSales = data.VatSales;
                    r.OtherTaxRev = data.OtherTaxRev;
                    r.OtherNonTaxCharge = data.OtherNonTaxCharge;
                    r.ExemptSales = data.ExemptSales;
                    r.ZeroSales = data.ZeroSales;
                    r.TotSalesAmt = data.TotSalesAmt;
                    r.Min = data.Min;
                    r.Msn = data.Msn;
                    r.TranType = data.TranType;
                    r.FileName = data.FileName;
                    r.CompanyCode = data.CompanyCode;

                    rec.Add(r);
                }
            }

            return rec;
        }

        public static List<RdsJsonDataResend> GetResend(int take)
        {
            List<RdsJsonDataResend> rec = new List<RdsJsonDataResend>();

            var recTmp = new List<RdsJsonDataResend>();

            using (var ctx = new BIREISDBContext())
            {
                recTmp = ctx.JsonResend.OrderBy(m => m.ID).Take(take).ToList();

                foreach (var data in recTmp)
                {
                    RdsJsonDataResend r = new RdsJsonDataResend();
                    r.ID = data.ID;
                    r.TranTypeCompInvoiceId = data.TranTypeCompInvoiceId;
                    r.CompInvoiceId = data.CompInvoiceId;
                    r.IssueDtm = data.IssueDtm;
                    r.EisUniqueId = data.EisUniqueId;
                    r.CorrYN = data.CorrYN;
                    r.TransClass = data.TransClass;
                    r.DocType = data.DocType;
                    r.Rmk1 = data.Rmk1;
                    r.CorrectionCd = data.CorrectionCd;
                    r.PrevUniqueId = data.PrevUniqueId;
                    r.SellerInfo_Tin = data.SellerInfo_Tin;
                    r.SellerInfo_BranchCd = data.SellerInfo_BranchCd;
                    r.SellerInfo_Type = data.SellerInfo_Type;
                    r.SellerInfo_RegNm = data.SellerInfo_RegNm;
                    r.SellerInfo_BusinessNm = data.SellerInfo_BusinessNm;
                    r.SellerInfo_Email = data.SellerInfo_Email;
                    r.SellerInfo_RegAddr = data.SellerInfo_RegAddr;
                    r.BuyerInfo_Tin = data.BuyerInfo_Tin;
                    r.BuyerInfo_BranchCd = data.BuyerInfo_BranchCd;
                    r.BuyerInfo_RegNm = data.BuyerInfo_RegNm;
                    r.BuyerInfo_BusinessNm = data.BuyerInfo_BusinessNm;
                    r.BuyerInfo_Email = data.BuyerInfo_Email;
                    r.BuyerInfo_RegAddr = data.BuyerInfo_RegAddr;
                    r.AirNum = data.AirNum;
                    r.AirNumDt = data.AirNumDt;
                    r.LadNum = data.LadNum;
                    r.LadNumDt = data.LadNumDt;
                    r.TotNetItemSales = data.TotNetItemSales;
                    r.ForCur_Currency = data.ForCur_Currency;
                    r.ForCur_ConvRate = data.ForCur_ConvRate;
                    r.ForCur_ForexAmt = data.ForCur_ForexAmt;
                    r.Discount_ScAmt = data.Discount_ScAmt;
                    r.Discount_PwdAmt = data.Discount_PwdAmt;
                    r.Discount_RegAmt = data.Discount_RegAmt;
                    r.Discount_SpeAmt = data.Discount_SpeAmt;
                    r.TotNetSalesAftDisct = data.TotNetSalesAftDisct;
                    r.VATAmt = data.VATAmt;
                    r.WithholdIncome = data.WithholdIncome;
                    r.WithholdBusVAT = data.WithholdBusVAT;
                    r.WithholdBusPT = data.WithholdBusPT;
                    r.LocalTax = data.LocalTax;
                    r.ServiceCharge = data.ServiceCharge;
                    r.NetAmtPay = data.NetAmtPay;
                    r.PtuNum = data.PtuNum;
                    r.VatSales = data.VatSales;
                    r.OtherTaxRev = data.OtherTaxRev;
                    r.OtherNonTaxCharge = data.OtherNonTaxCharge;
                    r.ExemptSales = data.ExemptSales;
                    r.ZeroSales = data.ZeroSales;
                    r.TotSalesAmt = data.TotSalesAmt;
                    r.Min = data.Min;
                    r.Msn = data.Msn;
                    r.TranType = data.TranType;
                    r.FileName = data.FileName;
                    r.CompanyCode = data.CompanyCode;

                    rec.Add(r);
                }
            }

            return rec;
        }

        public static List<RdsJsonDataResend> GetResendSP(string param)
        {
            List<RdsJsonDataResend> rec = new List<RdsJsonDataResend>();
            var recTmp = new List<RdsJsonDataResend>();

            string sql = "CALL spGetResendVS_Manual('" + param + "');";

            using (var ctx = new BIREISDBContext())
            {
                DbCommand cmd;
                DbDataReader rdr;

                cmd = ctx.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = sql;

                ctx.Database.OpenConnection();

                // Create a DataReader  
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    RdsJsonDataResend r = new RdsJsonDataResend();
                    r.ID = rdr.GetInt32("ID");
                    r.TranTypeCompInvoiceId = rdr.GetString("TranTypeCompInvoiceId");
                    r.CompInvoiceId = rdr.GetString("CompInvoiceId");
                    r.IssueDtm = rdr.GetString("IssueDtm");
                    r.EisUniqueId = rdr.GetString("EisUniqueId");
                    r.CorrYN = rdr.GetString("CorrYN");
                    r.TransClass = !rdr.IsDBNull("TransClass") ? rdr.GetString("TransClass") : null;
                    r.DocType = rdr.GetString("DocType");
                    r.Rmk1 = !rdr.IsDBNull("Rmk1") ? rdr.GetString("Rmk1") : null;
                    r.CorrectionCd = rdr.GetString("CorrectionCd");
                    r.PrevUniqueId = rdr.GetString("PrevUniqueId");
                    r.SellerInfo_Tin = rdr.GetString("SellerInfo_Tin");
                    r.SellerInfo_BranchCd = rdr.GetString("SellerInfo_BranchCd");
                    r.SellerInfo_Type = rdr.GetString("SellerInfo_Type");
                    r.SellerInfo_RegNm = rdr.GetString("SellerInfo_RegNm");
                    r.SellerInfo_BusinessNm = rdr.GetString("SellerInfo_BusinessNm");
                    r.SellerInfo_Email = rdr.GetString("SellerInfo_Email");
                    r.SellerInfo_RegAddr = rdr.GetString("SellerInfo_RegAddr");
                    r.BuyerInfo_Tin = !rdr.IsDBNull("BuyerInfo_Tin") ? rdr.GetString("BuyerInfo_Tin") : null;
                    r.BuyerInfo_BranchCd = !rdr.IsDBNull("BuyerInfo_BranchCd") ? rdr.GetString("BuyerInfo_BranchCd") : null;
                    r.BuyerInfo_RegNm = !rdr.IsDBNull("BuyerInfo_RegNm") ? rdr.GetString("BuyerInfo_RegNm") : null;
                    r.BuyerInfo_BusinessNm = !rdr.IsDBNull("BuyerInfo_BusinessNm") ? rdr.GetString("BuyerInfo_BusinessNm") : null;
                    r.BuyerInfo_Email = !rdr.IsDBNull("BuyerInfo_Email") ? rdr.GetString("BuyerInfo_Email") : null;
                    r.BuyerInfo_RegAddr = !rdr.IsDBNull("BuyerInfo_RegAddr") ? rdr.GetString("BuyerInfo_RegAddr") : null;
                    r.AirNum = !rdr.IsDBNull("AirNum") ? rdr.GetString("AirNum") : null;
                    r.AirNumDt = !rdr.IsDBNull("AirNumDt") ? rdr.GetString("AirNumDt") : null;
                    r.LadNum = !rdr.IsDBNull("LadNum") ? rdr.GetString("LadNum") : null;
                    r.LadNumDt = !rdr.IsDBNull("LadNumDt") ? rdr.GetString("LadNumDt") : null;
                    if (rdr.IsDBNull("TotNetItemSales"))
                    {
                        r.TotNetItemSales = null;
                    }
                    else
                    {
                        r.TotNetItemSales = rdr.GetDecimal("TotNetItemSales");
                    }
                    r.ForCur_Currency = !rdr.IsDBNull("ForCur_Currency") ? rdr.GetString("ForCur_Currency") : null;
                    if(rdr.IsDBNull("ForCur_ConvRate"))
                    {
                        r.ForCur_ConvRate = null;
                    }
                    else
                    {
                        r.ForCur_ConvRate = rdr.GetInt16("ForCur_ConvRate");
                    }
                    if (rdr.IsDBNull("ForCur_ForexAmt"))
                    {
                        r.ForCur_ForexAmt = null;
                    }
                    else
                    {
                        r.ForCur_ForexAmt = rdr.GetInt16("ForCur_ForexAmt");
                    }
                    if (rdr.IsDBNull("LocalTax"))
                    {
                        r.LocalTax = null;
                    }
                    else
                    {
                        r.LocalTax = rdr.GetDecimal("LocalTax");
                    }
                    if(rdr.IsDBNull("ServiceCharge"))
                    {
                        r.ServiceCharge = null;
                    }
                    else
                    {
                        r.ServiceCharge = rdr.GetDecimal("ServiceCharge");
                    }                        
                    r.Discount_ScAmt = rdr.GetDecimal("Discount_ScAmt");
                    r.Discount_PwdAmt = rdr.GetDecimal("Discount_PwdAmt");
                    r.Discount_RegAmt = rdr.GetDecimal("Discount_RegAmt");
                    r.Discount_SpeAmt = rdr.GetDecimal("Discount_SpeAmt");
                    r.Discount_Rmk2 = rdr.GetString("Discount_Rmk2");
                    r.TotNetSalesAftDisct = rdr.GetDecimal("TotNetSalesAftDisct");
                    r.VATAmt = rdr.GetDecimal("VATAmt");
                    r.WithholdIncome = rdr.GetDecimal("WithholdIncome");
                    r.WithholdBusVAT = rdr.GetDecimal("WithholdBusVAT");
                    r.WithholdBusPT = rdr.GetDecimal("WithholdBusPT");
                    //r.LocalTax = rdr.GetDecimal("LocalTax");
                    //r.ServiceCharge = rdr.GetDecimal("ServiceCharge");
                    r.NetAmtPay = rdr.GetDecimal("NetAmtPay");
                    r.PtuNum = rdr.GetString("PtuNum");
                    r.VatSales = rdr.GetDecimal("VatSales");
                    r.OtherTaxRev = rdr.GetDecimal("OtherTaxRev");
                    r.OtherNonTaxCharge = rdr.GetDecimal("OtherNonTaxCharge");
                    r.ExemptSales = rdr.GetDecimal("ExemptSales");
                    r.ZeroSales = rdr.GetDecimal("ZeroSales");
                    r.TotSalesAmt = rdr.GetDecimal("TotSalesAmt");
                    r.Min = rdr.GetString("Min");
                    r.Msn = rdr.GetString("Msn");
                    r.TranType = rdr.GetString("TranType");
                    r.FileName = rdr.GetString("FileName");
                    r.CompanyCode = rdr.GetString("CompanyCode");

                    rec.Add(r);
                }
            }

            return rec;
        }
    }
}
