using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ArtikalDTOs
{
    public class ArtikalDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv artikla je obavezno")]
        [StringLength(50, ErrorMessage = "Maksimalno 50 karaktera")]
        public string Naziv { get; set; } = string.Empty;

        [DisplayName("Jedinica mere")]
        [Required(ErrorMessage = "Jedinica mere je obavezna")]
        public string JedinicaMere { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cena je obavezna")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cena mora biti veća od nule")]
        public decimal Cena { get; set; }
    }
}
