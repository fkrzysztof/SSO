using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sasso.Data.Data;
using Sasso.Edit.Controllers.Abstract;
using Sasso.Edit.Models;

namespace Sasso.Edit.Controllers
{
    public class HomeController : AbstractController
    {
        public HomeController(ILogger<HomeController> logger, WebContext context)
        : base(logger, context)
        {
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index","About");
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
