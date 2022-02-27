using AutoMapper;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Tournament;
using KUB.SharedKernel.DTOModels.Tournament.Requests;

namespace KUB.Web.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TournamentPostRequest, Tournament>();
            CreateMap<Tournament, TournamentDto>();
            CreateMap<ParticipantRegistrationPostRequest, ParticipantInTournament>();
            CreateMap<ParticipantInTournamentDeletionRequest, ParticipantInTournament>();
            CreateMap<TournamentDto, Tournament>();
            
        }
    }
}
