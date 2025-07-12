
using Firebase.Auth;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TechdioApp.Dashboard.Models;
using TechdioApp.Services;
using User = TechdioApp.Dashboard.Models.User;

namespace TechdioApp.Pages;

public partial class EditProfilePage : ContentPage
{
    private readonly FirebaseService _firebaseService;
    private readonly FirebaseAuthClient _authClient;
    private User _user;

    public EditProfilePage(FirebaseAuthClient authClient, User user)
    {
        InitializeComponent();
        _firebaseService = new FirebaseService();
        _authClient = authClient;
        _user = user;
        LoadUserProfile();
    }

    // Fetch user data from Firebase and bind it to the UI
    private async void LoadUserProfile()
    {
        try
        {
            // Get the current logged-in user
            var currentUser = _authClient.User;
            if (currentUser == null)
            {
                await DisplayAlert("Error", "User is not logged in. Please log in first.", "OK");
                return;
            }

            var userId = currentUser.Uid;
            _user = await _firebaseService.GetUserAsync(userId); // Remove asterisks

            if (_user != null)
            {
                BindingContext = _user;
            }
            else
            {
                await DisplayAlert("Error", "User data not found.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load user profile: {ex.Message}", "OK");
        }
    }

    // Handle save button click to update the user data in Firebase
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Validate input fields
        if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(PhoneEntry.Text))
        {
            await DisplayAlert("Error", "Please fill all required fields.", "OK");
            return;
        }

        try
        {
            // Update the user model with the new data from the UI
            _user.Name = NameEntry.Text;
            _user.Email = EmailEntry.Text;
            _user.Phone = PhoneEntry.Text;
            _user.University = UniversityEntry.Text;
            _user.Location = LocationEntry.Text;

            // Show a loading indicator while saving the data
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            // Save the updated user data back to Firebase
            await _firebaseService.SaveUserAsync(_user); // Remove asterisks

            // Display a success message
            await DisplayAlert("Success", "Profile updated successfully!", "OK");

            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Handle any errors during the save operation
            await DisplayAlert("Error", $"Failed to update profile: {ex.Message}", "OK");
        }
        finally
        {
            // Hide the loading indicator after the save operation
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
        }
    }
    // Handle back button click to navigate back without saving
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}



