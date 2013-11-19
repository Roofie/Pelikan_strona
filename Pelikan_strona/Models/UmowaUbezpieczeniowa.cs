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
    
    public partial class UmowaUbezpieczeniowa
    {
        [Key]
        public int UmowaId { get; set; }
        public string Pesel { get; set; }
        public int UserId { get; set; }
        public int SzkodaId { get; set; }
        public int OdziałAgencjiId { get; set; }
        public int NaŻycieId { get; set; }
        public int TurystyczneId { get; set; }
        public Nullable<System.DateTime> DataZawarcia { get; set; }
        public Nullable<System.DateTime> DataZakończenia { get; set; }
        public Nullable<double> KwotaUbezpieczenia { get; set; }
        public Nullable<double> KwotaSkładki { get; set; }
        public Nullable<bool> Płatność { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }

        [InverseProperty("UmowaUbezpieczeniowa")]
        public virtual NaŻycie NaŻycie { get; set; }
        [InverseProperty("UmowaUbezpieczeniowa")]
        public virtual OdziałAgencji OdziałAgencji { get; set; }
        [InverseProperty("UmowaUbezpieczeniowa")]
        public virtual Szkoda Szkoda { get; set; }
        [InverseProperty("UmowaUbezpieczeniowa")]
        public virtual Turystyczne Turystyczne { get; set; }
    }
}
