using KUB.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public partial class ParticipantInTournament : BaseEntity
    {
        public Guid TournamentId { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid RoleId { get; set; } = Guid.Empty;
        public virtual Participant Participant { get; set; }
        public virtual Role Role { get; set; }
        public virtual Tournament Tournament { get; set; }
        public bool SetParticipantInTournament(Participant participant, Role role, Tournament tournament)
        {
            if(participant.CanBeAJury == false && role.RoleName == "Судья")
            {
                return false;
            }

            Role = role;
            Participant = participant;
            Tournament = tournament;
        
            return true;
        }
    }
}
