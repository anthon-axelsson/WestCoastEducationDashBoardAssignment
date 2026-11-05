using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty] private ObservableCollection<Course> _courses = new();
    [ObservableProperty] private Course? _selectedCourse;
    [ObservableProperty] private string _statusMessage = string.Empty;
    
    [ObservableProperty] private ViewModelBase? _currentCourseView;

    private readonly AddCourseViewModel _addCourseVM;

    public CoursesViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;
        _addCourseVM = new AddCourseViewModel(_restDbService);
        _addCourseVM.CourseAdded += async () =>
        {
            CurrentCourseView = null;
            await LoadDataAsync();
        };
    }

    [RelayCommand]
    public void ShowAddForm() => CurrentCourseView = _addCourseVM;

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        StatusMessage = "Loading courses...";
        var list = await _restDbService.GetCoursesAsync();
        Courses = new ObservableCollection<Course>(list);
        StatusMessage = $"Loaded {Courses.Count} courses.";
    }
}