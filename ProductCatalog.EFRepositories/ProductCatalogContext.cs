﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;

namespace ProductCatalog.EFRepositories
{
    public class ProductCatalogContext : DbContext
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCatalog.Domain.CatalogType> CatalogTypes { get; set; } = default!;

        public DbSet<ProductCatalog.Domain.CatalogItem> CatalogItems { get; set; }

        public DbSet<ProductCatalog.Domain.CatalogBrand> CatalogBrands { get; set; }
    }
}
