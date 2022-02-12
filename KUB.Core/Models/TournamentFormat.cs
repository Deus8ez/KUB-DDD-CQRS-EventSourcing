using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public class TournamentFormat
    {
        public Guid FormatId { get; set; }
        public string Format { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
