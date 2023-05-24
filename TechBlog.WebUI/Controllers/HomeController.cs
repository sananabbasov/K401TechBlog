using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechBlog.WebUI.Data;
using TechBlog.WebUI.Models;

namespace TechBlog.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly GetTime _getTime;

    public HomeController(ILogger<HomeController> logger, GetTime getTime)
    {
        _logger = logger;
        _getTime = getTime;
    }

    public IActionResult Index()
    {
        ViewBag.Test = _getTime.GetCurrentTime();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

