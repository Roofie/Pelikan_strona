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
    
    public partial class Wiadomości
    {
        public int WiadomościId { get; set; }
        public string Pesel { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Pra_Pesel { get; set; }
        public Nullable<int> PracownikId { get; set; }
        public string Temat { get; set; }
        public string Treść { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
        public virtual Pracownik Pracownik { get; set; }
    }
}
