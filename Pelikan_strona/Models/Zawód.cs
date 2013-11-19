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
    
    public partial class Zawód
    {
        public Zawód()
        {
            this.NaŻycie = new HashSet<NaŻycie>();
        }
    
        public int ZawódId { get; set; }
        public string NazwaZawodu { get; set; }
        public Nullable<int> KlasaRyzyka { get; set; }
    
        public virtual ICollection<NaŻycie> NaŻycie { get; set; }
    }
}
