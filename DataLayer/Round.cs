using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Round
    {
        public int ID { get; set; }
        [Required]
        public int TournamentID { get; set; }
        public int Number { get; set; }

        public Tournament Tournament { get; set; }
    }
}
