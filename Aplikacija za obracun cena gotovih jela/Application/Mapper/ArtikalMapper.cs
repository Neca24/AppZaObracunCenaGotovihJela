using Application.DTOs.ArtikalDTOs;
using Domain.Entities;
using Domain.Entities.Enums;

namespace Application.Mapper
{
    public static class ArtikalMapper
    {
        public static ArtikalDTO ToDto(this Artikal artikal)
        {
            return new ArtikalDTO
            {
                Id = artikal.Id,
                Naziv = artikal.Naziv,
                JedinicaMere = artikal.JedinicaMere.ToString(),
                Kolicina = artikal.Kolicina,
                Cena = artikal.Cena
            };
        }

        public static Artikal ToEntity(this ArtikalDTO dto)
        {
            return new Artikal
            {
                Id = dto.Id,
                Naziv = dto.Naziv,
                JedinicaMere = Enum.Parse<JMereSastojakEnum>(dto.JedinicaMere),
                Kolicina = dto.Kolicina,
                Cena = dto.Cena
            };
        }
    }
}
