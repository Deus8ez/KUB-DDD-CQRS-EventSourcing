using KUB.Core.Models;
using KUB.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Application.Interfaces
{
    public interface IService<TEntityDto, TPostDto>
    {
        /* ReadModel  */
        // Get all
        Task<IEnumerable<TEntityDto>> GetAllAsync();

        // Get one
        Task<TEntityDto> GetAsync(Guid id);

        Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid id);

        /* Commands */
        // Create Item
        Task PostAsync(TPostDto item);
        // Update Full Item
        Task PutAsync(TPostDto item);
        // Delete Item
        Task DeleteAsync(Guid id);
    }
}
