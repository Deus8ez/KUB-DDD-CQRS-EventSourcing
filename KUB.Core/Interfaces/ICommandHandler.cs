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

    public interface IUpdateCommand
    {

    }

    public interface IBaseCommandHandler  

    {
        Task Handle<T>(UpdateCommand<T> command) where T : BaseEntity, new();
        Task Handle<T>(CreateCommand<T> command) where T : BaseEntity, new();
        Task Handle<T>(DeleteCommand<T> command) where T : BaseEntity, new();
        Task Handle(AddParticipantsCommand command);
        Task Handle(AddParticipantCommand command);
        Task Handle(RemoveParticipantCommand command);
        Task Handle(UpdateTournamentCommand command);
    }
}
