using Domain.Entities;

namespace Application.Services
{
    public interface IRecepturaService
    {
        Task<List<Receptura>> GetForJeloAsync(int id);
        Task DodajStavku(int id, List<Receptura> stavke);
    }
}
