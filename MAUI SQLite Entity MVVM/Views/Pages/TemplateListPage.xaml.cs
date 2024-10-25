using MAUI_SQLite_Entity_MVVM.ViewModels;

namespace MAUI_SQLite_Entity_MVVM.Views.Pages;

public partial class TemplateListPage : ContentPage
{
	public TemplateListPage(TemplateListViewModel templateListViewModel)
	{
		InitializeComponent();
		this.BindingContext = templateListViewModel;
	}

    private async void TemplateListPage_Loaded(object sender, EventArgs e)
    {
        await((TemplateListViewModel)BindingContext).LoadTemplates();
    }
}