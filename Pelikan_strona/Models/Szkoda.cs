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
       
        public int SzkodaId { get; set; }
        public Nullable<int> UmowaId { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DataZgłoszenia { get; set; }
        [Display(Name = "Czy zweryfikowano pomyślnie")]
        public Nullable<bool> CzyPrzyznano{ get; set; }
        [Display(Name = "Wycena przez klienta")]
        public Nullable<double> KwotaSzkody { get; set; }
        public string Opis { get; set; }
    
        public virtual UmowaUbezpieczeniowa UmowaUbezpieczeniowa { get; set; }
        public virtual ICollection<Zdjecia> Zdjecia { get; set; }
    }
}
