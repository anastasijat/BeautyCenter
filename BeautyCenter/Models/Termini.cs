using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class Termini
    {
        public int IdTermin { get; set; }
        public TimeSpan Vreme { get; set; }
        public DateTime Datum { get; set; }
        public int? IdVraboten { get; set; }
        public int? IdUsluga { get; set; }
        public int? IdKlient { get; set; }
        public string Status { get; set; }
        public int? Ocenka { get; set; }
        public string Komentar { get; set; }

        public virtual Klienti IdKlientNavigation { get; set; }
        public virtual Uslugi IdUslugaNavigation { get; set; }
        public virtual Vraboteni IdVrabotenNavigation { get; set; }
    }
}
