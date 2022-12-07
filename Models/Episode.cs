using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boolflix.Models
{
    public class Episode
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il titolo non può essere oltre i 50 caratteri")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(255, ErrorMessage = "La descrizione non può essere oltre i 255 caratteri")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

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
