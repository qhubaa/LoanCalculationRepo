using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculation.Data.Entities;

namespace LoanCalculation.Services
{
    public interface ICalculateLoanService
    {
        Task<LoanPaymentOverview> GetLoanPaymentOverview(int configurationId, decimal loanAmount, int durationOfLoanInYears);
    }
}
