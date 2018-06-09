using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Model
{
    public class MatchModel
    {
        [Key]
        public int Id { get; set; }
        public TeamModel HomeTeam { get; set; }
        public TeamModel AwayTeam { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Kick-off")]
        public DateTime KickOff { get; set; }
        [Display(Name = "Home Team")]
        public string HomeTeamName { get; set; }
        [Display(Name = "Away Team")]
        public string AwayTeamName { get; set; }
        public int SelectedHomeTeamId { get; set; }
        public int SelectedAwayTeamId { get; set; }
    }
}
