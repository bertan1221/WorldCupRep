using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using WorldCup.Data.Model;

namespace WorldCup.Data
{
    public class PlayerRepository : IDisposable
    {
        private readonly WorldCupDbContext _context;

        public PlayerRepository()
        {
            _context = new WorldCupDbContext();
        }

        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public List<Player> GetAllPlayers(string searchCriteria)
        {
            return string.IsNullOrEmpty(searchCriteria)
                ? _context.Players.Include(x => x.Team).ToList()
                : _context.Players.Where(player => player.PlayerName.Contains(searchCriteria)).Include(x => x.Team).ToList();
        }
        public Player FindPlayer(int id)
        {
            return _context.Players.Include(x => x.Team).FirstOrDefault(player => player.PlayerId == id);
        }

        public void EditPlayer(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemovePlayer(int id)
        {
            var player = _context.Players.Find(id);
            _context.Players.Remove(player ?? throw new InvalidOperationException());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            SqlConnection.ClearAllPools();
        }
    }
}
