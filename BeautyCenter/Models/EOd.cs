using System;
using System.Collections.Generic;

namespace BeautyCenter.Models
{
    public partial class EOd
    {
        public int IdProizvod { get; set; }
        public int IdProdavnica { get; set; }

        public virtual Prodavnica IdProdavnicaNavigation { get; set; }
        public virtual Proizvodi IdProizvodNavigation { get; set; }
    }
}
