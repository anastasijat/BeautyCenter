using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Prodavnica
    {
        public Prodavnica()
        {
            EOd = new HashSet<EOd>();
        }

        public int IdProdavnica { get; set; }
        public string ImeProdavnica { get; set; }
        public string Lokacija { get; set; }
        public int? IdSalon { get; set; }

        public virtual Saloni IdSalonNavigation { get; set; }
        public virtual ICollection<EOd> EOd { get; set; }
    }
}
