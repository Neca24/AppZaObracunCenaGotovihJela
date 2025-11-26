using Application.DTOs.JeloDTOs;

namespace Application.Services
{
    public interface IJeloService:IService<JeloDTO>
    {
        Task<decimal> CenaPoPorciji(int id);
        Task<decimal> UkupnaCena(int id, int brojPorcija);
    }
}
