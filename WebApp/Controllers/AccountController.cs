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
			ViewData["HeaderNav"] = true;
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> UploadImage(IFormFile ImageFile)
		{
			var model = UsersTable.Find(HttpContext.Session.GetInt32("id"));
			using var memoryStream = new MemoryStream();
			await ImageFile.CopyToAsync(memoryStream);
			model.image = memoryStream.ToArray();
			UsersTable.Update(model);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
	}
}
