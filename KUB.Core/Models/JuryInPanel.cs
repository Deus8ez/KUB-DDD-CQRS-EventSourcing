using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KUB.Core.Models
{
    public class JuryInPanel
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid? JuryPanelId { get; set; }
        public virtual JuryPanel Panel { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
