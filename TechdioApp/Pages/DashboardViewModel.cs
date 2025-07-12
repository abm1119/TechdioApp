using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechdioApp.Models;
using TechdioApp.Services;


namespace TechdioApp.Pages
{
  
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private string _title = "Techdio Dashboard";
        private bool _isLoading;
        private ObservableCollection<MenuItem> _menuItems;
        private MenuItem _selectedMenuItem;
        private string _userName;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                if (_menuItems != value)
                {
                    _menuItems = value;
                    OnPropertyChanged(nameof(MenuItems));
                }
            }
        }

        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                if (_selectedMenuItem != value)
                {
                    _selectedMenuItem = value;
                    OnPropertyChanged(nameof(SelectedMenuItem));
                    OnMenuItemSelected(value);
                }
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        public Command LoadDataCommand { get; }
        public Command NavigateCommand { get; }

        public DashboardViewModel()
        {
            // Initializing Commands
            LoadDataCommand = new Command(async () => await LoadDataAsync());
            NavigateCommand = new Command<string>(async (route) => await NavigateToPageAsync(route));

            // Example data
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem { Title = "Home", Icon = "home.png", Route = "Home" },
                new MenuItem { Title = "Courses", Icon = "courseicon.png", Route = "Courses" },
                new MenuItem { Title = "Tutors", Icon = "tutor.png", Route = "Tutors" },
                new MenuItem { Title = "Profile", Icon = "profile.png", Route = "Profile" }
            };
        }

        private async Task LoadDataAsync()
        {
            IsLoading = true;

            // Simulating data loading
            await Task.Delay(2000);  // Simulate a delay (e.g., fetching data from a service)

            // Here, you could load data like user stats, courses, tutors, etc.

            UserName = "John Doe";  // Example of a dynamically loaded value

            IsLoading = false;
        }

        private async Task NavigateToPageAsync(string route)
        {
            // You could use Shell navigation for different pages
            await Shell.Current.GoToAsync(route);
        }

        private async void OnMenuItemSelected(MenuItem selectedItem)
        {
            if (selectedItem != null)
            {
                await NavigateToPageAsync(selectedItem.Route);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Class to represent menu items
    public class MenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
    }

}
