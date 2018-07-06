using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TournamentTracker.Models
{
    public enum States
    {
        New,
        Running,
        Finished
    }

    public class Tournament
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Tournament()
        {
            TierList = db.Tiers.Select(t => new SelectListItem { Value = t.ID.ToString(), Text = t.Name });
            StructureList = db.Structures.Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Name });
            FormatList = db.Formats.Select(f => new SelectListItem { Value = f.ID.ToString(), Text = f.Name });
            PersonList = db.People.Select(p => new SelectListItem { Value = p.ID.ToString(), Text = p.FirstName + " " + p.LastName + " (" + p.Email + ")" });
        }

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        [Required]
        [Display(Name = "Tier")]
        public int TierID { get; set; }
        [Required]
        [Display(Name = "Structure")]
        public int StructureID { get; set; }
        [Required]
        [Display(Name = "Format")]
        public int FormatID { get; set; }
        [Display(Name = "Round count")]
        public int RoundCount { get; set; } = 3;
        public States State { get; set; } = States.New;

        public Tier Tier { get; set; }
        public Structure Structure { get; set; }
        public Format Format { get; set; }

        public IEnumerable<SelectListItem> TierList { get; set; }
        public IEnumerable<SelectListItem> StructureList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
        public IEnumerable<SelectListItem> PersonList { get; set; }

        public List<Participant> GetParticipants()
        {
            return db.Participants.Include("Person").Where(p => p.TournamentID == ID).ToList();
        }

        public void AddParticipant(int personID)
        {
            Person person = db.People.Find(personID);
            if (person == null)
            {
                // Error HttpNotFound()
            }

            var participant = new Player()
            {
                TournamentID = ID,
                Person = person
            };
            db.Participants.Add(participant);
            db.SaveChanges();
        }

        public void DeleteParticipant(int participantID)
        {
            Participant participant = db.Participants.Find(participantID);
            if (participant == null)
            {
                // Error HttpNotFound()
            }
            db.Participants.Remove(participant);
            db.SaveChanges();
        }

        public Round GetOrCreateRound(int number)
        {
            Round round = db.Rounds.Include("Tournament")
                                   .Where(r => r.TournamentID == ID && r.Number == number)
                                   .SingleOrDefault();
            if (round == null)
            {
                round = new Round()
                {
                    TournamentID = ID,
                    Number = number
                };
                db.Rounds.Add(round);
                db.SaveChanges();
            }
            return round;
        }
    }
}
