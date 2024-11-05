using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eticaretb.Models;

namespace eticaretb.Data
{
    public class eticaretbContext : DbContext
    {
        public eticaretbContext (DbContextOptions<eticaretbContext> options)
            : base(options)
        {
        }

        public DbSet<eticaretb.Models.Urun> Urun { get; set; }
        public DbSet<eticaretb.Models.Slider> Slider { get; set; }
		public DbSet<eticaretb.Models.UstMenu> UstMenu { get; set; }
		public DbSet<eticaretb.Models.Blog> Blog { get; set; }
		public DbSet<eticaretb.Models.Kullanicilar> Kullanicilar { get; set; }

        public DbSet<eticaretb.Models.Genel_Ayarlar> Genel_Ayarlar { get; set; }
        public DbSet<eticaretb.Models.IcerikDiger> IcerikDiger { get; set; }
    }
}
