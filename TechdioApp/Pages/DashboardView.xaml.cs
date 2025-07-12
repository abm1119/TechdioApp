using TechdioApp.Dashboard.ViewModels;

namespace TechdioApp.Pages;

public partial class DashboardView : Shell
{
	public DashboardView(DashboardViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}