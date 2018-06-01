using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker.Models
{
    public class Round
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public int ID { get; set; }
        [Required]
        public int TournamentID { get; set; }
        public int Number { get; set; }
        public States State { get; set; } = States.New;

        public Tournament Tournament { get; set; }

        public List<Match> GetMatches()
        {
            return db.Matches.Where(m => m.RoundID == ID).ToList();
        }

        public List<Match> CreateMatches()
        {

            return new List<Match>();
        }
    }
}
