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
    
    public partial class OdziałAgencji
    {
        public OdziałAgencji()
        {
            this.UmowaUbezpieczeniowa = new HashSet<UmowaUbezpieczeniowa>();
        }

        public int OdziałAgencjiId { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public Nullable<int> NrDomu { get; set; }
        public string NrMieszkania { get; set; }
        public string NazwaOddziału { get; set; }
    
        public virtual ICollection<UmowaUbezpieczeniowa> UmowaUbezpieczeniowa { get; set; }
    }
}
