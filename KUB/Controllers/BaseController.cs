using AutoMapper;
using KUB.Core.Interfaces;
using KUB.Core.Models;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.DTOModels.Tournament;
using KUB.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TEntityDto, TRequest> : ControllerBase
            where TEntity : BaseEntity, new()
            where TEntityDto : Dto, new()
            where TRequest : class
    {
        private readonly IService _service;
        private readonly IMapper _mapper;
        private readonly IReadRepository<TEntityDto> _readRepository;

        public BaseController(IService service, IMapper mapper, IReadRepository<TEntityDto> readRepository)
        {
            _service = service;
            _mapper = mapper;
            _readRepository = readRepository;
        }

        [HttpGet]
        [Route("{offset:int}/{rowNumber:int}")]
        public virtual async Task<IActionResult> GetItems(int offset = 1, int rowNumber = 20)
        {
            var result = await _readRepository.GetAllAsync(offset, rowNumber);

            return Ok(result);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetItems()
        {
            var result = await _readRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public virtual async Task<IActionResult> GetItem(Guid id)
        {
            var result = await _readRepository.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("events/{id}")]
        public virtual async Task<IActionResult> GetEvents(Guid id)
        {
            var result = await _service.GetEventsAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TRequest data)
        {

            var entity = _mapper.Map<TEntity>(data);
            try
            {
                await _service.PostAsync<TEntity>(entity);
            } catch 
            {
                return StatusCode(500);
            }

            return Created("Item created", data);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public virtual async Task<IActionResult> Update(Guid id, TRequest data)
        {
            var entity = _mapper.Map<TEntity>(data);
            entity.Id = id; 
            try
            {
                await _service.PutAsync<TEntity>(entity);
            } catch (Exception ex)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync<TEntity>(id);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}
