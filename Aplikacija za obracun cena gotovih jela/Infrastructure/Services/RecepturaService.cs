using Application.DTOs.RecepturaDTOs;
using Application.Mapper;
using Application.Services;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class RecepturaService:IRecepturaService
    {
        private readonly AppDbContext _context;

        public RecepturaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DodajStavku(int id, List<RecepturaItemCreateDTO> stavke)
        {
            var postojece = _context.Recepture.Where(r=>r.IdJelo == id);
            _context.Recepture.RemoveRange(postojece);

            foreach(var s in stavke)
                _context.Recepture.Add(RecepturaMapper.ToEntity(id, s));

            await _context.SaveChangesAsync();
        }

        public async Task<List<RecepturaItemDTO>> GetForJeloAsync(int id)
        {
            return await _context.Recepture
                .Include(r=>r.Artikal)
                .Where(r=>r.IdJelo == id)
                .Select(r=>r.ToDto())
                .ToListAsync();
        }
    }
}
