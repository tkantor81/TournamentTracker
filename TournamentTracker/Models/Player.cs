using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentTracker.Models
{
    public class Player : Participant
    {
        [NotMapped]
        public int Points { get; set; }
        [NotMapped]
        public float SoS { get; set; }
        [NotMapped]
        public float ESoS { get; set; }
    }
}