using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Model
{
    public class PlayerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Player Name")]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Jersey Number")]
        public int JerseyNumber { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [Display(Name = "World Cup Appearances")]
        public int WCappearances { get; set; }
        [Required]
        [Display(Name = "World Cup Goals Scored")]
        public int WCgoalsScored { get; set; }
        public TeamModel Team { get; set; }
        [NotMapped]
        [DisplayName("Team")]
        public int SelectedTeamId { get; set; }
    }
}
