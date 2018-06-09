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
    public class MatchManager
    {
        public void CreateMatch(MatchModel match)
        {
            using (var repository = new MatchRepository())
            {
                var matchDbModel = new Match
                {
                    MatchHomeTeamName = match.HomeTeamName,
                    MatchAwayTeamName = match.AwayTeamName,
                    MatchAwayTeamId = match.SelectedAwayTeamId,
                    MatchHomeTeamId = match.SelectedHomeTeamId,
                    MatchKickOff = match.KickOff,
                    
                };

                repository.AddMatch(matchDbModel);
            }
        }

        public object CreateMatch(MatchModel matchModel, object match)
        {
            throw new NotImplementedException();
        }

        public List<MatchModel> ReturnAllMatches()
        {

            using (var repository = new MatchRepository())
            {
                return repository.GetAllMatches().Select(x => x.ToModel()).ToList(); 
            }
        }

        public MatchModel ReturnMatch(int matchId)
        {
            using (var repository = new MatchRepository())
            {
                return repository.FindMatch(matchId)?.ToModel();
            }
        }

        public void UpdateMatch(MatchModel match)
        {
            using (var repository = new MatchRepository())
            {
                var matchDbModel = new Match
                {
                    MatchId = match.Id,
                    MatchHomeTeamName = match.HomeTeamName,
                    MatchAwayTeamName = match.AwayTeamName,
                    MatchHomeTeamId = match.SelectedHomeTeamId,
                    MatchAwayTeamId = match.SelectedAwayTeamId,
                    MatchKickOff = match.KickOff
                    

                };

                repository.EditMatch(matchDbModel);
            }
        }

        public void DeleteMatch(int matchId)
        {
            using (var repository = new MatchRepository())
            {
                repository.RemoveMatch(matchId);
            }
        }
    }
}
