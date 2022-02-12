using KUB.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public partial class ParticipantInTournament
    {
        public Guid TournamentWithParticipantId { get; set; }
        public Guid ParticipantInId { get; set; }
        public Guid? ParticipantRoleId { get; set; }
        public virtual Participant ParticipantInTournamentNavigation { get; set; }
        public virtual Role ParticipantRole { get; set; }
        public virtual Tournament TournamentWithParticipant { get; set; }
        public bool SetParticipantInTournament(Participant participant, Role role, Tournament tournament)
        {
            if(participant.CanBeAJury == false && role.RoleName == "Судья")
            {
                return false;
            }

            ParticipantRole = role;
            ParticipantInTournamentNavigation = participant;
            TournamentWithParticipant = tournament;
        
            return true;
        }
    }
}
