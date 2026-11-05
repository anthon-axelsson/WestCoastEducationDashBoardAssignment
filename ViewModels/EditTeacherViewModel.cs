using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;

namespace WestCoastEducation.ViewModels;

public partial class EditTeacherViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;
    private readonly string _teacherId;

    [ObservableProperty] private string _firstName = string.Empty;
    [ObservableProperty] private string _lastName = string.Empty;
    [ObservableProperty] private string _personalNumber = string.Empty;
    [ObservableProperty] private long? _phoneNumber;
    [ObservableProperty] private string _address = string.Empty;
    [ObservableProperty] private int? _postalCode;
    [ObservableProperty] private string _region = string.Empty;
    [ObservableProperty] private string _subjectArea = string.Empty;
    [ObservableProperty] private string _statusMessage = string.Empty;

    public event Action? TeacherUpdated;

    public EditTeacherViewModel(IRestDbService restDbService, Teacher teacher)
    {
        _restDbService = restDbService;
        _teacherId = teacher.Id ?? string.Empty;

        _firstName = teacher.FirstName ?? string.Empty;
        _lastName = teacher.LastName ?? string.Empty;
        _personalNumber = teacher.PersonalNumber ?? string.Empty;
        _phoneNumber = teacher.PhoneNumber != 0 ? teacher.PhoneNumber : null;
        _address = teacher.Address ?? string.Empty;
        _postalCode = teacher.PostalCode != 0 ? teacher.PostalCode : null;
        _region = teacher.Region ?? string.Empty;
        _subjectArea = teacher.SubjectArea ?? string.Empty;
    }

    [RelayCommand]
    public async Task SaveChangesAsync()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            StatusMessage = "Förnamn och efternamn är obligatoriska!";
            return;
        }

        var updatedTeacher = new Teacher
        {
            Id = _teacherId,
            FirstName = FirstName,
            LastName = LastName,
            PersonalNumber = PersonalNumber,
            PhoneNumber = PhoneNumber ?? 0,
            Address = Address,
            PostalCode = PostalCode ?? 0,
            Region = Region,
            SubjectArea = SubjectArea
        };

        await _restDbService.UpdateTeacherAsync(_teacherId, updatedTeacher);
        StatusMessage = "Lärare uppdaterad!";
        TeacherUpdated?.Invoke();
    }
}