using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public class UpdateCommand : Command, ICommand
    {
        public UpdateCommand(BaseEntity data, string commandName)
        {
            Aggregate = data;
            Event = new BaseEvent();
            Event.SetEvent(Aggregate.Id, commandName, Aggregate);
        }
    }
}
