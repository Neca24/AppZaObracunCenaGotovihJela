using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Jelo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Naziv { get; set; }
        [MaxLength(254)]
        public string Opis { get; set; }
        [Required]
        public JMereJeloEnum JedinicaMere { get; set; }
        [Required]
        public decimal Kolicina { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public ICollection<Receptura> recepture { get; set; } = new List<Receptura>();
    }
}
