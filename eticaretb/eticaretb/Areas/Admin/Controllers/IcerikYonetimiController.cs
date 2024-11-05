using eticaretb.Data;
using eticaretb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eticaretb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IcerikYonetimiController : Controller
    {
        private readonly eticaretbContext db;

        public IcerikYonetimiController(eticaretbContext context)
        {
            db = context;
        }


        public IActionResult IcerikListele()
        {
            var icerikler = db.IcerikDiger.Where(a => a.Language.Equals("tr-TR"));
            var ustmenuler = db.UstMenu;
            foreach (var item in icerikler)
            {
                if (ustmenuler!=null && ustmenuler.Any(a=>a.Id== item.UstMenuId)) { 
                item.UstMenu = ustmenuler.Where(a => a.Id == item.UstMenuId).FirstOrDefault();
                }
            }
            return View(icerikler);
        }

        public IActionResult IcerikEkle()
        {
        var kategoriler = db.UstMenu.Where(a => a.Language.Equals("tr-TR")).OrderBy(a => a.Sira);
        ViewBag.Kategoriler = kategoriler;

            return View();
        }

        [HttpPost]
        [Route("Admin/IcerikYonetimi/IcerikEkle")]
   
        public async Task<IActionResult> IcerikEkle(IcerikDiger bilgiler, IFormFile KucukResimYolu)
        {
           

            bilgiler.EkleyenKisiID =(int)HttpContext.Session.GetInt32("Kullanici_ID");
            bilgiler.EklemeTarihi = DateTime.Now;
            bilgiler.Language = "tr-TR";
            if (KucukResimYolu != null)
            {
                string imageExtension = Path.GetExtension(KucukResimYolu.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Uploads/IcerikResimleri/{imageName}");
                using var stream = new FileStream(path, FileMode.Create);
                await KucukResimYolu.CopyToAsync(stream);
                bilgiler.KucukResimYolu = "/Uploads/IcerikResimleri/"+ imageName;
            }



            db.IcerikDiger.Add(bilgiler);
            db.SaveChanges();
            return RedirectToAction("IcerikEkle", "IcerikYonetimi");
        }






    }
}
