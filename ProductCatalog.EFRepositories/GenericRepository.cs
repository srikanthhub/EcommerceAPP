﻿using Microsoft.EntityFrameworkCore;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.EFRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly DbContext _context;
        DbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async virtual Task<T> Add(T item)
        {
            dbSet.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async virtual Task Delete(int id)
        {
            T entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async virtual Task<IEnumerable<T>> GetItems()
        {
            return await dbSet.ToListAsync<T>();
        }
        public async virtual Task<T> GetDetails(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async virtual Task Update(T item)
        {
            _context.Entry<T>(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
