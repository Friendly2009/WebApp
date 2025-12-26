using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
	public class ModelAuthorization
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Enter логин")]
		public string login { get; set; }
		[Required(ErrorMessage = "Enter Пароль")]
		public string Password { get; set; }
	}
}
