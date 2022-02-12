using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public class TournamentType
    {
        public Guid TypeId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
