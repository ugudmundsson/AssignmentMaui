using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class ListPage : ContentPage
{
	public ListPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}