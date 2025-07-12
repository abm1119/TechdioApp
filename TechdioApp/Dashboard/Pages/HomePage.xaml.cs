

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TechdioApp.Dashboard.ViewModels;
using TechdioApp.Models;
using TechdioApp.Pages;
using TechdioApp.Services;


namespace TechdioApp.Dashboard.Pages;

public partial class HomePage : ContentPage
{
    public HomePage( )
	{
		InitializeComponent();
      
    }
    private async void OnMenuClicked(object sender, EventArgs e)
    {
        // Implement menu navigation
        await DisplayAlert("Menu", "Menu clicked", "OK");
    }
    private async void OnTechCoursesTapped(object sender, EventArgs e)
    {
        // await Shell.Current.GoToAsync("//JoinWaitlist");
        var JoinWailistPage = new JoinWaitlist();
        await Navigation.PushModalAsync(JoinWailistPage);
    }

    private async void OnDesignCoursesTapped(object sender, EventArgs e)
    {
        // Navigate to CoursePage with the "Design" category
       // await Shell.Current.GoToAsync("//JoinWaitlist");
        var JoinWailistPage = new JoinWaitlist();
        await Navigation.PushModalAsync(JoinWailistPage);
    }

    private async void OnIslamicLearningTapped(object sender, EventArgs e)
    {
        // Navigate to CoursePage with the "Islam" category
       // await Shell.Current.GoToAsync("//JoinWaitlist");
        var JoinWailistPage = new JoinWaitlist();
        await Navigation.PushModalAsync(JoinWailistPage);
    }

    private async void OnOpportunitiesTapped(object sender, EventArgs e)
    {
        // Navigate to the ComingSoonPopup as a modal
        var comingSoonPopup = new ComingSoonPopup();
        await Navigation.PushModalAsync(comingSoonPopup);
    }

    private async void OnCustomCoursesTapped(object sender, EventArgs e)
    {
        var CustomCoursePage = new CustomCourse();
        await Navigation.PushModalAsync(CustomCoursePage);

    }

    private async void OnHireTutorTapped(object sender, EventArgs e)
    {
        // await Navigation.PushAsync(new HireTutorFormPage());
        var tutorPageViewModel = new TutorPageViewModel();
        await Navigation.PushModalAsync(new TutorPage(tutorPageViewModel));
    }
}
