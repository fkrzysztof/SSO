using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sasso.Data.Data;
using Sasso.Data.Data.Data;
using Sasso.Data.HelperClass;
using Sasso.Edit.Controllers.Abstract;

namespace Sasso.Edit.Controllers
{
    public class OfferController : AbstractController
    {
        public OfferController(ILogger<HomeController> logger, WebContext context)
        : base(logger, context)
        {
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Offers.ToListAsync());
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfferID,Name,Text,MediaItem,FormFileItem")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                if (offer.FormFileItem != null)
                {
                    offer.MediaItem = new CloudAccess().AddPic(offer.FormFileItem, "Offer");
                }
                _context.Add(offer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offer);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            return View(offer);
        }

        // POST: Offers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfferID,Name,Text,MediaItem,FormFileItem")] Offer offer)
        {
            if (id != offer.OfferID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (offer.FormFileItem != null && offer.MediaItem != null)
                    {
                        offer.MediaItem = new CloudAccess().ChangeItem(offer.MediaItem, offer.FormFileItem, "Offer");
                    }
                    else if(offer.FormFileItem != null)
                    {
                        offer.MediaItem = new CloudAccess().AddPic(offer.FormFileItem, "Offer");
                    }

                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.OfferID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(offer);
        }

        [HttpPost]
        public async Task<bool> DeleteJS(int id)
        {
            if (id < 0)
                return false;
            bool output;
            var offer = await _context.Offers.FindAsync(id);
            new CloudAccess().Remove(offer.MediaItem);
            var rezult = _context.Offers.Remove(offer);

            if (rezult.State.ToString() == "Deleted")
                output = true;
            else
                output = false;
            await _context.SaveChangesAsync();

            return output;
        }


        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offers
                .FirstOrDefaultAsync(m => m.OfferID == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if ( await DeleteJS(id))
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }

        private bool OfferExists(int id)
        {
            return _context.Offers.Any(e => e.OfferID == id);
        }
    }
}
