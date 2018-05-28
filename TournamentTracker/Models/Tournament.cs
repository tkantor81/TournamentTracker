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
    public class Tournament
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Tournament()
        {
            TierList = db.Tiers.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            StructureList = db.Structures.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            FormatList = db.Formats.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            PersonList = db.People.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.FirstName + " " + x.LastName + " (" + x.Email + ")" });
            Participants = new List<Participant>();
        }

        public enum States
        {
            New,
            Running,
            Finished
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

        public List<Participant> Participants { get; set; }

        public static Tournament Get()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            Tournament tournament = db.Tournaments.Where(t => t.State != Tournament.States.Finished).SingleOrDefault();
            if (tournament == null)
            {
                return new Tournament();
            }
            tournament.Participants = db.Participants.Where(p => p.TournamentID == tournament.ID).ToList();
            foreach (var participant in tournament.Participants)
            {
                participant.Person = db.People.Find(participant.PersonID);
                if (participant.Person == null)
                {
                    // Error HttpNotFound()
                }
            }
            return tournament;
        }

        public void AddParticipant(int personID)
        {
            Person person = db.People.Find(personID);
            if (person == null)
            {
                // Error HttpNotFound()
            }
            var participant = new Participant()
            {
                TournamentID = ID,
                Person = person
            };
            db.Participants.Add(participant);
            db.SaveChanges();
            Participants.Add(participant);
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
            Participants.Remove(Participants.Find(p => p.ID == participantID));
        }
    }
}
