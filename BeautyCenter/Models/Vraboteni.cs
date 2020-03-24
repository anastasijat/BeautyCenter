using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Vraboteni
    {
        public Vraboteni()
        {
            Termini = new HashSet<Termini>();
        }

        public int IdVraboten { get; set; }
        public string EmailVraboten { get; set; }
        public string PasswordVraboten { get; set; }
        public string ImeVraboten { get; set; }
        public int? IdSalon { get; set; }
        public int? IdRm { get; set; }
        public int? MesecnaPlata { get; set; }

        public virtual RabotniMesta IdRmNavigation { get; set; }
        public virtual Saloni IdSalonNavigation { get; set; }
        public virtual Direktor Direktor { get; set; }
        public virtual Menadzer Menadzer { get; set; }
        public virtual ICollection<Termini> Termini { get; set; }
    }
}
