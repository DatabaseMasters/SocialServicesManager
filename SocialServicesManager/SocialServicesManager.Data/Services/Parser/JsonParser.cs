using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace SocialServicesManager.Data.Services.Parser
{
    public static class JsonParser
    {
        public static T ParseJson<T>(string filePath, string dateFormat)
        {
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = dateFormat };

            string text = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(text, dateTimeConverter);
        }
    }
}
