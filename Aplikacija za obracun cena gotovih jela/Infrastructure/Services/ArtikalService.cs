using Application.DTOs.ArtikalDTOs;
using Application.Mapper;
using Application.Services;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ArtikalService : IArtikalService
    {
        private readonly AppDbContext _context;

        public ArtikalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(ArtikalDTO entity)
        {
            var artikal = entity.ToEntity();
            await _context.Artikli.AddAsync(artikal);
            await _context.SaveChangesAsync();
            return artikal.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var artikal = await _context.Artikli.FindAsync(id);
            if (artikal == null) return;

            artikal.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task<List<ArtikalDTO>> GetAllAsync()
        {
            return await _context.Artikli
                .Where(a => a.IsActive)
                .Select(a => a.ToDto())
                .ToListAsync();
        }

        public async Task<ArtikalDTO?> GetByIdAsync(int id)
        {
            var artikal = await _context.Artikli.FindAsync(id);
            return artikal?.ToDto();
        }

        public async Task UpdateAsync(ArtikalDTO entity)
        {
            var artikal = entity.ToEntity();
            _context.Artikli.Update(artikal);
            await _context.SaveChangesAsync();
        }
    }
}
