using League_Management_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Data.Context
{
    public class LMADbContext : IdentityDbContext<User>
    {
        public LMADbContext(DbContextOptions<LMADbContext> options) : base(options)
        {

        }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchStatistics> MatchStatistics { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Records> Records { get; set; }
        public DbSet<Refree> Refrees { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
