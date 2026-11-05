using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty]
    private ObservableCollection<Student> _students = new();

    [ObservableProperty]
    private Student? _selectedStudent;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    [ObservableProperty]
    private ViewModelBase? _currentStudentView;

    private readonly AddStudentViewModel _addStudentVM;

    public StudentsViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;
        
        _addStudentVM = new AddStudentViewModel(_restDbService);
        _addStudentVM.StudentAdded += async () => 
        {
            ShowList();
            await LoadDataAsync();
        };

        ShowList();
    }

    [RelayCommand]
    public void ShowList()
    {
        CurrentStudentView = null; 
    }

    [RelayCommand]
    public void ShowAddForm()
    {
        CurrentStudentView = _addStudentVM;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        StatusMessage = "Loading students...";
        var list = await _restDbService.GetStudentsAsync();
        Students = new ObservableCollection<Student>(list);
        StatusMessage = $"Loaded {Students.Count} students.";
    }
}