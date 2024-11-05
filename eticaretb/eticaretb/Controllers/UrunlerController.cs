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
	public class UrunlerController : Controller
	{
		private readonly eticaretbContext db;
		

		public UrunlerController(eticaretbContext context)
		{			
			db = context;
		}

		public IActionResult Urunler()
		{
			var product = db.Urun.OrderBy(a => a.ID).Take(16);           
            return View(product);
		}

		public IActionResult product_detail()
		{
            var product = db.Urun.OrderBy(a => a.ID);
            return View(product);
		}


	}
}