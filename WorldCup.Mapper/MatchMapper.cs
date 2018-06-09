using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Model;
using WorldCup.Data.Model;

namespace WorldCup.Mapper
{
    public static class MatchMapper
    {
        public static MatchModel ToModel(this Match match)
        {
            return new MatchModel
            {
                Id = match.MatchId,
                AwayTeam = match.MatchAwayTeam?.ToModel(),
                HomeTeam = match.MatchHomeTeam?.ToModel(),
                HomeTeamName = match.MatchHomeTeamName,
                AwayTeamName = match.MatchAwayTeamName,
                KickOff = match.MatchKickOff,
                SelectedAwayTeamId = match.MatchAwayTeamId,
                SelectedHomeTeamId = match.MatchHomeTeamId
                
            };
        }

    }
}
