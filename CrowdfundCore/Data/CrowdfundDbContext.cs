using CrowdfundCore.Model;
using Microsoft.EntityFrameworkCore;
using Autofac;
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
                Entity<Backer>().
                ToTable("Backer");
            modelBuilder.
                Entity<Backer>().
                HasIndex(p => p.Email).IsUnique();
            modelBuilder.
                Entity<Backer>().
                HasIndex(p => p.Phone).IsUnique();
            modelBuilder.
                Entity<ProjectCreator>().
                ToTable("ProjectCreator").Property(p => p.Id).IsRequired();
      
            modelBuilder.
                Entity<ProjectCreator>().
                ToTable("ProjectCreator").HasIndex(p => p.Id);
            modelBuilder.
                Entity<Project>().
                ToTable("Project") ;
            modelBuilder.
                Entity<Project>().
                ToTable("Project")
                .HasIndex(p => p.Id).IsUnique();
            modelBuilder
                .Entity<ProjectBacker>()
                .ToTable("ProjectBacker");
            modelBuilder.
                Entity<Status>().
                ToTable("Status");
            modelBuilder.
                Entity<Rewards>().
                ToTable("Rewards");
            modelBuilder
                .Entity<ProjectBacker>()
                .HasKey(pb => new { pb.ProjectId, pb.Backerid });

        }
    }

}
