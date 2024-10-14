using Newtonsoft.Json;

namespace MaskWebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SensitiveDataAttribute : Attribute { }

}
