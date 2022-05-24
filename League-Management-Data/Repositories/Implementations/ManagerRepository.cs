using League_Management_Data.Context;
using League_Management_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Data.Repositories.Implementations
{
   public class ManagerRepository : GenericRepository<Manager>
    {

        private readonly LMADbContext _context;
        private readonly DbSet<Manager> _dbSet;

        public ManagerRepository(LMADbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Manager>();
        }
        public async Task<Manager> GetPlayerAsync(string ManagerId)
        {
            return await _context.Managers.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == ManagerId);
        }
        public async Task<Manager> GetManagerByEmailAsync(string managerEmail)
        {
            return await _context.Managers.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Email == managerEmail);
        }
        public async Task<IEnumerable<Team>> GetPlayersPreviousTeamsAsync(string playerId)
        {
            Player currentPlayer = await _context.Players.FirstOrDefaultAsync(x => x.UserId == playerId);
            return currentPlayer.ListOfPreviousTeams;
        }
        public async Task<IEnumerable<Position>> GetPlayersPositionsAsync(string playerId)
        {
            Player currentPlayer = await _context.Players.FirstOrDefaultAsync(x => x.UserId == playerId);
            return currentPlayer.ListOfPositions;
        }
        public async Task<bool> DeletePlayerAsync(string playerId)
        {
            var player = await GetPlayerAsync(playerId);
            if (player != null)
            {
                _context.Players.Remove(player);
                return true;
            }
            return false;
        }

    }
}
