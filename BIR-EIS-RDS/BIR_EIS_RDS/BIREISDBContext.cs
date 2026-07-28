using Microsoft.EntityFrameworkCore;
using BIR_EIS_RDS.Models;

namespace BIR_EIS_RDS
{
    public class BIREISDBContext : DbContext
    {
        // DEV
        //private string _connString = "Server=bireisdevawsiv.clqlxmqe7y9e.ap-southeast-1.rds.amazonaws.com;Port=3306;database=BIREISDB;default command timeout=120;Uid=XXXXXXXX;Password=XXXXXXXX;SslMode=None";
        
        // PROD
        private string _connString = "Server=bireisproddb.cmaclx0xkqev.ap-southeast-1.rds.amazonaws.com;Port=3306;database=BIREISPRODDB;default command timeout=900;Uid=XXXXXXXX;Password=XXXXXXXX;SslMode=None";

        public DbSet<Configs> Configs { get; set; }
        public DbSet<RdsJsonData> JsonDatas { get; set; }
        public DbSet<RdsIesErrorLog> RdsIesErrorLogs { get; set; }

        public DbSet<RdsRecordCount> RdsRecordCounts { get; set; }

        public DbSet<HyperlocalMapping> RdsHyperlocalMapping { get; set; }

        public DbSet<RdsDecryptedInvResponse> DecryptedInvResponses { get; set; }

        public DbSet<RdsDecryptedInqResponse> DecryptedInqResponse { get; set; }

        public DbSet<RdsJsonDataResend> JsonResend { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder
        //       .UseMySql(_connString, ServerVersion.AutoDetect(_connString));

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connString, ServerVersion.AutoDetect(_connString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RdsJsonDataResend>(entity => {
                entity.HasNoKey();
                //entity.ToTable("vGetResend");
            });
        }
    }
}
