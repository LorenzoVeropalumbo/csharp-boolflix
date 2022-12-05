using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public class Episode
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1, 50, ErrorMessage = "il numero di episodi deve essere compreso tra 1 e 50")]
        public int Single_Episode { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(0.1, 500, ErrorMessage = "La durata non può essere oltre i 500 minuti")]
        public double Duration { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(0.1, 500, ErrorMessage = "il tempo rimanente non può essere oltre i 500 minuti")]
        public double Remaining_time { get; set; }

        public int SeasonId { get; set; }
        public Season? Seasons { get; set; }
    }
}
