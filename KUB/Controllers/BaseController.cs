using AutoMapper;
using KUB.Core.Interfaces;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KUB.Web.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TEntityDto, TRequest> : ControllerBase
            where TEntity : class
            where TEntityDto : class
            where TRequest : class
    {
        private readonly IService<TEntityDto, TEntity> _service;
        private readonly IMapper _mapper;
        public BaseController(IService<TEntityDto, TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetItems()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public virtual async Task<IActionResult> GetItem(Guid id)
        {
            var result = await _service.GetAsync(id);

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
                await _service.PostAsync(entity);
            } catch 
            {
                return StatusCode(500);
            }

            return Created("Item created", data);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TRequest data)
        {
            var entity = _mapper.Map<TEntity>(data);
            try
            {
                await _service.PutAsync(entity);
            } catch
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
                await _service.DeleteAsync(id);
            } catch
            {
                return StatusCode(500);
            }

            return NoContent();
        }
    }
}
