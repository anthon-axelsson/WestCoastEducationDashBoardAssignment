using System.Collections.Generic;

namespace WestCoastEducation.Models;

public class Teacher : Person
{
 public string? SubjectArea { get; set; }  
 public List<string> ResponsibleCourses { get; set; } = new List<string>();
    public override string GetDetails()
    {
        return base.GetDetails() + $", Knowledge Area: {SubjectArea}, Responsibile Courses {ResponsibleCourses.Count}";
    }
}
