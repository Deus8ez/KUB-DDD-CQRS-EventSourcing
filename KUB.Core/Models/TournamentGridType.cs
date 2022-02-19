using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public class TournamentGridType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
