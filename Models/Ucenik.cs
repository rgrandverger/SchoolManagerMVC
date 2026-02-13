using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagerMVC.Models
{
    public class Ucenik
    {
        public int Id { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DatumRodenja { get; set; }

        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5,2)")]
        public decimal Prosjek { get; set; }

        public int RazredId { get; set; }
        public Razred? Razred { get; set; }
    }
}