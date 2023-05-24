using System;
using TechBlog.WebUI.Models;

namespace TechBlog.WebUI.ViewModels
{
	public class HomeVM
	{
		public List<Article> HomeArticle { get; set; }
		public List<Tag> HomeTags { get; set; }
	}
}

