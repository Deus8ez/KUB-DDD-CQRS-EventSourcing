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

        [HttpPost]
        public override async Task<IActionResult> Post(TournamentRegistrationPostRequest participantRegistrationPostRequest)
        {
            List<ParticipantInTournament> participantInTournaments = new List<ParticipantInTournament>();
            var tournament = _mapper.Map<Tournament>(participantRegistrationPostRequest.Tournament);

            foreach (var item in participantRegistrationPostRequest.AddedParticipantIds)
            {
                var participantInTournament = _mapper.Map<ParticipantInTournament>(item);
                participantInTournaments.Add(participantInTournament);
            }


            await _tournamentService.AddParticipants(tournament, participantInTournaments);

            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public override async Task<IActionResult> Update(Guid id, TournamentRegistrationPostRequest participantRegistrationPostRequest)
        {
            List<ParticipantInTournament> participantInTournaments = new List<ParticipantInTournament>();
            var tournament = _mapper.Map<Tournament>(participantRegistrationPostRequest.Tournament);
            tournament.Id = id;

            if (participantRegistrationPostRequest.AddedParticipantIds != null)
            {
                foreach (var item in participantRegistrationPostRequest.AddedParticipantIds)
                {
                    var participantInTournament = _mapper.Map<ParticipantInTournament>(item);
                    participantInTournaments.Add(participantInTournament);
                }
            }

            await _tournamentService.UpdateTournament(tournament, participantInTournaments);

            return NoContent();
        }

        [HttpPost]
        [Route("removeParticipants")]
        public async Task<IActionResult> RemoveParticipant(List<ParticipantInTournamentDeletionRequest> participantRegistrationPostRequest)
        {
            foreach(var item in participantRegistrationPostRequest)
            {
                var participantInTournament = _mapper.Map<ParticipantInTournament>(item);

                await _tournamentService.RemoveParticipant(participantInTournament);
            }

            return Ok();
        }
    }
}