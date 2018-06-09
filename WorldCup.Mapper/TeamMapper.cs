using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;
using WorldCup.Model;

namespace WorldCup.Mapper
{
    public static class TeamMapper
    {
        public static TeamModel ToModel(this Team team)
        {
            return new TeamModel
            {
                Id = team.TeamId,
                Name = team.TeamName,
                Continent = team.TeamContinent,
                WCappearances = team.TeamWCappearances,
                WCwins = team.TeamWCwins
            };
        }
    }
}
