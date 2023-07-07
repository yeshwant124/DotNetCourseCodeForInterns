using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelExmaple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelExmaple.Data
{
    public class DataContextEF : DbContext
    {
        //private IConfiguration _config;
        private string? _connectionString;

        public DbSet<Computer> computer { get; set; }

        public DataContextEF(IConfiguration config)
        {
            //_config = config;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.72.230;Database=EmployeeInfo_YK;TrustServerCertificate=True;Trusted_Connection=True;",
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }       

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>()
                .HasKey(c=>c.ComputerId);
            //modelBuilder.Entity<Computer>().ToTable("Customer","TututorialsApp");
        }


    }

}

