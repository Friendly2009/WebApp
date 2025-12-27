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
		public ActionResult LogIn(ModelAuthorization model)
		{
			if (ModelState.IsValid)
			{
				foreach (var user in UsersTable)
				{
					if(user.Username == model.Username && user.Password == model.Password)
					{
						return RedirectToAction("Index", "Account", user);
					}
				}
				TempData["Message"] = "Login or password incorrect";
				return View("Authorization", model);
			}
			return View("Authorization", model);
		}
		[HttpPost]
		public ActionResult LogUp(User model)
		{
			if(ModelState.IsValid)
			{
				foreach(User user in UsersTable)
				{
					if(model.Username == user.Username)
					{
						TempData["Message"] = "This user already exist";
						return RedirectToAction("Registration", model);
					}
				}
				UsersTable.Add(model);
				_context.SaveChanges();
				TempData["Message"] = "your user has been registered";
				return RedirectToAction("Index", "Account", model);
			}
			return RedirectToAction("Registration", model);
		}
	}
}
