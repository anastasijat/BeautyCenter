using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Omileni
    {
        public int IdKlient { get; set; }
        public int IdUsluga { get; set; }

        public virtual Klienti IdKlientNavigation { get; set; }
        public virtual Uslugi IdUslugaNavigation { get; set; }
    }
}
