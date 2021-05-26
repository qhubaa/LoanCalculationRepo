using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Models
{
    public class LoanPaymentOverviewModel
    {
        public decimal Aop { get; set; }
        public decimal MonthlyCost { get; set; }
        public decimal TotalAmountPaidInterestRate { get; set; }
        public decimal TotalAmountPaidAdministrativeFees { get; set; }
    }
}
