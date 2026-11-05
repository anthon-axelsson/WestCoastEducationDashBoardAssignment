namespace WestCoastEducation.Models;

public class Administrator : EducationManager
{
    public override string GetDetails()
    {
        return base.GetDetails() + " [Administrator]";
    }
}
