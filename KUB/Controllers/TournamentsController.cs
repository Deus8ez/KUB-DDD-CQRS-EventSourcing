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
using KUB.Web.ViewModels;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : BaseController<Tournament, TournamentDto, TournamentRegistrationPostRequest>
    {
        private ITournamentService _tournamentService;
        private IMapper _mapper;
        private ManagementGamesDB _context;
        public TournamentsController(ITournamentService service, IMapper mapper, ITournamentReadRepository readRepository, ManagementGamesDB context) : base(service, mapper, readRepository)
        {
            _tournamentService = service;
            _mapper = mapper;
            _context = context; 
        }

        [HttpGet]
        [Route("meta")]
        public ActionResult<TournamentMeta> GetMeta()
        {
            TournamentMeta data = new TournamentMeta
            {
                tournamentGridTypes = _context.TournamentGridTypes.ToList(),
                tournamentFormats = _context.TournamentFormats.ToList(),
                tournamentTypes = _context.TournamentTypes.ToList()
            };

            return data;
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