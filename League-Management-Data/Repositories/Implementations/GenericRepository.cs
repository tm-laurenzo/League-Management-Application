using League_Management_Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Data.Repositories.Implementations
{
    public class GenericRepository<T> :  IGenericRepository<T> where T : class
    {
        private readonly LMADbContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepository(LMADbContext context)
        {
            _context = context;

            _dbSet = _context.Set<T>();


        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
