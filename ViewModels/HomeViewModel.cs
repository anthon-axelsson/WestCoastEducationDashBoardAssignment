using CommunityToolkit.Mvvm.ComponentModel;

namespace WestCoastEducation.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _welcomeMessage = "Välkommen till WestCoast Education Administration";

    [ObservableProperty]
    private string _description = "Använd sidomenyn för att navigera mellan Kurser, Studenter och Lärare för att hantera administrationen i molnet via RestDb.io.";
}