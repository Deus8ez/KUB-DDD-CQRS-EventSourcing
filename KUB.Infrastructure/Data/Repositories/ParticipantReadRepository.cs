using KUB.Core.Interfaces;
using KUB.SharedKernel.DTOModels.Participant;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.Repositories
{
    public class ParticipantReadRepository : BaseReadRepository, IParticipantReadRepository
    {
        string _connectionString;

        public ParticipantReadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalDB");
        }

        public Task<List<ParticipantDto>> GetAllAsync(int offset, int rowNumber)
        {
            throw new NotImplementedException();
        }

        public Task<ParticipantDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
