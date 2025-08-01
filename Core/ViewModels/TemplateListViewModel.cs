using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Core.Models;
using MAUI_Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Core.ViewModels
{
    public partial class TemplateListViewModel(IDatabaseService<Template> service, INavigationService<Template> navigation) : ListViewModel<Template>(service, navigation)
    {
        public override ObservableCollection<Template> FilterItems(string value)
        {
            return new ObservableCollection<Template>(
                Items
                .Select(t => new { Item = t, Score = Score(t.Id.ToString(), value) })
                .Where(x => x.Score > 0)
                .OrderByDescending(x => x.Score)
                .Select(x => x.Item)
            );
        }

        protected override Task NavigateToDetails(Template item, bool editable)
        {
            return navigationService.NavigateToDetailsAsync(item, editable);
        }

    }
}
