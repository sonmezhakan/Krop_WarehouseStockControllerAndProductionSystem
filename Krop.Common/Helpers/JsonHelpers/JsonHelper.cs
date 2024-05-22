using Newtonsoft.Json;

namespace Krop.Common.Helpers.JsonHelpers
{
    public static class JsonHelper
    {
        public static async Task<T> DeserializeAsync<T>(HttpResponseMessage response)
        {
            string jsonContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
