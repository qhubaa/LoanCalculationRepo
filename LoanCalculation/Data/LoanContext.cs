using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculation.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoanCalculation.Data
{
    public class LoanContext : DbContext
    {
        private readonly IConfiguration _config;

        public LoanContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<LoanConfiguration> LoanConfiguration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("LoanDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanConfiguration>()
                .HasData(new LoanConfiguration
                {
                    Id = 1,
                    AnnualInterestRate = 5,
                    PercentageAdministrationFee = 1,
                    AmountAdministrationFee = 10000
                });

        }
    }
}
