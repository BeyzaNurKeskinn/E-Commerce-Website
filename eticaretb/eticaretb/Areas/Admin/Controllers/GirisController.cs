using eticaretb.Areas.Admin.Filters;
using eticaretb.Data;
using eticaretb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Policy;

namespace eticaretb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GirisController : Controller
    {
        private readonly eticaretbContext db;

        public GirisController(eticaretbContext context)
        {
            db = context;
        }
        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GirisSorgula([FromBody] Kullanicilar data)
        {
            try
            {
                string Email = data.Email;
                string Parola = data.Parola;

                if (String.IsNullOrEmpty(Parola) && String.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı ve Şifrenizi Girmediniz!" });
                }
                else if (String.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı girmediniz!" });
                }
                else if (String.IsNullOrEmpty(Parola))
                {
                    return Json(new { Result = false, Message = "Şifrenizi Girmediniz!" });
                }
                else
                {

                    var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Email == Email && x.Parola == Parola);

                    if (kullanici == null) return Json(new { Result = false, Message = "Kullanıcı Adınızı ya da Şifreyi hatalı girdiniz!" });


                    //Güvenlik açısından bilgileri şifreleyerek saklamamız daha doğru bir yöntemdir.
                    //Asp.Net Membership yapısı, bu güvenliği sunmaktadır.

                    HttpContext.Session.SetInt32("Kullanici_ID", kullanici.Id); // Yeni bir session oluşturma.
                    HttpContext.Session.SetString("Ad", kullanici.Ad);
                    HttpContext.Session.SetString("Soyad", kullanici.Soyad);
                    HttpContext.Session.SetString("Resim", kullanici.KucukResimYolu);
                    HttpContext.Session.SetInt32("Rol", kullanici.Rol);



                    HttpContext.Session.SetInt32("KullaniciRol", kullanici.Rol);
                    HttpContext.Session.SetInt32("YoneticiRol", kullanici.Rol);


                    var url = "";
                    //Burada eğer, kullanıcı bilgileri, sistemde eşleşirse, geriye girişin başarılı
                    //olduğuna dair bir mesaj ve 3 saniye sonra, ana sayfaya yönlendirecek bir
                    //javascript kodu ekliyoruz.
                    if (kullanici.Rol == 1)
                    {
                        url = "Giris/Anasayfa" ;
                        // return "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...<script type='text/javascript'>setTimeout(function(){window.location='/Admin/Giris/AnaSayfa'},2000);</script>";
                    }
                    else if (kullanici.Rol == 0)
                    {
                        url = "/Anasayfa/Anasayfa";
                        // return "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...<script type='text/javascript'>setTimeout(function(){window.location='/Admin/Giris/AnaSayfa'},2000);</script>";
                    }
                    return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...", url = url });
                }

            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }

        public IActionResult OturumuKapat()
        {
            HttpContext.Session.Clear(); // Tüm sessionları temizle
            return View("Giris");
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult Hata()
        {
            return View();
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        public IActionResult GenelAyarlar()
        {
            var genelayarlar = db.Genel_Ayarlar.FirstOrDefault();

            return View(genelayarlar);
        }

        [HttpPost]
        [Route("Admin/Giris/GenelAyarlar")]
        public IActionResult GenelAyarlar(Genel_Ayarlar bilgiler)
        {
            var duzenle = db.Genel_Ayarlar.FirstOrDefault();

            duzenle.SiteAdi = bilgiler.SiteAdi;
            duzenle.MetaAuthor = bilgiler.MetaAuthor;
			duzenle.MetaKeyWords = bilgiler.MetaKeyWords;
			duzenle.MetaDescription = bilgiler.MetaDescription;
			duzenle.Facebook = bilgiler.Facebook;
			duzenle.Twitter = bilgiler.Twitter;
			duzenle.GooglePlus = bilgiler.GooglePlus;
			duzenle.Linkedln = bilgiler.Linkedln;
			duzenle.Youtube = bilgiler.Youtube;
			duzenle.Instagram = bilgiler.Instagram;
			duzenle.Tel = bilgiler.Tel;
			duzenle.Email = bilgiler.Email;
			duzenle.Fax = bilgiler.Fax;
			duzenle.WebAdres = bilgiler.WebAdres;
			duzenle.Adres = bilgiler.Adres;
			duzenle.KisaTarihce = bilgiler.KisaTarihce;
			duzenle.DuzenleyenKisiID = bilgiler.DuzenleyenKisiID;
            duzenle.DuzenlemeTarihi = DateTime.Now;
			duzenle.Language = bilgiler.Language;


			db.SaveChanges();
            return RedirectToAction("GenelAyarlar", "Giris");
        }


        public IActionResult SliderEkle()
        {
            var slider = db.Slider.FirstOrDefault();
            return View(slider);
        }
        [HttpPost]
        [Route("Admin/Giris/SliderEkle")]
        public IActionResult SliderEkle(Slider bilgiler)
        {
            var yeniSlider = new Slider
            {
                Resim = bilgiler.Resim,
                Aciklama = bilgiler.Aciklama,
                Baslik = bilgiler.Baslik,
                AltBaslik = bilgiler.AltBaslik,
                Sira = bilgiler.Sira,
                AktifMi = bilgiler.AktifMi,
                EkleyenKisiID = bilgiler.EkleyenKisiID,
                EklemeTarihi = DateTime.Now,
                Language = bilgiler.Language
            };

            db.Slider.Add(yeniSlider);
            db.SaveChanges();

            return RedirectToAction("SliderEkle", "Giris");
        }

        public IActionResult SliderListele()
        {
            var slider = db.Slider.OrderBy(a => a.Id);
            return View(slider);
        }

        public IActionResult UrunEkle()
        {
            var urun = db.Urun.FirstOrDefault();
            return View(urun);
        }

        [HttpPost]
        [Route("Admin/Giris/UrunEkle")]
        public IActionResult UrunEkle(Urun bilgiler)
        {
            var yeniUrun= new Urun
            {
                CATEGORYID = bilgiler.CATEGORYID,
                ITEMNAME = bilgiler.ITEMNAME,
                UNITPRICE = bilgiler.UNITPRICE,
                ACIKLAMA = bilgiler.ACIKLAMA,
                ITEMSTATE = bilgiler.ITEMSTATE,
                BRAND = bilgiler.BRAND,
                URL = bilgiler.URL,
                ITEMDATE = DateTime.Now,
    };

            db.Urun.Add(yeniUrun);
            db.SaveChanges();

            return RedirectToAction("UrunEkle", "Giris");
        }

        public IActionResult UrunListele()
        {
            var urun = db.Urun.OrderBy(a => a.ID);
            return View(urun);
        }

        public IActionResult MenuEkle()
        {
            var menu = db.UstMenu.FirstOrDefault();
            return View(menu);
        }

        [HttpPost]
        [Route("Admin/Giris/MenuEkle")]
        public IActionResult MenuEkle(UstMenu bilgiler)
        {
            var yeniMenu = new UstMenu
            {
                ParentId = bilgiler.ParentId,
                Adi = bilgiler.Adi,
                Link = bilgiler.Link,
                Language = bilgiler.Language,
                YeniSayfadaAc = bilgiler.YeniSayfadaAc,
                Sira = bilgiler.Sira,
                AktifMi = bilgiler.AktifMi,
    };

            db.UstMenu.Add(yeniMenu);
            db.SaveChanges();

            return RedirectToAction("MenuEkle", "Giris");
        }

        public IActionResult MenuListele()
        {
            var menu = db.UstMenu.OrderBy(a => a.Id);
            return View(menu);
        }

        public IActionResult IcerikEkle()
        {
            var icerik = db.IcerikDiger.FirstOrDefault();
            return View(icerik);
        }

        [HttpPost]
        [Route("Admin/Giris/IcerikEkle")]
        public IActionResult IcerikEkle(IcerikDiger bilgiler)
        {
            var yeniIcerik = new IcerikDiger
            {
                Icerik = bilgiler.Icerik,
            };

            db.IcerikDiger.Add(yeniIcerik);
            db.SaveChanges();

            return RedirectToAction("IcerikEkle", "Giris");
        }

        public IActionResult IcerikListele()
        {
            var icerik = db.IcerikDiger.OrderBy(a => a.Id);
            return View(icerik);
        }

        public IActionResult KullaniciEkle()
        {
            var kullanici = db.Kullanicilar.FirstOrDefault();
            return View(kullanici);
        }

        [HttpPost]
        [Route("Admin/Giris/KullaniciEkle")]
        public IActionResult KullaniciEkle(Kullanicilar bilgiler)
        {
            var yeniKullanici = new Kullanicilar
            {
                Ad = bilgiler.Ad,
                Soyad = bilgiler.Soyad,
                Kurum = bilgiler.Kurum,
                Parola = "000",
                Email = bilgiler.Email,
                KucukResimYolu = "",
                Rol = bilgiler.Rol,
                EklemeTarihi = DateTime.Now,
    };

            db.Kullanicilar.Add(yeniKullanici);
            db.SaveChanges();

            return RedirectToAction("KullaniciEkle", "Giris");
        }

        public IActionResult KullaniciListele()
        {
            var kullanici = db.Kullanicilar.OrderBy(a => a.Id);
            return View(kullanici);
        }

        public IActionResult GaleriEkle()
        {  
            return View();
        }

        public IActionResult GaleriListele()
        { 
            return View();
        }

        public IActionResult DuyuruEkle()
        {
            return View();
        }

        public IActionResult DuyuruListele()
        {
            return View();
        }

        public IActionResult ProfilDuzenle()
        {
            return View();
        }

        public IActionResult TumMesajListele()
        {
            return View();
        }

    }
}
    
