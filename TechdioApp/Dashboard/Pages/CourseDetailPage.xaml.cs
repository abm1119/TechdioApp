using System.Collections.ObjectModel;
using System.Windows.Input;
using TechdioApp;
using TechdioApp.Models;

namespace TechdioApp.Dashboard.Pages;

public partial class CourseDetailPage : ContentPage
{
	public CourseDetailPage(Course selectedCourse)
	{
		InitializeComponent();
        BindingContext = selectedCourse;
    }
    // Handle Enroll button click
    private async void OnEnrollClicked(object sender, EventArgs e)
    {
        var course = BindingContext as Course; // Cast to Course
        if (course != null)
        {
            // Show success message after enrolling
            await DisplayAlert("Success", $"You have enrolled successfully in {course.Title}", "OK");
        }
    }

    // Handle Back button click
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Navigate back to the previous page
        await Navigation.PopAsync();
    }
}

public class CourseDetailViewModel
{
    public string Title { get; } // Title of the course
    public string Category { get; } // Category of the course
    public string Price { get; } // Price of the course
    public string Description { get; } // Full description of the course
    public string TutorName { get; } // Name of the tutor/instructor
    public string Image { get; } // URL or local path to the course image
    public ObservableCollection<string> Modules { get; } // List of modules in the course
    public ICommand EnrollCommand { get; } // Command for enrolling in the course
    public ICommand NavigateBackCommand { get; } // Command for navigating back

    public CourseDetailViewModel(Course course)
    {
        // Initialize properties from the Course object
        Title = course.Title;
        Category = course.Category;
        Price = course.Price;
        Description = course.Description;
        TutorName = course.TutorName;
        Image = course.Image; // Use the Image property from the Course class
        Modules = course.Modules;

        // Initialize commands
        EnrollCommand = new Command(EnrollInCourse);
        NavigateBackCommand = new Command(OnNavigateBack);
    }

    private void EnrollInCourse()
    {
        // Logic for enrolling in the course
        App.Current.MainPage.DisplayAlert("Success", $"You have successfully enrolled in the {Title} course!", "OK");
    }

    private async void OnNavigateBack()
    {
        // Navigate back to the course listing page
        await App.Current.MainPage.Navigation.PopAsync();
    }
}

    