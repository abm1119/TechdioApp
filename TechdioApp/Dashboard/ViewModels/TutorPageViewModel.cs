using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechdioApp.Pages;

namespace TechdioApp.Dashboard.ViewModels
{
    public partial class TutorPageViewModel : ObservableObject
    {
        // Properties for Subjects, Availabilities, Modes, and Tutors
        public ObservableCollection<string> Subjects { get; }
        public ObservableCollection<string> Availabilities { get; }
        public ObservableCollection<string> Modes { get; }
        public ObservableCollection<string> SortOptions { get; }

        [ObservableProperty]
        private string _selectedSubject;

        [ObservableProperty]
        private string _selectedAvailability;

        [ObservableProperty]
        private string _selectedMode;

        [ObservableProperty]
        private string _selectedSortOption;

        [ObservableProperty]
        private ObservableCollection<Tutor> _tutors;

        [ObservableProperty]
        private string _searchText;

        public IRelayCommand<Tutor> HireTutorCommand { get; }

        public TutorPageViewModel()
        {
            // Initialize available options
            Subjects = new ObservableCollection<string> { "All", "Math", "Science", "History", "English", "Art" };
            Availabilities = new ObservableCollection<string> { "All", "Morning", "Afternoon", "Evening" };
            Modes = new ObservableCollection<string> { "All", "Online", "Offline" };
            SortOptions = new ObservableCollection<string> { "None", "Name", "Expertise", "Hourly Rate" };

            // Sample tutors data
            Tutors = new ObservableCollection<Tutor>
            {
                new Tutor { Name = "Muhammad Hanif", Expertise = "Math", Qualifications = "B.Sc. in Mathematics", Image = "tutor1.jpg", Availability = "Morning", Mode = "Online", HourlyRate = 25, Bio = "Experienced math tutor with 5+ years of teaching experience.", Rating = 5 },
                new Tutor { Name = "Saeed Ahmed", Expertise = "Science", Qualifications = "M.Sc. in Physics", Image = "tutor2.jpg", Availability = "Afternoon", Mode = "Offline", HourlyRate = 30, Bio = "Passionate about teaching physics and making complex concepts easy to understand.", Rating = 4 },
                new Tutor { Name = "Madam Saira", Expertise = "History", Qualifications = "Ph.D. in History", Image = "tutor_3.jpg", Availability = "Evening", Mode = "Online", HourlyRate = 20, Bio = "Specializes in world history and historical research methodologies.", Rating = 5 },
                new Tutor { Name = "Ansharah Maroof", Expertise = "English", Qualifications = "M.A. in English Literature", Image = "tutor_4.jpg", Availability = "Morning", Mode = "Offline", HourlyRate = 22, Bio = "Expert in English literature and creative writing.", Rating = 4 },
                new Tutor { Name = "Ali Raza", Expertise = "Art", Qualifications = "B.F.A. in Fine Arts", Image = "tutor.jpg", Availability = "Afternoon", Mode = "Online", HourlyRate = 18, Bio = "Professional artist with a focus on painting and digital art.", Rating = 4 }
            };

            // Initialize commands
            HireTutorCommand = new RelayCommand<Tutor>(ExecuteHireTutor);

            // Default selected options
            SelectedSubject = "All";
            SelectedAvailability = "All";
            SelectedMode = "All";
            SelectedSortOption = "None";

            // Initial filter and sort call
            FilterAndSortTutors();
        }

        private async void ExecuteHireTutor(Tutor tutor)
        {
            // Navigate to the hiring form page
            var hireTutorFormPage = new HireTutorFormPage(tutor);
            await Application.Current.MainPage.Navigation.PushModalAsync(hireTutorFormPage);
        }

        public void FilterAndSortTutors(string searchText = "")
        {
            if (Tutors == null)
                return;

            var filteredTutors = Tutors
                .Where(t => (SelectedSubject == "All" || t.Expertise == SelectedSubject) &&
                            (SelectedAvailability == "All" || t.Availability == SelectedAvailability) &&
                (SelectedMode == "All" || t.Mode == SelectedMode) &&
                            (string.IsNullOrEmpty(searchText) || t.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            SortTutors(filteredTutors);
        }

        private void SortTutors(List<Tutor> filteredTutors)
        {
            IEnumerable<Tutor> sortedTutors = SelectedSortOption switch
            {
                "None" => filteredTutors,
                "Name" => filteredTutors.OrderBy(t => t.Name),
                "Expertise" => filteredTutors.OrderBy(t => t.Expertise),
                "Hourly Rate" => filteredTutors.OrderBy(t => t.HourlyRate),
                _ => filteredTutors.AsEnumerable(),
            };

            Tutors = new ObservableCollection<Tutor>(sortedTutors);
        }
    }
}

public class Tutor
{
    public string Name { get; set; }
    public string Expertise { get; set; }
    public string Qualifications { get; set; }
    public string Image { get; set; }
    public string Availability { get; set; } // Morning, Afternoon, Evening
    public string Mode { get; set; } // Online, Offline
    public decimal HourlyRate { get; set; }
    public string Bio { get; set; } // Short bio about the tutor
    public int Rating { get; set; } // Tutor rating (1-5)
}