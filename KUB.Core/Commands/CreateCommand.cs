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

namespace KUB.Core.Commands
{
    public class CreateCommand<T> : Command<T>, ICommand
        where T : BaseEntity, new()
    {
        public CreateCommand(T data, string commandName)
        {
            Aggregate = data;
            Aggregate.Id = Guid.NewGuid();
            Event = new BaseEvent();
            Event.SetEvent(Aggregate.Id, commandName, Aggregate);
        }
    }
}
