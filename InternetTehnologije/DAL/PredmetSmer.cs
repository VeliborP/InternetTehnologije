using System;
using System.Collections.Generic;

#nullable disable

namespace InternetTehnologije.DAL
{
    public partial class PredmetSmer
    {
        public int PredmetId { get; set; }
        public int SmerId { get; set; }

        public virtual Predmet Predmet { get; set; }
        public virtual Smer Smer { get; set; }
    }
}
