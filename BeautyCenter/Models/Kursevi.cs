using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Kursevi
    {
        public Kursevi()
        {
            ImaZavrseno = new HashSet<ImaZavrseno>();
            Odrzuva = new HashSet<Odrzuva>();
            Posetuva = new HashSet<Posetuva>();
            Predava = new HashSet<Predava>();
        }

        public int IdKurs { get; set; }
        public string ImeKurs { get; set; }
        public int? CenaKurs { get; set; }

        public virtual ICollection<ImaZavrseno> ImaZavrseno { get; set; }
        public virtual ICollection<Odrzuva> Odrzuva { get; set; }
        public virtual ICollection<Posetuva> Posetuva { get; set; }
        public virtual ICollection<Predava> Predava { get; set; }
    }
}
