using System;
using System.ComponentModel.DataAnnotations;

namespace eticaretb.Models
{
    public class Kullanicilar
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Kurum { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
        public string KucukResimYolu { get; set; }
        public System.DateTime EklemeTarihi { get; set; }
        public int Rol { get; set; }
    }
}
