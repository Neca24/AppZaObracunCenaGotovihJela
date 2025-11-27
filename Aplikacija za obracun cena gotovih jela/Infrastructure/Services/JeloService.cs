using Application.DTOs.JeloDTOs;
using Application.Mapper;
using Application.Services;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class JeloService : IJeloService
    {
        private readonly AppDbContext _context;

        public JeloService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> CenaPoPorciji(int id)
        {
            var jelo = await GetByIdAsync(id);
            return jelo?.CenaPoPorciji ?? 0m;
        }

        public async Task<int> CreateAsync(JeloDTO entity)
        {
            var jelo = entity.ToEntity();
            await _context.Jela.AddAsync(jelo);
            await _context.SaveChangesAsync();
            return jelo.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var jelo = await _context.Jela.FindAsync(id);
            if (jelo == null) return;

            jelo.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task<List<JeloDTO>> GetAllAsync()
        {
            var jela = await _context.Jela
                .Include(j => j.recepture)
                .ThenInclude(r => r.Artikal)
                .Where(j => j.IsActive)
                .ToListAsync();

            var result = jela.Select(jelo =>
            {
                var dto = jelo.ToDto();

                dto.Sastojci = jelo.recepture.Select(r => r.ToDto()).ToList();
                dto.CenaPoPorciji = dto.Sastojci.Sum(x => x.CenaUkupno);

                return dto;
            }).ToList();

            return result;
        }

        public async Task<JeloDTO?> GetByIdAsync(int id)
        {
            var jelo = await _context.Jela
                .Include(j => j.recepture)
                .ThenInclude(r => r.Artikal)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (jelo == null) return null;

            var dto = jelo.ToDto();
            dto.Sastojci = jelo.recepture.Select(r => r.ToDto()).ToList();
            dto.CenaPoPorciji = dto.Sastojci.Sum(x => x.CenaUkupno);

            return dto;
        }

        public async Task<decimal> UkupnaCena(int id, int brojPorcija)
        {
            var cena = await CenaPoPorciji(id);
            return cena * brojPorcija;
        }

        public async Task UpdateAsync(JeloDTO entity)
        {
            var jelo = entity.ToEntity();
            _context.Jela.Update(jelo);
            await _context.SaveChangesAsync();
        }
    }
}
