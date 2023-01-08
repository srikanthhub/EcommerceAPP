using MVCWebApp.Models;

namespace MVCWebApp.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
    }
}
