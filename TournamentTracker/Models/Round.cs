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
            List<Match> matches = db.Matches.Include("Player1.Person")
                                            .Include("Player2.Person")
                                            .Where(m => m.RoundID == ID)
                                            .ToList();
            if (matches.Count == 0)
            {
                if (Number == 1)
                {
                    matches = GetRandomPairings();
                }
                else
                {
                    matches = GetPairings();
                }
                db.Matches.AddRange(matches);
                db.SaveChanges();
            }
            return matches;
        }

        private List<Match> GetRandomPairings()
        {
            var matches = new List<Match>();
            List<Participant> participants = Tournament.GetParticipants(); // TODO Get players
            int matchesCount = participants.Count / 2;
            Random random = new Random();

            for (int i = 0; i < matchesCount; ++i)
            {
                int index = random.Next(participants.Count);
                int player1ID = participants[index].ID;
                participants.RemoveAt(index);

                index = random.Next(participants.Count);
                int player2ID = participants[index].ID;
                participants.RemoveAt(index);

                var match = new Match() { RoundID = ID, Player1ID = player1ID, Player2ID = player2ID };
                matches.Add(match);
            }

            if (participants.Count > 0)
            {
                // bye
                int playerID = participants[0].ID;
                var match = new Match() { RoundID = ID, Player1ID = playerID, Player2ID = playerID };
                matches.Add(match);
            }

            return matches;
        }

        private List<Match> GetPairings()
        {
            var matches = new List<Match>();

            //TODO Calculate players points

            return matches;
        }
    }
}
