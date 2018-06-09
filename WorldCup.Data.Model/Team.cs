using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Data.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TeamWCwins { get; set; }
        public int TeamWCappearances { get; set; }
        public string TeamContinent { get; set; }
        public List<Player> PlayerList { get; set; }
    }
}
