using KUB.SharedKernel.DTOModels.Tournament.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels.Participant.Requests
{
    public class ParticipantWithTournamentsRegistrationPostRequest
    {
        public ParticipantPostRequest Participant { get; set; }

        public IEnumerable<ParticipantInTournamentsPostRequest>?  ParticipantInTournaments { get; set; }
    }

    public class ParticipantPostRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ClassicGameRank { get; set; }
        public int? BlitzGameRank { get; set; }
        public bool CanBeAJury { get; set; }
        public Guid SchoolId { get; set; }
    }
}
