using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Posetuva
    {
        public int IdKlient { get; set; }
        public int IdKurs { get; set; }

        public virtual Klienti IdKlientNavigation { get; set; }
        public virtual Kursevi IdKursNavigation { get; set; }
    }
}
