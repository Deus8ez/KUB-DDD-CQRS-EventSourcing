using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class TournamentAddParticipantCommand : Command, ICommand
    {
        public ParticipantInTournament ParticipantInTournament { get; set; }
        public TournamentAddParticipantCommand(ParticipantInTournament participantInTournament)
        {
            ParticipantInTournament = participantInTournament;
            Event = new BaseEvent();
            Event.SetEvent(participantInTournament.TournamentId, "AddParticipantToTournament", participantInTournament);
        }
    }
}
