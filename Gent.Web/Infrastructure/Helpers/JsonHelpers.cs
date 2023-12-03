using System.Text.Json;

namespace Gent.Web.Infrastructure.Helpers
{
    public static class JsonHelpers
    {
        public static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true                        // By default this property is set to 'false'
            };
        }
    }
}
