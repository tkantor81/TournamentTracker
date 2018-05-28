using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TournamentTracker.Helpers;
using TournamentTracker.Models;

namespace TournamentTracker.Controllers.Events
{
    public class TournamentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tournament
        public ActionResult Index()
        {
            Tournament tournament = Tournament.Get();
            return View(tournament);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Create")]
        public ActionResult Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Tournaments.Add(tournament);
                db.SaveChanges();
            }
            return View("Index", tournament);
        }
    }
}