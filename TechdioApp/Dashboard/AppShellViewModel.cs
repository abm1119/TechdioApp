using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechdioApp.Pages;

namespace TechdioApp.Dashboard
{
    public partial class AppShellViewModel : BaseViewModel
    {

        private readonly FirebaseAuthClient _firebaseAuthClient;

        public AppShellViewModel(FirebaseAuthClient firebaseAuthClient)
        {

            _firebaseAuthClient = firebaseAuthClient;
        }

        [RelayCommand]
        async Task Logout()
        {
            bool answer = await Shell.Current.DisplayAlert(
        "Log Out", "Are you sure you want to log out?", "Yes", "No");

            if (answer)
            {
                try
                {
                    _firebaseAuthClient.SignOut();
                    await Shell.Current.GoToAsync("//SignIn");
                }
                catch 
                {
                    await Shell.Current.DisplayAlert("Error",
                        "An error occurred while logging out. Please try again.", "OK");
                }
            }

        }
    }
}
