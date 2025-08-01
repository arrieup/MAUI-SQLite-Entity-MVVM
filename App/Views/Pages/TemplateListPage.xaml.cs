using MAUI_Core.ViewModels;

namespace MAUI_App.Views.Pages;

public partial class TemplateListPage : ContentPage
{
	public TemplateListPage(TemplateListViewModel templateListViewModel)
	{
		InitializeComponent();
		this.BindingContext = templateListViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is TemplateListViewModel vm)
        {
            await vm.LoadItems();
        }
    }
}