using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventController
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // GET: EventController/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: EventController/Add
        [HttpPost]
        public async Task<IActionResult> Add(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        // GET: EventController/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var eventModel = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        // POST: EventController/DeleteConfirmed/id
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventModel = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (eventModel != null)
            {
                _context.Events.Remove(eventModel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EventController/ShowDetails/id
        public async Task<IActionResult> ShowDetails(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        // POST: EventController/Edit/id
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Event eventModel)
        {
            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            existingEvent.Title = eventModel.Title;
            existingEvent.Description = eventModel.Description;
            existingEvent.EventDate = eventModel.EventDate;
            existingEvent.MaxParticipants = eventModel.MaxParticipants;
            existingEvent.Location = eventModel.Location;

            _context.Update(existingEvent);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
