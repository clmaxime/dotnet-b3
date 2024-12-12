using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

public class TeacherController : Controller
{
    private readonly UserManager<Teacher> _userManager;
    public TeacherController(UserManager<Teacher> userManager)
    {
        _userManager = userManager;
    }

    public ActionResult Index()
    {
        var teachers =  _userManager.Users.ToList();
        return View(teachers);
    }



    // Ajouter un Teacher
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(Teacher teacher)
    {
        if (teacher == null)
        {
            return BadRequest("Teacher object is null.");
        }

        if (!ModelState.IsValid)
        {
            return View();
        }

        teacher.UserName = teacher.Email;

        var result = await _userManager.CreateAsync(teacher);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(teacher);
        }

        return RedirectToAction("Index");
    }

  [HttpPost]
public async Task<IActionResult> Edit(string id, string Lastname, string Firstname, string Email, string PersonalWebSite)
{
    var teacher = await _userManager.FindByIdAsync(id);
    if (teacher == null)
    {
        return NotFound();
    }

    teacher.Firstname = Firstname;
    teacher.Lastname = Lastname;
    teacher.Email = Email;
    teacher.PersonalWebSite = PersonalWebSite;

    var result = await _userManager.UpdateAsync(teacher);
    if (!result.Succeeded)
    {
        return View("Error");
    }

    return RedirectToAction("Index");
}

    // Supprimer un Teacher 
    public async Task<IActionResult> Delete(int id)
    {
        var teacher = await _userManager.FindByIdAsync(id.ToString());
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var teacher = await _userManager.FindByIdAsync(id.ToString());
        if (teacher != null)
        {
            var result = await _userManager.DeleteAsync(teacher);
            if (!result.Succeeded)
            {
                throw new Exception("error");
            }
        }

        return RedirectToAction("Index");
    }

    // Afficher le détail d'un teacher
    public async Task<IActionResult> ShowDetails(string Id)
    {
        var teacher = await _userManager.FindByIdAsync(Id.ToString());
        return View(teacher);
    }


}