using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;
using System;

namespace WestCoastEducation.ViewModels;

public partial class AddTeacherViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty] private string _firstName = string.Empty;
    [ObservableProperty] private string _lastName = string.Empty;
    [ObservableProperty] private string _personalNumber = string.Empty;
    
    // Använd long? och int? så att de kan vara tomma i början!
    [ObservableProperty] private long? _phoneNumber;
    
    [ObservableProperty] private string _address = string.Empty;
    
    [ObservableProperty] private int? _postalCode;
    
    [ObservableProperty] private string _region = string.Empty;
    [ObservableProperty] private string _subjectArea = string.Empty;
    [ObservableProperty] private string _statusMessage = string.Empty;

    public event Action? TeacherAdded;

    public AddTeacherViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;
    }

    [RelayCommand]
    public async Task SaveTeacherAsync()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            StatusMessage = "Förnamn och efternamn är obligatoriska!";
            return;
        }

        var newTeacher = new Teacher
        {
            FirstName = FirstName,
            LastName = LastName,
            PersonalNumber = PersonalNumber,

            PhoneNumber = PhoneNumber ?? 0,
            Address = Address,
            PostalCode = PostalCode ?? 0,
            Region = Region,
            SubjectArea = SubjectArea
        };

        await _restDbService.AddTeacherAsync(newTeacher);
        StatusMessage = "Lärare sparad!";
        TeacherAdded?.Invoke();
    }
}