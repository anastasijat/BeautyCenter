using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Uslugi
    {
        public Uslugi()
        {
            Omileni = new HashSet<Omileni>();
            Termini = new HashSet<Termini>();
            Vrsi = new HashSet<Vrsi>();
        }

        public int IdUsluga { get; set; }
        public string ImeUsluga { get; set; }
        public int? CenaUsluga { get; set; }
        public string OpisUsluga { get; set; }
        public int? IdOddel { get; set; }

        public virtual Oddeli IdOddelNavigation { get; set; }
        public virtual ICollection<Omileni> Omileni { get; set; }
        public virtual ICollection<Termini> Termini { get; set; }
        public virtual ICollection<Vrsi> Vrsi { get; set; }
    }
}
