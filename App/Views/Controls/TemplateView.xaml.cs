using MAUI_Core.Models;

namespace MAUI_App.Views.Controls;

public partial class TemplateView : ContentView
{
    public TemplateView()
    {
        InitializeComponent();
    }

    public TemplateView(Template template) : this()
    {
        this.BindingContext = template;
    }

}