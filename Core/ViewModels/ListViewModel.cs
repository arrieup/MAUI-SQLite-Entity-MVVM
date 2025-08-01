using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Core.Services;
using System.Collections.ObjectModel;

namespace MAUI_Core.ViewModels
{
    /// <summary>
    /// Generic ViewModel class allowing the viewing of all items of generic type T, performing CRUD operations on them and searching through them.
    /// </summary>
    /// <typeparam name="T">Type of the items manipulated</typeparam>
    /// <param name="database">Service allowing the manipulation of the table of element T in the database.</param>
    /// <param name="navigation">Service enabling the navigation inside the app.</param>
    public abstract partial class ListViewModel<T>(IDatabaseService<T> database, INavigationService<T> navigation) : BaseViewModel where T : class, new()
    {
        /// <summary>
        /// Service allowing the manipulation of the table of element T in the database.
        /// </summary>
        protected readonly IDatabaseService<T> databaseService = database;
        /// <summary>
        /// Service enabling the navigation inside the app.
        /// </summary>
        protected readonly INavigationService<T> navigationService = navigation;


        /// <summary>
        /// Lisof all items of type T in the database.
        /// </summary>
        private List<T> items = [];
        public List<T> Items
        {
            get => items;
            set
            {
                if (SetProperty(ref items, value))
                {
                    OnPropertyChanged(nameof(DisplayedItems));
                }
            }
        }

        /// <summary>
        /// List of all items of type T currently displayed in the UI according to the search query.
        /// </summary>
        public ObservableCollection<T> DisplayedItems {
            get
            {
                return new ObservableCollection<T>(FilterItems(Query));
            }
        }


        [ObservableProperty]
        private T selectedItem = new();

        #region Startup
        /// <summary>
        /// Property indicating whether the items are up to date.
        /// </summary>
        [ObservableProperty]
        private bool isLoaded = false;


        /// <summary>
        /// Loads the items from the database if they are not already loaded.
        /// </summary>
        [RelayCommand]
        public async Task LoadItems()
        {
            if (IsLoaded)
                return;

            Items = await databaseService.GetAll();
            IsLoaded = true;
        }


        /// <summary>
        /// Loads the items from the database if they are not already loaded.
        /// </summary>
        [RelayCommand]
        public void RemoveItems()
        {
            if (Items.Count == 0)
                return;

            databaseService.RemoveAll();
            Items = [];
            IsLoaded = true;
        }
        #endregion

        #region CRUD
        [RelayCommand]
        public async Task CreateItem()
        {
            await databaseService.Create(new T());
            IsLoaded = false;
            await LoadItems();
        }

        [RelayCommand]
        public async Task UpdateItem(T item)
        {
            await databaseService.Update(item);
            IsLoaded = false;
            await LoadItems();
        }

        [RelayCommand]
        public async Task DeleteItem(T item)
        {
            await databaseService.Delete(item);
            IsLoaded = false;
            await LoadItems();
        }
        #endregion

        #region Search
        /// <summary>
        /// Property representing the search query entered by the user.
        /// </summary>
        private string query = string.Empty;
        public string Query
        {
            get => query;
            set             {
                if (SetProperty(ref query, value))
                {
                    OnPropertyChanged(nameof(DisplayedItems));
                }
            }
        }
        
        /// <summary>
        /// Action called when the <see cref="query">Query</see> property changes.
        /// </summary>
        /// <param name="value"></param>
        //void OnQueryChanged(string value) => ApplySearch(value);

        /// <summary>
        /// Function returning the items that match the filter criteria.
        /// </summary>
        /// <param name="value">Value which should be looked for in <see cref="items">Items</see></param>
        /// <returns></returns>
        public abstract ObservableCollection<T> FilterItems(string value);

        /// <summary>
        /// Returns a score for the item based on the number of characters in common and the length of the longest common substring with the query.
        /// </summary>
        /// <param name="reference">string that should be compared to</param>
        /// <param name="query">string to compare</param>
        /// <returns>Value computed to sort the results</returns>
        protected int Score(string reference, string query)
        {
            return string.IsNullOrWhiteSpace(query) ? 1 : CharactersInCommon(reference, query) + LongestCommonSubstringLength(reference, query) * 2;
        }

        /// <summary>
        /// Returns the number of characters in common between two strings, ignoring case.
        /// </summary>
        public static int CharactersInCommon(string a, string b)
        {
            var setA = new HashSet<char>(a.ToLower());
            var setB = new HashSet<char>(b.ToLower());
            setA.IntersectWith(setB);
            return setA.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int LongestCommonSubstringLength(string a, string b)
        {
            int[,] dp = new int[a.Length + 1, b.Length + 1];
            int maxLength = 0;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    if (char.ToLower(a[i - 1]) == char.ToLower(b[j - 1]))
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        maxLength = Math.Max(maxLength, dp[i, j]);
                    }
                }
            }

            return maxLength;
        }
        #endregion

        #region Navigation

        protected abstract Task NavigateToDetails(T item, bool editable);

        [RelayCommand]
        public async Task NavigateToViewDetailsPage(T item)
        {
            if (item == null)
                return;
            SelectedItem = item;

            await NavigateToDetails(item, false);
        }

        [RelayCommand]
        public async Task NavigateToEditDetailsPage(T item)
        {
            if (item == null)
                return;
            SelectedItem = item;

            await NavigateToDetails(item, true);
        }
        #endregion
    }
}
