using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
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
			ViewData["HeaderNav"] = true;
			ViewBag.id = HttpContext.Session.GetInt32("id");
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			return View(model);
		}
		[HttpPost]
		public IActionResult UploadImage(IFormFile ImageFile)
		{
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			using var memoryStream = new MemoryStream();
			ImageFile.CopyTo(memoryStream);
			model.image = memoryStream.ToArray();
			UsersTable.Update(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult UploadName(string name, string surname)
		{
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			model.name = name;
			model.surname = surname;
			UsersTable.Update(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult UploadLog(string log, string password)
		{
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			model.login = log;
			model.Password = password;
			UsersTable.Update(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult UploadPhone(string phone, string Email)
		{
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			model.phone = phone;
			model.Email = Email;
			UsersTable.Update(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult UploadDescription(string text)
		{
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			model.aboutMe = text;
			UsersTable.Update(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
