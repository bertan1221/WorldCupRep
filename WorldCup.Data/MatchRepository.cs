using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using WorldCup.Data.Model;

namespace WorldCup.Data
{
    public class MatchRepository : IDisposable
    {
        private readonly WorldCupDbContext _context;

        public MatchRepository()
        {
            _context = new WorldCupDbContext();
        }

        public void AddMatch(Match match)
        {
            _context.Matches.Include(x => x.MatchHomeTeam).Include(x => x.MatchAwayTeam).ToList();
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public List<Match> GetAllMatches()
        {
            return _context.Matches.Include(x => x.MatchHomeTeam).Include(x => x.MatchAwayTeam).ToList();


        }
        public Match FindMatch(int id)
        {
            return _context.Matches.Include(x => x.MatchHomeTeam).Include(x => x.MatchAwayTeam).FirstOrDefault(match => match.MatchId == id);
        }

        public void EditMatch(Match match)
        {
            _context.Entry(match).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveMatch(int id)
        {
            var match = _context.Matches.Find(id);
            _context.Matches.Remove(match ?? throw new InvalidOperationException());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            SqlConnection.ClearAllPools();
        }
    }
}
