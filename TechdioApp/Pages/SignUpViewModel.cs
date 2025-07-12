using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using TechdioApp.Dashboard.Models;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechdioApp.Services;
using Microsoft.Maui.Controls;
using User = TechdioApp.Dashboard.Models.User;

namespace TechdioApp.Pages
{
    public partial class SignUpViewModel : ObservableObject 
    {

    private readonly FirebaseAuthClient _authClient;
    private readonly FirebaseService _firebaseService;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string phone;

    [ObservableProperty]
    private string university;

    [ObservableProperty]
    private string location;

    [ObservableProperty]
    private string imageUrl;

    [ObservableProperty]
    private string password;

    public SignUpViewModel(FirebaseAuthClient authClient, FirebaseService firebaseService)
    {
        _authClient = authClient;
        _firebaseService = firebaseService;
    }

    [RelayCommand]
    private async Task SignUp()
    {
        try
        {
            // Firebase Authentication
            var firebaseUser = await _authClient.CreateUserWithEmailAndPasswordAsync(Email, Password, Name);

            // Create user profile for Firebase Realtime Database
            User newUser = new Dashboard.Models.User()
            {
                Id = firebaseUser.User.Uid,
                Email = Email,
                Name = Name,
                Phone = Phone,
                University = University,
                Location = Location,
                ImageUrl = string.IsNullOrWhiteSpace(ImageUrl)
                        ? "profile.png" // Default placeholder image
                        : ImageUrl
            };


            // Save user in Realtime Database
            await _firebaseService.SaveUserAsync(newUser);

            // Navigate to the SignIn page
            await Shell.Current.GoToAsync("//SignIn");
        }
        catch (Exception ex)
        {
            // Display an error message
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task NavigateSignIn()
    {
        // Navigate to the SignIn page
        await Shell.Current.GoToAsync("//SignIn");
    }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                Application.Current.MainPage.DisplayAlert("Validation Error", "Please enter a valid email address.", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                Application.Current.MainPage.DisplayAlert("Validation Error", "Name cannot be empty.", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Phone) || Phone.Length <= 11)
            {
                Application.Current.MainPage.DisplayAlert("Validation Error", "Please enter a valid phone number.", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
            {
                Application.Current.MainPage.DisplayAlert("Validation Error", "Password must be at least 6 characters long.", "OK");
                return false;
            }

            return true;
        }
    }
}

