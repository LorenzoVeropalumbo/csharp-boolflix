using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public class Film : Content
    {
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(0.1, 500, ErrorMessage = "La durata non può essere oltre i 500 minuti")]
        public double Duration { get; set; }

    }
}
