using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class UpdateParticipant : Command<Participant>, ICommand
    {
        public Participant Participant { get; set; }
        public Guid? SchoolId { get; set; }
        public UpdateParticipant(Participant participant, Guid? schoolId)
        {
            Participant = participant;
            SchoolId = schoolId;
            Event = new BaseEvent();
            Event.SetEvent(participant.Id, "UpdateParticipant", participant);
        }
    }
}
