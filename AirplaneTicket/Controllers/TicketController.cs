using BasicWebApp.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly EboardingContext _dbContext;

        public TicketController(EboardingContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            var tickets = _dbContext.Tickets
                .Include(t => t.Flight)
                .Include(t => t.Airport)
                .Include(t => t.Pass);
            return View(await tickets.ToListAsync());
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _dbContext.Tickets
                .Include(t => t.Flight)
                .Include(t => t.Airport)
                .Include(t => t.Pass)
                .FirstOrDefaultAsync(t => t.TicketId == id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            ViewBag.Flights = new SelectList(_dbContext.Flights, "FlightId", "FlightNumber");
            ViewBag.Airports = new SelectList(_dbContext.Airports, "AirportId", "AirportName");
            ViewBag.Passengers = new SelectList(_dbContext.Passengers, "PassId", "PassName");
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirportId,FlightId,PassId,DepartDate,Boarding,SeatNumber,Gate,Zone,Seq")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Tickets.Add(ticket);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Flights = new SelectList(_dbContext.Flights, "FlightId", "FlightNumber", ticket.FlightId);
            ViewBag.Airports = new SelectList(_dbContext.Airports, "AirportId", "AirportName", ticket.AirportId);
            ViewBag.Passengers = new SelectList(_dbContext.Passengers, "PassId", "PassName", ticket.PassId);
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);
            if (ticket == null)
                return NotFound();

            ViewBag.Flights = new SelectList(_dbContext.Flights, "FlightId", "FlightNumber", ticket.FlightId);
            ViewBag.Airports = new SelectList(_dbContext.Airports, "AirportId", "AirportName", ticket.AirportId);
            ViewBag.Passengers = new SelectList(_dbContext.Passengers, "PassId", "PassName", ticket.PassId);

            return View(ticket);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,AirportId,FlightId,PassId,DepartDate,Boarding,SeatNumber,Gate,Zone,Seq")] Ticket ticket)
        {
            if (id != ticket.TicketId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _dbContext.Update(ticket);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Flights = new SelectList(_dbContext.Flights, "FlightId", "FlightNumber", ticket.FlightId);
            ViewBag.Airports = new SelectList(_dbContext.Airports, "AirportId", "AirportName", ticket.AirportId);
            ViewBag.Passengers = new SelectList(_dbContext.Passengers, "PassId", "PassName", ticket.PassId);

            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _dbContext.Tickets
                .Include(t => t.Flight)
                .Include(t => t.Airport)
                .Include(t => t.Pass)
                .FirstOrDefaultAsync(t => t.TicketId == id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _dbContext.Tickets.Remove(ticket);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
