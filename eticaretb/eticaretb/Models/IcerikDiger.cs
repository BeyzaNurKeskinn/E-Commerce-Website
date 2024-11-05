using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaretb.Models
{
    public class IcerikDiger
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public Nullable <int> TurId { get; set; }
        public Nullable<int> UstMenuId { get; set; }
        public int EkleyenKisiID { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public Nullable<int> DuzenleyenKisiID { get; set; }
        public Nullable<DateTime> DuzenlemeTarihi { get; set; }
        public string Language { get; set; }
        public string KucukResimYolu { get; set; }

        public UstMenu UstMenu { get; set; }

}
}
