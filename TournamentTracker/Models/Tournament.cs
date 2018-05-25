using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TournamentTracker.Models
{
    public class Tournament
    {
        public Tournament()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            TierList = db.Tiers.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            StructureList = db.Structures.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
            FormatList = db.Formats.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name });
        }

        public enum States
        {
            New,
            Running,
            Finished
        }

        public int ID { get; set; }
        [Required]
        [Display(Name = "Tier")]
        public int TierID { get; set; }
        [Required]
        [Display(Name = "Structure")]
        public int StructureID { get; set; }
        [Required]
        [Display(Name = "Format")]
        public int FormatID { get; set; }
        [Display(Name = "Round count")]
        public int RoundCount { get; set; }
        [NotMapped]
        public States State { get; set; }

        public Tier Tier { get; set; }
        public Structure Structure { get; set; }
        public Format Format { get; set; }

        public IEnumerable<SelectListItem> TierList { get; set; }
        public IEnumerable<SelectListItem> StructureList { get; set; }
        public IEnumerable<SelectListItem> FormatList { get; set; }
    }
}
