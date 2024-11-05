using eticaretb.Data;
using eticaretb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eticaretb.Controllers
{
    public class SliderController : Controller
    {
        private readonly eticaretbContext db;


        public SliderController(eticaretbContext context)
        {   
            db = context;
        }
        public IActionResult Slider()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetirSlider()
        {
            try
            {
                var sliders = db.Slider.Where(a => a.AktifMi).OrderBy(a => a.Sira);
                return Json(new { gelendata = sliders, Result = true, Message = "Başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new {Result = false, Message = ex.Message });
            }
        }
    }
}
