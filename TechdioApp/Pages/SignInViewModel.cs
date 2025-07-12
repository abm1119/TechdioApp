using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechdioApp.Controls;
using TechdioApp.Services;
namespace TechdioApp.Pages
{
    public partial class SignInViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private string _username;

        public SignInViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        [RelayCommand]
        private async Task SignIn()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please fill in all fields.";
                return;
            }

            if (!IsValidEmail(Email))
            {
                ErrorMessage = "Please enter a valid email address.";
                return;
            }

            try
            {
                // Attempt sign-in
                var user = await _authClient.SignInWithEmailAndPasswordAsync(Email, Password);
                Username = user.User.Info.DisplayName ?? "User"; // Update the Username property

                // Navigate to dashboard
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl(_authClient);
                await Shell.Current.GoToAsync("//Dashboard");
               // await Shell.Current.GoToAsync("//Home");
            }
            catch (FirebaseAuthException)
            {
                ErrorMessage = "Invalid email or password.";
            }
            catch
            {
                ErrorMessage = "An unexpected error occurred. Please try again.";
            }
        }

        [RelayCommand]
        private async Task NavigateSignUp()
        {
            await Shell.Current.GoToAsync("//SignUp");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}