using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class RemoveParticipantCommand : Command<ParticipantInTournament>, ICommand
    {
        public ParticipantInTournament ParticipantInTournament { get; set; }
        public RemoveParticipantCommand(ParticipantInTournament participantInTournament)
        {
            ParticipantInTournament = participantInTournament;
            Event = new BaseEvent();
            Event.SetEvent(participantInTournament.TournamentId, "RemoveParticipantFromTournament", participantInTournament);
        }
    }
}
