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
    public class BlogController : Controller
    {
		private readonly eticaretbContext db;
		public IActionResult hakkinda()
        {
            return View();
        }

        public IActionResult blog_detail()
        {
			
	
			return View();
        }

		public IActionResult SayfaDetay()
		{
			var Id = RouteData.Values["id"].ToString().Split("-").Skip(1).FirstOrDefault();
			var IdInt = Int32.Parse(Id);
			// var icerik = db.IcerikDiger.Where(a => a.UstMenuId == sayfaIdInt).FirstOrDefault();
			var blog = db.Blog.Where(a => a.Id == IdInt).FirstOrDefault();

            ViewBag.Icerik = db.IcerikDiger.Where(a => a.UstMenuId == IdInt).FirstOrDefault();

            return View();
		}
	}
}
