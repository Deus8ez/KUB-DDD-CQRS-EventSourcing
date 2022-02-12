using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.Data.SqlClient;
using System.Net.Http;
using System.Net;
using KUB.Infrastructure.Data;
using KUB.SharedKernel.DTOModels.Participant.Responses;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Participant.Requests;
using KUB.SharedKernel.Interfaces;
using KUB.SharedKernel.DTOModels.Participant;
using KUB.Application.Interfaces;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : BaseController<ParticipantDto, ParticipantPostRequest>
    {
        public ParticipantsController(IService<ParticipantDto, ParticipantPostRequest> service) : base(service)
        {
        }
    }
}
