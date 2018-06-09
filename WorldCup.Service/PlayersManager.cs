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
    public class PlayersManager
    {
        public void CreatePlayer(PlayerModel player)
        {
            using (var repository = new PlayerRepository())
            {
                var playerDbModel = new Player
                {
                    PlayerName = player.Name,
                    PlayerAge = player.Age,
                    PlayerJerseyNumber = player.JerseyNumber,
                    PlayerPosition = player.Position,
                    PlayerWCappearances = player.WCappearances,
                    PlayerWCgoalsScored = player.WCgoalsScored,
                    TeamId = player.SelectedTeamId
                    
                };

                repository.AddPlayer(playerDbModel);
            }
        }

        public object CreatePlayer(PlayerModel playerModel, object player)
        {
            throw new NotImplementedException();
        }

        public List<PlayerModel> ReturnAllPlayers(string searchCriteria = null)
        {
            
            using (var repository = new PlayerRepository())
            {
                return repository.GetAllPlayers(searchCriteria).Select(x => x.ToModel()).ToList(); ;
            }
        }

        public PlayerModel ReturnPlayer(int playerId)
        {
            using (var repository = new PlayerRepository())
            {
                return repository.FindPlayer(playerId)?.ToModel();
            }
        }

        public void UpdatePlayer(PlayerModel player)
        {
            using (var repository = new PlayerRepository())
            {
                var playerDbModel = new Player
                {
                    PlayerId = player.Id,
                    PlayerName = player.Name,
                    PlayerAge = player.Age,
                    PlayerJerseyNumber = player.JerseyNumber,
                    PlayerPosition = player.Position,
                    PlayerWCappearances = player.WCappearances,
                    PlayerWCgoalsScored = player.WCgoalsScored,
                    TeamId = player.SelectedTeamId
                    
                };

                repository.EditPlayer(playerDbModel);
            }
        }

        public void DeletePlayer(int playerId)
        {
            using (var repository = new PlayerRepository())
            {
                repository.RemovePlayer(playerId);
            }
        }
    }
}
