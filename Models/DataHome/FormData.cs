namespace Boolflix.Models.DataHome
{
    public class FormData
    {
        public Film? Film { get; set; }
        public SerieTV? Serie { get; set; }
        public List<Cast>? Casts { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<Season>? Seasons { get; set; }
        public List<Episode>? Episodes { get; set; }
    }
}
