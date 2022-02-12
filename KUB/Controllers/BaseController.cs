using KUB.Application.Interfaces;
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
    public abstract class BaseController<TEntityDto, TRequest> : ControllerBase
            where TEntityDto : class
            where TRequest : class
    {
        private readonly IService<TEntityDto, TRequest> _service;
        public BaseController(IService<TEntityDto, TRequest> service)
        {
            _service = service;
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
            try
            {
                await _service.PostAsync(data);
            } catch 
            {
                return StatusCode(500);
            }

            return Created("Item created", data);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TRequest data)
        {
            try
            {
                await _service.PutAsync(data);
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
