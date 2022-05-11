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

    /* Get a player by Id ✔
       Get all previous teams of player
       Get all positions of a player 
       Get player by email ✔
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
        public async Task<Player> GetPlayerAsync(string playerId)
        {
            return await _context.Players.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == playerId);
        }
        public async Task<Player> GetPlayerByEmailAsync(string playerEmail)
        {
            return await _context.Players.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Email == playerEmail);
        }
        public async Task<IEnumerable<Team>> GetPlayersPreviousTeamsAsync(string playerId)
        {
            Player currentPlayer = await _context.Players.FirstOrDefaultAsync(x => x.UserId == playerId);
            return  currentPlayer.ListOfPreviousTeams;
        }
        public async Task<IEnumerable<Position>> GetPlayersPositionsAsync(string playerId)
        {
            Player currentPlayer = await _context.Players.FirstOrDefaultAsync(x => x.UserId == playerId);
            return currentPlayer.ListOfPositions;
        }
    }
}
