using MVCWebApp.Models;
using Newtonsoft.Json;

namespace MVCWebApp.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _remoteServiceBaseUrl;
        
        public CatalogService(IConfiguration config)
        {
            _remoteServiceBaseUrl = config["CatalogUri"];

        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(_remoteServiceBaseUrl + "/api/CatalogItems/");
            result.EnsureSuccessStatusCode();
            var dataString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CatalogItem>>(dataString);
        }

    }
}
