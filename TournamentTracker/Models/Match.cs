using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker.Models
{
    public class Match
    {
        public int ID { get; set; }
        [Required]
        public int RoundID { get; set; }
        [Required]
        public int Player1ID { get; set; }
        public int Score1 { get; set; }
        public int Player2ID { get; set; }
        public int Score2 { get; set; }

        public Round Round { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}
