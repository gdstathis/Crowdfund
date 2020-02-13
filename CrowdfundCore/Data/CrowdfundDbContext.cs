using CrowdfundCore.Model;
using Microsoft.EntityFrameworkCore;
namespace CrowdfundCore.Data
{
    public class CrowdfundDbContext : DbContext

    {
        private readonly string connectionString_;
        public CrowdfundDbContext() : base()
        {
            connectionString_ = "Server=localhost;Database=Crowdfund;User Id=sa;Password=QWE123!@#";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString_);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.
                Entity<User>().
                ToTable("User");
            modelBuilder.
                Entity<User>().
                ToTable("User").Property(p => p.id_user).IsRequired();
      
            modelBuilder.
                Entity<User>().
                ToTable("User").HasKey(p => p.id_user);
            modelBuilder.
                Entity<Project>().
                ToTable("Project").HasKey(p => p.id_project);



        }
    }

}
