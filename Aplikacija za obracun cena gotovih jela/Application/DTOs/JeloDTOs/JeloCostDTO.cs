namespace Application.DTOs.JeloDTOs
{
    public class JeloCostDTO
    {
        public int IdJelo { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public decimal CenaPoPorciji { get; set; }
        public int BrojPorcija { get; set; }
        public decimal UkupnaCena => CenaPoPorciji * BrojPorcija;
    }
}
