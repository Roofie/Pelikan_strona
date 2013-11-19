using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Pelikan_strona.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Szkoda
    {
        public Szkoda()
        {
            this.UmowaUbezpieczeniowa = new HashSet<UmowaUbezpieczeniowa>();
        }
    
        public int SzkodaId { get; set; }
        public Nullable<System.DateTime> DataZgłoszenia { get; set; }
        public Nullable<double> KwotaSzkody { get; set; }
        public string Opis { get; set; }
        public byte[] Zdjęcia { get; set; }
    
        public virtual ICollection<UmowaUbezpieczeniowa> UmowaUbezpieczeniowa { get; set; }
    }
}
