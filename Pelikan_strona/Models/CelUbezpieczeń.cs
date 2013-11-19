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
    
    public partial class CelUbezpieczeń
    {
        public CelUbezpieczeń()
        {
            this.NaŻycie = new HashSet<NaŻycie>();
        }
    
        public int CelUbezpieczeńId{ get; set; }
        public string NazwaCelu { get; set; }
    
        public virtual ICollection<NaŻycie> NaŻycie { get; set; }
    }
}
