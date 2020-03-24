using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Predavaci
    {
        public Predavaci()
        {
            Predava = new HashSet<Predava>();
        }

        public int IdPredavac { get; set; }
        public string ImePredavac { get; set; }
        public string EmailPredavac { get; set; }
        public string TelBrojPredavac { get; set; }
        public string Iskustvo { get; set; }

        public virtual ICollection<Predava> Predava { get; set; }
    }
}
