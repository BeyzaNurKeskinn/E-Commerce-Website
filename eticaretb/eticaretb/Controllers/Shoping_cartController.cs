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
	public class Shoping_cartController : Controller
	{
		private readonly eticaretbContext db;
		public Shoping_cartController(eticaretbContext context)
		{
			db = context;
		}
		public IActionResult shoping_cart()
		{
			var urun = db.Urun.OrderBy(a => a.ID).Take(2);
			return View(urun);
		}
	}
}
