using Microsoft.AspNetCore.Mvc;
using mvc.Models;


namespace mvc.Controllers;

public class StudentController : Controller
{
    public ActionResult Index()
    {
        var student = new Student();
        student.Id = 23;
        student.Lastname = "ropers";
        student.Firstname = "frank";
        student.Age = 23;
        student.GPA = "?";
        return View(student);
    }
}