using Microsoft.AspNetCore.Mvc.Rendering;

namespace Boolflix.Models.DataHome
{
    public class FormData
    {
        public Film? Film { get; set; }
        public SerieTV? Serie { get; set; }
        public List<SelectListItem>? Casts { get; set; }
        public List<int>? SelectedCasts { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public List<int>? SelectedGenres { get; set; }
        public List<Season>? Seasons { get; set; }
        public List<Episode>? Episodes { get; set; }
    }
}
