using System;
using System.ComponentModel.DataAnnotations;

namespace eticaretb.Models
{
    public class Urun
    {
        [Key]
        public int ID { get; set; }

        public int CATEGORYID { get; set; }
        public string ITEMNAME { get; set; }
        public double UNITPRICE { get; set; }
        public string ACIKLAMA { get; set; }
        public DateTime ITEMDATE { get; set; }
        public string ITEMSTATE { get; set; }
        public string BRAND { get; set; }
		public string URL { get; set; }
        public string Link { get; set; }
	}
}
