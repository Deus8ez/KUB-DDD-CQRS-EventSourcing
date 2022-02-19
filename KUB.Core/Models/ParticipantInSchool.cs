using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KUB.Core.Models
{
    public partial class ParticipantInSchool
    {
        public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid? SchoolId { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual School School { get; set; }
    }
}
