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
        
        public List<Match> GetOrCreateMatches()
        {
            // TODO Test participants are included
            List<Match> matches = db.Matches.Include("Player1").Include("Player2").Where(m => m.RoundID == ID).ToList();
            if (matches.Count == 0)
            {
                matches = CreatePairings();
                db.Matches.AddRange(matches);
                db.SaveChanges();

            }
            return matches;
        }

        private List<Match> CreatePairings()
        {
            var matches = new List<Match>();
            List<Participant> participants = Tournament.GetParticipants();
            
            // TODO Get participant standings
            
            var match = new Match() { RoundID = ID, Player1ID = 109, Player2ID = 110 };
            matches.Add(match);
            return matches;
        }
    }
}
