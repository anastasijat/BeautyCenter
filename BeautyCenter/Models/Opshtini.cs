using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Opshtini
    {
        public Opshtini()
        {
            Klienti = new HashSet<Klienti>();
            Saloni = new HashSet<Saloni>();
        }

        public int IdOpshtina { get; set; }
        public string NazivOpshtina { get; set; }
        public string Grad { get; set; }

        public virtual ICollection<Klienti> Klienti { get; set; }
        public virtual ICollection<Saloni> Saloni { get; set; }
    }
}
