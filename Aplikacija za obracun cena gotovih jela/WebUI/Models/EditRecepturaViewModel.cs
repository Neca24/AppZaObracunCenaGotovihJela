using Application.DTOs.ArtikalDTOs;
using Application.DTOs.RecepturaDTOs;

namespace WebUI.Models
{
    public class EditRecepturaViewModel
    {
        public int JeloId { get; set; }

        public List<ArtikalDTO> Artikli { get; set; } = new();
        public List<RecepturaItemDTO> PostojeceStavke { get; set; } = new();

        public List<RecepturaItemCreateDTO> Stavke { get; set; } = new();
    }
}
