﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vleko.Bayarind.Web.Models;

namespace Vleko.Bayarind.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
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
}