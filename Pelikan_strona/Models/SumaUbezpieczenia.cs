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
    
    public partial class SumaUbezpieczenia
    {
        public SumaUbezpieczenia()
        {
            this.NaŻycie = new HashSet<NaŻycie>();
        }

        public int SumaUbezpieczeniaId { get; set; }
        public Nullable<double> Kwota { get; set; }
    
        public virtual ICollection<NaŻycie> NaŻycie { get; set; }
    }
}
