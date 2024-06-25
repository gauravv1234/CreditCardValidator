using System;
using CreditCardValidator.Services;
using Xunit;

namespace CreditCardValidator.Tests
{
    public class LuhnValidatorServiceTests
    {
        private readonly ILuhnValidatorService _luhnValidatorService;

        public LuhnValidatorServiceTests()
        {
            _luhnValidatorService = new LuhnValidatorService();
        }

        [Theory]
        [InlineData("4539578763621486", true)]
        [InlineData("8273123273520569", false)]
        [InlineData("4111111111111111", true)]
        [InlineData("1234567812345670", false)]
        public void ValidateCreditCardNumber_ShouldReturnExpectedResult(string creditCardNumber, bool expected)
        {
            var result = _luhnValidatorService.ValidateCreditCardNumber(creditCardNumber);
            Assert.Equal(expected, result);
        }
    }
}
