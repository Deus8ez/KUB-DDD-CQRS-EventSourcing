//using KUB.Core.Interfaces;
//using KUB.Core.Models;
//using KUB.SharedKernel.DTOModels.Tournament;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KUB.Core.Services
//{
//    public class SchoolService : IParticipantService
//    {
//        private IReadRepository<School> _readRepository;
//        private IEventRepository<BaseEvent> _eventRepository;
//        private ISchoolCommandHandler _commandHandler;

//        public SchoolService(
//                IReadRepository<School> readRepository,
//                IEventRepository<BaseEvent> eventRepository,
//                ISchoolCommandHandler commandHandler
//            )
//        {
            
//        }

//        public Task DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity, new()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<TEntityDto>> GetAllAsync<TEntityDto>() where TEntityDto : Dto, new()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<TEntityDto> GetAsync<TEntityDto>(Guid id) where TEntityDto : Dto, new()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task PostAsync<TEntity>(TEntity item) where TEntity : BaseEntity, new()
//        {
//            throw new NotImplementedException();
//        }

//        public Task PutAsync<TEntity>(TEntity item) where TEntity : BaseEntity, new()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
