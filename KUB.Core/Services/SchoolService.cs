using KUB.Core.Interfaces;
using KUB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Services
{
    public class SchoolService : IParticipantService<School, School>
    {
        private IReadRepository<School> _readRepository;
        private IEventRepository<BaseEvent> _eventRepository;
        private ISchoolCommandHandler _commandHandler;

        public SchoolService(
                IReadRepository<School> readRepository,
                IEventRepository<BaseEvent> eventRepository,
                ISchoolCommandHandler commandHandler
            )
        {
            
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<School>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<School> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(School item)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(School item)
        {
            throw new NotImplementedException();
        }
    }
}
