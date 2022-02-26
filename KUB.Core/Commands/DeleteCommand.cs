using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class DeleteCommand<T> : Command<T>, ICommand
        where T : BaseEntity, new()
    {
        public Guid AggregateId { get; set; }

        public DeleteCommand(Guid AggregateId, string commandName)
        {
            Event = new BaseEvent();
            Event.SetEvent(AggregateId, commandName, AggregateId);
        }
    }
}
