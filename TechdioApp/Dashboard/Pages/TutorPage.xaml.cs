using TechdioApp.Dashboard.ViewModels;

namespace TechdioApp.Dashboard.Pages;

public partial class TutorPage : ContentPage
{
    private readonly TutorPageViewModel _viewModel;

    public TutorPage(TutorPageViewModel tutorPageViewModel)
	{
		InitializeComponent();
        _viewModel = tutorPageViewModel;
        BindingContext = _viewModel;

    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel.FilterAndSortTutors(e.NewTextValue);
    }
}