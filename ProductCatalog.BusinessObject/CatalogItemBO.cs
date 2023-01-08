using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessObject
{
    public class CatalogItemBO : ICatalogItemBO
    {
        readonly ICatalogItemRepository _repository;
        public CatalogItemBO(ICatalogItemRepository repository)
        {
            _repository = repository;
        }


        public async Task<CatalogItem> Add(CatalogItem item)
        {
            await _repository.Add(item);
            return item;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<CatalogItem> GetCatalogItemDetails(int id)
        {
            return await _repository.GetDetails(id);
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            return await _repository.GetItems();
        }

        public async Task Update(CatalogItem item)
        {
            await _repository.Update(item);
        }
    }
}
