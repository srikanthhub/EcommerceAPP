using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public interface IGenericRepository<T> where T : class

    {
        Task<IEnumerable<T>> GetItems();
        Task<T> GetDetails(int id);
        Task<T> Add(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
