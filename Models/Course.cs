using System;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Models;

public class Course
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    [JsonPropertyName("courseNumber")]
    public string CourseNumber { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("durationInWeeks")]
    public int DurationInWeeks { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }

    // Virtuell metod för polymorfism (om ni använder det)
    public virtual string GetCourseDetails()
    {
        return $"{CourseNumber}: {Title} ({DurationInWeeks} weeks)";
    }
}