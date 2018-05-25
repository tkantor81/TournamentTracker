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
        // GET: Tournament
        public ActionResult Index()
        {
            var tournament = new Tournament();
            return View(tournament);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "AddParticipant")]
        public ActionResult AddParticipant(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                //TODO add participant
            }
            return View("Index", tournament);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Start")]
        public ActionResult Start(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                //TODO start tournament
            }
            return View(tournament);
        }
    }
}