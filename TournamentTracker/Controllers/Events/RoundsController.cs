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
    public class RoundsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rounds
        public ActionResult Index()
        {
            Tournament tournament = Tracker.GetTournament();
            Round round = tournament.GetRound(1);
            return View(round);
        }

        //[HttpPost]
        //public ActionResult Index(Round round)
        //{
        //    return View(round);
        //}

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
