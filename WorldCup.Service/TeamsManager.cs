using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data;
using WorldCup.Data.Model;
using WorldCup.Model;
using WorldCup.Mapper;

namespace WorldCup.Service
{
    public class TeamsManager
    {
        public void CreateTeam(TeamModel team)
        {
            using (var repository = new TeamRepository())
            {
                var teamDbModel = new Team
                {
                    TeamId = team.Id,
                    TeamName = team.Name,
                    TeamContinent = team.Continent,
                    TeamWCappearances = team.WCappearances,
                    TeamWCwins = team.WCwins
                };

                repository.AddTeam(teamDbModel);
            }
        }

        public object CreateTeam(TeamModel teamModel, object team)
        {
            throw new NotImplementedException();
        }

        public List<TeamModel> ReturnAllTeams()
        {

            using (var repository = new TeamRepository())
            {
                return repository.GetAllTeams().Select(x => x.ToModel()).ToList(); ;
            }
        }

        public TeamModel ReturnTeam(int teamId)
        {
            using (var repository = new TeamRepository())
            {
                return repository.FindTeam(teamId).ToModel();
            }
        }

        public void UpdateTeam(TeamModel team)
        {
            using (var repository = new TeamRepository())
            {
                var teamDbModel = new Team
                {
                    TeamId = team.Id,
                    TeamName = team.Name,
                    TeamContinent = team.Continent,
                    TeamWCappearances = team.WCappearances,
                };

                repository.EditTeam(teamDbModel);
            }
        }

        public void DeleteTeam(int teamId)
        {
            using (var repository = new TeamRepository())
            {
                repository.RemoveTeam(teamId);
            }
        }
    }
}
