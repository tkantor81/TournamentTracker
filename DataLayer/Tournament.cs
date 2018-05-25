using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class Tournament
    {
        public Tournament()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ViewBag.TierList = db.Tiers.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
        }

        public enum States
        {
            New,
            Running,
            Finished
        }

        public int ID { get; set; }
        [Required]
        public int TierID { get; set; }
        [Required]
        public int StructureID { get; set; }
        [Required]
        public int FormatID { get; set; }
        public int RoundCount { get; set; }
        public States State { get; set; }

        public Tier Tier { get; set; }
        public Structure Structure { get; set; }
        public Format Format { get; set; }

        public IEnumerable<SelectListItem> TierList { get; set; }
    }
}
