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
    
    public partial class NaŻycie
    {
        public NaŻycie()
        {
            this.UmowaUbezpieczeniowa = new HashSet<UmowaUbezpieczeniowa>();
        }
    
        public int NaŻycieId { get; set; }
        public Nullable<int> SumaUbezpieczeniaId { get; set; }
        public Nullable<int> ZawódId { get; set; }
        public Nullable<int> CelUbezpieczeńId { get; set; }
    
        public virtual CelUbezpieczeń CelUbezpieczeń { get; set; }
        public virtual SumaUbezpieczenia SumaUbezpieczenia { get; set; }
        public virtual Zawód Zawód { get; set; }
        public virtual ICollection<UmowaUbezpieczeniowa> UmowaUbezpieczeniowa { get; set; }
    }
}
