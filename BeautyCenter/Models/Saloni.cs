using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Saloni
    {
        public Saloni()
        {
            Oddeli = new HashSet<Oddeli>();
            Odrzuva = new HashSet<Odrzuva>();
            Prodavnica = new HashSet<Prodavnica>();
            Vraboteni = new HashSet<Vraboteni>();
        }

        public int IdSalon { get; set; }
        public string ImeSalon { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string TelBrojSalon { get; set; }
        public int? IdOpshtina { get; set; }
        public int IdVrabotenDirektor { get; set; }

        public virtual Opshtini IdOpshtinaNavigation { get; set; }
        public virtual Direktor IdVrabotenDirektorNavigation { get; set; }
        public virtual ICollection<Oddeli> Oddeli { get; set; }
        public virtual ICollection<Odrzuva> Odrzuva { get; set; }
        public virtual ICollection<Prodavnica> Prodavnica { get; set; }
        public virtual ICollection<Vraboteni> Vraboteni { get; set; }
    }
}
