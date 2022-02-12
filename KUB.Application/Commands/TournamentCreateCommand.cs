using KUB.Core;
using KUB.Core.Models;
using KUB.SharedKernel;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.DTOModels.Tournament.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Application.Commands
{
    public class TournamentCreateCommand : Command, ICommand
    {
        public Tournament TournamentAggregate { get; set; }

        public TournamentCreateCommand(TournamentRegistrationPostRequest data)
        {
            Event = new BaseEvent();
            Event.SetEvent(TournamentAggregate.Id, "CreateTournament", TournamentAggregate);
            TournamentAggregate = new Tournament
            {
                Date = data.Date,
                EndTime = data.EndTime,
                LocationId = data.LocationId,
                StartTime = data.StartTime,
                TournamentFormatId = data.TournamentFormatId,
                TournamentGridId = data.TournamentGridId,
                Id = Guid.NewGuid(),
                TournamentTypeId = data.TournamentTypeId,
            };
        }
    }
}
