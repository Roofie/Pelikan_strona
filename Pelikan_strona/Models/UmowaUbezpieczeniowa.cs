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
        public string User_Pesel { get; set; }
        public Nullable<int> UserId { get; set; }
        [Display(Name = "Numer polisy na życie")]
        public Nullable<int> NaŻycieId { get; set; }
        [Display(Name = "Pesel członka rodziny")]
        public string Czl_Pesel { get; set; }
        [Display(Name = "Id członka rodziny")]
        public Nullable<int> CzlonekRodzinyId { get; set; }
        [Display(Name = "Numer polisy turystycznej")]
        public Nullable<int> TurystyczneId { get; set; }
        [Display(Name = "Nazwa Agencji")]
        public Nullable<int> OdziałAgencjiId { get; set; }
        [Display(Name = "Data zawarcia umowy")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DataZawarcia { get; set; }
        [Display(Name = "Data zakończenia umowy")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DataZakończenia { get; set; }
        [Display(Name = "Potwierdzenie płatności")]
        public Nullable<bool> Płatność { get; set; }

        public virtual CzlonekRodziny CzlonekRodziny { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual NaŻycie NaŻycie { get; set; }
        public virtual OdziałAgencji OdziałAgencji { get; set; }
        public virtual ICollection<Szkoda> Szkoda { get; set; }
        public virtual Turystyczne Turystyczne { get; set; }
    }
}
