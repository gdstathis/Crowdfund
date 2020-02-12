using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdfundCore.Data;
using Microsoft.EntityFrameworkCore;
namespace CrowdfundCore.Data
{
    public class CrowdfundDbContext: DbContext
    {
            private readonly string connectionString_;

            /// <summary>
            /// Parameterless constructor required for Migrations
            /// to run
            /// </summary>
            public CrowdfundDbContext() : base()
            {
                connectionString_ = "Server=localhost;Database=Crowdfund;User Id=sa;Password=QWE123!@#";
            }

            public CrowdfundDbContext(string connString)
            {
                connectionString_ = connString;
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

               

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                 base.OnConfiguring(optionsBuilder);
                 optionsBuilder.UseSqlServer(connectionString_);
        }
    }
    
}
