
namespace TechdioApp.Pages;

public partial class CustomCourse : ContentPage
{
	public CustomCourse()
	{
		InitializeComponent();
        LoadUrl();
    }
    private void LoadUrl()
    {
        // Define the URL to load
        var url = "https://tally.so/r/w71v42";

        // Create a URL WebView source and load it
        var urlSource = new UrlWebViewSource
        {
            Url = url
        };

        // Assign the URL source to the WebView
        webView.Source = urlSource;
    }


    /* Unmerged change from project 'TechdioApp (net8.0-windows10.0.19041.0)'
    Before:
        private void Back_Button(object sender, NavigatedToEventArgs e)
        {
    After:
        private async Task Back_ButtonAsync(object sender, NavigatedToEventArgs e)
        {
    */
   

  
}


