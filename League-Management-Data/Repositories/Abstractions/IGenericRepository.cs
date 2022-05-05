using System.Collections.Generic;
using System.Threading.Tasks;

namespace League_Management_Data.Repositories.Abstractions

{
    public interface IGenericRepository<T> where T : class
    {
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task InsertAsync(T entity);
        void Update(T entity);
    }
}