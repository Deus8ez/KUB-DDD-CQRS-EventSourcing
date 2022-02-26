using KUB.Core.Interfaces;
using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class UpdateCommand<T> : Command<T>, ICommand, IUpdateCommand
        where T : BaseEntity, new()
    {
        public UpdateCommand(T data, string commandName)
        {
            Aggregate = data;
            Event = new BaseEvent();
            Event.SetEvent(Aggregate.Id, commandName, Aggregate);
        }
    }
}
