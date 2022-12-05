using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public abstract class Content
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
        [Range(1, 5, ErrorMessage = "il rating deve essere compreso tra 1 e 5 stelle")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public bool AlreadySeen { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public DateTime Year { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1, 99, ErrorMessage = "la compatibility deve essere compresa tra 1 e 99")]
        public int Compatibility { get; set; }

        public List<Genre>? Genres { get; set; }

        public List<Cast>? Casts { get; set; }
    }
}
