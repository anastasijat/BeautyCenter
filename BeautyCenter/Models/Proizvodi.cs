using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Proizvodi
    {
        public Proizvodi()
        {
            EOd = new HashSet<EOd>();
        }

        public int IdProizvod { get; set; }
        public string ImeProizvod { get; set; }
        public int? CenaProizvod { get; set; }

        public virtual ICollection<EOd> EOd { get; set; }
    }
}
