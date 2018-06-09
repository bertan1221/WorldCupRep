using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data.Model;

namespace WorldCup.Data
{
    internal class WorldCupDbInitializer : DropCreateDatabaseIfModelChanges<WorldCupDbContext>
    {
        protected override void Seed(WorldCupDbContext context)
        {
            //var germany = new Team
            //{
            //    TeamName = "Germany",
            //    TeamContinent = "Europe",
            //    TeamWCwins = 4,
            //    TeamWCappearances = 20,
                
                
            //};

            //var argentina = new Team
            //{
            //    TeamName = "Argentina",
            //    TeamContinent = "South America",
            //    TeamWCwins = 0,
            //    TeamWCappearances = 20,
                
                
            //};

            //context.Teams.Add(germany);
            //context.Teams.Add(argentina);

            //context.Players.Add(new Player
            //{
            //    PlayerAge = 32,
            //    PlayerJerseyNumber = 14,
            //    PlayerName = "Manuel Neuer",
            //    PlayerPosition = "GK",
            //    PlayerWCappearances = 4,
            //    PlayerWCgoalsScored = 1,
            //    Team = germany

            //});

            //context.Matches.Add(new Match
            //{
                
            //    MatchAwayTeam = germany,
            //    MatchHomeTeam = argentina,
            //    MatchAwayTeamName = germany.TeamName,
            //    MatchHomeTeamName = argentina.TeamName,
            //    MatchHomeTeamId = 20,
            //    MatchAwayTeamId = 10,
            //    MatchKickOff = new DateTime(2018, 07, 03)
            //});

            base.Seed(context);
        }
    }
}
