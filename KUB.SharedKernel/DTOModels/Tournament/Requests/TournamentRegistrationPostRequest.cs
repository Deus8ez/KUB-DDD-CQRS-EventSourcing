using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels.Tournament.Requests
{
    public class TournamentRegistrationPostRequest
    {
        public IEnumerable<ParticipantRegistrationPostRequest>? AddedParticipantIds { get; set; }
        public TournamentPostRequest Tournament { get; set; }
    }
}
