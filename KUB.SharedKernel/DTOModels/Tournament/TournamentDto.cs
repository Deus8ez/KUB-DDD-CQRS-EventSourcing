using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.SharedKernel.DTOModels.Tournament
{
    public class Dto
    {

    }
    public class TournamentDto : Dto
    {
        public Guid Id { get; set; }
        public string TournamentName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string TournamentFormat { get; set; }
        public string TournamentType { get; set; }
        public string TournamentGrid { get; set; }
        public string Location { get; set; }
    }
}
