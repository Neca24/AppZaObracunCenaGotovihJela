using Application.DTOs.JeloDTOs;
using Domain.Entities;
using Domain.Entities.Enums;

namespace Application.Mapper
{
    public static class JeloMapper
    {
        public static JeloDTO ToDto(this Jelo jelo)
        {
            return new JeloDTO
            {
                Id = jelo.Id,
                Naziv = jelo.Naziv,
                Opis = jelo.Opis,
                JedinicaMere = jelo.JedinicaMere.ToString(),
                Kolicina = jelo.Kolicina,
                IsActive = jelo.IsActive
            };
        }

        public static Jelo ToEntity(this JeloDTO dto)
        {
            return new Jelo
            {
                Id = dto.Id,
                Naziv = dto.Naziv,
                Opis = dto.Opis,
                JedinicaMere = Enum.Parse<JMereJeloEnum>(dto.JedinicaMere),
                Kolicina = dto.Kolicina,
                IsActive = dto.IsActive
            };
        }
    }
}
