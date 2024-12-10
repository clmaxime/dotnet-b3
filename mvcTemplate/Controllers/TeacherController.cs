using Microsoft.AspNetCore.Mvc;

using mvc.Models;

public class TeacherController : Controller
{
    // liste d'enseignants
    private static List<Teacher> _teachers = new List<Teacher>
    {
        new Teacher { Id = 1, Lastname = "Doe", Firstname = "John" },
        new Teacher { Id = 2, Lastname = "Smith", Firstname = "Jane" }
    };


    public IActionResult Index()
    {
        return View(_teachers);
    }

    // Ecrire une liste d'Actions


    // Ajouter un Teacher
    // Accessible via /Teacher/Add en GET affichera le formulaire
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    // Accessible via /Teacher/Add en POST ajoutera le teacher
    [HttpPost]
    public IActionResult Add(Teacher teacher)
    {
        // Declencher le mecanisme de validation
        if (!ModelState.IsValid)
        { 
            return View();
        }
        // Ajouter le teacher
        _teachers.Add(teacher);
        return RedirectToAction("Index");
    }

    // Supprimer un Teacher
     [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var etudiant = _teachers.FirstOrDefault(e => e.Id == id);
            if (etudiant != null)
            {
                _teachers.Remove(etudiant);
            }

            return RedirectToAction(nameof(Index));
        }


    // Afficher le détail d'un teacher
    // Accessible via /Teacher/ShowDetails/10
    public IActionResult ShowDetails(int id)
    {
        Teacher teacher = new Teacher();
        if (id == 10)
        {
            teacher.Firstname = "John";
            teacher.Lastname = "Doe";
            teacher.Email = "johndoe@a.com";
            teacher.PersonalWebSite = "www.jondoe.com ";
            teacher.Id = 10;
        }
        else
        {
            teacher.Id = 20;
            teacher.Firstname = "Jane";
            teacher.Lastname = "Smith";
            teacher.Email = "janesmith@a.com";
            teacher.PersonalWebSite = "Www.janesmith.com";
        }
        return View(teacher);
    }

    // Afficher tous les Teachers

}