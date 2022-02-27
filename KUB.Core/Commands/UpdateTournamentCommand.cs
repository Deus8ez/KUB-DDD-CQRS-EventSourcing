using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class UpdateTournamentCommand : Command<Tournament>, ICommand
    {
        public Tournament Tournament { get; set; }
        public List<ParticipantInTournament> ParticipantsInTournament { get; set; }
        public UpdateTournamentCommand(Tournament tournament, List<ParticipantInTournament> participantsInTournament)
        {
            Tournament = tournament;
            ParticipantsInTournament = participantsInTournament;
            Event = new BaseEvent();
            Event.SetEvent(tournament.Id, "UpdateTournamentWithParticipants", participantsInTournament);
        }
    }
}
