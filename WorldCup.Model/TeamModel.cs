using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Model
{
    public class TeamModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Team Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "World Cup Wins")]
        public int WCwins { get; set; }
        [Required]
        [Display(Name = "World Cup Appearances")]
        public int WCappearances { get; set; }
        [Required]
        public string Continent { get; set; }
        //public List<PlayerModel> PlayerList { get; set; }
    }
}
