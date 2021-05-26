using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoanCalculation.Data.Entities;
using LoanCalculation.Models;

namespace LoanCalculation.Data
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<LoanConfiguration, LoanConfigurationModel>();
            CreateMap<LoanPaymentOverview, LoanPaymentOverviewModel>();
            CreateMap<LoanConfigurationModel, LoanConfiguration>();
        }
    }
}
