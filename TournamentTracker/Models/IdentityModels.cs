using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TournamentTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Tier> Tiers { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Structure> Structures { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Format> Formats { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Tournament> Tournaments { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Participant> Participants { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Round> Rounds { get; set; }

        public System.Data.Entity.DbSet<TournamentTracker.Models.Match> Matches { get; set; }
    }
}