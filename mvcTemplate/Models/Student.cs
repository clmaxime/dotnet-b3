using Microsoft.AspNetCore.Mvc;

namespace mvc.Models;


public class Student
{
    public int Id { get; set;}
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public string GPA { get; set; }

}