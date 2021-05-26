using LoanCalculation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculation.Data;
using Microsoft.IdentityModel.Tokens;

namespace LoanCalculation.Services
{
    public class CalculateLoanService : ICalculateLoanService
    {
        private readonly ILoanConfigurationRepository _loanConfigurationRepository;
        public CalculateLoanService(ILoanConfigurationRepository loanConfigurationRepository)
        {
            _loanConfigurationRepository = loanConfigurationRepository;
        }
        public async Task<LoanPaymentOverview> GetLoanPaymentOverview(int configurationId, decimal loanAmount, int durationOfLoanInYears)
        {
            var loanConfiguration = await _loanConfigurationRepository.GetLoanConfigurationAsync(configurationId);
            var monthlyCost = CalculateMonthlyCost(Convert.ToDouble(loanAmount), durationOfLoanInYears,
                Convert.ToDouble(loanConfiguration.AnnualInterestRate));
            var totalAmountPaidInterestRate =
                CalculateTotalAmountPaidInterestRate(monthlyCost, loanAmount, durationOfLoanInYears);

            return new LoanPaymentOverview
            {
                Aop = CalulateAop(Convert.ToDouble(totalAmountPaidInterestRate), Convert.ToDouble(loanAmount), durationOfLoanInYears),
                MonthlyCost = monthlyCost,
                TotalAmountPaidAdministrativeFees = CalculateTotalAmountPaidAdministrativeFees(loanAmount, loanConfiguration.PercentageAdministrationFee, loanConfiguration.AmountAdministrationFee),
                TotalAmountPaidInterestRate = totalAmountPaidInterestRate
            };
        }

        private decimal CalculateMonthlyCost(double loanAmount, int durationOfLoanInYears, double annualInterestRate)
        {
            var monthlyCost = loanAmount * Math.Pow((1 + (annualInterestRate/100) / 12), (durationOfLoanInYears*12)) *
                                 (annualInterestRate/100) /
                                 (12 * (Math.Pow((1 + (annualInterestRate/100) / 12), durationOfLoanInYears*12) - 1));

            return Convert.ToDecimal(monthlyCost);
        }

        private decimal CalculateTotalAmountPaidInterestRate(decimal monthlyCost, decimal loanAmount, decimal durationOfLoanInYears)
        {
            return (monthlyCost * durationOfLoanInYears * 12) - loanAmount;
        }

        private decimal CalculateTotalAmountPaidAdministrativeFees(decimal loanAmount,
            decimal percentageAdministrationFee, decimal amountAdministrationFee)
        {
            var administrationFeeFrompercentage = loanAmount * (percentageAdministrationFee / 100);
            if (administrationFeeFrompercentage <= amountAdministrationFee)
            {
                return administrationFeeFrompercentage;
            }
            else
            {
                return amountAdministrationFee;
            }
        }

        private decimal CalulateAop(double totalAmountPaidInterestRate, double loanAmount, int durationOfLoanInYears)
        {
            double apr = (((totalAmountPaidInterestRate / loanAmount / (durationOfLoanInYears * (12 * 30.41666))) * 365)) * 100;

            return Convert.ToDecimal(apr);
        }
    }
}
