using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessObject
{
    public interface ICatalogItemBO
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<CatalogItem> GetCatalogItemDetails(int id);
        Task<CatalogItem> Add(CatalogItem item);
        Task Update(CatalogItem item);
        Task Delete(int id);

    }
}
