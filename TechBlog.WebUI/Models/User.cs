using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TechBlog.WebUI.Models
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhotoUrl { get; set; }
    }
}

