namespace Application.DTOs.RecepturaDTOs
{
    public class RecepturaItemDTO
    {
        public int Id { get; set; }

        public int IdArtikal { get; set; }
        public string NazivArtikla { get; set; } = string.Empty;
        public string JedinicaMere { get; set; } = string.Empty;

        public decimal Kolicina { get; set; }
        public decimal CenaArtikla { get; set; }

        public decimal CenaUkupno => Kolicina * CenaArtikla;
    }
}