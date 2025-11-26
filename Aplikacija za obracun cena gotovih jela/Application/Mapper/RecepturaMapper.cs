using Application.DTOs.RecepturaDTOs;
using Domain.Entities;

namespace Application.Mapper
{
    public static class RecepturaMapper
    {
        public static RecepturaItemDTO ToDto(this Receptura receptura)
        {
            return new RecepturaItemDTO
            {
                IdJelo = receptura.IdJelo,
                IdArtikal = receptura.IdArtikal,
                NazivArtikla = receptura.Artikal.Naziv,
                JedinicaMere = receptura.Artikal.JedinicaMere.ToString(),
                Kolicina = receptura.Kolicina,
                CenaArtikla = receptura.Artikal.Cena
            };
        }

        public static Receptura ToEntity(int jeloId, RecepturaItemCreateDTO dto)
        {
            return new Receptura
            {
                IdJelo = jeloId,
                IdArtikal = dto.IdArtikal,
                Kolicina = dto.Kolicina
            };
        }
    }
}
