using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Vrsi
    {
        public int IdUsluga { get; set; }
        public int IdRm { get; set; }

        public virtual RabotniMesta IdRmNavigation { get; set; }
        public virtual Uslugi IdUslugaNavigation { get; set; }
    }
}
