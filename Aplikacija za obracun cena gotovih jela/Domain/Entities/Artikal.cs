using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Artikal
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }
        [Required]
        public JMereSastojakEnum JedinicaMere{ get; set; }
        [Required]
        public decimal Kolicina { get; set; }
        [Required]
        public decimal Cena { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;

        public ICollection<Receptura> recepture { get; set; } = new List<Receptura>();
    }
}
