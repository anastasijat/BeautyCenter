using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Odrzuva
    {
        public int IdSalon { get; set; }
        public int IdKurs { get; set; }

        public virtual Kursevi IdKursNavigation { get; set; }
        public virtual Saloni IdSalonNavigation { get; set; }
    }
}
