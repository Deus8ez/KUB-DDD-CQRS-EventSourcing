using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class RegisterParticipantWithTournamentsCommand : Command<Participant>, ICommand
    {
        public Participant Participant { get; set; }
        public List<ParticipantInTournament> ParticipantsInTournament { get; set; }
        public RegisterParticipantWithTournamentsCommand(Participant participant, List<ParticipantInTournament> participantsInTournament)
        {
            Participant = participant;
            ParticipantsInTournament = participantsInTournament;
            Event = new BaseEvent();
            Event.SetEvent(participant.Id, "RegisterPrticipantWithTournaments", participantsInTournament);
        }
    }
}
