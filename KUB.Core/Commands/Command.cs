using KUB.Core;
using KUB.Core.Models;
using KUB.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Commands
{
    public interface ICommand
    {
    };

    public abstract class Command<T> : ICommand
        where T : BaseEntity, new()
    {
        public BaseEvent Event { get; set; }
        public T Aggregate { get; set; }
    }
}
