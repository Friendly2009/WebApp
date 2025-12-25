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
		public ActionResult Authorization()
		{
			return View();
		}
		public ActionResult Registration()
		{
			return View();
		}
	}
}
