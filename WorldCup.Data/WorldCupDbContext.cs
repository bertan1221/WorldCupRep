using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Data
{
    internal class WorldCupDbContext : DbContext
    {
        public WorldCupDbContext() : base("WorldCup")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }
    }
}
