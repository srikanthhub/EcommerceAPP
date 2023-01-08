using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessObjects
{
    public interface ICatalogItemBO
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<CatalogItem> GetCatalogItemDetails(int id);
        Task<CatalogItem> Add(CatalogItem item);
        Task Update(CatalogItem item);
        Task Delete(int id);
    }

    public class CatalogItemBO : ICatalogItemBO
    {
        private readonly ICatalogItemRepository _rep;
        public CatalogItemBO(ICatalogItemRepository rep)
        {
            _rep = rep;
        }
        public async Task<CatalogItem> Add(CatalogItem item)
        {
            await _rep.Add(item);
            //Rules of Business...
            return item;
        }

        public async Task Delete(int id)
        {
            await _rep.Delete(id);
        }

        public async Task<CatalogItem> GetCatalogItemDetails(int id)
        {
            return await _rep.GetDetails(id);
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            return await _rep.GetItems();
        }

        public async Task Update(CatalogItem item)
        {
            await _rep.Update(item);
        }
    }
}
