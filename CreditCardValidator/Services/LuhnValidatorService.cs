using System.Linq;

namespace CreditCardValidator.Services
{
    public interface ILuhnValidatorService
    {
        bool ValidateCreditCardNumber(string creditCardNumber);
    }
    
        public class LuhnValidatorService : ILuhnValidatorService
        {
            public bool ValidateCreditCardNumber(string creditCardNumber)
            {
                if (string.IsNullOrWhiteSpace(creditCardNumber) || !creditCardNumber.All(char.IsDigit))
                {
                    return false;
                }

                int sum = 0;
                bool alternate = false;
                for (int i = creditCardNumber.Length - 1; i >= 0; i--)
                {
                    int n = int.Parse(creditCardNumber[i].ToString());
                    if (alternate)
                    {
                        n *= 2;
                        if (n > 9)
                        {
                            n -= 9;
                        }
                    }
                    sum += n;
                    alternate = !alternate;
                }
                return (sum % 10 == 0);
            }
        }

    }

