using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Controllers
{
	public class LogController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ConfigurationDataBase _context;
		DbSet<User> UsersTable;
		public LogController(ILogger<HomeController> logger, ConfigurationDataBase context)
		{
			_logger = logger;
			_context = context;
			UsersTable = _context.users;
		}
		public ActionResult Authorization()
		{
			return View();
		}
		public ActionResult Registration()
		{
			return View();
		}
		[HttpGet]
		public ActionResult LogIn(User model)
		{
			if (ModelState.IsValid)
			{
				foreach (var user in UsersTable)
				{
					if(user.Username == model.Username && user.Password == model.Password)
					{
						return RedirectToAction("Index", "Account", model);
					}
				}
				return RedirectToAction("Index", "Home");
			}
			return View("Authorization", model);
		}

	}
}
