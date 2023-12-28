using System.ComponentModel.DataAnnotations;

namespace InternetTehnologije.Models
{
    public class PredmetPostModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string Sifra { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public int Espb { get; set; }
    }
}
