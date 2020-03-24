using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Direktor
    {
        public Direktor()
        {
            Saloni = new HashSet<Saloni>();
        }

        public int IdVrabotenDirektor { get; set; }

        public virtual Vraboteni IdVrabotenDirektorNavigation { get; set; }
        public virtual ICollection<Saloni> Saloni { get; set; }
    }
}
