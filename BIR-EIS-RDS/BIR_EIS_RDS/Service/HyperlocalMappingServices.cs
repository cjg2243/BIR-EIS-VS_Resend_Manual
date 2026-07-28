using BIR_EIS_RDS.Models;
using System.Collections.Generic;
using System.Linq;

namespace BIR_EIS_RDS.Service
{
    public class HyperlocalMappingServices
    {
        public static List<HyperlocalMapping> GetAll(string connectionString)
        {
            using (var ctx = new BIREISDBContext())
            {
                return ctx.RdsHyperlocalMapping.ToList();
            }
        }

        public static HyperlocalMapping GetHyperlocal(string connectionString, string hyperLocalBranch)
        {
            using (var ctx = new BIREISDBContext())
            {
                return ctx.RdsHyperlocalMapping
                                .Where(m => m.HyperlocalBranch == hyperLocalBranch)
                                .FirstOrDefault();
            }
        }

    }
}
