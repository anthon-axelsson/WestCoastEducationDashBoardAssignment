namespace WestCoastEducation.Models;

public class EducationManager : Teacher
{
    public string? EmploymentDate { get; set; }
    public override string GetDetails()
    {
        return base.GetDetails() + $"Employed since: {EmploymentDate} (Education Manager)";
    }
}
