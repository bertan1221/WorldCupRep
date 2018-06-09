using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Data.Model
{
    public class Match
    {
        public int MatchId { get; set; }
        public Team MatchHomeTeam { get; set; }
        public Team MatchAwayTeam { get; set; }
        public DateTime MatchKickOff { get; set; }
        public string MatchHomeTeamName { get; set; }
        public string MatchAwayTeamName { get; set; }
        public int MatchHomeTeamId { get; set; }
        public int MatchAwayTeamId { get; set; }

        
    }
}
