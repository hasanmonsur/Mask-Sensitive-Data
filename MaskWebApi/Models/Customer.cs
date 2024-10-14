using MaskWebApi.Helpers;

namespace MaskWebApi.Models
{
    public class Customer
    {
        public string Name { get; set; }

        [SensitiveData]
        public string CreditCardNumber { get; set; }
    }
}
