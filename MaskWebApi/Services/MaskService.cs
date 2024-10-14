using MaskWebApi.Helpers;
using MaskWebApi.Models;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MaskWebApi.Services
{
    public class MaskService
    {
        public MaskService() { }

        public string StringManipulation(string data)
        {
            if (data.Length < 4)
            {
                return new string('*', data.Length); // If data is too short, mask the entire thing
            }

            return new string('*', data.Length - 4) + data.Substring(data.Length - 4);
        }

        public string RegularExpressions(string email)
        {
            return Regex.Replace(email, @"(?<=.).(?=.*@)", "*");
        }

        public string MaskingJSONSerializer(Person person)
        {                      
            return JsonConvert.SerializeObject(person);
        }


        public string MaskObjectProperties(object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.IsDefined(typeof(SensitiveDataAttribute), false) && prop.PropertyType == typeof(string))
                {
                    var value = (string)prop.GetValue(obj);
                    if (!string.IsNullOrEmpty(value))
                    {
                        prop.SetValue(obj, new string('*', value.Length - 4) + value.Substring(value.Length - 4));
                    }
                }
            }
            return JsonConvert.SerializeObject(obj);
        }

        public string ProtectionProvider(string  strVal)
        {
            var dataProtectionProvider = DataProtectionProvider.Create("MaskWebApi");

            // Create a protector for your specific purpose
            var protector = dataProtectionProvider.CreateProtector("SensitiveDataProtector");

            string protectedData = protector.Protect(strVal);


            return JsonConvert.SerializeObject(protectedData);
        }

    }
}
