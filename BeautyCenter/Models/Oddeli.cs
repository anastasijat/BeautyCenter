using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Oddeli
    {
        public Oddeli()
        {
            Uslugi = new HashSet<Uslugi>();
        }

        public int IdOddel { get; set; }
        public string ImeOddel { get; set; }
        public int IdVrabotenMenadzer { get; set; }
        public int IdRm { get; set; }
        public int IdSalon { get; set; }

        public virtual RabotniMesta IdRmNavigation { get; set; }
        public virtual Saloni IdSalonNavigation { get; set; }
        public virtual Menadzer IdVrabotenMenadzerNavigation { get; set; }
        public virtual ICollection<Uslugi> Uslugi { get; set; }
    }
}
