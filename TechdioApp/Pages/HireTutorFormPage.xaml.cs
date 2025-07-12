using Org.BouncyCastle.Asn1.X509;

namespace TechdioApp.Pages;

public partial class HireTutorFormPage : ContentPage
{
    private Tutor _selectedTutor;

    public HireTutorFormPage()
    {
    }

    public HireTutorFormPage(Tutor selectedTutor)
	{
		InitializeComponent();
        _selectedTutor = selectedTutor;
        SelectedTutorLabel.Text = _selectedTutor.Name;
        SubjectPicker.SelectedItem = _selectedTutor.Expertise;
        AvailabilityPicker.SelectedItem = _selectedTutor.Availability;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UserNameEntry.Text) ||
            string.IsNullOrWhiteSpace(UserEmailEntry.Text) ||
            string.IsNullOrWhiteSpace(UserPhoneEntry.Text) ||
            SubjectPicker.SelectedItem == null ||
            AvailabilityPicker.SelectedItem == null ||
            string.IsNullOrWhiteSpace(CardNumberEntry.Text) ||
            string.IsNullOrWhiteSpace(ExpiryDateEntry.Text) ||
            string.IsNullOrWhiteSpace(CvvEntry.Text))
        {
            await DisplayAlert("Error", "Please fill all required fields.", "OK");
            return;
        }

        var hiringRequest = new
        {
            TutorName = _selectedTutor.Name,
            UserName = UserNameEntry.Text,
            UserEmail = UserEmailEntry.Text,
            UserPhone = UserPhoneEntry.Text,
            Subject = SubjectPicker.SelectedItem.ToString(),
            Availability = AvailabilityPicker.SelectedItem.ToString(),
            Mode = OnlineRadioButton.IsChecked ? "Online" : "Offline",
            PreferredTime = PreferredTimePicker.Time,
            CardNumber = CardNumberEntry.Text,
            ExpiryDate = ExpiryDateEntry.Text,
            CVV = CvvEntry.Text
        };

        await Task.Delay(1000); // Simulate network delay
        await DisplayAlert("Success", "Your request has been submitted successfully!", "OK");
        await Navigation.PopModalAsync();
    }
}
