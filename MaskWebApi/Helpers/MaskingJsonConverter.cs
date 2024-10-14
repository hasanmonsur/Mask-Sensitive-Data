using Newtonsoft.Json;
using System.Formats.Asn1;

namespace MaskWebApi.Helpers
{
    public class MaskingJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string sensitiveData = value as string;
            if (!string.IsNullOrEmpty(sensitiveData))
            {
                // Mask all but the last 4 characters
                sensitiveData = new string('*', sensitiveData.Length - 4) + sensitiveData.Substring(sensitiveData.Length - 4);
            }
            writer.WriteValue(sensitiveData);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value; // No need to unmask
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }

}
