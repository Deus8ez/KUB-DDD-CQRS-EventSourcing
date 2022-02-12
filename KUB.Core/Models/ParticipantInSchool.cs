using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KUB.Core.Models
{
    public partial class ParticipantInSchool
    {
        public Guid SchoolParticipantId { get; set; }
        public Guid ParticipantInSchoolId { get; set; }
        public Guid? ParticipantSchoolId { get; set; }
        public virtual Participant ParticipantInSchoolNavigation { get; set; }
        public virtual School ParticipantSchool { get; set; }
    }
}
