using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
