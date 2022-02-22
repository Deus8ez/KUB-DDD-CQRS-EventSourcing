﻿using KUB.Core.Models;
using KUB.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Core.Interfaces
{
    public interface IService<TEntity> 
    {

        Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid id);
        
        /* Commands */
        // Create Item
        Task PostAsync<TEntity>(TEntity item) where TEntity : BaseEntity, new();
        // Update Full Item
        Task PutAsync<TEntity>(TEntity item) where TEntity : BaseEntity, new();
        // Delete Item
        Task DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity, new();
    }
    public interface ITournamentService<TEntityDto, TEntity> : IService<TEntity>
    {
        /* ReadModel  */
        // Get all
        Task<IEnumerable<TEntityDto>> GetAllAsync();

        // Get one
        Task<TEntityDto> GetAsync<TEntityDto>(Guid id);
        Task AddParticipant(ParticipantInTournament participantInTournament);
        Task RemoveParticipant(ParticipantInTournament participantInTournament);
    }

    public interface ISchoolService<TEntityDto, TEntity> : IService<TEntity>
    {
    }

    public interface IParticipantService<TEntityDto, TEntity> : IService<TEntity>
    {
    }
}
