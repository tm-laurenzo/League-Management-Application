using League_Management_Data.Context;
using League_Management_Data.Repositories.Implementations;
using League_Management_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Data.Repositories
{
    public class PlayerRepository : GenericRepository<Player>
    {
        private readonly LMADbContext _context;
        private readonly DbSet<Player> _dbSet;

        public PlayerRepository(LMADbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Player>();
        }
    }
}
