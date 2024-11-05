using System.ComponentModel.DataAnnotations;
using System;

namespace eticaretb.Models
{
	public class Blog
	{
		[Key]
		public int Id { get; set; }
		public string Adi { get; set; }
		public string Link { get; set; }
		public string Language { get; set; }
		public Nullable<bool> YeniSayfadaAc { get; set; }
		public Nullable<int> Sira { get; set; }
		public bool AktifMi { get; set; }
	}
}
