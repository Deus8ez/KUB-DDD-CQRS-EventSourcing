using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Net.Http;
using System.Net;
using KUB.Infrastructure.Data;
using KUB.SharedKernel.DTOModels.Participant.Responses;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Participant.Requests;
using KUB.SharedKernel.Interfaces;
using KUB.SharedKernel.DTOModels.Participant;
using KUB.Core.Interfaces;
using AutoMapper;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : BaseController<Participant, ParticipantAndRolesDto, ParticipantWithTournamentsRegistrationPostRequest>
    {
        IParticipantReadRepository _readRepository;
        IParticipantService _participantService;
        IMapper _mapper;
        public ParticipantsController(IParticipantService service, IMapper mapper, IParticipantReadRepository readRepository) : base(service, mapper, readRepository)
        {
            _participantService = service;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public override async Task<IActionResult> Post(ParticipantWithTournamentsRegistrationPostRequest request)
        {
            var participant = _mapper.Map<Participant>(request.Participant);
            var participantInTournaments = new List<ParticipantInTournament>();

            if (request.ParticipantInTournaments != null && request.ParticipantInTournaments.Any())
            {
                foreach (var item in request.ParticipantInTournaments)
                {
                    participantInTournaments.Add(_mapper.Map<ParticipantInTournament>(item));
                }
            }

            await _participantService.RegisterParticipant(participant, participantInTournaments);

            return Ok();
        }

        [HttpGet]
        [Route("getByTournament/{id:guid}")]
        public async Task<IActionResult> GetByTournamentId(Guid id)
        {
            var result = await _readRepository.GetAllAsync(id);

            return Ok(result);
        }


        [HttpGet]
        [Route("getNotInTournament/{id:guid}")]
        public async Task<IActionResult> GetNotInTournamentId(Guid id)
        {
            var result = await _readRepository.GetAllAsyncNotInTournament(id);

            return Ok(result);
        }
    }
}
