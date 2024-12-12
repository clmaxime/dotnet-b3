using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }

        // GET: StudentController/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: StudentController/Add
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: StudentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentController/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(e => e.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ShowDetails(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string Lastname, string Firstname, int Age, DateTime AdmissionDate)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            student.Firstname = Firstname;
            student.Lastname = Lastname;
            student.Age = Age;

            _context.Update(student); await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
    }
}