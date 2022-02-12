using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KUB.Core.Models
{
    public class JuryInPanel
    {
        public Guid JuryInPanelId { get; set; }
        public Guid TournamentWithJuryId { get; set; }
        public Guid JuryParticipantId { get; set; }
        public Guid? JuryPanelId { get; set; }
        public virtual JuryPanel JuryPanel { get; set; }
        public virtual Participant JuryParticipant { get; set; }
        public virtual Tournament TournamentWithJury { get; set; }
    }
}
