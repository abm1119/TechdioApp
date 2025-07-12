using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;
using System.ComponentModel;
using System.Windows.Input;
using TechdioApp.Dashboard.Models;
using TechdioApp.Pages;
using TechdioApp.Services;
using User = TechdioApp.Dashboard.Models.User;



namespace TechdioApp.Dashboard.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly FirebaseService _firebaseService;

    private readonly FirebaseAuthClient _authClient;

    public User User { get; set; }



    public ProfilePage(FirebaseAuthClient authClient)

    {

        InitializeComponent();

        _firebaseService = new FirebaseService();

        _authClient = authClient;

    }



    protected override async void OnAppearing()

    {

        base.OnAppearing();



        try

        {

            var currentUser = _authClient.User;

            if (currentUser != null)

            {

                // Get user profile from Firebase Realtime Database

                var user = await _firebaseService.GetUserByEmailAsync(currentUser.Info.Email);



                // If no profile exists, create one with default values

                if (user == null)

                {

                    user = new User

                    {

                        Email = currentUser.Info.Email,

                        Name = "New User",

                        Phone = "Not set",

                        University = "Not set",

                        Location = "Not set",

                        ImageUrl = "profile.png"

                    };

                    await _firebaseService.SaveUserAsync(user);

                }



                User = user;

            }

            else

            {

                // If not authenticated, use default profile

                User = GetDefaultUser();

                await DisplayAlert("Notice", "Please sign in to view your profile.", "OK");

                await Shell.Current.GoToAsync("//SignIn");

            }

        }

        catch (Exception ex)

        {

            User = GetDefaultUser();

            await DisplayAlert("Error", "Failed to fetch user data: " + ex.Message, "OK");

        }



        BindingContext = this;

    }



    private async void OnEditProfileClicked(object sender, EventArgs e)

    {

        if (_authClient.User != null)

        {

            if (Navigation.NavigationStack.LastOrDefault() is not EditProfilePage)

            {

                await Navigation.PushAsync(new EditProfilePage(_authClient, User));

            }

        }

        else

        {

            await DisplayAlert("Notice", "Please sign in to edit your profile.", "OK");

            await Shell.Current.GoToAsync("//SignIn");

        }

    }



    private User GetDefaultUser()

    {

        return new User

        {

            Name = "Guest User",

            Email = "Not signed in",

            Phone = "Not available",

            University = "Not available",

            Location = "Not available",

            ImageUrl = "profile.png"

        };

    }

}

