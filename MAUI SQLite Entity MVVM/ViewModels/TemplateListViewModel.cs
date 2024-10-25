using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_SQLite_Entity_MVVM.Models;
using MAUI_SQLite_Entity_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_SQLite_Entity_MVVM.ViewModels
{
    public partial class TemplateListViewModel : BaseViewModel
    {
        private readonly TemplateService _templateService;

        [ObservableProperty]
        private List<Template> templates = [];

        [RelayCommand]
        public async Task LoadTemplates()
        {
            Templates = await _templateService.GetAll();
        }

        [RelayCommand]
        public async Task AddTemplate()
        {
            await _templateService.Add(new Template());
            await LoadTemplates();
        }

        public TemplateListViewModel(TemplateService templateService)
        {
            _templateService = templateService;
        }
    }
}
