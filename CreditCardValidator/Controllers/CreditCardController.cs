using CreditCardValidator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;


namespace CreditCardValidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ILuhnValidatorService _luhnValidatorService;
        public CreditCardController(ILuhnValidatorService luhnValidatorService)
        {
            _luhnValidatorService = luhnValidatorService;
        }
        
        [HttpPost("validate")]
        public IActionResult Validate([FromBody] string creditCardNumber)
        {
            if (string.IsNullOrWhiteSpace(creditCardNumber))
            {
                return BadRequest("Credit card number cannot be empty.");
            }

            if (!creditCardNumber.All(char.IsDigit))
            {
                return BadRequest("Credit card number must contain only digits.");
            }

            try
            {
                bool isValid = _luhnValidatorService.ValidateCreditCardNumber(creditCardNumber);
                return Ok(isValid);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error.");
            }
        }
    }
   

   
}

