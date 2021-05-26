using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LoanCalculation.Data
{
    public class LoanContextFactory : IDesignTimeDbContextFactory<LoanContext>
    {
        public LoanContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new LoanContext(new DbContextOptionsBuilder<LoanContext>().Options, config);
        }
    }
}
