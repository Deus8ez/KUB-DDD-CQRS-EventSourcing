using KUB.Core.Commands;
using KUB.Core.Models;
using KUB.SharedKernel.Interfaces;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    /// <summary>
    /// Used to decorate a command handler interface with commands
    /// </summary>
    public interface ICommandHandler<ICommand>
    {
        Task Handle(ICommand command);
    }

    public interface ITournamentCommandHandler : ICommandHandler<TournamentCreateCommand>
    {

    }

    public interface IBaseTournamentHandler 
    {

    }
}
