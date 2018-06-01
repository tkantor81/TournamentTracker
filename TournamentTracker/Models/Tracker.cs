using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentTracker.Models
{
    public static class Tracker
    {
        public static Tournament GetTournament()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            Tournament tournament = db.Tournaments.Where(t => t.State != States.Finished).SingleOrDefault();
            if (tournament == null)
            {
                return new Tournament();
            }

            return tournament;
        }
    }
}