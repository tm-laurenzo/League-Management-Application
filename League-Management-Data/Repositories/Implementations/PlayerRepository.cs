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

    /* Get a player by Id
       Get all players in a team
       Get p
     */
    public class PlayerRepository : GenericRepository<Player>
    {
        private readonly LMADbContext _context;
        private readonly DbSet<Player> _dbSet;

        public PlayerRepository(LMADbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Player>();
        }
        public async Task<Player> GetPlayerAsync(string PlayerId)
        {
            return await _context.Players.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == PlayerId);
        }
    }
}
