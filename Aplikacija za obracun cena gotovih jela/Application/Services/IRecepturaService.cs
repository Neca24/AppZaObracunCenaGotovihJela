using Application.DTOs.RecepturaDTOs;

namespace Application.Services
{
    public interface IRecepturaService
    {
        Task<List<RecepturaItemDTO>> GetForJeloAsync(int id);
        Task DodajStavku(int id, List<RecepturaItemCreateDTO> stavke);
    }
}
