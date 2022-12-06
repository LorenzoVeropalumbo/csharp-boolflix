using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }

        public List<Episode>? Episodes { get; set; }
        public int SerieTVId { get; set; }
        public SerieTV? SerieTV { get; set; }
    }
}
