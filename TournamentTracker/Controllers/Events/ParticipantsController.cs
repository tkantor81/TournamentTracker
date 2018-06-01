using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TournamentTracker.Models;

namespace TournamentTracker.Controllers.Events
{
    public class ParticipantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Participants
        public ActionResult Index()
        {
            Tournament tournament = Tracker.GetTournament();
            return View(tournament);
        }

        // GET: Participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            participant.Person = db.People.Find(participant.PersonID);
            if (participant.Person == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        public ActionResult AddParticipant(int? personID)
        {
            if (personID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = Tracker.GetTournament();
            tournament.AddParticipant((int)personID);
            return PartialView("_Participants", tournament.GetParticipants());
        }

        public ActionResult DeleteParticipant(int? participantID)
        {
            if (participantID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = Tracker.GetTournament();
            tournament.DeleteParticipant((int)participantID);
            return PartialView("_Participants", tournament.GetParticipants());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
