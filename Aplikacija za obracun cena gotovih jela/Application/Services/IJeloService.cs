using Domain.Entities;

namespace Application.Services
{
    public interface IJeloService:IService<Jelo>
    {
        Task<decimal> CenaPoPorciji(int id);
        Task<decimal> UkupnaCena(int id, int brojPorcija);
    }
}
