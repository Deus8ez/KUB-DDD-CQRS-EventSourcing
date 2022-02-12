using KUB.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUB.Core.Models
{
    public class Tournament : BaseEntity, IAggregateRoot
    {
        public string TournamentName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public Guid TournamentFormatId { get; set; }
        public virtual TournamentFormat TournamentFormat { get; set; }
        public Guid TournamentTypeId { get; set; }
        public virtual TournamentType TournamentType { get; set; }
        public Guid TournamentGridId { get; set; }
        public virtual TournamentGridType TournamentGrid { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; } = new Collection<ParticipantInTournament>();

        public void AddParticipant(ParticipantInTournament participantInTournament)
        {
            if(participantInTournament.ParticipantRole == null)
            {
                participantInTournament.ParticipantRole = new Role
                {
                    RoleId = Guid.NewGuid(),
                    RoleName = "Зритель"
                };
            }

            ParticipantInTournaments.Add(participantInTournament);
        }

        public void RemoveParticipant(ParticipantInTournament participantInTournament)
        {

            ParticipantInTournaments.Remove(participantInTournament);
        }
    }
}
