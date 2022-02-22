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
using KUB.Core.Interfaces;
using System.Diagnostics;
using AutoMapper;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : BaseController<Tournament, TournamentDto, TournamentRegistrationPostRequest>
    {
        private ITournamentService<TournamentDto, Tournament> _tournamentService;
        private IMapper _mapper;
        public TournamentsController(ITournamentService<TournamentDto, Tournament> service, IMapper mapper) : base(service, mapper)
        {
            _tournamentService = service;
            _mapper = mapper;
        }

        [HttpPut]
        [Route("addParticipant")]
        public async Task<IActionResult> AddParticipant(ParticipantRegistrationPostRequest participantRegistrationPostRequest)
        {

            var participantInTournament = _mapper.Map<ParticipantInTournament>(participantRegistrationPostRequest);

            await _tournamentService.AddParticipant(participantInTournament);

            return Ok();
        }

        [HttpDelete]
        [Route("removeParticipant")]
        public async Task<IActionResult> RemoveParticipant(ParticipantInTournamentDeletionRequest participantRegistrationPostRequest)
        {
            var participantInTournament = _mapper.Map<ParticipantInTournament>(participantRegistrationPostRequest);

            await _tournamentService.RemoveParticipant(participantInTournament);

            return Ok();
        }
    }
}