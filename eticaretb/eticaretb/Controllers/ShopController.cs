using eticaretb.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eticaretb.Controllers
{
	public class ShopController : Controller
	{

        private readonly eticaretbContext db;



        public ShopController(eticaretbContext context)
        {
            db = context;
        }

        public IActionResult product()
		{
            var product = db.Urun.OrderBy(a => a.ID).Take(16);
            return View(product);
		}

		
	}
}
