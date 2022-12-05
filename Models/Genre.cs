using System.ComponentModel.DataAnnotations;

namespace Boolflix.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può essere oltre i 50 caratteri")]
        public string Name { get; set; }

        public List<Content>? Contents { get; set; }
    }
}
