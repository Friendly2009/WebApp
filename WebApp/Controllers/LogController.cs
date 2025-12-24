using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class LogController : Controller
	{
		// GET: LogController
		public ActionResult AuthorizationPage()
		{
			return View();
		}
		public ActionResult RegistrationPage()
		{
			return View();
		}
	}
}
