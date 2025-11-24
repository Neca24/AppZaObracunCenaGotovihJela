namespace Application.DTOs.RecepturaDTOs
{
    public class RecepturaCreateDTO
    {
        public int IdJelo { get; set; }
        public List<RecepturaItemCreateDTO> Stavke { get; set; } = new();
    }
}
