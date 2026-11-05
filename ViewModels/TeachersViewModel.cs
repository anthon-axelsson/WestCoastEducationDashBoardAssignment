using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty] private ObservableCollection<Teacher> _teachers = new();
    [ObservableProperty] private Teacher? _selectedTeacher;
    [ObservableProperty] private string _statusMessage = string.Empty;

    [ObservableProperty] private ViewModelBase? _currentTeacherView;

    private readonly AddTeacherViewModel _addTeacherVM;

    public TeachersViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;
        _addTeacherVM = new AddTeacherViewModel(_restDbService);
        _addTeacherVM.TeacherAdded += async () =>
        {
            CurrentTeacherView = null;
            await LoadDataAsync();
        };
    }

    [RelayCommand]
    public void ShowAddForm() => CurrentTeacherView = _addTeacherVM;

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        StatusMessage = "Loading teachers...";
        var list = await _restDbService.GetTeachersAsync();
        Teachers = new ObservableCollection<Teacher>(list);
        StatusMessage = $"Loaded {Teachers.Count} teachers.";
    }

    [RelayCommand]
    public void EditTeacher(Teacher teacher)
    {
        if (teacher == null) return;

        var editVM = new EditTeacherViewModel(_restDbService, teacher);
        editVM.TeacherUpdated += async () =>
        {
            CurrentTeacherView = null;
            await LoadDataAsync();
        };
        CurrentTeacherView = editVM;
    }
}