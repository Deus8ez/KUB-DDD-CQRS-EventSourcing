using KUB.SharedKernel.DTOModels;
using KUB.SharedKernel.DTOModels.Participant;
using KUB.SharedKernel.DTOModels.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync(int offset, int rowNumber);
        Task<List<T>> GetAllAsync();

    }

    public interface ITournamentReadRepository : IReadRepository<TournamentDto>
    {
        Task<TournamentDto> GetByIdAsync(Guid id);
        Task<List<TournamentDto>> GetAllAsync(int offset, int rowNumber);
        Task<List<TournamentDto>> GetAllAsync();
    }

    public interface IParticipantReadRepository : IReadRepository<ParticipantDto>
    {
        Task<ParticipantDto> GetByIdAsync(Guid id);
        Task<List<ParticipantDto>> GetAllAsync(int offset, int rowNumber);
    }

    public interface ISchoolReadRepository : IReadRepository<SchoolDto>
    {
        Task<SchoolDto> GetByIdAsync(Guid id);
        Task<List<SchoolDto>> GetAllAsync(int offset, int rowNumber);
    }
}
