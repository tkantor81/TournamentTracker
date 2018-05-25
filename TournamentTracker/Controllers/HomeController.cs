using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TournamentTracker.Models;

namespace TournamentTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityDbContext()));
            //roleManager.Create(new IdentityRole("admin"));

            //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //ApplicationUser user = userManager.FindByEmail("tkantor81@gmail.com");
            //userManager.AddToRole(user.Id, "admin");

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}