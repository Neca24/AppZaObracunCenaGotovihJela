using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Jelo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public JMereJeloEnum JedinicaMere { get; set; } = JMereJeloEnum.Por;
        public decimal Kolicina { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<Receptura> recepture { get; set; } = new List<Receptura>();
    }
}
