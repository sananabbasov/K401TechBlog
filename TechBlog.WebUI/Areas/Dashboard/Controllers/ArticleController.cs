using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechBlog.WebUI.Data;
using TechBlog.WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechBlog.WebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public ArticleController(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var tagList = _context.Tags.ToList();
            ViewBag.Tags = new SelectList(tagList,"Id","TagName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Article article, List<int> tagIds)
        {
            try
            {
                article.UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                article.SeoUrl = "dasdjaskd";
                article.CreatedDate = DateTime.Now;
                article.UpdatedDate = DateTime.Now;
                await _context.Articles.AddAsync(article);
                await _context.SaveChangesAsync();
                for (int i = 0; i < tagIds.Count; i++)
                {
                    ArticleTag articleTag = new()
                    {
                        TagId = tagIds[i],
                        ArticleId = article.Id
                    };
                    await _context.ArticleTags.AddAsync(articleTag);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(article);

            }
        }


    }
}

