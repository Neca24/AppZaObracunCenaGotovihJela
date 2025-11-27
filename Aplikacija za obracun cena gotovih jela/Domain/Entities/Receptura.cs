using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Receptura
    {
        public int Id { get; set; }

        public int IdJelo { get; set; }
        public Jelo Jelo { get; set; } = null!;
        public int IdArtikal { get; set; }
        public Artikal Artikal { get; set; } = null!;
        [Required]
        public decimal Kolicina { get; set; }

    }
}
