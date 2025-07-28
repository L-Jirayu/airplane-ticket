using BasicWebApp.Models.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApp.Controllers
{
    public class AirportController : Controller
    {
        private readonly EboardingContext _dbContext;
        public AirportController(EboardingContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: AirportController
        public async Task<ActionResult> Index()
        {
            var pub = from p in _dbContext.Airports select p;
            return View(await pub.ToListAsync());
        }



        // GET: AirportController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var pub = await _dbContext.Airports.FirstOrDefaultAsync(c => c.AirportId == id);
            if (pub == null)
            {
                return NotFound();
            }
            return View(pub);
        }

        // GET: AirportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Airport pub)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Airports.Add(pub);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pub);
        }

        // GET: AirportController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var pub = await _dbContext.Airports.FindAsync(id);
            if (pub == null)
            {
                return NotFound();
            }
            return View(pub);
        }

        //Update II
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Airport publisher)
        {
            if (id != publisher.AirportId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Airports.Update(publisher);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.AirportId))
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
            return View(publisher);
        }

        private bool PublisherExists(int id)
        {
            return _dbContext.Airports.Any(p => p.AirportId == id);
        }

        // GET: AirportController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var pub = await _dbContext.Airports.FindAsync(id);
            if (pub == null)
            {
                return NotFound();
            }
            return View(pub);
        }

        //Delete II
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var publisher = await _dbContext.Airports.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            var relatedTickets = _dbContext.Tickets.Where(t => t.AirportId == id);
            _dbContext.Tickets.RemoveRange(relatedTickets);

            _dbContext.Airports.Remove(publisher);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
