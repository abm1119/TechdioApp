using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TechdioApp.Dashboard.ViewModels;
using TechdioApp.Models;

namespace TechdioApp.Dashboard.Pages;

public partial class CoursePage : ContentPage
{
   
    public CoursePage(CoursePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

    }
    

    // Handles course selection
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var viewModel = BindingContext as CoursePageViewModel;
        viewModel?.FilterCourses(e.NewTextValue);
    }
}
public class CoursePageViewModel
{
    public ObservableCollection<Course> AllCourses { get; set; }
    public ObservableCollection<Course> FilteredCourses { get; set; }
    public Command<Course> NavigateToDetailCommand { get; set; }
    public Command<string> FilterCommand { get; set; }

    private string currentSearchText = string.Empty;
    private string currentCategoryFilter = "All";

    public CoursePageViewModel()
    {
        NavigateToDetailCommand = new Command<Course>(async (course) => await NavigateToDetail(course));
        FilterCommand = new Command<string>(ApplyFilter);

        // Sample data (this would typically come from an API or a database)
        AllCourses = new ObservableCollection<Course>
        {
            new Course
            {
                Title = "Web Development",
                Category = "Tech",
                Price = "$200",
                ShortDescription = "Learn to build professional websites.",
                Image = "web_dev.jpg",
                TutorName = "John Doe",
                Description = "This course will teach you everything about building websites from scratch.",
                Modules = new ObservableCollection<string>
                {
                    "Introduction to Web Development",
                    "HTML Basics",
                    "CSS and Styling",
                    "JavaScript Basics",
                    "Final Project"
                }
            },
            new Course
            {
                Title = "Graphic Design Basics",
                Category = "Design",
                Price = "$150",
                ShortDescription = "Master the basics of graphic design.",
                Image = "ui_ux.jpg",
                TutorName = "Jane Smith",
                Description = "This course covers the essential tools and concepts of graphic design.",
                Modules = new ObservableCollection<string>
                {
                    "Principles of Design",
                    "Typography Basics",
                    "Adobe Photoshop",
                    "Creating Your First Design",
                    "Final Project"
                }
            },
            new Course
            {
                Title = "Introduction to Islamic Studies",
                Category = "Islam",
                Price = "$100",
                ShortDescription = "Learn the fundamentals of Islamic teachings.",
                Image = "learn_islam.jpg",
                TutorName = "Imam Ali",
                Description = "This course provides an introduction to Islamic history, beliefs, and practices.",
                Modules = new ObservableCollection<string>
                {
                    "The Five Pillars of Islam",
                    "Prophet Muhammad's Life",
                    "The Quran and Hadith",
                    "Islamic Civilization",
                    "Final Project"
                }
            }
        };

        FilteredCourses = new ObservableCollection<Course>(AllCourses); // Initially showing all courses
    }

    private async Task NavigateToDetail(Course course)
    {
        // Navigate to detailed course view and pass course object
        await App.Current.MainPage.Navigation.PushAsync(new CourseDetailPage(course));
    }

    private void ApplyFilter(string category)
    {
        currentCategoryFilter = category;
        FilterCourses(currentSearchText);
    }

    public void FilterCourses(string searchText)
    {
        currentSearchText = searchText;

        var filtered = AllCourses.Where(c =>
            (string.IsNullOrEmpty(currentCategoryFilter) || currentCategoryFilter == "All" || c.Category == currentCategoryFilter) &&
            (string.IsNullOrEmpty(searchText) || c.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase) || c.ShortDescription.Contains(searchText, StringComparison.OrdinalIgnoreCase))
        ).ToList();

        FilteredCourses.Clear();
        foreach (var course in filtered)
        {
            FilteredCourses.Add(course);
        }
    }
}
public class Course
{
    public string Title { get; set; }
    public string Category { get; set; }
    public string Price { get; set; }
    public string ShortDescription { get; set; }
    public string Image { get; set; }
    public string TutorName { get; set; }
    public string Description { get; set; }
    public ObservableCollection<string> Modules { get; set; }
}



