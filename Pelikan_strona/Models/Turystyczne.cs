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
    
    public partial class Turystyczne
    {
        public Turystyczne()
        {
            this.UmowaUbezpieczeniowa = new HashSet<UmowaUbezpieczeniowa>();
        }
    
        public int TurystyczneId { get; set; }
        [Display(Name = "Liczba osoób  ubepieczanych")]
        public Nullable<int> IloscOsob { get; set; }
        [Display(Name = "Liczba osoób  do lat 18")]
        public Nullable<int> IloscOsob18 { get; set; }
        [Display(Name = "Liczba osoób   19-70 lat")]
        public Nullable<int> IloscOsobAvg { get; set; }
        [Display(Name = "Liczba osoób  pow 70 lat")]
        public Nullable<int> IloscOsob70 { get; set; }
        [Display(Name = "Kierunek wyjazdu")]
        public string WyjazdDo { get; set; }
        public Nullable<int> WariantPolisyId { get; set; }
    
        public virtual ICollection<UmowaUbezpieczeniowa> UmowaUbezpieczeniowa { get; set; }
        public virtual WariantPolisy WariantPolisy { get; set; }
    }
}
