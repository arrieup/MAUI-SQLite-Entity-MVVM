using MAUI_Core.Services;

namespace MAUI_App.Services
{
    public class NavigationService<T> : INavigationService<T>
    {
        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }

        public Task NavigateToDetailsAsync(T item, bool editable)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }
            var navigationParameter = new Dictionary<string, object>
            {
                { typeof(T).Name, item },
                { "Editable", editable }
            };
            return Shell.Current.GoToAsync($"//{typeof(T).Name}DetailsPage", navigationParameter);
        }

        public Task NavigateToRootAsync()
        {
            return Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
