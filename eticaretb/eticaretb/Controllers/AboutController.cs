using Microsoft.AspNetCore.Mvc;

namespace eticaretb.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult about()
		{
			return View();
		}
	}
}
