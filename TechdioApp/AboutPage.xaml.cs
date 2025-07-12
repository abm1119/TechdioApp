using Firebase.Auth;
using TechdioApp.Controls;
using TechdioApp.Dashboard.Pages;
using TechdioApp.Dashboard.ViewModels;
using TechdioApp.Pages;
using TechdioApp.Services;

namespace TechdioApp;

public partial class AboutPage : ContentPage
{

    //private FirebaseAuthClient _authClient;
    //private readonly FirebaseService _firebaseService;

    public AboutPage(/*FirebaseAuthClient authClient*/)
	{
		InitializeComponent();
      //  _authClient = authClient;
      //  _firebaseService = new FirebaseService();

        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += async (s, e) =>
        {
            await Launcher.OpenAsync(new Uri("https://plant-event-dd7.notion.site/Techdio-178461206ba380f4b205dfbc2364f7c1?pvs=74"));
        };

        LinkLabel.GestureRecognizers.Add(tapGestureRecognizer);
    }

    /*
    private async void OnGetStartedClicked(object sender, EventArgs e)
    {
        
        await Shell.Current.GoToAsync("//Home");
        // Update the FlyoutHeader after navigation
        SetFlyoutHeader();

        // Pass the view model to the HomePage constructor
        //var homePageViewModel = new HomePageViewModel();
        //await Navigation.PushAsync(new HomePage(homePageViewModel));

    }
    */
    private async void OnSignInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignIn");
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignUp");
    }

    /*
    private void SetFlyoutHeader()
    {
        // Set the FlyoutHeader to the custom control
        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl(_authClient);
    }
    */

}
