using BIR_EIS_RDS.Models;
using System.Collections.Generic;
using System.Linq;

namespace BIR_EIS_RDS.Service
{
    public static class ConfigService
    {
        public static List<Configs> GetAll()
        {
            using (var ctx = new BIREISDBContext())
            {
                return ctx.Configs.ToList();
            }
        }

        public static Configs Get(string CompanyCode, string TransType)
        {
            using (var ctx = new BIREISDBContext())
            {
                return ctx.Configs.Where(m => m.CompanyCode == CompanyCode
                    && m.TransType == TransType).FirstOrDefault();
            }
        }

        public static Configs GetByCompanyCode(string companyCode)
        {
            using (var ctx = new BIREISDBContext())
            {
                return ctx.Configs
                                .Where(m => m.CompanyCode == companyCode)
                                .FirstOrDefault();
            }
        }

        public static int UpdateSessionKey(string sessionKey, string companyCode)
        {
            using (var ctx = new BIREISDBContext())
            {
                int i = 0;
                var config = ctx.Configs
                        .Where(m => m.CompanyCode == companyCode)
                        .FirstOrDefault();

                if (config != null)
                {
                    config.SessionKey = sessionKey;
                    ctx.Entry(config).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    i = ctx.SaveChanges();
                }

                return i;

            }
        }

        public static int UpdateAuthKey(string authKey, string companyCode)
        {
            using (var ctx = new BIREISDBContext())
            {
                int i = 0;
                var config = ctx.Configs
                        .Where(m => m.CompanyCode == companyCode)
                        .FirstOrDefault();

                if (config != null)
                {
                    config.AuthKey = authKey;
                    ctx.Entry(config).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    i = ctx.SaveChanges();
                }

                return i;

            }
        }

        public static int UpdateKeys(string companyCode, string transType, string sessionKey, string authKey)
        {
            using (var ctx = new BIREISDBContext())
            {
                int i = 0;
                var config = ctx.Configs
                        .Where(m => m.CompanyCode == companyCode && m.TransType == transType)
                        .FirstOrDefault();

                if (config != null)
                {
                    config.SessionKey = sessionKey;
                    config.AuthKey = authKey;
                    ctx.Entry(config).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    i = ctx.SaveChanges();
                }

                return i;

            }
        }

    }
}
