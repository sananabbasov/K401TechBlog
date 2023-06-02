using System;
using TechBlog.WebUI.Models;

namespace TechBlog.WebUI.ViewModels
{
	public class HomeVM
	{
		public List<Article> HomeArticles { get; set; }
		public List<Tag> HomeTags { get; set; }
		public List<ArticleTag> ArticleTags { get; set; }
	}
}

