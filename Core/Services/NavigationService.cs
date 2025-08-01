using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Core.Services
{
    public interface INavigationService<T>
    {
        Task NavigateToDetailsAsync(T item, bool editable);
        Task GoBackAsync();
        Task NavigateToRootAsync();
    }
}
