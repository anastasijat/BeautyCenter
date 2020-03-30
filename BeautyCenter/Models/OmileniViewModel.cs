using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models
{
    public class OmileniViewModel
    {
        public Klienti Klient { get; set; }
        public IEnumerable<Omileni> Omilenis{ get; set; }
        public IEnumerable<Uslugi> Uslugis { get; set; }
    }
}
