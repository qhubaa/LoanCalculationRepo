using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculation.Models;
using LoanCalculation.Services;

namespace LoanCalculation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanCalculationController : ControllerBase
    {
        private readonly ICalculateLoanService _calculateLoanService;
        private readonly IMapper _mapper;

        public LoanCalculationController(ICalculateLoanService calculateLoanService, IMapper mapper)
        {
            _calculateLoanService = calculateLoanService;
            _mapper = mapper;
        }

        [HttpGet("/{configurationid:int}/{loanamount:decimal}/{durationofloaninyears:int}")]
        public async Task<ActionResult<LoanPaymentOverviewModel>> Get(int configurationid, decimal loanamount, int durationofloaninyears)
        {
            try
            {
                var result = await _calculateLoanService.GetLoanPaymentOverview(configurationid, loanamount, durationofloaninyears);

                return _mapper.Map<LoanPaymentOverviewModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }
    }
}
