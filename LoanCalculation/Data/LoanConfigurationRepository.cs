using LoanCalculation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Data
{
    public class LoanConfigurationRepository : ILoanConfigurationRepository
    {
        private readonly LoanContext _loanContext;

        public LoanConfigurationRepository(LoanContext loanContext)
        {
            _loanContext = loanContext;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<LoanConfiguration> GetLoanConfigurationAsync(int id)
        {
            IQueryable<LoanConfiguration> query = _loanContext.LoanConfiguration;

            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _loanContext.SaveChangesAsync()) > 0;
        }
    }
}
