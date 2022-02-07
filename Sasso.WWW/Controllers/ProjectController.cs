using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sasso.Data.Data;
using Sasso.Data.Data.Data;
using System.Web;

namespace Sasso.WWW.Controllers
{
    public class ProjectController : Controller
    {
        private readonly WebContext _context;

        public ProjectController(WebContext context)
        {
            _context = context;
        }

        private void send(int id)
        {
            ViewBag.Contact = _context.Contacts.FirstOrDefault();
            ViewBag.Address = _context.Addresses.Include(i => i.Phones).Include(i => i.Emails).ToList();
            ViewBag.Partners = _context.Partners.Select(s => s.MediaItem).ToList();
            ViewBag.Name = _context.Projects.FirstOrDefault(f => f.ProjectsID == id).Name;
            ViewBag.Id = id;
        }

        

        public async Task<IActionResult> Download(int id)
        {
            send(id);
            return View("Index", await _context.Projects.Include(i => i.Files).FirstOrDefaultAsync(f => f.ProjectsID == id));
        }

        public IActionResult About(int id)
        {
            send(id);
            ViewBag.Content = _context.Projects.FirstOrDefault(f => f.ProjectsID == id).About;
            return View("Index");
        }

        public IActionResult News(int id)
        {
            send(id);
            ViewBag.Content = _context.Projects.FirstOrDefault(f => f.ProjectsID == id).News;
            return View("Index");
        }

        public IActionResult Participants(int id)
        {
            send(id);
            ViewBag.Content = _context.Projects.FirstOrDefault(f => f.ProjectsID == id).Participants;
            return View("Index");
        }

        public IActionResult FormOfSupport(int id)
        {
            send(id);
            ViewBag.Content = _context.Projects.FirstOrDefault(f => f.ProjectsID == id).FormOfSupport;
            return View("Index");
        }

        public IActionResult Recruitment(int id)
        {
            send(id);
            ViewBag.Content = _context.Projects.FirstOrDefault(f => f.ProjectsID == id).Recruitment;
            return View("Index");
        }

        public IActionResult Contact(int id)
        {
            send(id);
            ViewBag.Content = _context.Projects.FirstOrDefault(f => f.ProjectsID == id).Contact;
            return View("Index");
        }

    }
}
