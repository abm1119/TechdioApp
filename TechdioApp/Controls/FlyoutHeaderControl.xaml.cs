using Firebase.Auth;
using TechdioApp.Services;

namespace TechdioApp.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
    private readonly FirebaseAuthClient _authClient;
    private readonly FirebaseService _firebaseService;

    public FlyoutHeaderControl(FirebaseAuthClient authClient)
    {
        InitializeComponent();
        _authClient = authClient;
        _firebaseService = new FirebaseService();
        ValidateAuthentication();
    }

    private async void ValidateAuthentication()
    {
        var currentUser = _authClient.User;

        if (currentUser == null)
        {
            // User not signed in, redirect to sign-in page
            await App.Current.MainPage.DisplayAlert("Sign In Required", "Please sign in to access the app.", "OK");
            await Shell.Current.GoToAsync("//SignIn");
            return;
        }

        LoadUserDetails(currentUser.Info.Email);
    }

    private async void LoadUserDetails(string email)
    {
        try
        {
            // Fetch user profile from Firebase
            var user = await _firebaseService.GetUserByEmailAsync(email);

            if (user != null)
            {
                lblUserName.Text = user.Name ?? "New User";
                lblUserEmail.Text = user.Email ?? "No Email";
                lblUserRole.Text = "Student"; // Adjust role dynamically if needed

                // Check for user profile image
                UserProfileImage.Source = !string.IsNullOrEmpty(user.ImageUrl)
                    ? user.ImageUrl
                    : "profile.png"; // Default image if ImageUrl is null or empty
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "User profile not found.", "OK");
                await Shell.Current.GoToAsync("//SignIn");
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", $"Failed to load user details: {ex.Message}", "OK");
            await Shell.Current.GoToAsync("//SignIn");
        }
    }
}