using System;
using System.Collections.Generic;

#nullable disable

namespace InternetTehnologije.DAL
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }
        public int? SmerId { get; set; }

        public virtual Smer Smer { get; set; }
    }
}
