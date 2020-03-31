using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Models
{
    public class SalonViewModel
    {
        public Saloni Salon { get; set; }
        public IEnumerable<Oddeli> Oddelis { get; set; }
        public IEnumerable<Uslugi> Uslugis { get; set; }
    }
}
