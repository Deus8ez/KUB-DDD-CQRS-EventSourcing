using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels.Participant.Responses
{
    public class ParticipantGetResponse
    {
        public Guid ParticipantId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ClassicGameRank { get; set; }
        public int? BlitzGameRank { get; set; }
        public bool CanBeAJury { get; set; }
    }
}
