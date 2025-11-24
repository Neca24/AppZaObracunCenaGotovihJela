using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Artikal
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public JMereSastojakEnum Jmere{ get; set; }
        public decimal Kolicina { get; set; }
        public decimal Cena { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Receptura> recepture { get; set; } = new List<Receptura>();
    }
}
