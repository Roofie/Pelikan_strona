using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pelikan_strona.Models
{
    public class WariantPolisy
    {
        public int WariantPolisyId { get; set; }
        [Display(Name = "Nazwa wariantu polisy")]
        public string NazwaWariantu { get; set; }
        [Display(Name = "Koszty leczenia do kwoty")]
        public Nullable<double> KosztLeczenia { get; set; }
        [Display(Name = "Następstwa nieszczęśliwych wypadków(NWW) do kwoty")]
        public Nullable<double> NNW { get; set; }
        [Display(Name = "W razie awaryjnych powrotów")]
        public Nullable<bool> PowrotOsobBliskich { get; set; }
        [Display(Name = "OC w prywatnym życiu do kwoty")]
        public Nullable<double> OCwPrywatnym { get; set; }
        [Display(Name = "Ubezpieczenie bagażu do kwoty")]
        public Nullable<double> BagazPodrozny { get; set; }
        [Display(Name = "Zwrot kosztów ratownictwa")]
        public Nullable<bool> Ratownictwo { get; set; }

        public virtual ICollection<Turystyczne> Turystyczne { get; set; }
    }
}