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
					if(user.login == model.login && user.Password == model.Password)
					{
						HttpContext.Session.SetInt32("id",user.Id);
						return RedirectToAction("Index", "Account");
					}
				}
				TempData["Message"] = "Login or password incorrect";
				return View("Authorization", model);
			}
			return View("Authorization", model);
		}
		[HttpPost]
		public ActionResult LogUp(ModelAuthorization model)
		{
			if(ModelState.IsValid)
			{
				foreach(User user in UsersTable)
				{
					if(model.login == user.login)
					{
						TempData["Message"] = "This user already exist";
						return RedirectToAction("Registration", model);
					}
				}
				User NewUser = new User{
					login = model.login,
					Password = model.Password,
					Email = "",
					phone = "",
					aboutMe = "",
					image = new byte[255],
					name = "",
					surname = "",
				};
				UsersTable.Add(NewUser);
				_context.SaveChanges();
				TempData["Message"] = "your user has been registered";
				return RedirectToAction("Index", "Account", NewUser);
			}
			return RedirectToAction("Registration", model);
		}
	}
}
