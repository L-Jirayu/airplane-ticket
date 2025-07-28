using BasicWebApp.Models.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApp.Controllers
{
    public class PassengerController : Controller
    {
        private readonly EboardingContext _dbContext;
        public PassengerController(EboardingContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: FlightController
        public async Task<ActionResult> Index()
        {
            var pub = from p in _dbContext.Passengers select p;
            return View(await pub.ToListAsync());
        }



        // GET: AirportController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var pub = await _dbContext.Passengers.FirstOrDefaultAsync(c => c.PassId == id);
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
        public async Task<ActionResult> Create(Passenger pub)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Passengers.Add(pub);
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
            var pub = await _dbContext.Passengers.FindAsync(id);
            if (pub == null)
            {
                return NotFound();
            }
            return View(pub);
        }

        //Update II
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Passenger publisher)
        {
            if (id != publisher.PassId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Passengers.Update(publisher);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PassId))
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
            return _dbContext.Passengers.Any(p => p.PassId == id);
        }

        // GET: AirportController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var pub = await _dbContext.Passengers.FindAsync(id);
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
            var publisher = await _dbContext.Passengers.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            var relatedTickets = _dbContext.Tickets.Where(t => t.PassId == id);
            _dbContext.Tickets.RemoveRange(relatedTickets);

            _dbContext.Passengers.Remove(publisher);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
