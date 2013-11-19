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
        public Nullable<int> IlośćOsób { get; set; }
    
        public virtual ICollection<UmowaUbezpieczeniowa> UmowaUbezpieczeniowa { get; set; }
    }
}
