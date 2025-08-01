using MAUI_Core.Models;
using MAUI_Core.ViewModels;

namespace MAUI_App.Views.Pages;

[QueryProperty(nameof(Template), "Template")]
[QueryProperty(nameof(Editable), "Editable")]
public partial class TemplateDetailsPage : ContentPage
{
    public TemplateDetailsPage(TemplateDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public Template Template
    {
        set
        {
            if (BindingContext is TemplateDetailsViewModel vm)
                vm.Item = value;
        }
    }

    public bool Editable
    {
        set
        {
            if (BindingContext is TemplateDetailsViewModel vm)
                vm.Editable = value;
        }
    }
}