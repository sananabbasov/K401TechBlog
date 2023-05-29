using System;
using System.ComponentModel.DataAnnotations;

namespace TechBlog.WebUI.DTOs
{
	public class RegisterDTO
	{
		[Required]
		[MaxLength(15)]
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		public string Password { get; set; }
		public string PasswordRepeat { get; set; }
	}
}

