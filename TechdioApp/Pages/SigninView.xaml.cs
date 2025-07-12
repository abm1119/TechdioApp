namespace TechdioApp.Pages;

public partial class SigninView : ContentPage
{
   
    private SignInViewModel _viewModel;
   
    public SigninView(SignInViewModel viewModel )
	{
		InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;

    }
}