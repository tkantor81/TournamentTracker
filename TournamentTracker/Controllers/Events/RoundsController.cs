using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TournamentTracker.Helpers;
using TournamentTracker.Models;

namespace TournamentTracker.Controllers.Events
{
    public class RoundsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rounds
        public ActionResult Index()
        {
            Tournament tournament = Tracker.GetTournament();
            Round round = tournament.GetOrCreateRound(1);
            return View(round);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Next")]
        public ActionResult Next(Round round)
        {
            var newRound = new Round();
            if (ModelState.IsValid)
            {
                Tournament tournament = Tracker.GetTournament();
                newRound = tournament.GetOrCreateRound(2);
            }
            return View("Index", newRound);
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
