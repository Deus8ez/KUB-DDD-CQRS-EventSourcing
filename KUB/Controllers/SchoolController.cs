using AutoMapper;
using KUB.Core;
using KUB.Core.Interfaces;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : BaseController<School, SchoolDto, School>
    {
        public SchoolController(ISchoolService service, IMapper mapper, ISchoolReadRepository readRepository) : base(service, mapper, readRepository)
        {
        }
    }
}
