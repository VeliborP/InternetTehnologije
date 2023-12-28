using System;
using System.Collections.Generic;

#nullable disable

namespace InternetTehnologije.DAL
{
    public partial class Predmet
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public int Espb { get; set; }
    }
}
