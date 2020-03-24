using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Predava
    {
        public int IdPredavac { get; set; }
        public int IdKurs { get; set; }

        public virtual Kursevi IdKursNavigation { get; set; }
        public virtual Predavaci IdPredavacNavigation { get; set; }
    }
}
