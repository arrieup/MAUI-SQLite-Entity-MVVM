using MAUI_SQLite_Entity_MVVM.Helpers;
using MAUI_SQLite_Entity_MVVM.Models;
using SQLite;

namespace MAUI_SQLite_Entity_MVVM.Repositories
{
    internal class BaseRepository<T> where T : new()
    {
        static SQLiteAsyncConnection SharedDatabase;

        async static Task Init()
        {
            if (SharedDatabase is not null)
                return;

            SharedDatabase = new SQLiteAsyncConnection(DatabaseHelper.DatabasePath, DatabaseHelper.Flags);
            await SharedDatabase.CreateTableAsync<Template>();
        }

        internal static async Task<List<T>> ReadAllAsync()
        {
            await Init();
            return await SharedDatabase.Table<T>().ToListAsync();
        }
        public static async Task DeleteAllAsync()
        {
            await Init();
            await SharedDatabase.DeleteAllAsync<T>();
        }

        public static async Task CreateAsync(T item)
        {
            await Init();
            await SharedDatabase.InsertAsync(item);
        }
        public static async Task<T> ReadAsync(int id)
        {
            await Init();
            return await SharedDatabase.FindAsync<T>(id);
        }
        public static async Task UpdateAsync(T item)
        {
            await Init();
            await SharedDatabase.UpdateAsync(item);
        }
        public static async Task DeleteAsync(int id)
        {
            await Init();
            await SharedDatabase.DeleteAsync(id);
        }


    }
}
