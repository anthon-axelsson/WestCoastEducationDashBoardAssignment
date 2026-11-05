using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty] private string _courseNumber = string.Empty;
    [ObservableProperty] private string _title = string.Empty;
    [ObservableProperty] private int _durationInWeeks;
    [ObservableProperty] private DateTimeOffset _startDate = DateTimeOffset.Now;
    [ObservableProperty] private DateTimeOffset _endDate = DateTimeOffset.Now.AddDays(70);
    [ObservableProperty] private string _statusMessage = string.Empty;

    public event Action? CourseAdded;

    public AddCourseViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;
    }

    [RelayCommand]
    public async Task SaveCourseAsync()
    {
        if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(CourseNumber))
        {
            StatusMessage = "Kursnummer och titel är obligatoriska!";
            return;
        }

        var newCourse = new Course
        {
            CourseNumber = CourseNumber,
            Title = Title,
            DurationInWeeks = DurationInWeeks,
            StartDate = StartDate.DateTime,
            EndDate = EndDate.DateTime
        };

        await _restDbService.AddCourseAsync(newCourse);
        StatusMessage = "Kurs sparad!";
        CourseAdded?.Invoke();
    }
}