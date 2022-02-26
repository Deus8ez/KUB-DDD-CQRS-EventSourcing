using KUB.Core.Models;

namespace KUB.Web.ViewModels
{
    public class TournamentMeta
    {
        public List<TournamentFormat> tournamentFormats { get; set; }
        public List<TournamentGridType> tournamentGridTypes { get; set; }
        public List<TournamentType> tournamentTypes { get; set; }
    }
}
