using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class RabotniMesta
    {
        public RabotniMesta()
        {
            Oddeli = new HashSet<Oddeli>();
            Vraboteni = new HashSet<Vraboteni>();
            Vrsi = new HashSet<Vrsi>();
        }

        public int IdRm { get; set; }
        public string ImeRm { get; set; }

        public virtual ICollection<Oddeli> Oddeli { get; set; }
        public virtual ICollection<Vraboteni> Vraboteni { get; set; }
        public virtual ICollection<Vrsi> Vrsi { get; set; }
    }
}
