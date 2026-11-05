using System;

namespace WestCoastEducation.Models;

public class CourseDistance : Course
{
    public string MeetingPlatform { get; set; } = string.Empty;
    public override string GetCourseDetails()
    {
        return base.GetCourseDetails() + $" [Distance lesson on {MeetingPlatform}]";
    }
}
