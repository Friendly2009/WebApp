using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ConfigurationDataBase _context;
		DbSet<User> UsersTable;
		public AccountController(ILogger<HomeController> logger, ConfigurationDataBase context)
		{
			_logger = logger;
			_context = context;
			UsersTable = _context.users;
		}
		public IActionResult Index()
		{
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			return View(model);
		}
		
	}
}
