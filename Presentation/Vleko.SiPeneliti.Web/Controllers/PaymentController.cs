﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vleko.Bayarind.Web.Models;

namespace Vleko.Bayarind.Web.Controllers
{
    public class PaymentController : BaseController<PaymentController>
    {
        public IActionResult Index()
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