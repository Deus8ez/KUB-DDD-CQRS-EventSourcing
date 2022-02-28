using AutoMapper;
using KUB.Core;
using KUB.Core.Interfaces;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels;
using KUB.SharedKernel.DTOModels.School.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : BaseController<School, SchoolDto, SchoolPostRequest>
    {
        public SchoolsController(ISchoolService service, IMapper mapper, ISchoolReadRepository readRepository) : base(service, mapper, readRepository)
        {
        }
    }
}
