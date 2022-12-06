using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public class SerieTV : Content
    {
        public List<Season>? Seasons { get; set; }
    }
}
