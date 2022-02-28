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
        public string City { get; set; }
        public string Address { get; set; }
        public int? Number { get; set; }
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; }

        public void AddParticipant(ParticipantInTournament participantInTournament)
        {
            ParticipantInTournaments = new Collection<ParticipantInTournament>();
            ParticipantInTournaments.Add(participantInTournament);
        }

        public void RemoveParticipant(ParticipantInTournament participantInTournament)
        {
            foreach(var participant in ParticipantInTournaments)
            {
                if(participant.ParticipantId == participantInTournament.ParticipantId)
                {
                    ParticipantInTournaments.Remove(participant);
                    break;
                }
            }

            Console.WriteLine(ParticipantInTournaments.Count);
        }
    }
}
