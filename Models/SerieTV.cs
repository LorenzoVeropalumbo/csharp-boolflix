using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public class SerieTV : Content
    {
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1, 500, ErrorMessage = "il numero di episodi deve essere compreso tra 1 e 500")]
        public int Number_Episode { get; set; }

        public List<Season>? Seasons { get; set; }
    }
}
