using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Participant
    {
        public int ID { get; set; }
        [Required]
        public int PersonID { get; set; }
        [Required]
        public int TournamentID { get; set; }
        public List<int> Roles { get; set; }

        public Person Person { get; set; }
        public Tournament Tournament { get; set; }
    }
}
