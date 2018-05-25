using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                //TODO start tournament
            }
            return View(tournament);
        }
    }
}