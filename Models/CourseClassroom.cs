using System;

namespace WestCoastEducation.Models;

public class CourseClassroom : Course
{
    public string Location { get; set; } = string.Empty;
    public override string GetCourseDetails()
    {
        return base.GetCourseDetails() + $" [Classroombased in {Location}]";
    }

}
