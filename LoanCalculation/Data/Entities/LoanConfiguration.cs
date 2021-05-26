using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Data.Entities
{
    public class LoanConfiguration
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal AnnualInterestRate { get; set; }
        [Required]
        public decimal PercentageAdministrationFee { get; set; }
        [Required]
        public decimal AmountAdministrationFee { get; set; }
    }
}
