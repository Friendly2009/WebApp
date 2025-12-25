using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index(User model)
		{
			return View(model);
		}
	}
}
