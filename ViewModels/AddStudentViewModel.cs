using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using WestCoastEducation.Models;
using WestCoastEducation.Interfaces;
using System;

namespace WestCoastEducation.ViewModels;

public partial class AddStudentViewModel : ViewModelBase
{
    private readonly IRestDbService _restDbService;

    [ObservableProperty] private string _firstName = string.Empty;
    [ObservableProperty] private string _lastName = string.Empty;
    [ObservableProperty] private string _personalNumber = string.Empty;
    [ObservableProperty] private long _phoneNumber;
    [ObservableProperty] private string _address = string.Empty;
    [ObservableProperty] private int _postalCode;
    [ObservableProperty] private string _region = string.Empty;

    [ObservableProperty] private string _statusMessage = string.Empty;

    // Event eller callback för att meddela när studenten har sparats
    public event Action? StudentAdded;

    public AddStudentViewModel(IRestDbService restDbService)
    {
        _restDbService = restDbService;
    }

    [RelayCommand]
    public async Task SaveStudentAsync()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            StatusMessage = "Förnamn och efternamn är obligatoriska!";
            return;
        }

        var newStudent = new Student
        {
            FirstName = FirstName,
            LastName = LastName,
            PersonalNumber = PersonalNumber,
            PhoneNumber = PhoneNumber,
            Address = Address,
            PostalCode = PostalCode,
            Region = Region
        };

        await _restDbService.AddStudentAsync(newStudent);
        
        StatusMessage = "Student sparad!";
        
        StudentAdded?.Invoke();
    }
}