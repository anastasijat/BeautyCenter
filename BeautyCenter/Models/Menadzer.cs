using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Menadzer
    {
        public Menadzer()
        {
            Oddeli = new HashSet<Oddeli>();
        }

        public int IdVrabotenMenadzer { get; set; }

        public virtual Vraboteni IdVrabotenMenadzerNavigation { get; set; }
        public virtual ICollection<Oddeli> Oddeli { get; set; }
    }
}
