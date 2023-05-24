using System;
namespace TechBlog.WebUI.Models
{
	public class ArticleTag : BaseEntity
	{
		// ArticleId INT FOREIGN KEY REFERENCES Article(Id)
		public int ArticleId { get; set; }
		public Article Article { get; set; }
		public int TagId { get; set; }
		public Tag Tag { get; set; }
	}
}

