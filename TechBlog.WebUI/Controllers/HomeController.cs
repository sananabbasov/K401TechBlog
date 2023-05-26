﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechBlog.WebUI.Data;
using TechBlog.WebUI.Models;
using TechBlog.WebUI.ViewModels;

namespace TechBlog.WebUI.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;


    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var articles = _context.Articles.ToList();
        var tags = _context.Tags.ToList();
        HomeVM vm = new()
        {
            HomeArticles = articles,
            HomeTags = tags
        };
        return View(vm);
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

