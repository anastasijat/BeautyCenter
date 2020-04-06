using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeautyCenter.Models
{
    public partial class Klienti
    {
        public Klienti()
        {
            ImaZavrseno = new HashSet<ImaZavrseno>();
            Omileni = new HashSet<Omileni>();
            Posetuva = new HashSet<Posetuva>();
            Termini = new HashSet<Termini>();
        }

        public int IdKlient { get; set; }
        [Required]
        public string ImeKlient { get; set; }

        [Required] 
        public string EmailKlient { get; set; }
        [Required]
        public string PasswordKlient { get; set; }
        public string TelBrojKlient { get; set; }
        public int? IdOpshtinaZhiveenje { get; set; }

        public virtual Opshtini IdOpshtinaZhiveenjeNavigation { get; set; }
        public virtual ICollection<ImaZavrseno> ImaZavrseno { get; set; }
        public virtual ICollection<Omileni> Omileni { get; set; }
        public virtual ICollection<Posetuva> Posetuva { get; set; }
        public virtual ICollection<Termini> Termini { get; set; }
    }
}
