using eticaretb.Data;
using eticaretb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eticaretb.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly ILogger<AnasayfaController> _logger;
		private readonly eticaretbContext db;



		public AnasayfaController(ILogger<AnasayfaController> logger, eticaretbContext context)
        {
            _logger = logger;
			db = context;
		}

        public IActionResult Anasayfa()
        {
			ViewBag.slider = db.Slider.OrderBy(a => a.Id).Take(3);
			ViewBag.product = db.Urun.OrderBy(a => a.ID).Take(16);
			

			return View();
		}

        public IActionResult SayfaDetay()
        {
            var sayfaId = RouteData.Values["id"].ToString().Split("-").Skip(1).FirstOrDefault();
            var sayfaIdInt = Int32.Parse(sayfaId);
            // var icerik = db.IcerikDiger.Where(a => a.UstMenuId == sayfaIdInt).FirstOrDefault();
            var ust_menu = db.UstMenu.Where(a => a.Id == sayfaIdInt).FirstOrDefault();
            ViewBag.Icerik = db.IcerikDiger.Where(a => a.UstMenuId == sayfaIdInt).FirstOrDefault();
            ViewBag.Sayfa = "";
            ViewBag.UstSayfa = "";
            if (ust_menu != null)
            {
                var birUstMenu = db.UstMenu.Where(a => a.Id == ust_menu.ParentId).FirstOrDefault();
                ViewBag.Sayfa = ust_menu.Adi;
                if (birUstMenu != null) { ViewBag.UstSayfa = birUstMenu.Adi; }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
