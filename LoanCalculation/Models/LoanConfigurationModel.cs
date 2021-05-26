using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Models
{
    public class LoanConfigurationModel
    {
        public int Id { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public decimal PercentageAdministrationFee { get; set; }
        public decimal AmountAdministrationFee { get; set; }
    }
}
