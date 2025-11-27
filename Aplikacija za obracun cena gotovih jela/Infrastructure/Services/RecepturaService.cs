using Application.DTOs.RecepturaDTOs;
using Application.Mapper;
using Application.Services;
using Domain.Entities;
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

        public async Task DodajStavku(int jeloId, List<RecepturaItemCreateDTO> stavke)
        {
            var stare = await _context.Recepture
                .Where(r => r.IdJelo == jeloId)
                .ToListAsync();

            _context.Recepture.RemoveRange(stare);
            await _context.SaveChangesAsync();

            foreach (var s in stavke)
            {
                var r = new Receptura
                {
                    IdJelo = jeloId,
                    IdArtikal = s.IdArtikal,
                    Kolicina = s.Kolicina
                };

                _context.Recepture.Add(r);
            }

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
