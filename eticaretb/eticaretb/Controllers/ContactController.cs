using Microsoft.AspNetCore.Mvc;

namespace eticaretb.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult contact()
		{
			return View();
		}
	}
}
