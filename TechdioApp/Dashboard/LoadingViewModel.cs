using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechdioApp.Pages;

namespace TechdioApp.Dashboard
{
   public  partial class LoadingViewModel : BaseViewModel
    {
        private readonly FirebaseAuthClient _firebaseAuthClient;
        
        public LoadingViewModel(FirebaseAuthClient firebaseAuthClient)
        {

            _firebaseAuthClient = firebaseAuthClient;
            CheckUserLoginDetails();
            }

        private async void CheckUserLoginDetails() {
            if (String.IsNullOrWhiteSpace(_firebaseAuthClient?.User?.Info?.Email))
            {
                if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    AppShell.Current.Dispatcher.Dispatch(async () =>
                    {
                        await Shell.Current.GoToAsync($"{nameof(SigninView)}");

                    });
                }
                else
                {
                    await Shell.Current.GoToAsync($"{nameof(SigninView)}");
                }
            } // mnavigate to Login page here !
            else {
                await Shell.Current.GoToAsync($"{nameof(DashboardView)}");
            }

         }
        


    }
}
