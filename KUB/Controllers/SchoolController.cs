using AutoMapper;
using KUB.Core.Interfaces;
using KUB.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : BaseController<School, School, School>
    {
        public SchoolController(ISchoolService<School, School> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
