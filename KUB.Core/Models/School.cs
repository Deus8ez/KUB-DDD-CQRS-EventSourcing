using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public class School
    {
        public Guid SchoolId { get; set; }
        public string SchoolName { get; set; }
        public virtual ICollection<ParticipantInSchool> ParticipantInSchools { get; set; }
    }
}
