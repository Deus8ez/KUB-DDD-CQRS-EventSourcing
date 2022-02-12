using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KUB.SharedKernel.Interfaces;

namespace KUB.Core.Models
{
    public class Participant : BaseEntity, IAggregateRoot
    {
        public Guid ParticipantId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ClassicGameRank { get; set; }
        public int? BlitzGameRank { get; set; }
        public bool CanBeAJury { get; set; }
        public virtual ParticipantInSchool ParticipantInSchool { get; set; }
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
        public virtual ICollection<ParticipantInTournament> ParticipantInTournaments { get; set; }
    }
}
