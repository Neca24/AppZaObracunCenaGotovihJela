using Application.DTOs.RecepturaDTOs;

namespace Application.DTOs.JeloDTOs
{
    public class JeloDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string? Opis { get; set; }
        public string JedinicaMere { get; set; } = string.Empty;
        public decimal Kolicina { get; set; }
        public bool IsActive { get; set; }
        public List<RecepturaItemDTO> Sastojci { get; set; } = new List<RecepturaItemDTO>();
        public decimal CenaPoPorciji { get; set; }
    }
}
