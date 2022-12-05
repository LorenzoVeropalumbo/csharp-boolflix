using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public class Cast
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può essere oltre i 50 caratteri")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il cognome non può essere oltre i 50 caratteri")]
        public string Lastnome { get; set; }

        public List<Content>? Contents { get; set; }
    }
}
