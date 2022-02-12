using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using KUB.Web.Controllers;
using KUB.Infrastructure.Data;
using KUB.SharedKernel.DTOModels.Tournament.Responses;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Tournament.Requests;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.DTOModels.Tournament;
using KUB.Application.Interfaces;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : BaseController<TournamentDto, TournamentRegistrationPostRequest>
    {
        public TournamentsController(IService<TournamentDto, TournamentRegistrationPostRequest> service) : base(service)
        {
        }

    }
}