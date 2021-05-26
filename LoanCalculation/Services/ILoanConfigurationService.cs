using LoanCalculation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Services
{
    public interface ILoanConfigurationService
    {
        Task<LoanConfiguration> GetLoanConfiguration(int id);
        Task<bool> SaveChanges();
    }
}
