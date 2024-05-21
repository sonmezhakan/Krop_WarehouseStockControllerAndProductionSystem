using Newtonsoft.Json;

namespace Krop.Common.Helpers.JsonHelpers
{
    public static class JsonHelper
    {
        public static async Task<T> DeserializeAsync<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonContent);
            }
            else
            {
                // İsteğin başarılı olması durumunda null dönebilir veya isteğin içeriğini
                // geri döndürebilirsiniz, bağlamınıza bağlı olarak işleyebilirsiniz.
                return default;
            }
        }
    }
}
