using System;
namespace TechBlog.WebUI.Data
{
	public class GetTime
	{
		public string GetCurrentTime()
		{
			return Guid.NewGuid().ToString();
		}
	}
}

