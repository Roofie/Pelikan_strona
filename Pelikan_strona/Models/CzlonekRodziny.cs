using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pelikan_strona.Models
{
    public class CzlonekRodziny
    {
        public CzlonekRodziny()
        {
            this.UmowaUbezpieczeniowa = new HashSet<UmowaUbezpieczeniowa>();
        }

        [Display(Name = "Id członka rodziny")]
        public int CzlonekRodzinyId { get; set; }
        [Display(Name = "Pesel ")]
        public string Czl_Pesel { get; set; }
        [Display(Name = "Pesel Rodzica")]
        public string User_Pesel { get; set; }
        [Display(Name = "Id Rodzica")]
        public Nullable<int> UserId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        [Display(Name = "Data Urodzenia")]
        public Nullable<System.DateTime> DataUrodzenia { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<UmowaUbezpieczeniowa> UmowaUbezpieczeniowa { get; set; }
    }
}