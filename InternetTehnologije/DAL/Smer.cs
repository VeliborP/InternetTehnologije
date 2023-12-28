using System;
using System.Collections.Generic;

#nullable disable

namespace InternetTehnologije.DAL
{
    public partial class Smer
    {
        public Smer()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
