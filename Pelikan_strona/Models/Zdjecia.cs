using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pelikan_strona.Models
{
    public class Zdjecia
    {
        public int ZdjeciaId { get; set; }
        public Nullable<int> SzkodaId { get; set; }
        public string SciezkaDoZdjecia { get; set; }
        [Display(Name = "Data dodania zdjęcia")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DataDodania { get; set; }
        

        public virtual Szkoda Szkoda { get; set; }
    }
}