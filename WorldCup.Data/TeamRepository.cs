using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Data
{
    public class TeamRepository : IDisposable
    {
        private readonly WorldCupDbContext _context;

        public TeamRepository()
        {
            _context = new WorldCupDbContext();
        }

        public void AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public List<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
                
        }
        public Team FindTeam(int id)
        {
            return _context.Teams.FirstOrDefault(team => team.TeamId == id);
        }

        public void EditTeam(Team team)
        {
            _context.Entry(team).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveTeam(int id)
        {
            var team = _context.Teams.Find(id);
            _context.Teams.Remove(team ?? throw new InvalidOperationException());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            SqlConnection.ClearAllPools();
        }
    }
}
