using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculation.Data.Entities;

namespace LoanCalculation.Data
{
    public interface ILoanConfigurationRepository
    {
        Task<bool> SaveChangesAsync();

        Task<LoanConfiguration> GetLoanConfigurationAsync(int id);
    }
}
