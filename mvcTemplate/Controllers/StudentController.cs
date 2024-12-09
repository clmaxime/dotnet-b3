using Microsoft.AspNetCore.Mvc;

using mvc.Models;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult Delete(int id)
        {
            var etudiant = students.FirstOrDefault(e => e.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var etudiant = students.FirstOrDefault(e => e.Id == id);
            if (etudiant != null)
            {
                students.Remove(etudiant);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Add(Student etudiant)
    {
        if (ModelState.IsValid)
        {
            etudiant.Id = students.Max(e => e.Id) + 1;
            students.Add(etudiant);
            return RedirectToAction(nameof(Index));
        }
        return View(etudiant);
}
        // Creation d'une liste statique de Student
        private static List<Student> students = new()
        {
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
            new() { AdmissionDate = new DateTime(2021, 9, 1), Age = 20, Firstname = "John", GPA = 3.5, Id = 1, Lastname = "Doe", Major = Major.CS },
        };
        // GET: StudentController
        public ActionResult Index()
        {
            return View(students);
        }

    }
}