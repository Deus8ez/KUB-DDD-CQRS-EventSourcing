using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels.Tournament.Requests
{
    public class ParticipantRegistrationPostRequest
    {
        public Guid ParticipantId { get; set; }
        public Guid? RoleId { get; set; }
    }

    public class ParticipantInTournamentDeletionRequest
    {
        //public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid? RoleId { get; set; }
        public Guid TournamentId { get; set; }
    }
}
