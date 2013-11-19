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
    
    public partial class Pracownik
    {
        public Pracownik()
        {
            this.Wiadomości = new HashSet<Wiadomości>();
        }
        public int PracownikId { get; set; }
        public string Pesel { get; set; }
        
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public Nullable<int> NrDomu { get; set; }
        public string NrMieszkania { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public Nullable<System.DateTime> DataUrodzenia { get; set; }
        public string Stanowisko { get; set; }
        public Nullable<decimal> Płaca { get; set; }
        public string EmialP { get; set; }
        public string HasłoP { get; set; }
    
        public virtual ICollection<Wiadomości> Wiadomości { get; set; }
    }
}
