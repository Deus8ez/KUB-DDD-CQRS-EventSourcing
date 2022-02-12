using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels.Tournament.Requests
{
    public class ParticipantRegistrationPostRequest
    {
        public int ParticipantId { get; set; }
        public int? RoleId { get; set; }
        public Guid Id { get; set; }
    }
}
