using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Data.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public int PlayerJerseyNumber { get; set; }
        public string PlayerPosition { get; set; }
        public int PlayerWCappearances { get; set; }
        public int PlayerWCgoalsScored { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
