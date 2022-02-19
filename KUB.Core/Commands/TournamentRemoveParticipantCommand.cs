using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class TournamentRemoveParticipantCommand : Command, ICommand
    {
        public ParticipantInTournament ParticipantInTournament { get; set; }
        public TournamentRemoveParticipantCommand(ParticipantInTournament participantInTournament)
        {
            ParticipantInTournament = participantInTournament;
            Event = new BaseEvent();
            Event.SetEvent(participantInTournament.TournamentId, "RemoveParticipantFromTournament", participantInTournament);
        }
    }
}
