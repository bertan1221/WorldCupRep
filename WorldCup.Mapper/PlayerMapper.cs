using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Model;
using WorldCup.Data.Model;

namespace WorldCup.Mapper
{
    public static class PlayerMapper
    {
        public static PlayerModel ToModel(this Player player)
        {
            return new PlayerModel
            {
                Id = player.PlayerId,
                Name = player.PlayerName,
                Age = player.PlayerAge,
                JerseyNumber = player.PlayerJerseyNumber,
                Position = player.PlayerPosition,
                WCappearances = player.PlayerWCappearances,
                WCgoalsScored = player.PlayerWCgoalsScored,
                Team = player.Team?.ToModel()
            };
        }
    }
}
