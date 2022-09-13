using League_Management_Data.Context;
using League_Management_Data.Repositories.Abstractions;
using League_Management_DTOs;
using League_Management_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Data.Repositories.Implementations
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {

        private readonly LMADbContext _context;
        private readonly DbSet<Manager> _dbSet;

        public ManagerRepository(LMADbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Manager>();
        }
        public async Task<Manager> GetManagerAsync(string managerId)
        {
            return await _dbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == managerId);
        }
        public async Task<Manager> GetManagerByEmailAsync(string managerEmail)
        {
            return await _dbSet.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Email == managerEmail);
        }
        public async Task<IEnumerable<Team>> GetManagersPreviousTeamsAsync(string managerId)
        {
            Manager currentManger = await _dbSet.FirstOrDefaultAsync(x => x.UserId == managerId);
            return currentManger.ListOfPreviousTeams;
        }
        public async Task<bool> AddManagerAsync(Manager managerFromDTO)
        {
            Manager newManager = managerFromDTO;
            if (newManager != null)
            {
                await _dbSet.AddAsync(newManager);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteManagerAsync(string managerId)
        {
            var manager = await GetManagerAsync(managerId);
            if (manager != null)
            {
                _dbSet.Remove(manager);

                return true;
            }
            return false;
        }

    }
}
