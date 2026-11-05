using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty]
    private ObservableCollection<Course> _courses = new();
    [ObservableProperty]
    private ObservableCollection<Student> _students = new();
    [ObservableProperty]
    private ObservableCollection<Teacher> _teachers = new();

    [ObservableProperty]
    private Course? _selectedCourse;
    [ObservableProperty]
    private Student? _selectedStudent;
    [ObservableProperty]
    private Teacher? _selectedTeacher;

    [ObservableProperty]
    private string _currentView = "Courses";

    [ObservableProperty]
    private string _statusMessage = "Ready";

    public MainViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;
        _ = LoadAllDataAsync();
    }

    [RelayCommand]
    public async Task LoadAllDataAsync()
    {
        StatusMessage = "Loading courses from RestDb...";

        var coursesFromDb = await _restDbService.GetCoursesAsync();
        Courses = new ObservableCollection<Course>(coursesFromDb);

        var studentsFromDb = await _restDbService.GetStudentsAsync();
        Students = new ObservableCollection<Student>(studentsFromDb);

        var teachersFromDb = await _restDbService.GetTeachersAsync();
        Teachers = new ObservableCollection<Teacher>(teachersFromDb);

        StatusMessage = $"Loaded {Courses.Count} courses succesfully.";
    }
    
    [RelayCommand]
    public void SwitchView(string viewName)
    {
        CurrentView = viewName;
        StatusMessage = $"Switched to {viewName}";
    }

}
