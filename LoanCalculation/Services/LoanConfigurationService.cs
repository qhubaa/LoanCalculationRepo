using LoanCalculation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculation.Data;

namespace LoanCalculation.Services
{
    public class LoanConfigurationService : ILoanConfigurationService
    {
        private readonly ILoanConfigurationRepository _loanConfigurationRepository;
        public LoanConfigurationService(ILoanConfigurationRepository loanConfigurationRepository)
        {
            _loanConfigurationRepository = loanConfigurationRepository;
        }
        public Task<LoanConfiguration> GetLoanConfiguration(int id)
        {
            return _loanConfigurationRepository.GetLoanConfigurationAsync(id);
        }

        public Task<bool> SaveChanges()
        {
            return _loanConfigurationRepository.SaveChangesAsync();
        }
    }
}
