using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Enter логин")]
		public string login { get; set; }
		[Required(ErrorMessage = "Enter Пароль")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Enter email")]
		public string Email { get; set; }
		public string phone {  get; set; }
		public string aboutMe { get; set; }
		public byte[] image { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		
	}
}
