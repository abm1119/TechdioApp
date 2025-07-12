namespace TechdioApp.Dashboard.Pages;

public partial class ComingSoonPopup : ContentPage
{
	public ComingSoonPopup()
	{
		InitializeComponent();
        // Set the page to be transparent
        BackgroundColor = Colors.Transparent;

        // Add an animation when the page appears
        Appearing += OnPageAppearing;
    }
    private async void OnPageAppearing(object sender, EventArgs e)
    {
        // Ensure PopupFrame is initialized
        if (PopupFrame == null)
            return;

        // Animate the pop-up frame
        PopupFrame.Scale = 0.8;
        PopupFrame.Opacity = 0;
        await Task.WhenAll(
            PopupFrame.ScaleTo(1, 300, Easing.SpringOut),
            PopupFrame.FadeTo(1, 300)
        );
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        // Ensure PopupFrame is initialized
        if (PopupFrame == null)
            return;

        // Animate the pop-up frame before closing
        await Task.WhenAll(
            PopupFrame.ScaleTo(0.8, 200, Easing.SpringIn),
            PopupFrame.FadeTo(0, 200)
        );

        // Close the pop-up
        await Navigation.PopModalAsync();
    }

}