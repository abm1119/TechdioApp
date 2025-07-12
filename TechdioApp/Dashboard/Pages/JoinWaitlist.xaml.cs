
namespace TechdioApp.Dashboard.Pages;

public partial class JoinWaitlist : ContentPage
{
	public JoinWaitlist()
	{
		InitializeComponent();
        

    }

    private async void BackButtonCLicked(object sender, EventArgs e)
    {

        // Check if there is a previous page in the navigation stack
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync(); // Navigate to the previous page
        }
        else
        {
            // If there is no previous page, you can handle it accordingly
            await DisplayAlert("Info", "No previous page available.", "OK");
        }
    }
}

