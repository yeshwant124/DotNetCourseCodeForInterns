using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExample3
{
    public class DataContextEF: DbContext
    {
        private string? _connectionString;

        public DbSet<Computer>? computer { get; set; }

        public DataContextEF(IConfiguration config) {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,  optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);
            //modelBuilder.Entity<Computer>().HasNoKey();
        }
    }
}
