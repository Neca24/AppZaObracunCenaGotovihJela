namespace Application.DTOs.ArtikalDTOs
{
    public class ArtikalDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string JedinicaMere { get; set; } = string.Empty;
        public decimal Kolicina { get; set; }
        public decimal Cena { get; set; }
        public bool IsActive { get; set; }
    }
}
