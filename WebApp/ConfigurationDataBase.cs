using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp
{
	public class ConfigurationDataBase : DbContext
	{
		public DbSet<User> users { get; set; }
		public ConfigurationDataBase(DbContextOptions<ConfigurationDataBase> option) :base(option) { } 
	}
}
