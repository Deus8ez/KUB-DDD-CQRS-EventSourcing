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

    public interface ITournamentCommandHandler : 
        ICommandHandler<CreateCommand>,
        ICommandHandler<UpdateCommand>,
        ICommandHandler<DeleteCommand>,
        ICommandHandler<AddParticipantCommand>,
        ICommandHandler<RemoveParticipantCommand>
    {
    }

    //public interface ITournamentCommandHandler :
    //ICommandHandler<TournamentCreateCommand>,
    //ICommandHandler<TournamentUpdateCommand>,
    //ICommandHandler<TournamentDeleteCommand>,
    //ICommandHandler<TournamentAddParticipantCommand>,
    //ICommandHandler<TournamentRemoveParticipantCommand>
    //{
    //}

    public interface IBaseTournamentHandler 
    {

    }
}
