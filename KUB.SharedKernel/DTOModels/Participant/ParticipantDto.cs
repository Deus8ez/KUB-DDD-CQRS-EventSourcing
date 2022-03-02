using KUB.SharedKernel.DTOModels.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels.Participant
{
    public class ParticipantAndRolesDto : Dto
    {
        public List<ParticipantDto> Participants { get; set; } = new List<ParticipantDto>();
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }

    public class ParticipantDto : Dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ClassicGameRank { get; set; }
        public int? BlitzGameRank { get; set; }
        public bool CanBeAJury { get; set; }
        public string SchoolName { get; set; }
        public string RoleName { get; set; }
        public bool? IsInTournament { get; set; } = false;

    }

    public class RoleDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
    }
}
