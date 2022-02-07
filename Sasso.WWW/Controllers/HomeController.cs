using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sasso.Data.Data;
using Sasso.WWW.Models;

namespace Sasso.WWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebContext _context;

        public HomeController(ILogger<HomeController> logger, WebContext context)
        {
            _context = context;
            _logger = logger;
        }

        //public IActionResult Index(string id)
        //{
        //    return Redirect("www.facebook.com/sharer/sharer.php?u=http://www.sasso.pl");
        //}

        public IActionResult Index()
        {
                ViewBag.MainText = _context.Abouts.FirstOrDefault().Maintext;
                ViewBag.Text = _context.Abouts.FirstOrDefault().Text;
                ViewBag.Partners = _context.Partners.Select(s => s.MediaItem).ToList();
                ViewBag.Offer = _context.Offers.ToList();
                ViewBag.Contact = _context.Contacts.FirstOrDefault();
                ViewBag.Address = _context.Addresses.Include(i => i.Phones).Include(i => i.Emails).ToList();
                ViewBag.Project = _context.Projects.Where(w => w.Active == true && w.DateOfPublication.CompareTo(DateTime.Now) < 1).ToList();
                ViewBag.ProjectText = _context.ProjectsPages.FirstOrDefault().Text;
                return View();
        }

        #region share
        public IActionResult Fb()
        {
            return Redirect("http://www.facebook.com/sharer/sharer.php?u=http://www.sasso.pl");
        }
        public IActionResult Twitter()
        {
            return Redirect("https://twitter.com/intent/tweet?text=http://www.sasso.pl");
        }
        public IActionResult Whatsapp()
        {
            return Redirect("https://api.whatsapp.com/send?text=%0ahttp://www.sasso.pl");
        }
        #endregion share


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
