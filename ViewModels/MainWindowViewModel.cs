using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Services;

namespace WestCoastEducation.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty]
    private ViewModelBase _currentPage;

    [ObservableProperty]
    private string _statusMessage = "Ready";

    public HomeViewModel HomeVM { get; }
    public CoursesViewModel CoursesVM { get; }
    public StudentsViewModel StudentsVM { get; }
    public TeachersViewModel TeachersVM { get; }

    public MainWindowViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;

        // Initiera alla undervyer
        HomeVM = new HomeViewModel();
        CoursesVM = new CoursesViewModel(_restDbService);
        StudentsVM = new StudentsViewModel(_restDbService);
        TeachersVM = new TeachersViewModel(_restDbService);

        // Starta på Hem-vyn
        _currentPage = HomeVM;
    }

    [RelayCommand]
    public void NavigateHome()
    {
        CurrentPage = HomeVM;
        StatusMessage = "Navigated to Home";
    }

    [RelayCommand]
    public void NavigateCourses()
    {
        CurrentPage = CoursesVM;
        StatusMessage = "Navigated to Courses";
        _ = CoursesVM.LoadDataAsync();
    }

    [RelayCommand]
    public void NavigateStudents()
    {
        CurrentPage = StudentsVM;
        StatusMessage = "Navigated to Students";
        _ = StudentsVM.LoadDataAsync();
    }

    [RelayCommand]
    public void NavigateTeachers()
    {
        CurrentPage = TeachersVM;
        StatusMessage = "Navigated to Teachers";
        _ = TeachersVM.LoadDataAsync();
    }
}