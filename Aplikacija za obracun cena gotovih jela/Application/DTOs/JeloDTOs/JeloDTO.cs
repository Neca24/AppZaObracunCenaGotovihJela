using Application.DTOs.RecepturaDTOs;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.JeloDTOs
{
    public class JeloDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv jela je obavezno")]
        [StringLength(50,ErrorMessage = "Maksimalno 50 karaktera")]
        public string Naziv { get; set; } = string.Empty;
        [StringLength(254,ErrorMessage = "Maksimalno 254 karaktera")]
        public string? Opis { get; set; }
        [Required(ErrorMessage = "Jedinica mere je obavezna")]
        public string JedinicaMere { get; set; } = string.Empty;
        [Required(ErrorMessage = "Količina je obavezna")]
        [Range(0.01,double.MaxValue,ErrorMessage = "Kolicina mora biti veća od nule")]
        public decimal Kolicina { get; set; }
        [Required(ErrorMessage = "Obavezno uneti sastojke")]
        public List<RecepturaItemDTO> Sastojci { get; set; } = new List<RecepturaItemDTO>();
        [Required(ErrorMessage = "Cena po porciji je obavezna")]
        [Range(1,double.MaxValue,ErrorMessage = "Cena mora biti veća od nule")]
        public decimal CenaPoPorciji { get; set; }
    }
}
