namespace SchoolManagerMVC.Models
{
    public class Razred
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Smjer { get; set; } = string.Empty;
        public int GodinaUpisa { get; set; }

        public ICollection<Ucenik> Ucenici { get; set; } = new List<Ucenik>();
    }
}