using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaretb.Areas.Admin.Controllers
{
    public class HataYonetimiController : Controller
    {
        public IActionResult Hata()
        {
            return View();
            //return Redirect("/Admin/Giris");
        }
    }
}
