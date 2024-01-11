using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InternetTehnologije.Models
{
    public class SmerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Šifra")]
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string Sifra { get; set; }
        [DisplayName("Naziv")]
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string Naziv { get; set; }
        [DisplayName("Spisak predmeta")]
        public string SpisakPredmeta { get; set; }

        [DisplayName("Predmeti")]
        public List<PredmetViewModel> Predmeti { get; set; }
        public int[] PredmetiIds { get; set; }
        public string OznaceniPredmeti { get; set; }
    }
}
