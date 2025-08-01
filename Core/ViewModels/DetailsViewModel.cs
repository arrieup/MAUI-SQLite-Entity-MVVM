using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Core.ViewModels
{
    /// <summary>
    /// Generic ViewModel class allowing the viewing and editing of a single item of generic type T
    /// </summary>
    /// <typeparam name="T">Type of the item</typeparam>
    public abstract partial class DetailsViewModel<T> : ObservableObject where T : class, new()
    {
        /// <summary>
        /// Central property of the ViewModel, representing the item being viewed or edited.
        /// </summary>
        [ObservableProperty]
        private T item = new();

        /// <summary>
        /// Property indicating whether the object is editable.
        /// </summary>
        [ObservableProperty]
        private bool editable;

    }
}
