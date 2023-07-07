using DotNetAPIIntermediate.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPIIntermediate.Data
{
    public class DataContextEF:DbContext
    {
        private readonly IConfiguration _config;


        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserJobInfo> UserJobInfo { get; set; }
        public virtual DbSet<UserSalary> UserSalary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),optionsBuilder=>optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<User>().ToTable("Users", "TutorialAppSchema").HasKey(t => t.UserId);
            modelBuilder.Entity<UserJobInfo>().ToTable("UserJobInfo", "TutorialAppSchema").HasKey(t => t.UserId);
            modelBuilder.Entity<UserSalary>().ToTable("UserSalary", "TutorialAppSchema").HasKey(t => t.UserId);
        }
    }
}
