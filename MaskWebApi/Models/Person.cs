using MaskWebApi.Helpers;
using Newtonsoft.Json;

namespace MaskWebApi.Models
{
    public class Person
    {
        public string Name { get; set; }

        [JsonConverter(typeof(MaskingJsonConverter))]
        public string CreditCardNumber { get; set; }
    }
}
