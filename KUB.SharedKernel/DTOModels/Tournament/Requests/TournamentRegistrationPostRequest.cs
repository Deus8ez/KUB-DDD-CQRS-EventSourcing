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
        public string TournamentName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public Guid TournamentFormatId { get; set; }
        public Guid TournamentTypeId { get; set; }
        public Guid TournamentGridId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
