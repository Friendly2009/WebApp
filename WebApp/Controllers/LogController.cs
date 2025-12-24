using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class LogController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ConfigurationDataBase _context;
		public LogController(ILogger<HomeController> logger, ConfigurationDataBase context)
		{
			_logger = logger;
			_context = context;
		}
		public ActionResult AuthorizationPage()
		{
			var obj = _context.users.Find(1);
			ViewBag.User = obj.Username;
			return View();
		}
		public ActionResult RegistrationPage()
		{
			return View();
		}
	}
}
