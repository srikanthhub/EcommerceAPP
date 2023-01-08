using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.EFRepositories
{
    public class CatalogItemRepository : GenericRepository<CatalogItem>, ICatalogItemRepository
    {
        private readonly ProductCatalogContext _context;
        public CatalogItemRepository(ProductCatalogContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<CatalogItem> GetDetails(int id)
        {
            var catalogItem = await
_context.CatalogItems.Include("CatalogType").Include("CatalogBrand").FirstAsync(item => item.Id == id);
            if (catalogItem == null)
            {
                throw new ApplicationException("Not Found");
            }
            return catalogItem;
        }

        public async override Task<IEnumerable<CatalogItem>> GetItems()
        {
            return await _context.CatalogItems.Include("CatalogType").Include("CatalogBrand").ToListAsync();
        }
    }

    public class CatalogTypeRepository : GenericRepository<CatalogType>, ICatalogTypeRepository
    {
        public CatalogTypeRepository(ProductCatalogContext context) : base(context)
        { }
    }

    public class CatalogBrandRepository : GenericRepository<CatalogBrand>, ICatalogBrandRepository
    {
        public CatalogBrandRepository(ProductCatalogContext context) : base(context)
        { }
    }


}



