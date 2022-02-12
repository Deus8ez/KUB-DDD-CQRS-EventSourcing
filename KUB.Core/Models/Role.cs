using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public partial class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; }
    }
}
