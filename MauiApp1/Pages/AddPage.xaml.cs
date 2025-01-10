using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class AddPage : ContentPage
{
	public AddPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}