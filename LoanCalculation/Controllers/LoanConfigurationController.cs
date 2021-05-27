using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoanCalculation.Data;
using LoanCalculation.Models;
using LoanCalculation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.WebEncoders.Testing;

namespace LoanCalculation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanConfigurationController : ControllerBase
    {
        private readonly ILoanConfigurationService _loanConfigurationService;
        private readonly IMapper _mapper;
        public LoanConfigurationController(ILoanConfigurationService loanConfigurationService, IMapper mapper)
        {
            _loanConfigurationService = loanConfigurationService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanConfigurationModel>> Get(int id)
        {
            try
            {
                var result = await _loanConfigurationService.GetLoanConfiguration(id);

                if (result == null)
                {
                    NotFound($"Not found loan configuration with id {id}");
                }

                return _mapper.Map<LoanConfigurationModel>(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LoanConfigurationModel>> Put(int id, LoanConfigurationModel model)
        {
            try
            {
                var oldLoanConfiguration = await _loanConfigurationService.GetLoanConfiguration(id);
                if (oldLoanConfiguration == null)
                    return NotFound("Not found loan configuration");

                _mapper.Map(model, oldLoanConfiguration);

                if (await _loanConfigurationService.SaveChanges())
                {
                    return _mapper.Map<LoanConfigurationModel>(oldLoanConfiguration);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }

            return BadRequest();
        }
    }
}
