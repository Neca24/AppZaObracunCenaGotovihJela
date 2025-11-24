namespace Domain.Entities
{
    public class Receptura
    {
        public int IdJelo { get; set; }
        public Jelo Jelo { get; set; } = null!;
        public int ArtikalId { get; set; }
        public Artikal Artikal { get; set; } = null!;
        public decimal Kolicina { get; set; }

    }
}
